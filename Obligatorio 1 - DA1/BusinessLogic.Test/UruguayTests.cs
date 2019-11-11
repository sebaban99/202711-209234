using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Exceptions;
using Moq;

namespace BusinessLogic.Test
{
    [TestClass]
    public class UruguayTests
    {
        private Uruguay uy;

        [TestInitialize]
        public void SetUpUruguay()
        {
            uy = new Uruguay();
        }

        [TestMethod]
        public void ValidatePhoneNumberWithSpaceAndZero()
        {
            Assert.IsTrue(uy.IsPhoneNumberValid("098 204 265"));
        }

        [TestMethod]
        public void ValidatePhoneNumberWithZeroAndWithoutSpace()
        {
            Assert.IsTrue(uy.IsPhoneNumberValid("098204265"));
        }

        [TestMethod]
        public void ValidatePhoneNumberWithSpaceAndWithoutZero()
        {
            Assert.IsTrue(uy.IsPhoneNumberValid("98 204 265"));
        }

        [TestMethod]
        public void ValidatePhoneNumberWithoutSpaceAndWithoutZero()
        {
            Assert.IsTrue(uy.IsPhoneNumberValid("98204265"));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidatePhoneNumberStaringWithZeroNotFollowedByNine()
        {
            uy.IsPhoneNumberValid("082 042 656");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidatePhoneNumberNotStaringWithZeroNorNine()
        {
            uy.IsPhoneNumberValid("82 042 656");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidatePhoneNumberTooManyNumbers()
        {
            uy.IsPhoneNumberValid("9820426568435131");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidatePhoneNumberNotEnoughNumbers()
        {
            uy.IsPhoneNumberValid("98204");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidatePhoneNumberContainsLetters()
        {
            uy.IsPhoneNumberValid("098 740 mal");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void ValidatePhoneStartWithNineInvalidLength()
        {
            uy.IsPhoneNumberValid("982 004 658");
        }
    }
}
