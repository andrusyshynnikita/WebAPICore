using System.Collections.Generic;
using System.Linq;
using WebAPICore.Common.DBModels;
using WebAPICore.DAL.Interfaces;

namespace WebAPICore.DAL.Repositories
{
    public class TaskRepository : BaseRepository<TaskDB>, ITaskRepository
    {

        public TaskRepository(WebAPICoreContext webAPICoreContext) : base(webAPICoreContext)
        {
        }

        public IEnumerable<TaskDB> GetAllUserTasks(string userId)
        {
            IEnumerable<TaskDB> userTasks = DbSet.Where(x => x.User_Id == userId);

            return userTasks;
        }
    }
}
