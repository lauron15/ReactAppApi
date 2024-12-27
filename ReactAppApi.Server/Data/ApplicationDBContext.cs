using Microsoft.EntityFrameworkCore;
using ReactAppApi.Server.Models;

namespace ReactAppApi.Server.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)

        {



        }


        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
