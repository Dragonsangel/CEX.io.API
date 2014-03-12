/****************************************************************/
/*                                                              */
/* Author: Dragonsangel                                         */
/* E-Mail: drag0nsang3l@gmail.com                               */
/* BTC   : 1P8RuwZuRdmBfrXdURSaxsoJzUPfBEvBie                   */
/*         Donations are welcome                                */
/*                                                              */
/****************************************************************/
using System;
using System.Runtime.Serialization;
using System.Text;

namespace CEX.io.API.ApiObjects
{
  /// <summary>
  /// A representation of a CEX.io ticker
  /// </summary>
  [DataContract]
  public class Ticker
  {
    /// <summary>
    /// The timestamp, in seconds, that the ticker information was retrieved
    /// </summary>
    [DataMember(Name="timestamp")]
    public double TimestampSeconds { get; set; }
    /// <summary>
    /// The current bid price
    /// </summary>
    [DataMember(Name = "bid")]
    public decimal BidPrice { get; set; }
    /// <summary>
    /// The current ask price
    /// </summary>
    [DataMember(Name = "ask")]
    public decimal AskPrice { get; set; }
    /// <summary>
    /// The lowest price for the ticker
    /// </summary>
    [DataMember(Name = "low")]
    public decimal LowPrice { get; set; }
    /// <summary>
    /// The highest price for the ticker
    /// </summary>
    [DataMember(Name = "high")]
    public decimal HighPrice { get; set; }
    /// <summary>
    /// The last trading price
    /// </summary>
    [DataMember(Name = "last")]
    public decimal LastPrice { get; set; }
    /// <summary>
    /// The volume of trades that occured in the ticker
    /// </summary>
    [DataMember(Name = "volume")]
    public decimal Volume { get; set; }

    /// <summary>
    /// A <c>DateTime</c> representation of the TimestampSeconds
    /// </summary>
    public DateTime Timestamp
    {
      get
      {
        DateTime convertDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        convertDateTime = convertDateTime.AddSeconds(TimestampSeconds).ToLocalTime();
        return convertDateTime;
      }
    }

    public override string ToString()
    {
      StringBuilder outputString = new StringBuilder();
      outputString.AppendLine(string.Format("Timestamp  = {0}", Timestamp));
      outputString.AppendLine(string.Format("Bid  Price = {0}", BidPrice));
      outputString.AppendLine(string.Format("Ask  Price = {0}", AskPrice));
      outputString.AppendLine(string.Format("Low  Price = {0}", LowPrice));
      outputString.AppendLine(string.Format("High Price = {0}", HighPrice));
      outputString.AppendLine(string.Format("Last Price = {0}", LastPrice));
      outputString.AppendLine(string.Format("Volume     = {0}", Volume));
      return outputString.ToString();
    }
  }
}
