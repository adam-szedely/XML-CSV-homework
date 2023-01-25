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
            return true;
        }
    }
}

