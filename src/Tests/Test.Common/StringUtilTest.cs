using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntrepidProducts.Common.Tests
{
    [TestClass]
    public class StringUtilTest
    {
        [TestMethod]
        public void ShouldFormatText()
        {
            const string INPUT = "   A B  c    ";
            const string EXPECTED = "a_b__c";

            var result = StringsUtil.ToLowerSnakeCase(INPUT);
            Assert.AreEqual(EXPECTED, result);
        }

        [TestMethod]
        public void ShouldReverseOrderOfWords()
        {
            const string INPUT = "One Two Three";
            const string EXPECTED = "Three Two One";

            var result = StringsUtil.ReverseOrderOfWords(INPUT);
            Assert.AreEqual(EXPECTED, result);
        }

        [TestMethod]
        public void ShouldIdentifyPalindromeWord()
        {
            Assert.IsTrue(StringsUtil.IsPalindrome("Radar"));

            Assert.IsFalse(StringsUtil.IsPalindrome("Not A Palindrome"));
        }

        [TestMethod]
        public void ShouldMaskify()
        {
            const string INPUT1 = "4556364607935616";
            const string INPUT2 = "64607935616";
            const string INPUT3 = "1";
            const string INPUT4 = "";

            const string EXPECTED_OUTPUT1 = "************5616";
            const string EXPECTED_OUTPUT2 = "*******5616";
            const string EXPECTED_OUTPUT3 = "1";
            const string EXPECTED_OUTPUT4 = "";

            Assert.AreEqual(EXPECTED_OUTPUT1, StringsUtil.Maskify(INPUT1));
            Assert.AreEqual(EXPECTED_OUTPUT2, StringsUtil.Maskify(INPUT2));
            Assert.AreEqual(EXPECTED_OUTPUT3, StringsUtil.Maskify(INPUT3));
            Assert.AreEqual(EXPECTED_OUTPUT4, StringsUtil.Maskify(INPUT4));
        }

        [TestMethod]
        public void ShouldReverseAndNot()
        {
            const int INPUT1 = 123;
            const int INPUT2 = 987654321;
            const int INPUT3 = 1;

            const string EXPECTED_OUTPUT1 = "321123";
            const string EXPECTED_OUTPUT2 = "123456789987654321";
            const string EXPECTED_OUTPUT3 = "11";

            Assert.AreEqual(EXPECTED_OUTPUT1, StringsUtil.ReverseAndNot(INPUT1));
            Assert.AreEqual(EXPECTED_OUTPUT2, StringsUtil.ReverseAndNot(INPUT2));
            Assert.AreEqual(EXPECTED_OUTPUT3, StringsUtil.ReverseAndNot(INPUT3));
        }
    }
}