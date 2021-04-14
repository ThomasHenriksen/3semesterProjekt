using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArmysalgDataAccess.ModelLayer;

namespace ArmysalgService.Data
{
    public class ArmysalgServiceContext : DbContext
    {
        public ArmysalgServiceContext (DbContextOptions<ArmysalgServiceContext> options)
            : base(options)
        {
        }

        public DbSet<ArmysalgDataAccess.ModelLayer.Product> Product { get; set; }
    }
}
