using System;
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
            throw new NotImplementedException();
        }
    }
}

