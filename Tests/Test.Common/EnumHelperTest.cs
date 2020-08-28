using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace intrepidproducts.common.tests
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
            Assert.AreEqual("Fo", EnumHelper.GetEnumDescription(TestEnum.Fo));
            Assert.AreEqual("FumbleLeana", EnumHelper.GetEnumDescription(TestEnum.Fum));
        }

        [TestMethod]
        public void ShouldReturnNullIfEnumValueIsOutOfRange()
        {
            const TestEnum outOfRangeEnum = (TestEnum)999;
            Assert.IsNull(EnumHelper.GetEnumDescription(outOfRangeEnum));
        }

        [TestMethod]
        public void ShouldConvertStringToEnum()
        {
            var testEnum = EnumHelper.GetEnumFromString<TestEnum>("Fee");
            Assert.AreEqual(TestEnum.Fee, testEnum);
        }

        [TestMethod]
        public void ShouldConvertStringToEnumRegardlessOfCase()
        {
            var testEnum = EnumHelper.GetEnumFromString<TestEnum>("fEe");
            Assert.AreEqual(TestEnum.Fee, testEnum);
        }

        [TestMethod]
        public void ShouldReturnNullIfStringValueDoesNotMatchEnum()
        {
            var testEnum = EnumHelper.GetEnumFromString<TestEnum>("Baz");
            Assert.IsNull(testEnum);
        }
    }
}