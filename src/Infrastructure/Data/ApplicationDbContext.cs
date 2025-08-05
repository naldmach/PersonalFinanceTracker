using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSet properties represent database tables
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(entity => e.Id);
                entity.Property(entity => e.Amount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500);

                // Define relationships
                entity.HasOne(entity => e.User) // Each transaction belongs to one user
                .WithMany(u => u.Transactions) // Each user can have many transactions
                .HasForeignKey(e => e.UserId) // Foreign key column
                .OnDelete(DeleteBehavior.Cascade); // Delete transactions when user is deleted

                entity.HasOne(e => e.Category)
                .WithMany(c => c.Transactions)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // Don't allow deleting categories with transactions 
            });

            // Seed initial data
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Food & Dining", Type = CategoryType.Expense },
                new Category { Id = 2, Name = "Transportation", Type = CategoryType.Expense },
                new Category { Id = 3, Name = "Salary", Type = CategoryType.Income },
                new Category { Id = 4, Name = "Investment", Type = CategoryType.Income }
            );
        }
     }
}