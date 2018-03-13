using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace MathSequence.RestService.Interfaces
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/calculate", Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<int> Calculate();

        [OperationContract]
        [WebInvoke(UriTemplate = "/sum/{limit}", Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        int Sum(string limit);
    }
}
