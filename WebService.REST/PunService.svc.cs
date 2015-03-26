using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Data;


namespace WebService.REST
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class PunService
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        //[WebGet(UriTemplate = "/DoRealWork")]
        [WebGet]
        public void DoWork()
        {
            // Add your operation implementation here
            return;
        }

        private PunDataService _service;

        private PunService()
        {
            _service = new PunDataService();
        }

        [OperationContract]
        //[WebGet(UriTemplate = "/Puns")]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public Pun[] Puns()
        {
            return _service.GetPuns();
        }

        //[WebGet(UriTemplate = "/Pun?id={punID}")]
        [WebGet(UriTemplate = "/Pun/{punID}")]
        public Pun GetPunByID(string punID)
        {
            long parsedPunID;
            Int64.TryParse(punID, out parsedPunID);

            return _service.GetPunById(parsedPunID);
        }

        //[WebInvoke(UriTemplate = "/Puns")]
        public Pun CreatePun(Pun pun)
        {
            return _service.AddPun(pun);
        }

        //[WebInvoke(Method = "PUT", UriTemplate = "/Pun/{punID}")]
        public Pun UpdatePun(string punID, Pun pun)
        {
            long parsedPunID;
            Int64.TryParse(punID, out parsedPunID);

            return _service.UpdatePun(parsedPunID, pun);
        }
    }
}
