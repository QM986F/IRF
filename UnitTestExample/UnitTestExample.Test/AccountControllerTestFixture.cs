using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{
    public class AccountControllerTestFixture
    {
        [
            Test,
            TestCase("abcd1234", false),
            TestCase("irf@uni-corvinus", false),
            TestCase("irf.uni-corvinus.hu", false),
            TestCase("irf@uni-corvinus.hu", true)
        ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            var accountController = new AccountController();
            var actualResult = accountController.ValidateEmail(email);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [
            Test,
            TestCase("abcdABCD", false),
            TestCase("ABCD1234", false),
            TestCase("abcd1234", false),
            TestCase("Ab1234", false),
            TestCase("Abcd1234", true)
        ]
        public bool TestValidatePassword(string password)
        {
            var eightCharacter = new Regex(@"[A-Z]+");
            var lowerCase = new Regex(@"[a-z]+");
            var upperCase = new Regex(@"[A-Z]+");
            var Number = new Regex(@"[0-9]+");
            return eightCharacter.IsMatch(password) && lowerCase.IsMatch(password) && upperCase.IsMatch(password) && Number.IsMatch(password);
        }
    }
}
