using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FairFunds.Models;

namespace FairFunds.Data
{
    public class ApplicationDbContext : IdentityDbContext<CustomUser, IdentityRole, string>
    {
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Expenditure> Expenditures { get; set; }   

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }

    }
}
