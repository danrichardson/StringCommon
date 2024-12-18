namespace StringCommonTests
{
    using FunWithStrings;
    using StringCommon;

    [TestClass]

    public class Tests
    {
        [TestMethod]
        public void TestBlank()
        {
            FindCommonString sortEm = new FindCommonString();
            List<string> stringList = new List<string>();
            var result = sortEm.execute(stringList);
            Assert.IsTrue(string.IsNullOrEmpty(result));
        }
        [TestMethod]
        [DataRow(new string[] { "Apple", "AppleBar", "AppleFoo", "Appleicious" }, "Apple")]
        [DataRow(new string[] { "Apple", "Banana", "Cherry", "Date" }, "")]
        [DataRow(new string[] { "Date", "Banana", "Cherry", "Apple" }, "")]
        [DataRow(new string[] { "Apple", "ACpleBar", "AppleFoo", "Appleicious" }, "A")]
        [DataRow(new string[] { "App", "Ap", "Apple" }, "Ap")]
        [DataRow(new string[] { "App", "Ap", "Apple", "App", "Ap", "Apple", "App", "Ap", "Apple" }, "Ap")]
        [DataRow(new string[] { "App", "ap", "Apple" }, "")]
        public void TestCases(string[] input, string expectedResult)
        {
            FindCommonString sortEm = new FindCommonString();
            List<string> stringList = input.ToList();
            var result = sortEm.execute(stringList);
            Assert.AreEqual(result, expectedResult);
        }
    }
}
