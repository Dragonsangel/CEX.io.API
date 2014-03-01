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
  [DataContract]
  public class AccountBalanceTrade : AccountBalanceNonTrade
  {
    [DataMember(Name = "orders")]
    public double InOrders { get; set; }

    public override string ToString()
    {
      return string.Format("{0,13:F8} - {1,13:F8}", Available, InOrders);
    }
  }
}