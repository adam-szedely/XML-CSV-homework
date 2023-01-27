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

Stopwatch sw = new Stopwatch();

string arg1 = "";
string arg2 = "";

Console.WriteLine("Provide XML file to convert");

while (!validationHelper.FileExists(arg1))
{
    arg1 = Console.ReadLine();
    if (!validationHelper.FileExists(arg1))
    {
        Console.WriteLine("File does not exist, or the format is incorrect");
    }
}

Console.WriteLine("Where would you like to save the file?");

while (!validationHelper.CheckPath(arg2))
{
    arg2 = Console.ReadLine();
    if (!validationHelper.CheckPath(arg2))
    {
        Console.WriteLine("File path does not exist");
    }
}

try
{
    sw.Start();
    validationHelper.ValidateSchema(arg1);
    //validationHelper.ValidateXML(arg1);

    Console.WriteLine($"XML validated in {sw.ElapsedMilliseconds} milliseconds");

    string header = String.Format("{0}, {1}, {2}" + Environment.NewLine,
    "locid",
    "en",
    "cs");

    var xmlData = xmlReaderHelper.ReadXml(arg1);

    Console.WriteLine($"XML read in {sw.ElapsedMilliseconds} milliseconds");

    File.WriteAllText(arg2 + "/retezce.csv", header + xmlData);

    Console.WriteLine($"Done in {sw.ElapsedMilliseconds} milliseconds");
}
catch (Exception ex)
{
    Console.WriteLine("There was a problem: " + ex.Message);
}
Console.Read();