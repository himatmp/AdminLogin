using Microsoft.EntityFrameworkCore;

namespace Backend.Entities
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> dbContextOptions): base(dbContextOptions) 
        { }  
        public DbSet<Admin> Admin { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=WINDOWS-BVQNF6J;database=AdminDB;trusted_connection=true;encrypt=false");
        }
    }
}
