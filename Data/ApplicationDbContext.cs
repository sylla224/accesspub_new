using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using accesspubnew.Models;

namespace accesspubnew.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<accesspubnew.Models.testmodel> testmodel { get; set; }
        public DbSet<accesspubnew.Models.rate> rate { get; set; }
    }
}
