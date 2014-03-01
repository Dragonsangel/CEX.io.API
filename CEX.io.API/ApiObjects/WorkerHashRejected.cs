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
  [DataContract]
  public class WorkerHashRejected
  {
    [DataMember(Name="stale")]
    public string Stale { get; set; }
    [DataMember(Name = "duplicate")]
    public int Duplicate { get; set; }
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
