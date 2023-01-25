using System;
namespace SeyforHomework.Services
{
	public interface IXMLValidator
	{
		public bool FileExists(string filePath);
		public bool IsValidXML(string filePath);
	}
}

