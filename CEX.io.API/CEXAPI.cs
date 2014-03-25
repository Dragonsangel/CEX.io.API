/****************************************************************/
/*                                                              */
/* Author: Dragonsangel                                         */
/* E-Mail: drag0nsang3l@gmail.com                               */
/* BTC   : 1P8RuwZuRdmBfrXdURSaxsoJzUPfBEvBie                   */
/*         Donations are welcome                                */
/*                                                              */
/****************************************************************/
using CEX.io.API.ApiObjects;
using System;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;

namespace CEX.io.API
{
  /// <summary>
  /// A wrapper class for the CEX.io API calls
  /// </summary>
  public class CEXAPI
  {
    #region Private Variables
    /// <summary>
    /// The Account Username at CEX.io
    /// </summary>
    private string apiUsername;
    /// <summary>
    /// The API access Key
    /// </summary>
    private string apiKey;
    /// <summary>
    /// The API access Secret
    /// </summary>
    private string apiSecret;
    #endregion

    #region Constructors
    /// <summary>
    /// Default constructor for <c>CEXAPI</c>
    /// </summary>
    public CEXAPI()
    {
      apiUsername = string.Empty;
      apiKey = string.Empty;
      apiSecret = string.Empty;
    }

    /// <summary>
    /// Overloaded constructor for <c>CEXAPI</c>
    /// </summary>
    /// <param name="username">The CEX.io Username</param>
    /// <param name="key">The CEX.io API Key</param>
    /// <param name="secret">The CEX.io API secret</param>
    public CEXAPI(string username, string key, string secret)
    {
      apiUsername = username;
      apiKey = key;
      apiSecret = secret;
    }
    #endregion

    #region Private Methods
    private Int64 GetNonce()
    {
      return Convert.ToInt64(Math.Truncate((DateTime.UtcNow - DateTime.MinValue).TotalMilliseconds));
    }

    private string GetSignature(Int64 nonce)
    {
      // Validation first
      if (string.IsNullOrEmpty(apiUsername))
      {
        throw new ArgumentException("Parameter apiUsername is not set.");
      }
      if (string.IsNullOrEmpty(apiKey))
      {
        throw new ArgumentException("Parameter apiKey is not set");
      }
      if (string.IsNullOrEmpty(apiSecret))
      {
        throw new ArgumentException("Parameter apiSecret is not set");
      }

      // HMAC input is nonce + username + key
      string hashInput = string.Format(CultureInfo.InvariantCulture, "{0}{1}{2}", nonce, apiUsername, apiKey);
      byte[] hashInputBytes = Encoding.UTF8.GetBytes(hashInput);

      byte[] secretBytes = Encoding.UTF8.GetBytes(apiSecret);
      HMACSHA256 hmac = new HMACSHA256(secretBytes);
      byte[] signatureBytes = hmac.ComputeHash(hashInputBytes);
      string signature = BitConverter.ToString(signatureBytes).ToUpper().Replace("-", string.Empty);
      return signature;
    }

    private string CallAPI(string method, bool isPrivate, string couple = "", NameValueCollection inputParams = null)
    {
      if (inputParams == null)
      {
        inputParams = new NameValueCollection();
      }

      // Determine if we need to add the private parameters
      if (isPrivate)
      {
        Int64 currentNonce = GetNonce();
        inputParams.Add("key", apiKey);
        inputParams.Add("signature", GetSignature(currentNonce));
        inputParams.Add("nonce", Convert.ToString(currentNonce));
      }

      // Build the API URL
      string apiUrl = string.Format("https://cex.io/api/{0}{1}/",
                                    method,
                                    string.IsNullOrEmpty(couple) ? "" : "/" + couple);

      string responseText;
      WebClient webClient = new WebClient();
      try
      {
        byte[] returnValue = webClient.UploadValues(apiUrl, inputParams);
        responseText = Encoding.UTF8.GetString(returnValue);

        // Check for an error
        ApiError apiError;
        using (Stream jsonStream = new MemoryStream(Encoding.UTF8.GetBytes(responseText)))
        {
          DataContractJsonSerializer jSerializer = new DataContractJsonSerializer(typeof(ApiError));
          apiError = jSerializer.ReadObject(jsonStream) as ApiError;
        }

        // If there was an API error, throw it with details
        if ((apiError != null) &&
            !string.IsNullOrWhiteSpace(apiError.ErrorMessage))
        {
          throw new ApiException(inputParams, apiError);
        }
      }
      catch (ApiException apiExc)
      {
        // Rethrow the exception
        throw apiExc;
      }
      catch (Exception exc)
      {
        throw new Exception("Unable to communicate with CEX.io\r\nDetails: " + exc.Message, exc);
      }

      return responseText;
    }
    #endregion

    #region Public Methods
    #region Public Data Functions
    /// <summary>
    /// Retrieves the current ticker information
    /// </summary>
    /// <returns>A <c>Ticker</c> object populated with the values of the current information</returns>
    public Ticker GetTicker()
    {
      Ticker output;

      string jsonString = CallAPI("ticker", false, "GHS/BTC");
      using (Stream jsonStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
      {
        DataContractJsonSerializer jSerializer = new DataContractJsonSerializer(typeof(Ticker));
        output = jSerializer.ReadObject(jsonStream) as Ticker;
      }

      return output;
    }

    /// <summary>
    /// Retrieves the last 1000 trades from CEX.io
    /// </summary>
    /// <param name="sinceTradeID">From how many milliseconds ago should the trade history be retrieved (NOTE: currently CEX.io ignores this parameter)</param>
    /// <returns>A <c>TradeHistoryList</c> object of the last 1000 trades</returns>
    public TradeHistoryList GetTradeHistory(int sinceTradeID)
    {
      TradeHistoryList output = new TradeHistoryList();

      // Setup the since parameter
      NameValueCollection inputParams = new NameValueCollection();
      inputParams.Add("since", Convert.ToString(sinceTradeID));

      // Call the API to get the result JSON
      string jsonString = CallAPI("trade_history", false, "GHS/BTC", inputParams);

      // Convert the JSON into something we can use
      using (Stream jsonStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
      {
        DataContractJsonSerializer jSerializer = new DataContractJsonSerializer(typeof(TradeHistoryList));
        output = jSerializer.ReadObject(jsonStream) as TradeHistoryList;
      }

      return output;
    }

    /// <summary>
    /// Retrieve the current order history
    /// </summary>
    /// <param name="depth">The depth that the history needs to be returned in</param>
    /// <returns>A <c>OrderBook</c> object with the current bid and buy orders</returns>
    public OrderBook GetOrderHistory(int depth)
    {
      OrderBook output = new OrderBook();

      // Setup the since parameter
      NameValueCollection inputParams = new NameValueCollection();
      inputParams.Add("depth", Convert.ToString(depth));

      // Call the API to get the result JSON
      string jsonString = CallAPI("order_book", false, "GHS/BTC", inputParams);

      // Convert the JSON into something we can use
      using (Stream jsonStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
      {
        DataContractJsonSerializer jSerializer = new DataContractJsonSerializer(typeof(OrderBook));
        output = jSerializer.ReadObject(jsonStream) as OrderBook;
      }


      return output;
    }
    #endregion

    #region Private Data Functions
    /// <summary>
    /// Retrieve the current account balance for the account
    /// </summary>
    /// <returns>A <c>AccountBalance</c> object with the current account information in it</returns>
    public AccountBalance GetAccountBalance()
    {
      AccountBalance output;

      string jsonString = CallAPI("balance", true);
      using (Stream jsonStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
      {
        DataContractJsonSerializer jSerializer = new DataContractJsonSerializer(typeof(AccountBalance));
        output = jSerializer.ReadObject(jsonStream) as AccountBalance;
      }

      return output;
    }

    /// <summary>
    /// Retrieves the current open orders for the account
    /// </summary>
    /// <returns>An <c>OpenOrderList</c> of the current orders</returns>
    public OpenOrderList GetOpenOrders()
    {
      OpenOrderList output;

      string jsonString = CallAPI("open_orders", true, "GHS/BTC");
      using (Stream jsonStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
      {
        DataContractJsonSerializer jSerializer = new DataContractJsonSerializer(typeof(OpenOrderList));
        output = jSerializer.ReadObject(jsonStream) as OpenOrderList;
      }

      return output;
    }

    /// <summary>
    /// Cancels a specific order as determined by <paramref name="OrderID"/>
    /// </summary>
    /// <param name="OrderID">The ID of the order to cancel</param>
    /// <returns><c>true</c> if the order was cancelled, otherwise <c>false</c></returns>
    public bool CancelOrder(int OrderID)
    {
      // Setup the since parameter
      NameValueCollection inputParams = new NameValueCollection();
      inputParams.Add("id", Convert.ToString(OrderID));

      bool output;
      string orderSuccessString = CallAPI("cancel_order", true, string.Empty, inputParams);

      if (!Boolean.TryParse(orderSuccessString, out output))
      {
        output = false;
      }
      return output;
    }

    /// <summary>
    /// Places an order on the account
    /// </summary>
    /// <param name="orderType">The type of order to place</param>
    /// <param name="price">The price at which to place the order</param>
    /// <param name="amount">The amount that should be processed by the order</param>
    /// <returns></returns>
    public OpenOrder PlaceOrder(OrderType orderType, double price, double amount)
    {
      OpenOrder output;

      // Setup the since parameter
      NameValueCollection inputParams = new NameValueCollection();
      inputParams.Add("type", Convert.ToString(orderType));
      inputParams.Add("price", string.Format(CultureInfo.InvariantCulture, "{0:F8}", price));
      inputParams.Add("amount", string.Format(CultureInfo.InvariantCulture, "{0:F8}", amount));

      string jsonString = CallAPI("place_order", true, "GHS/BTC", inputParams);
      using (Stream jsonStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
      {
        DataContractJsonSerializer jSerializer = new DataContractJsonSerializer(typeof(OpenOrder));
        output = jSerializer.ReadObject(jsonStream) as OpenOrder;
      }

      return output;
    }

    /// <summary>
    /// Retrieves the current Hash rate of the account
    /// </summary>
    /// <returns>A <c>HashRate</c> object with the current hash rate information</returns>
    public HashRate GetHashRate()
    {
      HashRate output;

      string jsonString = CallAPI("ghash.io/hashrate", true);
      using (Stream jsonStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
      {
        DataContractJsonSerializer jSerializer = new DataContractJsonSerializer(typeof(HashRate));
        output = jSerializer.ReadObject(jsonStream) as HashRate;
      }

      return output;
    }

    /// <summary>
    /// Retrieves the current hash rate of the different workers
    /// </summary>
    /// <returns>A <c>WorkersHashRates</c> object with the information</returns>
    public WorkersHashRates GetWorkerHashRate()
    {
      WorkersHashRates output;

      string jsonString = CallAPI("ghash.io/workers", true);
      using (Stream jsonStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
      {
        DataContractJsonSerializer jSerializer = new DataContractJsonSerializer(typeof(WorkersHashRates));
        output = jSerializer.ReadObject(jsonStream) as WorkersHashRates;
      }

      return output;
    }
    #endregion
    #endregion
  }
}