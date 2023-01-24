using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Text;
using System.Xml.Schema;
using CsvHelper;

var sourceTestXML = @"/Users/adamszedely/Projects/TestFiles/xmlSample2.xml";


var header = new string[4]; //ToDo - přečíst v xml data dole z prvního řádku

XDocument xmlData = XDocument.Load(sourceTestXML);

string csv =
    (from el in xmlData.Element("Localization").Elements("String")
     select
         String.Format("{0},{1},{2}",
             (string)el.Attribute("locid"),
             (string)el.Attribute("en"),
             (string)el.Attribute("cs"),
             Environment.NewLine
         )
    )
    .Aggregate(
        new StringBuilder(),
        (sb, s) => sb.Append(s),
        sb => sb.ToString()
    );
Console.WriteLine(csv);

Console.WriteLine("done");


