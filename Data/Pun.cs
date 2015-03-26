using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace Data
{
    [Serializable]
    [DataContract]
    [XmlRoot(Namespace = "http://schemas.datacontract.org/2004/07/Data")]
    public class Pun
    {
        [DataMember]
        public long PunID { get; set; }
        
        [DataMember]
        public string Joke { get; set; }

        [DataMember]
        public string Title { get; set; }

        public override string ToString()
        {
            return PunID + "; " + Joke + "; " + Title;
        }
    }
}