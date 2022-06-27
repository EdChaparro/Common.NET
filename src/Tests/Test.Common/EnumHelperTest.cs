using System.Collections.Generic;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntrepidProducts.Common.Tests
{
    [TestClass]
    public class EnumHelperTest
    {
        public enum TestEnumWithSpacesUnderscoresAndDashes
        {

            [Description("Number One")]
            NumberOne = 1,

            [Description("Number_Two")]
            NumberTwo = 2,

            [Description("Number-Three")]
            NumberThree = 3,
        }

        public enum TestEnum
        {
            Fee = 1,
            Fi = 2,
            Fo = 3,
            [Description("FumbleLeana")]
            Fum = 4
        }

        [TestMethod]
        public void ShouldReturnDescriptionAttributeValueWhenAvailable()
        {
            Assert.AreEqual("Fo", EnumHelper.GetDescription(TestEnum.Fo));
            Assert.AreEqual("FumbleLeana", EnumHelper.GetDescription(TestEnum.Fum));
        }

        [TestMethod]
        public void ShouldReturnDescriptionAttributeValuesWithSpacesUnderscoresAndDashes()
        {
            Assert.AreEqual("Number One", EnumHelper.GetDescription
                (TestEnumWithSpacesUnderscoresAndDashes.NumberOne));

            Assert.AreEqual("Number_Two", EnumHelper.GetDescription
                (TestEnumWithSpacesUnderscoresAndDashes.NumberTwo));

            Assert.AreEqual("Number-Three", EnumHelper.GetDescription
                (TestEnumWithSpacesUnderscoresAndDashes.NumberThree));
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

            var testEnum2 = EnumHelper
                .GetFromString<TestEnumWithSpacesUnderscoresAndDashes>("Number One");
            Assert.AreEqual(TestEnumWithSpacesUnderscoresAndDashes.NumberOne,
                testEnum2);

            testEnum2 = EnumHelper
                .GetFromString<TestEnumWithSpacesUnderscoresAndDashes>("Number_Two");
            Assert.AreEqual(TestEnumWithSpacesUnderscoresAndDashes.NumberTwo,
                testEnum2);

            testEnum2 = EnumHelper
                .GetFromString<TestEnumWithSpacesUnderscoresAndDashes>("Number-Three");
            Assert.AreEqual(TestEnumWithSpacesUnderscoresAndDashes.NumberThree,
                testEnum2);
        }

        [TestMethod]
        public void ShouldConvertStringToEnumRegardlessOfCase()
        {
            var testEnum = EnumHelper.GetFromString<TestEnum>("fEe");
            Assert.AreEqual(TestEnum.Fee, testEnum);

            var testEnum2 = EnumHelper
                .GetFromString<TestEnumWithSpacesUnderscoresAndDashes>("numBer oNe");
            Assert.AreEqual(TestEnumWithSpacesUnderscoresAndDashes.NumberOne,
                testEnum2);
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