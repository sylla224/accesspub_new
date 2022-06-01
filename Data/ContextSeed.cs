using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace accesspubnew.Data
{
    public class ContextSeed
    {
        public IConfiguration Configuration { get;  }
        public ContextSeed(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //string Role1 = Configuration.GetValue<string>("PowerUser:Username");
        //string Role2 = Configuration.GetValue<string>("PowerUser:Email");
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
                
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Enum.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enum.Roles.Customer.ToString()));
            
        }
    }
}
