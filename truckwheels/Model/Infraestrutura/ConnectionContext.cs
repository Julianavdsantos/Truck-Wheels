using Microsoft.EntityFrameworkCore;

   

namespace truckwheels.Model.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        //mapea a table employee
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseNpgsql(
              "Server=localhost;" +
              "Port=5432;Database=postgres;" +
              "User Id=postgres;" +
              "Password=Juju1704;");

    }
}
