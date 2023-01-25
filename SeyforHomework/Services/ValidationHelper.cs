using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SeyforHomework.Services
{
	public class ValidationHelper
	{
		public ValidationHelper()
		{
		}

        public bool FileExists(string filePath) //todo - add path exists , string je not null a > 0
        {
            if (filePath != null && filePath.Length > 0)
            {
                return File.Exists(filePath);
            }
            return false;
        }

        public void ValidateXML(string filePath)
        {
            XmlReader xmlReader = null;
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();

                settings.ValidationType = ValidationType.Schema; //Používám .xsd
                settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation; //ToDo schema v xsd
                settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings; //Vrací varování
                settings.ValidationEventHandler += new System.Xml.Schema.ValidationEventHandler(this.ValidationEventHandle);
                xmlReader = XmlReader.Create(filePath, settings);

                while (xmlReader.Read()) { };
                Console.WriteLine("Validation passed");
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

