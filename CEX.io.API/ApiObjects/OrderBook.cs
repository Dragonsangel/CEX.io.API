/****************************************************************/
/*                                                              */
/* Author: Dragonsangel                                         */
/* E-Mail: drag0nsang3l@gmail.com                               */
/* BTC   : 1P8RuwZuRdmBfrXdURSaxsoJzUPfBEvBie                   */
/*         Donations are welcome                                */
/*                                                              */
/****************************************************************/
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CEX.io.API.ApiObjects
{
  [DataContract]
  public class OrderBook
  {
    [DataMember(Name = "timestamp")]
    public double TimestampSeconds { get; set; }
    [DataMember(Name = "bids")]
    public List<List<double>> Bids { get; set; }
    [DataMember(Name = "asks")]
    public List<List<double>> Asks { get; set; }

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

      output.AppendLine("Current bids:");
      if (Bids != null)
      {
        foreach (List<double> outerItem in Bids)
        {
          output.AppendLine(string.Format("    {1,15:F8} at {0,13:F8}", outerItem[0], outerItem[1]));
        }
      }
      else
      {
        output.AppendLine("None");
      }

      output.AppendLine("Current asks:");
      if (Asks != null)
      {
        foreach (List<double> outerItem in Asks)
        {
          output.AppendLine(string.Format("    {1,15:F8} at {0,13:F8}", outerItem[0], outerItem[1]));
        }
      }
      else
      {
        output.AppendLine("None");
      }

      return output.ToString();
    }
  }
}
