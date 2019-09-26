using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.BLL.Helpers.Interfaces;
using WebAPICore.BLL.Interfaces;
using WebAPICore.Common.DBModels;
using WebAPICore.Common.ViewModels;
using WebAPICore.DAL.Interfaces;

namespace WebAPICore.BLL.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly IStorageHelper _storageHelper;
        public TaskService(ITaskRepository taskRepository, IMapper mapper, IStorageHelper storageHelper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _storageHelper = storageHelper;
        }

        public async Task<IEnumerable<TaskViewModel>> GetTasks(string id)
        {
            IEnumerable<TaskViewModel> tasksviewModel = null;

            IEnumerable<DBTask> tasksModel = _taskRepository.GetAllUserTasks(id);
            try
            {
                var test = tasksModel.ToList();
                tasksviewModel = _mapper.Map<IEnumerable<DBTask>, IEnumerable<TaskViewModel>>(tasksModel);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return tasksviewModel;
        }

        public async Task<ResponseViewModel> CreateOrUpdateTask(TaskViewModel taskViewModel)
        {
            var responseViewModel = new ResponseViewModel();

            DBTask task = _mapper.Map<TaskViewModel, DBTask>(taskViewModel);

            if (task.Id == 0)
            {
                await _taskRepository.Create(task);
            }
            else
            {
                await _taskRepository.Update(task);
            }
            responseViewModel.IsSuccess = true;

            if (!string.IsNullOrEmpty(taskViewModel.AudioFileName) && taskViewModel.AudioFileContent != null)
            {
                responseViewModel.IsSuccess = await _storageHelper.WriteByteToFileAsync(taskViewModel.AudioFileName, taskViewModel.AudioFileContent);
            }

            return responseViewModel;
        }

        public async Task<ResponseViewModel> Delete(int id)
        {
            var responseViewModel = new ResponseViewModel();

            DBTask task = await _taskRepository.GetItem(id);
            await _taskRepository.Delete(id);
            responseViewModel.IsSuccess = true;

            if (!string.IsNullOrEmpty(task?.AudioFileName))
            {
                responseViewModel.IsSuccess = await _storageHelper.DeleteFile(task.AudioFileName);
            }

            return responseViewModel;
        }

        public async Task<TaskViewModel> DownloadAudioFile(int id)
        {
            DBTask taskModel = await _taskRepository.GetItem(id);
            var taskViewModel = _mapper.Map<DBTask, TaskViewModel>(taskModel);

            if (!string.IsNullOrEmpty(taskModel.AudioFileName))
            {
                taskViewModel.AudioFileContent = await _storageHelper.ReadFileAsync(taskViewModel.AudioFileName);
            }

            return taskViewModel;
        }

    }
}
