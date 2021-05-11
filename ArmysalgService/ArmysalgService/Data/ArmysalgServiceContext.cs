using Microsoft.EntityFrameworkCore;

namespace ArmysalgService.Data
{
    public class ArmysalgServiceContext : DbContext
    {
        public ArmysalgServiceContext(DbContextOptions<ArmysalgServiceContext> options)
            : base(options)
        {
        }

        public DbSet<ArmysalgDataAccess.Model.Product> Product { get; set; }
    }
}
