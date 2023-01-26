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
        var result = validationHelper.FileExists("/Users/adamszedely/Projects/TestFiles/xmlSample2.xml");
        result.ShouldBeTrue();
    }

    [Fact]
    public void XMLValidationHelper_InvalidXML_ShouldFail()
    {
        var filePath = @"TestData\TestXMLFile.xml";
        validationHelper.ValidateXML(filePath);
    }

    [Fact]
    public void XMLValidationHelper_ValidXMLInvalidSchema_ShouldFail()
    {

    }

    [Fact]
    public void XMLValidationHelper_ValidInput_ShouldPass()
    {

    }

    [Fact]
    public void XMLReaderHelper_ValidInput_ShouldPass()
    {
        var filePath = @"\TestXMLFile.xml";
        var resultCsv = xmlReaderHelper.ReadXml(filePath);
        resultCsv.Substring(0, 6).ShouldBe("str1234");
    }
}
