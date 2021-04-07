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

        [HttpGet("{id}")]
        public async Task<ResponseRequestViewModel<IEnumerable<TaskViewModel>>> GetTasks(string id)
        {
            var result = new ResponseRequestViewModel<IEnumerable<TaskViewModel>>();

            IEnumerable<TaskViewModel> tasks = await _taskService.GetTasks(id);
            result.ResponseData = tasks;
            result.IsSuccess = true;

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTasks(int id)
        {
            ResponseViewModel result = await _taskService.Delete(id);

            if (result.IsSuccess)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> PostTask(TaskViewModel task)
        {
            ResponseViewModel result = await _taskService.CreateOrUpdateTask(task);

            if (result.IsSuccess)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("audio_file/{id}")]
        public async Task<TaskViewModel> GetAudioFile(int id)
        {
            TaskViewModel _taskModel = await _taskService.DownloadAudioFile(id);

            return _taskModel;
        }
    }
}
