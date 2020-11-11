using System;
using System.Collections.Generic;
using System.Text;
using CourtDatabase2.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CourtDatabase2.ViewModels;

namespace CourtDatabase2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private const string connectionString = @"Server=.;Database=CourtDatabase2;Integrated Security=true;";

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<LawCase>().HasOne(x => x.Obligation).WithOne(x => x.LawCase).OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<CaseAction> CaseActions { get; set; }

        public DbSet<CommonInterestRate> CommonInterestRates { get; set; }

        public DbSet<Court> Courts { get; set; }

        public DbSet<CourtCase> CourtCases { get; set; }

        public DbSet<CourtTown> CourtTowns { get; set; }

        public DbSet<Debitor> Debitors { get; set; }

        public DbSet<Executor> Executors { get; set; }

        public DbSet<ExecutorCase> ExecutorCases { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<HeatEstate> HeatEstates { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<LawCase> LawCases { get; set; }

        public DbSet<LegalAction> LegalActions { get; set; }
        //public DbSet<Obligation> Obligations { get; set; }

        public DbSet<Payment> Payments { get; set; }
        //public DbSet<CourtDatabase2.ViewModels.LegalActionViewModel> LegalActionViewModel { get; set; }
        //public DbSet<CourtDatabase2.ViewModels.CourtCasesViewModel> CourtCasesViewModel { get; set; }

    }
}
