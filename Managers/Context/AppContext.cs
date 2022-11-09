using Managers.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Managers.Context
{
    public class AppContext: DbContext
    {
        public AppContext(DbContextOptions<AppContext> options): base(options) {}
        public DbSet<ManagersDB> managers { set; get; }
    }
}
