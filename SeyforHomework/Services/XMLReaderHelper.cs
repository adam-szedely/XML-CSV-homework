using System;
using System.Text;
using System.Xml.Linq;

namespace SeyforHomework.Services
{
    public class XMLReaderHelper
    {
        public XMLReaderHelper()
        {
        }
        public string ReadXml(string filePath)
        {
            XDocument xmlData = XDocument.Load(filePath);

            string csv = // https://learn.microsoft.com/en-us/dotnet/standard/linq/generate-text-files-xml
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