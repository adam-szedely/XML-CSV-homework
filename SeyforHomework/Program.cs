using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Text;
using System.Xml.Schema;
using CsvHelper;
using System;
using System.Xml;
using System.Diagnostics;
using SeyforHomework.Services;

var sourceTestXML = @"/Users/adamszedely/Projects/TestFiles/xmlSample2.xml";
var outputCSV = @"/Users/adamszedely/Projects/TestFiles/CSVSample.csv";

Stopwatch sw = new Stopwatch();

ValidationHelper validationHelper = new ValidationHelper();
XMLReaderHelper xmlReaderHelper = new XMLReaderHelper();

sw.Start();

try
{
    if (validationHelper.FileExists(sourceTestXML))
    {
        try
        {
            validationHelper.ValidateXML(sourceTestXML);

            string header = String.Format("{0}, {1}, {2}" + Environment.NewLine,
            "locid",
            "en",
            "cs");

            var xmlData = xmlReaderHelper.ReadXml(sourceTestXML);

            Console.WriteLine($"XML parsed in {sw.ElapsedMilliseconds} miliseconds");

            File.WriteAllText(outputCSV, xmlData);

            Console.WriteLine($"Written to CSV in {sw.ElapsedMilliseconds} miliseconds");
        }
        catch (Exception ex)
        {
            Console.WriteLine("XML asi není valid " + ex.Message);
        }
    }
}
catch (FileNotFoundException ex)
{
    Console.WriteLine("Soubor neexistuje " + ex.Message);
}