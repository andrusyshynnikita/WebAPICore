using System.Collections.Generic;
using WebAPICore.Common.DBModels;

namespace WebAPICore.DAL.Interfaces
{
    public interface ITaskRepository : IBaseRepository<TaskDB>
    {
        IEnumerable<TaskDB> GetAllUserTasks(string userId);
    }
}
