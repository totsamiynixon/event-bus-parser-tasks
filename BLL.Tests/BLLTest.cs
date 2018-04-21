using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTO.Projections;
using BLL.Helpers;
using CsQuery;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BLL.Tests
{
    [TestClass]
    public class BLLTests
    {
        [TestMethod]
        public void TestCsQueryCounter()
        {
            PrivateType type = new PrivateType(typeof(TaskRunnerHelper));
            object[] args = new object[1] { "https://henris.com" };
            var result = (List<TagNameCountProjection>)type.InvokeStatic("GetTagsCountProjection", args);
            Assert.IsTrue(result != null && result.Any(f => f.TagName == "HTML" && f.Count == 1) && result.Any(f => f.TagName == "META" && f.Count == 5));
        }
    }
}
