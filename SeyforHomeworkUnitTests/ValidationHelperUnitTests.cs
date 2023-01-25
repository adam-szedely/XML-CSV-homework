﻿using SeyforHomework.Services;
using Shouldly;

namespace SeyforHomeworkUnitTests;

public class UnitTest : IClassFixture<ValidationHelper>
{
    private ValidationHelper validationHelper;

    public UnitTest(ValidationHelper validationHelper)
    {
        this.validationHelper = validationHelper;
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
    public void TesIt1()
    {

    }
}
