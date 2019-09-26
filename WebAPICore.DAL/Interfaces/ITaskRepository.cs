using System.Collections.Generic;
using WebAPICore.Common.DBModels;

namespace WebAPICore.DAL.Interfaces
{
    public interface ITaskRepository : IBaseRepository<DBTask>
    {
        IEnumerable<DBTask> GetAllUserTasks(string userId);
    }
}
