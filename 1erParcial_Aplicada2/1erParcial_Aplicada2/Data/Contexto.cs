using _1erParcial_Aplicada2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1erParcial_Aplicada2.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Inscripciones> Inscripciones { get; set; }
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Asignaturas> Asignaturas { get; set; }
        public DbSet<Pagos> Pagos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Database/SistemaDb");
        }
    }
}
