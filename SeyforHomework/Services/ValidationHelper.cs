using System;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;
using SeyforHomework.Services;
using Microsoft.VisualBasic;
using System.Reflection.Metadata;

namespace SeyforHomework.Services
{
	public class ValidationHelper
	{
        public bool FileExists(string filePath)
        {
            if (filePath != null && filePath.Length > 0 && filePath.Substring(filePath.Length - 3) == "xml")
            {
                return File.Exists(filePath);
            }
            return false;
        }     

        public bool CheckPath(string filePath)
        {
            if (filePath != null && filePath.Length > 0)
            {
                return (System.IO.Directory.Exists(filePath));
            }
            return false;
        }

        public bool ValidateSchema(string filePath)
        {
            try
            {
                XmlSchemaSet schemas = new XmlSchemaSet();

                schemas.Add("http://www.w3.org/2001/XMLSchema", @"/Users/adamszedely/Projects/SeyforHomework/SeyforHomework/XMLSchema.xsd");

                XDocument doc = XDocument.Load(filePath);

                bool validationErrors = false;

                doc.Validate(schemas, (s, e) =>
                {
                    Console.WriteLine(e.Message);
                    validationErrors = true;
                });
                return !validationErrors;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Validation Error: " + ex.Message);
                return false;
            }
        }

        private void ValidationEventHandle(object sender, ValidationEventArgs args)
        {
            throw new Exception("Validation Error " + args.Message);
        }
    }
}

