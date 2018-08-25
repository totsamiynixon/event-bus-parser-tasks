using BLL.DTO.Projections;
using BLL.Implementations;
using BLL.Interfaces;
using DAL.Data;
using IFL.DI;
using IFL.Initializer;
using IFL.Mapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Web.Mvc;
using Web.Controllers.Api;

namespace Web.Tests.Controllers
{
    [TestClass]
    public class TagsApiControllerTests
    {
        private ITagsCounterTaskService _tagsCounterTaskService;
        [TestInitialize]
        public void InitTest()
        {
            IFLInitializer.Initialize();
            _tagsCounterTaskService = DependencyResolver.Current.GetService<ITagsCounterTaskService>();
        }
        [TestMethod]
        public async Task CreateAndGetTaskStateTestAsync()
        {
            var controller = new TagsApiController(_tagsCounterTaskService);
            var result = await controller.CreateTask(new Models.Api.CreateTagsParserTaskModel
            {
                Url = "https://henris.com"
            });
            Assert.IsInstanceOfType(result, typeof(CreatedNegotiatedContentResult<string>));
            var trackingCode = ((CreatedNegotiatedContentResult<string>)result).Content;
            var taskParsingActionResult = await controller.GetTask(new Models.Api.GetTagsParserTaskModel
            {
                TrackingCode = trackingCode
            });
            List<TagNameCountProjection> parsingResult;
            try
            {
                parsingResult = ((OkNegotiatedContentResult<List<TagNameCountProjection>>)taskParsingActionResult).Content;
                Assert.IsNotNull(parsingResult);
            }
            catch
            {
                Assert.IsInstanceOfType(taskParsingActionResult, typeof(OkNegotiatedContentResult<string>));
            }
        }
    }
}
