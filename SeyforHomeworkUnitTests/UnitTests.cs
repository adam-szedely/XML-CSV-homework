using SeyforHomework.Services;
using Shouldly;

namespace SeyforHomeworkUnitTests;

public class UnitTest : IClassFixture<ValidationHelper>, IClassFixture<XMLReaderHelper> 
{
    private ValidationHelper validationHelper;
    private XMLReaderHelper xmlReaderHelper;

    public UnitTest(ValidationHelper validationHelper, XMLReaderHelper xmlReaderHelper)
    {
        this.validationHelper = validationHelper;
        this.xmlReaderHelper = xmlReaderHelper;
    }

    [Fact]
    public void ValidationHelper_NoInput_ShouldFail()
    {
        var result = validationHelper.FileExists(null);
        result.ShouldBeFalse();
    }

    [Fact]
    public void ValidationHelper_InvalidInput_ShouldFail()
    {
        var result = validationHelper.FileExists("");
        result.ShouldBeFalse();
    }

    [Fact]
    public void ValidationHelper_ValidInput_ShouldPass()
    {
        var result = validationHelper.FileExists("/Users/adamszedely/Projects/SeyforHomework/SeyforHomeworkUnitTests/TestXMLFile.xml");
        result.ShouldBeTrue();
    }

    [Fact]
    public void PathValidationHelper_InvalidInputs_ShouldFail()
    {
        bool[] results = new bool[5];
        results[0] = validationHelper.CheckPath("/path/path");
        results[1] = validationHelper.CheckPath("wrongpathwrongpath");
        results[2] = validationHelper.CheckPath(null);
        results[3] = validationHelper.CheckPath("/path?");
        results[4] = validationHelper.CheckPath(@"a:\invalidpath\invalidpath\invalidpath");

        bool result = true;

        for (int i = 0; i < results.Length - 1; i++)
        {
            result = results[i];
        }

        result.ShouldBe(false);
    }

    [Fact]
    public void PathValidationHelper_ValidInput_ShouldPass()
    {
        var result = validationHelper.CheckPath(Directory.GetCurrentDirectory());
        result.ShouldBeTrue();
    }

    [Fact]
    public void XMLReaderHelper_ValidInput_ShouldPass()
    {
        var filePath = "/Users/adamszedely/Projects/SeyforHomework/SeyforHomeworkUnitTests/TestXMLFile.xml";
        var resultCsv = xmlReaderHelper.ReadXml(filePath);
        resultCsv.Substring(0, 7).ShouldBe("str1234");
    }

    [Fact]
    public void SchemaValidation_InvalidInput_ShouldFail()
    {
        var filePath = "/Users/adamszedely/Projects/SeyforHomework/SeyforHomeworkUnitTests/TestXMLFile.xml";
        File.AppendAllText(filePath, "fail please, thank you");
        var result = validationHelper.ValidateSchema(filePath);
        result.ShouldBeFalse();

    }

    [Fact]
    public void SchemaValidation_ValidInput_ShouldPass()
    {
        var filePath = "/Users/adamszedely/Projects/SeyforHomework/SeyforHomeworkUnitTests/TestXMLFile.xml";
        var result = validationHelper.ValidateSchema(filePath);
        result.ShouldBeTrue();
    }

    [Fact]
    public void WritingIntoCSV_ValidInput_ShouldPass()
    {
        var filePath = "/Users/adamszedely/Projects/SeyforHomework/SeyforHomeworkUnitTests/TestXMLFile.xml";
        var resultCsv = xmlReaderHelper.ReadXml(filePath);
        resultCsv.Substring(0, 7).ShouldBe("str1234");
    }

}
