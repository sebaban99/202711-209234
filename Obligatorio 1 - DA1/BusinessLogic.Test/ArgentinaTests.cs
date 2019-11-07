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
            arg.IsPhoneNumberValid("123456");
        }

    }
}
