using Api.Controllers;
using Api.Data.Map;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class SystemTaskDBContex : DbContext
{

    public SystemTaskDBContex(DbContextOptions<SystemTaskDBContex> options)
        : base(options)
    {
        
    }
    
    public  DbSet<UserModel> Users { get; set; }
    
    public DbSet<DebtModel> Debts { get; set; }
    
    public  DbSet<CustomerDebtModel> CustomerDebts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new DebtMap());
        modelBuilder.ApplyConfiguration(new CustomerDebtMap());
        base.OnModelCreating(modelBuilder);
    }

}