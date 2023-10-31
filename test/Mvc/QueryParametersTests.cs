using Microsoft.VisualStudio.TestTools.UnitTesting;
using XSwift.Mvc;

namespace XSwift.Test.Mvc
{

    [TestClass]
    public class QueryParametersTests
    {
        [TestMethod]
        public void TestToGetQueryparameters()
        {
            QueryParameters helper = new QueryParameters();

            helper.AddParameter("param1", "value1");
            helper.AddParameter("param2", "value2");

            string fullQuery = helper.GetQueryparameters();

            // Check if the full query is as expected
            Assert.AreEqual("?param1=value1&param2=value2", fullQuery);
        }
    }
}
