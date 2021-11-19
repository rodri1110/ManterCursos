using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ManterCursos.Models;

namespace ManterCursos.Data
{
    public class ManterCursosContext : DbContext
    {
        public ManterCursosContext (DbContextOptions<ManterCursosContext> options)
            : base(options)
        {
        }

        public DbSet<ManterCursos.Models.Curso> Cursos { get; set; }
        public DbSet<ManterCursos.Models.Categoria> Categorias { get; set; }
        public DbSet<ManterCursos.Models.Log> Logs { get; set; }
    }
}
