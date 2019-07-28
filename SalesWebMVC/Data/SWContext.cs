using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Models
{
    public class SWContext : DbContext
    {
        public SWContext (DbContextOptions<SWContext> options)
            : base(options)
        {
        }

        public DbSet<SalesWebMVC.Models.Department> Department { get; set; }
    }
}
