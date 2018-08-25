using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTO.Projections;
using IFL.EventBus;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IFL.Tests
{
    [TestClass]
    public class EventBusTests
    {
        [TestMethod]
        public void TestCsQueryCounter()
        {
            PrivateType type = new PrivateType(typeof(EventBusInitializer));
            object[] args = new object[1] { "https://henris.com" };
            var result = (List<TagNameCountProjection>)type.InvokeStatic("GetTagsCountProjection", args);
            Assert.IsTrue(result != null && result.Any(f => f.TagName == "HTML" && f.Count == 1) && result.Any(f => f.TagName == "META" && f.Count == 5));
        }
    }
}
