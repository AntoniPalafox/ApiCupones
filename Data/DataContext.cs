using ApiConEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiConEFCore.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Cupon> Cupones {get; set;}
    }
}