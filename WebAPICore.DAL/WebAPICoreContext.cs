using Microsoft.EntityFrameworkCore;
using WebAPICore.Common.DBModels;
using WebAPICore.Common.ViewModels;

namespace WebAPICore.DAL
{
    public class WebAPICoreContext : DbContext
    {
        public WebAPICoreContext(DbContextOptions<WebAPICoreContext> options)
            : base(options)
        { }

        public DbSet<DBTask> Tasks { get; set; }
    }
}
