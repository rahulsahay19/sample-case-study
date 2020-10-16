using Medical.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Medical.API.Data
{
    public class MedicineDbContext : DbContext
    {
        public MedicineDbContext(DbContextOptions<MedicineDbContext> options) : base(options)
        {
        }

        public DbSet<Medicine> Medicines { get; set; }
        
        //TODO:- In case, if any relationship is required between user and medicine 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
    
}
