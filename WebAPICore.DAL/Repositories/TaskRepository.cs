using System.Collections.Generic;
using System.Linq;
using WebAPICore.Common.DBModels;
using WebAPICore.DAL.Interfaces;

namespace WebAPICore.DAL.Repositories
{
    public class TaskRepository : BaseRepository<DBTask>, ITaskRepository
    {

        public TaskRepository(WebAPICoreContext webAPICoreContext) : base(webAPICoreContext)
        {
        }

        public IEnumerable<DBTask> GetAllUserTasks(string userId)
        {
            IEnumerable<DBTask> userTasks = GetAll().Where(x => x.User_Id == userId);

            return userTasks;
        }
    }
}
