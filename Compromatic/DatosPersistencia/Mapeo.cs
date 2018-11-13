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
        //Modelo_SQL_Server
        public Mapeo(string schema,string db= "Postgresql")
            : base("name="+db)
        {
           
           if (this.schema == "public")
           {
              schema = "dbo";
           }
            
        }

        //TABLAS DE LA BD A MAPEAR
        public DbSet<UEUsuario> user { get; set; }
        public DbSet<UEUIdioma> idiom { get; set; }
        public DbSet<UEUCategoria> categ {get;set;}
        public DbSet<UEUEmpresa> empre { get; set; }
        public DbSet<UEUSolici_Regist> sol_reg { get; set; }
        public DbSet<UEUMembresia> membresia{ get; set; }
        public DbSet<UEUTipoMembresia> type_membership { get; set; }
        public DbSet<UEUVenta> ventas { get; set; }
        public DbSet<UEUProducto>productos { get; set; }
        public DbSet<UEURango> rangos { get; set; }
        public DbSet<UEUQueja> quejas { get; set; }
        public DbSet<UEUMotiRepo> report { get; set; }
        public DbSet<UEUFotoProd> fotosPro { get; set; }
        public DbSet<UEUTag> tag { get; set; }
        public DbSet<TQuejas> inf_quejas { get; set; }
        public DbSet<UEUTopTen> top_ten { get; set; }
        public DbSet<UEUIdimControles> idiom_contro { get; set; } 
        public DbSet<UEUFormula_Idiom> form_idioma { get; set; }
        public DbSet<UEUArchivoSolic> archiv_Emp { get; set; }
        public DbSet<UEUReporte> reporte_T { get; set; }
        public DbSet<UEUBloqueo> bloqueos { get; set; }
        public DbSet<EAuditoria> auditoria { get; set; }
        public DbSet<UEUComentEmpres> comentEmpre { get; set; }
        public DbSet<UEUPublic_User> publicaciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.HasDefaultSchema(this.schema);

            base.OnModelCreating(builder);
        }
    }
}
