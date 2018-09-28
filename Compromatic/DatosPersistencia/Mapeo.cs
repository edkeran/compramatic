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

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.HasDefaultSchema(this.schema);

            base.OnModelCreating(builder);
        }
    }
}
