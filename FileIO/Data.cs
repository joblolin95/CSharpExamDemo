using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace FileIO
{
    [DataContract, Serializable]
    public class Data
    {
        
        [DataMember, XmlAttribute]
        public int Number { get; set; }
        [XmlIgnore]// Taking this out includes Multiples in the Xml Serialization
        public int [] Multiples { get; set; }

        public override string ToString()
        {
            string returnedString = "";
            if(Multiples != null)
            {
                returnedString += "Multiples: " + Multiples.ToString();
            }
            returnedString += "\nNumber: " + Number;

            return returnedString;
        }

    }
}
