namespace StringCommonTests
{
    using FunWithStrings;
    using StringCommon;

    [TestClass]

    public class Test2
    {
        [TestMethod]
        public void TestBlank()
        {
            SortEm sortEm = new SortEm();
            List<string> stringList = new List<string>();
            var result = sortEm.execute(stringList);
            Assert.IsTrue(string.IsNullOrEmpty(result));
        }
        [TestMethod]
        [DataRow(new string[] { "Apple", "AppleBar", "AppleFoo", "Appleicious" }, "Apple")]
        [DataRow(new string[] { "Apple", "Banana", "Cherry", "Date" }, "")]
        [DataRow(new string[] { "Apple", "ACpleBar", "AppleFoo", "Appleicious" }, "A")]
        public void TestCases(string[] input, string expectedResult)
        {
            SortEm sortEm = new SortEm();
            List<string> stringList = input.ToList();
            var result = sortEm.execute(stringList);
            Assert.AreEqual(result, expectedResult);
        }
    }
}
