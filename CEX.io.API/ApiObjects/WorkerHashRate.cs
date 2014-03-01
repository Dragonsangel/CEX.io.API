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
  public class WorkersHashRates : List<WorkersHashRates>
  {
    public override string ToString()
    {
      StringBuilder outputString = new StringBuilder();
      foreach (WorkersHashRates item in this)
      {
        outputString.AppendLine(item.ToString());
      }

      return outputString.ToString();
    }
  }

  [DataContract]
  public class WorkerHashRate: HashRate
  {
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
