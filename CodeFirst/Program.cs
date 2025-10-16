using CodeFirst.Class;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Iniciando aplicación...");
        var services = ConfigureDependencies();
        var scope = services.CreateScope();
        CFContext context = scope.ServiceProvider.GetService<CFContext>();
        context.Database.Migrate();
        Alumno a = new Alumno
        {
            Nombre = "Jorge",
            Apellido = "Borges",
            Email = "borges@example.com"
        };
        a.Materias.Add(context.Materias.Find(1));
        // var eliminarcontenido = context.Alumnos.Find(1);
        context.SaveChanges();
    }

    private static IServiceProvider ConfigureDependencies()
    {
        IConfiguration config = SetConfigurationRoot();
        var connectionString = config.GetConnectionString("DefaultConnection");
        Console.WriteLine($"Connection string obtenido: {connectionString ?? "NULL"}");
        
        IServiceCollection services = new ServiceCollection();
        services.AddDbContext<CFContext>(options =>
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("No se pudo obtener la cadena de conexión del archivo appsettings.json");
            }
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }, ServiceLifetime.Scoped);
        return services.BuildServiceProvider(); 
    }

    private static IConfiguration SetConfigurationRoot()
    {
        string directory = Directory.GetCurrentDirectory();
        Console.WriteLine($"Directorio actual: {directory}");
        Console.WriteLine($"Buscando archivo appsettings.json en: {Path.Combine(directory, "appsettings.json")}");
        
        var builder = new ConfigurationBuilder()
            .SetBasePath(directory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        
        try
        {
            var configuration = builder.Build();
            return configuration;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al cargar la configuración: {ex.Message}");
            throw;
        }
    }
}