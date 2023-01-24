using System;
using System.Xml.Linq;
using System.Xml.Schema;

namespace SeyforHomework.Services
{
	public class XMLValidator : IXMLValidator
	{
		public XMLValidator()
		{
		}

        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public bool IsValidXML(string filePath)
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(@"XMLSchema.xsd", "XMLSchema");

            XDocument doc = XDocument.Load("XMLSchema");
            string msg = "";
            doc.Validate(schemas, (o, e) => {
                msg += e.Message + Environment.NewLine;
            });
            Console.WriteLine(msg == "" ? "Document is valid" : "Document invalid: " + msg);

            return true;
        }
    }
}

