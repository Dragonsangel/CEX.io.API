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
  /// A representation of the account balance of an CEX.io account
  /// </summary>
  [DataContract]
  public class AccountBalance
  {
    /// <summary>
    /// The timestamp that the account balance was retrieved
    /// </summary>
    [DataMember(Name = "timestamp")]
    public double TimestampSeconds { get; set; }
    /// <summary>
    /// The CEX.io username of the account
    /// </summary>
    [DataMember(Name = "username")]
    public string Username { get; set; }
    /// <summary>
    /// The current BTC balance
    /// </summary>
    [DataMember(Name = "BTC")]
    public AccountBalanceTrade BTC { get; set; }
    /// <summary>
    /// The current GHS balance
    /// </summary>
    [DataMember(Name = "GHS")]
    public AccountBalanceTrade GHS { get; set; }
    /// <summary>
    /// The current NMC balance
    /// </summary>
    [DataMember(Name = "NMC")]
    public AccountBalanceTrade NMC { get; set; }
    /// <summary>
    /// The current IXC balance
    /// </summary>
    [DataMember(Name = "IXC")]
    public AccountBalanceNonTrade IXC { get; set; }
    /// <summary>
    /// The current DVC balance
    /// </summary>
    [DataMember(Name = "DVC")]
    public AccountBalanceNonTrade DVC { get; set; }

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
      StringBuilder output = new StringBuilder();

      output.AppendLine(string.Format("Timestamp = {0}", Timestamp));
      output.AppendLine(string.Format("Username  = {0}", Username));
      output.AppendLine(string.Format("BTC       = {0}", BTC));
      output.AppendLine(string.Format("GHS       = {0}", GHS));
      output.AppendLine(string.Format("NMC       = {0}", NMC));
      output.AppendLine(string.Format("IXC       = {0}", IXC));
      output.AppendLine(string.Format("DVC       = {0}", DVC));

      return output.ToString();
    }
  }
}
