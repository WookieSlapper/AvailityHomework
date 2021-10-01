using Availity_Test.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Availity_Test.Tests.Models
{
    [TestClass]
    public class CSVTests
    {
        private readonly CSV testClass;

        // set up some .csv file to send into the test in a base class, or have a method read and write into memory for testing
        // for now, just using a static string value to use as a parameter
        private readonly string testCSV;

        public CSVTests()
        {
            testClass = new CSV();
        }

        [TestMethod]
        public void SaveCSVtoFile_ThisPhraseWillContainTheTestConditions()
        {
            //Arrange
            // be sure the appropriate .csv file conditions were set up in a test file

            //Act
            //Call ttestClass.ReadAndWriteCSVs(testCSV);

            //Assert
            //AssertString to check the string output, or Assert to match on some specific portion, maybe the file address
        }

        // Would write additional test for bad data in .csv, null values, etc., once a method for importing a test .csv was decided upon...
    }
}
