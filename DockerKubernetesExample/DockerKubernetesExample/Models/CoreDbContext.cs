using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerKubernetesExample.Models
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> students { get; set; }
    }
    //PM> add-migration MyMigration
    //PM> update-database
}
