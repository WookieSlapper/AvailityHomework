using Microsoft.VisualStudio.TestTools.UnitTesting;
using Availity_Test.Models;
using System;

namespace Availity_Test.Tests.Models
{
    [TestClass]
    public class ParenthesesTests
    {
        private readonly Parentheses parentheses;

        public ParenthesesTests()
        {
            parentheses = new Parentheses();
        }

        [TestMethod]
        public void ReturnTrue_ValidPairs()
        {
            //Arrange
            var trueString = "abc(123)def((456))";

            //Act
            var result = parentheses.HasValidParenPairs(trueString);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ReturnFalse_UnmatchedLeftParens()
        {
            //Arrange
            var unmatchedLeftString = "abc(123def((456))";

            //Act
            var result = parentheses.HasValidParenPairs(unmatchedLeftString);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReturnFalse_RightParenComesFirst()
        {
            //Arrange
            var rightComesFirst = "a(b(c(d)))) * abc((ba)";

            //Act
            var result = parentheses.HasValidParenPairs(rightComesFirst);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
