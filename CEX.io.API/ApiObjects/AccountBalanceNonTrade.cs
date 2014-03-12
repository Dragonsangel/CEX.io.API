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
  /// An Account Balance value for a non tradable currency
  /// </summary>
  [DataContract]
  public class AccountBalanceNonTrade
  {
    /// <summary>
    /// The amount available
    /// </summary>
    [DataMember(Name="available")]
    public double Available { get; set; }

    public override string ToString()
    {
      return string.Format("{0,13:F8}", Available);
    }
  }
}
