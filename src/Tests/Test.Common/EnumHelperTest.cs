using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntrepidProducts.Common.Tests
{
    [TestClass]
    public class EnumHelperTest
    {
        public enum TestEnum
        {
            Fee = 1,
            Fi = 2,
            Fo = 3,
            [System.ComponentModel.Description("FumbleLeana")]
            Fum = 4
        }

        [TestMethod]
        public void ShouldReturnDescriptionAttributeValueWhenAvailable()
        {
            Assert.AreEqual("Fo", EnumHelper.GetDescription(TestEnum.Fo));
            Assert.AreEqual("FumbleLeana", EnumHelper.GetDescription(TestEnum.Fum));
        }

        [TestMethod]
        public void ShouldReturnNullIfEnumValueIsOutOfRange()
        {
            const TestEnum outOfRangeEnum = (TestEnum)999;
            Assert.IsNull(EnumHelper.GetDescription(outOfRangeEnum));
        }

        [TestMethod]
        public void ShouldConvertStringToEnum()
        {
            var testEnum = EnumHelper.GetFromString<TestEnum>("Fee");
            Assert.AreEqual(TestEnum.Fee, testEnum);
        }

        [TestMethod]
        public void ShouldConvertStringToEnumRegardlessOfCase()
        {
            var testEnum = EnumHelper.GetFromString<TestEnum>("fEe");
            Assert.AreEqual(TestEnum.Fee, testEnum);
        }

        [TestMethod]
        public void ShouldReturnNullIfStringValueDoesNotMatchEnum()
        {
            var testEnum = EnumHelper.GetFromString<TestEnum>("Baz");
            Assert.IsNull(testEnum);
        }

        [TestMethod]
        public void ShouldReturnAllValues()
        {
            var enums = TestEnum.Fee.GetAllValues();
            Assert.AreEqual(4, enums.Count());

            var expectedValues = new List<TestEnum>
            {
                TestEnum.Fee, TestEnum.Fi, TestEnum.Fo, TestEnum.Fum
            };

            Assert.IsTrue(!enums.Except(expectedValues).Any());
        }
    }
}