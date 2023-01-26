using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Text;
using System.Xml.Schema;
using System.Diagnostics;
using SeyforHomework.Services;

ValidationHelper validationHelper = new ValidationHelper();
XMLReaderHelper xmlReaderHelper = new XMLReaderHelper();

var sourceTestXML = @"/Users/adamszedely/Projects/TestFiles/xmlSample2.xml";
var outputCSV = @"/Users/adamszedely/Projects/TestFiles/CSVSample.csv";

string arg1 = "";
string arg2 = "";

Console.WriteLine("Provide XML file to convert");

while (!validationHelper.FileExists(arg1))
{
    arg1 = Console.ReadLine();
    if (!validationHelper.FileExists(arg1))
    {
        Console.WriteLine("File path does not exist, or the format is incorrect");
    }
}

Console.WriteLine("Where would you like to save the file?");

while (!validationHelper.CheckPath(arg2))
{
    arg1 = Console.ReadLine();
    if (!validationHelper.FileExists(arg2))
    {
        Console.WriteLine("File path does not exist");
    }
}

try
{
    validationHelper.ValidateXML(arg1);

    string header = String.Format("{0}, {1}, {2}" + Environment.NewLine,
    "locid",
    "en",
    "cs");

    var xmlData = xmlReaderHelper.ReadXml(arg1);

    File.WriteAllText(outputCSV, header + xmlData);
}
catch (Exception ex)
{
    Console.WriteLine("There was a problem: " + ex.Message);
}
