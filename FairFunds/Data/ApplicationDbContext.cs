using FairFunds.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FairFunds.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Depense> Depenses { get; set; }   

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }

    }
}
