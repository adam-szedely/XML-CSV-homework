using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Text;
using System.Xml.Schema;
using CsvHelper;
using System;
using System.Xml;

var sourceTestXML = @"/Users/adamszedely/Projects/TestFiles/xmlSample2.xml";
var outputCSV = @"/Users/adamszedely/Projects/TestFiles/CSVSample.csv";

XDocument xmlData = XDocument.Load(sourceTestXML);

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

File.WriteAllText(outputCSV, csv.ToString());

Console.Write(csv);
Console.WriteLine("done");


