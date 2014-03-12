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
  /// A representation of worker shares that were rejected
  /// </summary>
  [DataContract]
  public class WorkerHashRejected
  {
    /// <summary>
    /// The number of stale shares
    /// </summary>
    [DataMember(Name="stale")]
    public string Stale { get; set; }
    /// <summary>
    /// The number of duplicate shares
    /// </summary>
    [DataMember(Name = "duplicate")]
    public int Duplicate { get; set; }
    /// <summary>
    /// The number of shares at a lower difficulty
    /// </summary>
    [DataMember(Name = "lowdiff")]
    public int LowDifficulty { get; set; }

    public override string ToString()
    {
      StringBuilder outputString = new StringBuilder();

      outputString.AppendLine(string.Format("Stale         = {0}", Stale));
      outputString.AppendLine(string.Format("Duplicate     = {0}", Duplicate));
      outputString.AppendLine(string.Format("LowDifficulty = {0}", LowDifficulty));
      
      return outputString.ToString();
    }
  }
}
