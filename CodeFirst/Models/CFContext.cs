using System;
using System.Collections.Generic;
using CodeFirst.Class;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Models;

public partial class CFContext : DbContext
{
    public DbSet<Alumno> Alumnos { get; set; }
    public DbSet<Materia> Materias { get; set; }
    public DbSet<Cursado> Cursados { get; set; }
    public DbSet<Aula> Aulas { get; set; }
    public CFContext()
    {
    }

    public CFContext(DbContextOptions<CFContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
