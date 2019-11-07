using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogic.Test
{
    [TestClass]
    public class ArgentinaTests
    {
        private Argentina arg;

        [TestInitialize]
        public void SetUpArgentina()
        {
            arg = new Argentina();
        }

        [TestMethod]
        public void ValidatePhoneNumberValidNumberLength6()
        {
            Assert.IsTrue(arg.IsPhoneNumberValid("123456"));
        }

        [TestMethod]
        public void ValidatePhoneNumberValidNumberLength7()
        {
            Assert.IsTrue(arg.IsPhoneNumberValid("1234567"));
        }

        [TestMethod]
        public void ValidatePhoneNumberValidNumberLength8()
        {
            Assert.IsTrue(arg.IsPhoneNumberValid("12345678"));
        }

        [TestMethod]
        public void ValidatePhoneNumberValidNumberWithOneHyphen()
        {
            Assert.IsTrue(arg.IsPhoneNumberValid("1-23456"));
        }

    }
}
