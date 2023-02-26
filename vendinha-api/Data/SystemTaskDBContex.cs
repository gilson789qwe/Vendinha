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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new DebtMap());
        base.OnModelCreating(modelBuilder);
    }

}