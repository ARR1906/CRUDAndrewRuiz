//Creacion de clase ApplicationDbContext para iniciar sesion en el servidor de la BD y ejecutar querys

using CRUDARR.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDARR.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<BSideCard> BSideCard { get; set; } 
    }
}
