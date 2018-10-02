using System;
using System.Collections.Generic;
using System.Data.Entity;
using Utilitarios;

namespace DatosPersistencia
{
    public class Mapeo : DbContext
    {
        static Mapeo()
        {
            Database.SetInitializer<Mapeo>(null);
        }
        private readonly string schema;

        public Mapeo(string schema)
            : base("name=Postgresql")
        {
            this.schema = schema;
        }

        //TABLAS DE LA BD A MAPEAR
        public DbSet<UEUsuario> user { get; set; }
        public DbSet<UEUIdioma> idiom { get; set; }
        public DbSet<UEUCategoria> categ {get;set;}
        public DbSet<UEUEmpresa> empre { get; set; }
        public DbSet<UEUSolici_Regist> sol_reg { get; set; }
        public DbSet<UEUMembresia> membresia{ get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.HasDefaultSchema(this.schema);

            base.OnModelCreating(builder);
        }
    }
}
