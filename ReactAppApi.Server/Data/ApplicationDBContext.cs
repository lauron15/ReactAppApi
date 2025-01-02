using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReactAppApi.Server.Models;

namespace ReactAppApi.Server.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>  //DbContext, we used it before starting the identity process
    {

        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)

        {



        }


        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Portfolio> Portfolios { get; set; }


        protected override void OnModelCreating(ModelBuilder builder) //token and verification
        {
            base.OnModelCreating(builder);

            builder.Entity<Portfolio>()
                .HasOne(u => u.AppUser)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(p => p.AppUserId);
           
            builder.Entity<Portfolio>()
                .HasOne(u => u.Stock)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(p => p.StockId);



            List<IdentityRole> roles = new List<IdentityRole>
            {
            new IdentityRole
            {
                 Id = "Admin",
                 Name= "Admin",
                 NormalizedName="ADMIN"

            },



              new IdentityRole
            {
                Id = "User", // Adicione o Id aqui
                Name = "User",
                NormalizedName = "USER"


            },

            };
            builder.Entity<IdentityRole>().HasData(roles);
        }



    }
}




