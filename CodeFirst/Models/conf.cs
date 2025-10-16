using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class CFContextFactory : IDesignTimeDbContextFactory<CFContext>
    {
        public CFContext CreateDbContext(string[] args)
        {
            // 1. Obtener la configuración de appsettings.json
            // Este código es similar al que tienes en tu Program.cs
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // 2. Crear las opciones para el DbContext
            var optionsBuilder = new DbContextOptionsBuilder<CFContext>();

            // 3. Obtener la cadena de conexión y configurar el proveedor de MySQL
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            // 4. Devolver una nueva instancia del DbContext con las opciones configuradas
            return new CFContext(optionsBuilder.Options);
        }
    }
}
