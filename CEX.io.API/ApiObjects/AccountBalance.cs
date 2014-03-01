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
  [DataContract]
  public class AccountBalance
  {
    [DataMember(Name = "timestamp")]
    public double TimestampSeconds { get; set; }
    [DataMember(Name = "username")]
    public string Username { get; set; }
    [DataMember(Name = "BTC")]
    public AccountBalanceTrade BTC { get; set; }
    [DataMember(Name = "GHS")]
    public AccountBalanceTrade GHS { get; set; }
    [DataMember(Name = "NMC")]
    public AccountBalanceTrade NMC { get; set; }
    [DataMember(Name = "IXC")]
    public AccountBalanceNonTrade IXC { get; set; }
    [DataMember(Name = "DVC")]
    public AccountBalanceNonTrade DVC { get; set; }

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
