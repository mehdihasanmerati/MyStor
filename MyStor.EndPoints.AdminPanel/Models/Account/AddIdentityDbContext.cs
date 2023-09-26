using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace MyStor.EndPoints.AdminPanel.Models.Account
{
    public class AppIdentityDbContext : IdentityDbContext<Microsoft.AspNetCore.Identity.IdentityUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options) { }
    }

}
