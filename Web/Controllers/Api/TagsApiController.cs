
using BLL.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TinyMessenger;
using Web.Models;
using Web.Models.Api;
using Web.Models.Domain;

namespace Web.Controllers.Api
{
    [RoutePrefix("api/tags")]
    public class TagsApiController : ApiController
    {
        private readonly ITagsCounterTaskService _tagsCounterService;
        public TagsApiController(ITagsCounterTaskService tagsCounterTaskService)
        {
            _tagsCounterService = tagsCounterTaskService;
        }
        [HttpPost]
        [Route("create")]
        public async Task<IHttpActionResult> CreateTask([FromBody]CreateTagsParserTaskModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Provide correct url");
            }
            var trackingCode = await _tagsCounterService.AddAsync(model.Url);
            return Created("", trackingCode);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IHttpActionResult> GetTask([FromUri]GetTagsParserTaskModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var task = await _tagsCounterService.GetCompletionStateAsync(model.TrackingCode);
            if (task == null)
            {
                return NotFound();
            }
            if (task.Status == TagsCounterTaskStatus.Started)
            {
                return Ok("Task is starded");
            }
            else if (task.Status == TagsCounterTaskStatus.Failed)
            {
                return Ok("Task is failed");
            }
            return Ok(task.Result);
        }
    }
}