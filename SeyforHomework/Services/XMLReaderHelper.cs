using System;
using System.Text;
using System.Xml.Linq;
using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Diagnostics;
using SeyforHomework.Services;
using System.Xml;

namespace SeyforHomework.Services
{
    public class XMLReaderHelper
    {
        public string ReadXml(string filePath)
        {        
            XDocument xmlData = XDocument.Load(filePath);

            string csv = 
                   (from el in xmlData.Element("Localization").Elements("String")
                    select
                        String.Format("{0},{1},{2}" + Environment.NewLine,
                            (string)el.Attribute("locid"),
                            (string)el.Attribute("en"),
                            (string)el.Attribute("cs")
                        )
                   )
                   .Aggregate(
                       new StringBuilder(),
                       (sb, s) => sb.Append(s),
                       sb => sb.ToString()
                   );

            return csv;
        }
    }
}