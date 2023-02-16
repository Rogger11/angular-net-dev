using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Back.Models;

namespace Back.Data
{
    public class BackContext : DbContext
    {
        public BackContext (DbContextOptions<BackContext> options)
            : base(options)
        {
        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
