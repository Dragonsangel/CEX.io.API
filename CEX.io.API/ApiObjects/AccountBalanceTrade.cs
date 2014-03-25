/****************************************************************/
/*                                                              */
/* Author: Dragonsangel                                         */
/* E-Mail: drag0nsang3l@gmail.com                               */
/* BTC   : 1P8RuwZuRdmBfrXdURSaxsoJzUPfBEvBie                   */
/*         Donations are welcome                                */
/*                                                              */
/****************************************************************/
using System.Runtime.Serialization;

namespace CEX.io.API.ApiObjects
{
  /// <summary>
  /// An account balance for a tradable currency
  /// </summary>
  [DataContract]
  public class AccountBalanceTrade : AccountBalanceNonTrade
  {
    /// <summary>
    /// The amount currently in orders
    /// </summary>
    [DataMember(Name = "orders")]
    public double InOrders { get; set; }

    public override string ToString()
    {
      return ToString(true);
    }

    public string ToString(bool includeOrders)
    {
      if (includeOrders)
      {
        return string.Format("{0:F8} - {1:F8}", Available, InOrders);
      }
      else
      {
        return string.Format("{0:F8}", Available);
      }
    }
  }
}