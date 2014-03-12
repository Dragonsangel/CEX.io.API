/****************************************************************/
/*                                                              */
/* Author: Dragonsangel                                         */
/* E-Mail: drag0nsang3l@gmail.com                               */
/* BTC   : 1P8RuwZuRdmBfrXdURSaxsoJzUPfBEvBie                   */
/*         Donations are welcome                                */
/*                                                              */
/****************************************************************/
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CEX.io.API.ApiObjects
{
  /// <summary>
  /// The list of <c>WorkerHashRate</c>
  /// </summary>
  public class WorkersHashRates : List<WorkerHashRate>
  {
    public override string ToString()
    {
      StringBuilder outputString = new StringBuilder();
      foreach (WorkerHashRate item in this)
      {
        outputString.AppendLine(item.ToString());
      }

      return outputString.ToString();
    }
  }

  /// <summary>
  /// A representation of a workers hash rate
  /// </summary>
  [DataContract]
  public class WorkerHashRate: HashRate
  {
    /// <summary>
    /// The <c>WorkerHashRejected</c> values of rejected shares by the worker
    /// </summary>
    [DataMember(Name = "rejected")]
    public WorkerHashRejected Rejected { get; set; }

    public override string ToString()
    {
      StringBuilder outputString = new StringBuilder();

      outputString.Append(base.ToString());
      outputString.AppendLine("Rejected:");
      outputString.AppendLine(Rejected.ToString());
      
      return outputString.ToString();
    }
  }
}
