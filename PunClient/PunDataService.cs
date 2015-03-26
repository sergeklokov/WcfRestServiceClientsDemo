using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using System.Runtime.Serialization.Json; // add reference on System.Runtime.Serialization.dll 
using System.Xml.Serialization;
using Data;

namespace PunClient
{
    public class PunDataService
    {
        public Pun[] GetPuns()
        {
            var client = new WebClient();
            client.Headers.Add("Accept", "application/json");
            var result = client.DownloadString("http://localhost:5576/PunService.svc/Puns");

            var serializer = new DataContractJsonSerializer(typeof(Pun[]));

            Pun[] resultObject;

            using (var stream = new MemoryStream(Encoding.ASCII.GetBytes(result)))
            {
                resultObject = (Pun[])serializer.ReadObject(stream);
            }

            return resultObject;
        }

        public Pun GetPunByID(long punID)
        {
            var client = new WebClient();
            //client.Headers.Add("Accept", "application/json");
            //client.Headers.Add("Accept", "text/xml");

            var result = client.DownloadString("http://localhost:5576/PunService.svc/Pun/1");
            //var serializer = new DataContractJsonSerializer(typeof(Pun));
            var serializer = new XmlSerializer(typeof(Pun));

            Pun resultObject;

            using (var stream = new MemoryStream(Encoding.ASCII.GetBytes(result)))
            {
                resultObject = (Pun)serializer.Deserialize(stream);
                //resultObject = (Pun)serializer.ReadObject(stream);
            }

            return resultObject;
        }

    }
}
