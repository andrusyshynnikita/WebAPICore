using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPICore.Common.ViewModels;

namespace WebAPICore.BLL.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskViewModel>> GetTasks(string id);
        Task<ResponseViewModel> CreateOrUpdateTask(TaskViewModel taskViewModel);
        Task<ResponseViewModel> Delete(int id);
        Task<TaskViewModel> DownloadAudioFile(int id);
    }
}
