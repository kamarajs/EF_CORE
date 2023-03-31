using EF.Models.CodeFirstApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;

namespace CodeFirstApp.Data;
public class EFCoreCodeDBContext : DbContext

{
    public EFCoreCodeDBContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Employees> Employee { get; set; }
    // public DbSet<Product> Products {get; set;}

}