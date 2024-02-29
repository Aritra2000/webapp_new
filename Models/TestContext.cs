using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Db_employee_salary.Models;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblEmployee> TblEmployees { get; set; }

    public virtual DbSet<TblEmployeeSalary> TblEmployeeSalaries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-FIV98DPG\\SQLEXPRESS;Database=Test;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblEmployee>(entity =>
        {
            entity.HasKey(e => e.EId);

            entity.ToTable("Tbl_employee");

            entity.Property(e => e.EId).HasColumnName("E_id");
            entity.Property(e => e.Ph)
                .HasMaxLength(10)
                .HasColumnName("ph");
        });

        modelBuilder.Entity<TblEmployeeSalary>(entity =>
        {
            entity.ToTable("Tbl_Employee_salary");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
