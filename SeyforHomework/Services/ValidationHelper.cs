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
            return (System.IO.Directory.Exists(filePath));
        }

        public void ValidateXML(string filePath)
        {
            XmlReader xmlReader = null;
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();

                settings.ValidationType = ValidationType.Schema; 
                settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation; 
                settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings; 
                settings.ValidationEventHandler += new System.Xml.Schema.ValidationEventHandler(this.ValidationEventHandle);
                //settings.Schemas.Add("http://www.w3.org/2001/XMLSchema", new XmlTextReader(@"XMLSchema.xsd"));
                xmlReader = XmlReader.Create(filePath, settings);

                while (xmlReader.Read()) { };
                Console.WriteLine("XML validation passed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\r\n\tValidation Error " + ex.Message);
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Close();
                }
            }
        }

        private void ValidationEventHandle(object sender, ValidationEventArgs args)
        {
            throw new Exception("\r\n\tValidation Error " + args.Message);
        }
    }
}

