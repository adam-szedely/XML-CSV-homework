using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Text;
using System.Xml.Schema;
using CsvHelper;
using System;
using System.Xml;
using System.Diagnostics;

var sourceTestXML = @"/Users/adamszedely/Projects/TestFiles/xmlSample2.xml";
var outputCSV = @"/Users/adamszedely/Projects/TestFiles/CSVSample.csv";

XDocument xmlData = XDocument.Load(sourceTestXML);

Stopwatch sw = new Stopwatch();
sw.Start();             //ToDo - read line and write to CSV straight away so I don't have to do it twice?

string csv =
    (from el in xmlData.Element("Localization").Elements("String")
     select
         String.Format("{0},{1},{2}" + Environment.NewLine,
             (string)el.Attribute("locid"),
             (string)el.Attribute("en"),
             (string)el.Attribute("cs")
         )
    )
    .Aggregate(
        new StringBuilder(),
        (sb, s) => sb.Append(s),
        sb => sb.ToString()
    );

Console.WriteLine($"XML parsed in {sw.ElapsedMilliseconds} miliseconds");

File.WriteAllText(outputCSV, csv.ToString());

Console.WriteLine($"Written to CSV in {sw.ElapsedMilliseconds} miliseconds");

Console.WriteLine("done");
