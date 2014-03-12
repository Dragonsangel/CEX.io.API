/****************************************************************/
/*                                                              */
/* Author: Dragonsangel                                         */
/* E-Mail: drag0nsang3l@gmail.com                               */
/* BTC   : 1P8RuwZuRdmBfrXdURSaxsoJzUPfBEvBie                   */
/*         Donations are welcome                                */
/*                                                              */
/****************************************************************/
using System.Runtime.Serialization;
using System.Text;

namespace CEX.io.API.ApiObjects
{
  /// <summary>
  /// A representation of the Hash Rate of an CEX.io account
  /// </summary>
  [DataContract]
  public class HashRate
  {
    /// <summary>
    /// The average hash rate, in MH/s, over the last 5 minutes
    /// </summary>
    [DataMember(Name = "last5m")]
    public double Last5Mins { get; set; }
    /// <summary>
    /// The average hash rate, in MH/s, over the last 15 minutes
    /// </summary>
    [DataMember(Name = "last15m")]
    public double Last15Mins { get; set; }
    /// <summary>
    /// The average hash rate, in MH/s, over the last 1 hour
    /// </summary>
    [DataMember(Name = "last1h")]
    public double Last1Hour { get; set; }
    /// <summary>
    /// The average hash rate, in MH/s, over the last 1 day
    /// </summary>
    [DataMember(Name = "last1d")]
    public double Last1Day { get; set; }
    /// <summary>
    /// The average hash rate, in MH/s, of the previous 5 minutes
    /// </summary>
    [DataMember(Name = "prev5m")]
    public double Prev5Mins { get; set; }
    /// <summary>
    /// The average hash rate, in MH/s, of the previous 15 minutes
    /// </summary>
    [DataMember(Name = "prev15m")]
    public double Prev15Mins { get; set; }
    /// <summary>
    /// The average hash rate, in MH/s, of the previous 1 hour
    /// </summary>
    [DataMember(Name = "prev1h")]
    public double Prev1Hour { get; set; }
    /// <summary>
    /// The average hash rate, in MH/s, of the previous 1 day
    /// </summary>
    [DataMember(Name = "prev1d")]
    public double Prev1Day { get; set; }

    public override string ToString()
    {
      StringBuilder outputString = new StringBuilder();

      outputString.AppendLine(string.Format("Last5Mins  = {0:F10}", Last5Mins));
      outputString.AppendLine(string.Format("Last15Mins = {0:F10}", Last15Mins));
      outputString.AppendLine(string.Format("Last1Hour  = {0:F10}", Last1Hour));
      outputString.AppendLine(string.Format("Last1Day   = {0:F10}", Last1Day));
      outputString.AppendLine(string.Format("Prev5Mins  = {0:F10}", Prev5Mins));
      outputString.AppendLine(string.Format("Prev15Mins = {0:F10}", Prev15Mins));
      outputString.AppendLine(string.Format("Prev1Hour  = {0:F10}", Prev1Hour));
      outputString.AppendLine(string.Format("Prev1Day   = {0:F10}", Prev1Day));

      return outputString.ToString();
    }
  }
}
