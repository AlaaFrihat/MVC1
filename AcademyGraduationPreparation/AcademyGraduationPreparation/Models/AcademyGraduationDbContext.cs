using Microsoft.EntityFrameworkCore;

namespace AcademyGraduationPreparation.Models
{
    public class AcademyGraduationDbContext : DbContext
    {
        public AcademyGraduationDbContext(DbContextOptions<AcademyGraduationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Offer> Offers { get; set; }
    }
}
