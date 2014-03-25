using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CEX.io.API.ApiObjects
{
  /// <summary>
  /// A representation of an error of an API call
  /// </summary>
  [DataContract]
  public class ApiError
  {
    /// <summary>
    /// Details of the error message
    /// </summary>
    [DataMember(Name = "error")]
    public string ErrorMessage;

    public override string ToString()
    {
      return ErrorMessage;
    }
  }
}
