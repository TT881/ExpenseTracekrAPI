﻿using ExepnseTrackerAPI.Models.Domains;
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

        public virtual DbSet<TblUIColumnConfig> TblUIColumnConfig { get; set; } = null!;   

        public virtual DbSet<TblUITableConfig> TblUITableConfig { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Explicitly configure CategoryID as the primary key for TblExpenseCategory
            modelBuilder.Entity<TblExpenseCategory>()
                .HasKey(c => c.CategoryID);

            modelBuilder.Entity<TblUser>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<TblExpenseLists>()
                .HasKey(e => e.ExpenseID);

            modelBuilder.Entity<TblUIColumnConfig>()
                .HasKey(e => e.ColumnID);

            modelBuilder.Entity<TblUITableConfig>()
                .HasKey(e => e.UITableID);
        }

    }
}
