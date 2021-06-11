using Microsoft.EntityFrameworkCore;
using NEEIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEEIT.Data
{
    /// <summary>
    /// Representa a BD dos Eventos do NEEIT
    /// </summary>
    
    public class NEEITBD : DbContext
    {
        public NEEITBD(DbContextOptions<NEEITBD>options):base(options) { }
       
        /// <summary>
        /// Método para assistir a criação da BD que representa o modelo
        /// </summary>
        /// <param name="modelBuilder">Opção de configuração da criação do modelo</param>
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // importa todo o comportamento deste método definido na class DbContext
            base.OnModelCreating(modelBuilder);

        }

        //********************************
        //Especificação das tabelas da BD
        //********************************
        public DbSet<Membros> Membros {get; set;}
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<Recursos> Recursos { get; set; }
        public DbSet<Detalhes> Detalhes { get; set; }
        //********************************
    }
}
