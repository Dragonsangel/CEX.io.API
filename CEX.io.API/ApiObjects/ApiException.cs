using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEX.io.API.ApiObjects
{
  public class ApiException: Exception
  {
    public NameValueCollection InputParams;
    public ApiError ApiError;

    public ApiException(NameValueCollection inputParams, ApiError apiError) 
    {
      InputParams = inputParams;
      ApiError = apiError;
    }
  }
}
