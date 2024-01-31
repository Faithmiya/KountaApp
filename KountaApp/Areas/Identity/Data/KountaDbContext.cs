using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace KountaApp.Areas.Identity.Data;

public class KountaDbContext : IdentityDbContext<IdentityUser>
{
    public KountaDbContext(DbContextOptions<KountaDbContext> options)
        : base(options)
    {
    }

    // Adding the DbSets
    public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<Expense> Expenses { get; set; }
    public virtual DbSet<Income> Incomes { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Quota> Quotas { get; set; }
    public virtual DbSet<Salary> Salaries { get; set; }
    public virtual DbSet<Sale> Sales { get; set; }
    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);


        // Relationship configs

        
        builder.Entity<Employee>()
            .HasOne(x => x.ApplicationUsers)
            .WithMany(y => y.Employees)
            .HasForeignKey(u => u.UserId);

        builder.Entity<Client>()
            .HasOne(X => X.ApplicationUsers)
            .WithMany(y => y.Clients)
            .HasForeignKey(u => u.UserId);

        builder.Entity<Expense>()
            .HasOne(X => X.ApplicationUsers)
            .WithMany(y => y.Expenses)
            .HasForeignKey(u => u.UserId);

        builder.Entity<Income>()
            .HasOne(x => x.ApplicationUsers)
            .WithMany(y => y.Incomes)
            .HasForeignKey(u => u.UserId);

        builder.Entity<Product>()
            .HasOne(x => x.ApplicationUsers)
            .WithMany(y => y.Products)
            .HasForeignKey(u => u.UserId);

        builder.Entity<Vendor>()
            .HasOne(x => x.ApplicationUsers)
            .WithMany(y => y.Vendors)
            .HasForeignKey(u => u.UserId);

        builder.Entity<Salary>(entity =>
        {
            entity.HasOne(x => x.Employee).WithMany(u => u.Salaries).HasForeignKey(y => y.EmployeeId);

            entity.HasOne(x => x.ApplicationUsers).WithMany(u => u.Salaries).HasForeignKey(y => y.UserId);


        });

        builder.Entity<Quota>(entity =>
        {
            entity.HasOne(x => x.Vendor).WithMany(u => u.Quotas).HasForeignKey(y => y.VendorId);

            entity.HasOne(x => x.ApplicationUsers).WithMany(u => u.Quotas).HasForeignKey(y => y.UserId);

            entity.HasOne(x => x.Product).WithMany(u => u.Quotas).HasForeignKey(y => y.ProductId);

        });

        builder.Entity<Sale>(entity =>
        {
            entity.HasOne(x => x.Product).WithMany(u => u.Sales).HasForeignKey(y => y.ProductId);

            entity.HasOne(x => x.ApplicationUsers).WithMany(u => u.Sales).HasForeignKey(y => y.UserId);

            entity.HasOne(x => x.Client).WithMany(u => u.Sales).HasForeignKey(y => y.ClientId);

        });



    }


}
