/****************************************************************/
/*                                                              */
/* Author: Dragonsangel                                         */
/* E-Mail: drag0nsang3l@gmail.com                               */
/* BTC   : 1P8RuwZuRdmBfrXdURSaxsoJzUPfBEvBie                   */
/*         Donations are welcome                                */
/*                                                              */
/****************************************************************/
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CEX.io.API.ApiObjects
{
  /// <summary>
  /// A list of <c>OpenOrder</c>
  /// </summary>
  public class OpenOrderList : List<OpenOrder>
  {
    public override string ToString()
    {
      StringBuilder outputString = new StringBuilder();
      foreach (OpenOrder item in this)
      {
        outputString.AppendLine(item.ToString());
      }

      return outputString.ToString();
    }
  }

  /// <summary>
  /// A current open order on the CEX.io account
  /// </summary>
  [DataContract]
  public class OpenOrder
  {
    /// <summary>
    /// The order ID
    /// </summary>
    [DataMember(Name="id")]
    public int OrderID { get; set; }
    /// <summary>
    /// The time the order was placed
    /// </summary>
    [DataMember(Name = "time")]
    public double Time { get; set; }
    /// <summary>
    /// The type of the order
    /// </summary>
    [DataMember(Name = "type")]
    public string Type { get; set; }
    /// <summary>
    /// The price that the order is placed at
    /// </summary>
    [DataMember(Name = "price")]
    public double Price { get; set; }
    /// <summary>
    /// The amount that the order is placed for
    /// </summary>
    [DataMember(Name = "amount")]
    public double Amount { get; set; }
    /// <summary>
    /// The current amount still pending of the original order
    /// </summary>
    [DataMember(Name = "pending")]
    public double Pending { get; set; }

    /// <summary>
    /// A <c>DateTime</c> representation of the Time
    /// </summary>
    public DateTime OrderTime
    {
      get
      {
        DateTime convertDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        convertDateTime = convertDateTime.AddMilliseconds(Time).ToLocalTime();
        return convertDateTime;
      }
    }

    /// <summary>
    /// An enumerated <c>OrderType</c> of the type
    /// </summary>
    public OrderType OrderType
    {
      get
      {
        return (OrderType)Enum.Parse(typeof(OrderType), Type);
      }
    }

    public override string ToString()
    {
      StringBuilder outputString = new StringBuilder();

      outputString.AppendLine(string.Format("OrderID     = {0}", OrderID));
      outputString.AppendLine(string.Format("OrderTime   = {0}", OrderTime));
      outputString.AppendLine(string.Format("OrderType   = {0}", OrderType));
      outputString.AppendLine(string.Format("Price       = {0:F8}", Price));
      outputString.AppendLine(string.Format("Amount      = {0:F8}", Amount));
      outputString.AppendLine(string.Format("Pending     = {0:F8}", Pending));

      return outputString.ToString();
    }
  }
}
