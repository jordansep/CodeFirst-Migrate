ste es un proyecto de consola en .NET que demuestra el uso de Entity Framework Core con el enfoque Code-First para interactuar con una base de datos MySQL. La aplicación está configurada utilizando inyección de dependencias y gestiona un modelo de datos simple orientado a un sistema académico con Alumnos, Materias y Aulas.

✨ Características
Enfoque Code-First: Las tablas de la base de datos se generan y gestionan a partir de las clases de C# (los modelos).

Inyección de Dependencias: Se utiliza Microsoft.Extensions.DependencyInjection para configurar y gestionar el DbContext, siguiendo las mejores prácticas de .NET.

Configuración centralizada: La cadena de conexión a la base de datos se lee desde un archivo appsettings.json, separando la configuración del código.

Relación Muchos a Muchos: Demuestra cómo configurar una relación de muchos a muchos entre las entidades Alumno y Materia usando Fluent API.

Migraciones Automáticas: El programa está configurado para aplicar automáticamente las migraciones pendientes al iniciarse (context.Database.Migrate()).

🛠️ Tecnologías Utilizadas
.NET 9

Entity Framework Core 9

Pomelo.EntityFrameworkCore.MySql: Proveedor de base de datos para conectar Entity Framework Core con MySQL.

Microsoft.Extensions.DependencyInjection: Para la configuración de la inyección de dependencias.

Microsoft.Extensions.Configuration.Json: Para leer el archivo appsettings.json.

🚀 Puesta en Marcha
Para ejecutar este proyecto en tu máquina local, seguí estos pasos.

Prerrequisitos
SDK de .NET 9: Descargar aquí.

Servidor MySQL: Podés tener una instancia local o usar un contenedor de Docker.

Herramientas de EF Core: Asegurate de tenerlas instaladas globalmente o localmente en el proyecto.

Bash

dotnet tool install --global dotnet-ef
Configuración
Cloná el repositorio.

Configurá la cadena de conexión: Abrí el archivo appsettings.json y modificá la sección DefaultConnection con los datos de tu servidor MySQL.

JSON

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=testcodefirst;User=tu_usuario;Password=tu_contraseña;"
  }
}
Ejecución
Abrí una terminal en el directorio raíz del proyecto (CodeFirst).

Ejecutá la aplicación con el siguiente comando:

Bash

dotnet run
La primera vez que se ejecute, creará la base de datos testcodefirst (si no existe) y aplicará todas las migraciones para crear las tablas. Luego, ejecutará la lógica definida en el método Main.

🔄 Gestión de Migraciones
Las migraciones de Entity Framework son una forma de mantener el esquema de tu base de datos sincronizado con los modelos de tu aplicación a lo largo del tiempo.

Crear una Nueva Migración
Cuando realices un cambio en tus clases de modelo (por ejemplo, agregar una propiedad a la clase Alumno), necesitás generar una nueva migración que contenga las instrucciones para aplicar ese cambio en la base de datos.

Abrí una terminal en el directorio del proyecto (CodeFirst).

Ejecutá el siguiente comando, reemplazando NombreDeLaMigracion por un nombre descriptivo del cambio (ej: AddFechaNacimientoToAlumno).

Bash

dotnet ef migrations add NombreDeLaMigracion
Esto creará un nuevo archivo en la carpeta Migrations.

Aplicar o Revertir Migraciones
Para aplicar los cambios a la base de datos, podés hacerlo de dos maneras:

Automáticamente al ejecutar la aplicación: El método Main ya incluye la línea context.Database.Migrate();, que aplicará cualquier migración pendiente.

Manualmente desde la terminal:

Bash

dotnet ef database update
Para revertir a una migración anterior, usá el nombre de la última migración buena que querés mantener:

Bash

dotnet ef database update <NombreDeLaMigracionAnterior>
📝 Modelo de Datos
El proyecto define las siguientes entidades:

Alumno: Representa a un estudiante con propiedades como Nombre, Apellido y Email.

Materia: Representa una asignatura con Descripcion y Nivel.

Aula: Representa un salón de clases.

Cursado: Representa el horario de una materia en un aula específica.
