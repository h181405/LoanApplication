using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LoanApplication.Models;

public partial class LoanDbContext : DbContext
{
    public LoanDbContext()
    {
    }

    public LoanDbContext(DbContextOptions<LoanDbContext> options)
        : base(options)
    {
    }

    public DbSet<Loan> Loans { get; set; }
    public DbSet<HouseLoan> HouseLoans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Loan>().UseTpcMappingStrategy();
    }
}
