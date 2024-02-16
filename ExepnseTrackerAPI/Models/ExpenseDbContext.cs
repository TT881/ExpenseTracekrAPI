using ExepnseTrackerAPI.Models.Domains;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace ExepnseTrackerAPI.Models
{
    public partial class ExpenseDbContext : DbContext
    {
        public ExpenseDbContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<TblUser> TblUser { get; set; } = null!; 

        public virtual DbSet<TblExpenseCategory> TblExpenseCategory { get;set; } = null!;

        public virtual DbSet<TblExpenseLists> TblExpenseLists { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Explicitly configure CategoryID as the primary key for TblExpenseCategory
            modelBuilder.Entity<TblExpenseCategory>()
                .HasKey(c => c.CategoryID);

            // Similarly, ensure other entities have their primary keys defined
            modelBuilder.Entity<TblUser>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<TblExpenseLists>()
                .HasKey(e => e.ExpenseID);

            // Add any other Fluent API configurations as needed
        }

    }
}
