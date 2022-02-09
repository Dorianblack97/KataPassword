using KataPassword;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace KataPasswordTest
{
    public class Tests
    {
        private CheckerPassword _checker;
        private ResultValidation resultValidation;

        [SetUp]
        public void Setup()
        {
            _checker = new CheckerPassword();
            resultValidation = new ResultValidation { ErrorDescription = new List<string>() };
        }

        [Test]
        public void TestAtLeast8char_valid()
        {
            var result = _checker.Validate("Ab!cdfg12");
            Assert.IsTrue(result.IsValid);
            Assert.IsEmpty(result.ErrorDescription);

        }
        [Test]
        public void TestAtLeast8char_NotValid()
        {
            var result = _checker.Validate("asfh");

            var expected = new List<string>()
            {
                "Password must be at least 8 characters",
                "The password must contain at least 2 number",
                "The password must contain at least one capital letter",
                "The password must contain at least one special character"
            };

            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(expected, result.ErrorDescription);

        }
        [Test]
        public void TestAtLeast8charAndATLeast2Number_NotValid()
        {
            var expected = new List<string>()
            {
                "The password must contain at least 2 number"
            };

            var result = _checker.Validate("Abc!dfg1s");
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(expected, result.ErrorDescription);

        }
        [Test]
        public void TestCapitalLetter_NotValid()
        {
            var result = _checker.Validate("asfrj23jasdfb");     
            Assert.IsFalse(result.IsValid);
            Assert.Contains("The password must contain at least one capital letter", result.ErrorDescription);
        }
        [Test]
        public void TestSpecialChar_NotValid()
        {
            var result = _checker.Validate("Abcsdfg1s");
            Assert.IsFalse(result.IsValid);
            Assert.Contains("The password must contain at least one special character", result.ErrorDescription);

        }
        [Test]
        public void TestSpecialChar_Valid()
        {          
            var result = _checker.Validate("Abc!sf2g1s");
            Assert.IsTrue(result.IsValid);

        }
        [TestCase("Passw3ord3!", ExpectedResult = true)]
        [TestCase("pAssword23*", ExpectedResult = true)]
        [TestCase("Password23", ExpectedResult = false)]
        public bool TestValidPassword(string input) => _checker.Validate(input).IsValid;

        [TearDown]
        public void Destroy()
        {
            _checker = null;
            GC.Collect();
        }
    }
}