using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPICore.BLL.Interfaces;
using WebAPICore.Common.ViewModels;

namespace WeAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("Tasks/{id}")]
        public async Task<IEnumerable<TaskViewModel>> GetTasks(string id)
        {
            IEnumerable<TaskViewModel> tasks = await _taskService.GetTasks(id);

            return tasks;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTasks(int id)
        {
            ResponseViewModel result = await _taskService.Delete(id);

            if (result.IsSuccess)
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PostTask(TaskViewModel task)
        {
            ResponseViewModel result = await _taskService.CreateOrUpdateTask(task);

            if (result.IsSuccess)
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<TaskViewModel> GetAudioFile(int id)
        {
            TaskViewModel _taskModel = await _taskService.DownloadAudioFile(id);

            return _taskModel;
        }

        // GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
