namespace UtiliPersistencia
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modelo_SQL_Server : DbContext
    {
        public Modelo_SQL_Server()
            : base("name=Modelo_SQL_Server")
        {
        }

        public virtual DbSet<tbl_modification> tbl_modification { get; set; }
        public virtual DbSet<tbl_modified_field> tbl_modified_field { get; set; }
        public virtual DbSet<ArchivoSolicitud> ArchivoSolicitud { get; set; }
        public virtual DbSet<Bloqueos> Bloqueos { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Foto_producto> Foto_producto { get; set; }
        public virtual DbSet<Membresia> Membresia { get; set; }
        public virtual DbSet<MotivoQ> MotivoQ { get; set; }
        public virtual DbSet<MotivoR> MotivoR { get; set; }
        public virtual DbSet<Palabra_clave> Palabra_clave { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Quejas> Quejas { get; set; }
        public virtual DbSet<Rango> Rango { get; set; }
        public virtual DbSet<Reporte> Reporte { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Solicitud_registro> Solicitud_registro { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tipo_membresia> Tipo_membresia { get; set; }
        public virtual DbSet<Top_10> Top_10 { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }
        public virtual DbSet<controles> controles { get; set; }
        public virtual DbSet<formulario> formulario { get; set; }
        public virtual DbSet<idioma> idioma { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_modification>()
                .Property(e => e.schema_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_modification>()
                .Property(e => e.table_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_modification>()
                .Property(e => e.operation)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_modification>()
                .Property(e => e.table_pk)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_modification>()
                .Property(e => e.user_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_modification>()
                .Property(e => e.user_db)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_modification>()
                .Property(e => e.TRIAL367)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_modification>()
                .HasMany(e => e.tbl_modified_field)
                .WithOptional(e => e.tbl_modification)
                .HasForeignKey(e => e.table_id);

            modelBuilder.Entity<tbl_modified_field>()
                .Property(e => e.field_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_modified_field>()
                .Property(e => e.old_value)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_modified_field>()
                .Property(e => e.new_value)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_modified_field>()
                .Property(e => e.TRIAL367)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ArchivoSolicitud>()
                .Property(e => e.rutaArchivo)
                .IsUnicode(false);

            modelBuilder.Entity<ArchivoSolicitud>()
                .Property(e => e.nombreArchivo)
                .IsUnicode(false);

            modelBuilder.Entity<ArchivoSolicitud>()
                .Property(e => e.modified_by)
                .IsUnicode(false);

            modelBuilder.Entity<ArchivoSolicitud>()
                .Property(e => e.TRIAL720)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bloqueos>()
                .Property(e => e.modified_by)
                .IsUnicode(false);

            modelBuilder.Entity<Bloqueos>()
                .Property(e => e.TRIAL720)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .Property(e => e.nomCategoria)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .Property(e => e.modified_by)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .Property(e => e.TRIAL720)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Producto)
                .WithRequired(e => e.Categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.nomEmpresa)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.telEmpresa)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.correoEmpresa)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.dirEmpresa)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.nitEmpresa)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.nomArchivo)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.rutaArchivo)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.passEmpresa)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.modified_by)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.TRIAL720)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.Producto)
                .WithRequired(e => e.Empresa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.Rango)
                .WithRequired(e => e.Empresa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.Solicitud_registro)
                .WithRequired(e => e.Empresa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Foto_producto>()
                .Property(e => e.rutaArchivo)
                .IsUnicode(false);

            modelBuilder.Entity<Foto_producto>()
                .Property(e => e.nomArchivo)
                .IsUnicode(false);

            modelBuilder.Entity<Foto_producto>()
                .Property(e => e.modified_by)
                .IsUnicode(false);

            modelBuilder.Entity<Foto_producto>()
                .Property(e => e.TRIAL720)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Membresia>()
                .Property(e => e.modified_by)
                .IsUnicode(false);

            modelBuilder.Entity<Membresia>()
                .Property(e => e.TRIAL720)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MotivoQ>()
                .Property(e => e.nomQueja)
                .IsUnicode(false);

            modelBuilder.Entity<MotivoQ>()
                .Property(e => e.modified_by)
                .IsUnicode(false);

            modelBuilder.Entity<MotivoQ>()
                .Property(e => e.TRIAL723)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MotivoQ>()
                .HasMany(e => e.Quejas)
                .WithRequired(e => e.MotivoQ)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MotivoR>()
                .Property(e => e.desMotivo)
                .IsUnicode(false);

            modelBuilder.Entity<MotivoR>()
                .Property(e => e.modified_by)
                .IsUnicode(false);

            modelBuilder.Entity<MotivoR>()
                .Property(e => e.TRIAL723)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MotivoR>()
                .HasMany(e => e.Reporte)
                .WithRequired(e => e.MotivoR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Palabra_clave>()
                .Property(e => e.palabra)
                .IsUnicode(false);

            modelBuilder.Entity<Palabra_clave>()
                .Property(e => e.modified_by)
                .IsUnicode(false);

            modelBuilder.Entity<Palabra_clave>()
                .Property(e => e.TRIAL723)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.nomProducto)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.desProducto)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.modified_by)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.TRIAL723)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.Foto_producto)
                .WithRequired(e => e.Producto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.Palabra_clave)
                .WithRequired(e => e.Producto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.Reporte)
                .WithRequired(e => e.Producto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.Top_10)
                .WithRequired(e => e.Producto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.Venta)
                .WithRequired(e => e.Producto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quejas>()
                .Property(e => e.desQueja)
                .IsUnicode(false);

            modelBuilder.Entity<Quejas>()
                .Property(e => e.modified_by)
                .IsUnicode(false);

            modelBuilder.Entity<Quejas>()
                .Property(e => e.TRIAL723)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Rango>()
                .Property(e => e.comentarios)
                .IsUnicode(false);

            modelBuilder.Entity<Rango>()
                .Property(e => e.modified_by)
                .IsUnicode(false);

            modelBuilder.Entity<Rango>()
                .Property(e => e.TRIAL723)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Rango>()
                .HasMany(e => e.Venta)
                .WithOptional(e => e.Rango)
                .HasForeignKey(e => e.calEmp);

            modelBuilder.Entity<Reporte>()
                .Property(e => e.modified_by)
                .IsUnicode(false);

            modelBuilder.Entity<Reporte>()
                .Property(e => e.TRIAL723)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.nomRol)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.TRIAL723)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.Empresa)
                .WithRequired(e => e.Rol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Rol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Solicitud_registro>()
                .Property(e => e.modified_by)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud_registro>()
                .Property(e => e.TRIAL723)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_membresia>()
                .Property(e => e.nomMembresia)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_membresia>()
                .Property(e => e.modified_by)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_membresia>()
                .Property(e => e.TRIAL723)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_membresia>()
                .HasMany(e => e.Membresia)
                .WithRequired(e => e.Tipo_membresia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Top_10>()
                .Property(e => e.modified_by)
                .IsUnicode(false);

            modelBuilder.Entity<Top_10>()
                .Property(e => e.TRIAL726)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nomUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.apeUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.telUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.correoUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.passUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.ccUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.dirUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.rutaArchivo)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nomArchivo)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.modified_by)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.TRIAL726)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Rango)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Reporte)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Top_10)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Venta)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Venta>()
                .Property(e => e.modified_by)
                .IsUnicode(false);

            modelBuilder.Entity<Venta>()
                .Property(e => e.TRIAL726)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<controles>()
                .Property(e => e.nom_control)
                .IsUnicode(false);

            modelBuilder.Entity<controles>()
                .Property(e => e.texto)
                .IsUnicode(false);

            modelBuilder.Entity<controles>()
                .Property(e => e.TRIAL605)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<formulario>()
                .Property(e => e.nombre_form)
                .IsUnicode(false);

            modelBuilder.Entity<formulario>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<formulario>()
                .Property(e => e.TRIAL605)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<formulario>()
                .HasMany(e => e.controles)
                .WithRequired(e => e.formulario)
                .HasForeignKey(e => e.form_id);

            modelBuilder.Entity<idioma>()
                .Property(e => e.nombre_idioma)
                .IsUnicode(false);

            modelBuilder.Entity<idioma>()
                .Property(e => e.terminacion)
                .IsUnicode(false);

            modelBuilder.Entity<idioma>()
                .Property(e => e.TRIAL605)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<idioma>()
                .HasMany(e => e.controles)
                .WithRequired(e => e.idioma)
                .HasForeignKey(e => e.idioma_id);
        }
    }
}
