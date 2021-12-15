using DAL.DO.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public partial class SolutionDbContext : DbContext
    {
        public SolutionDbContext()
        {
        }
        public SolutionDbContext(DbContextOptions<SolutionDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }

        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<Puesto> Puesto { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Cedula);

                entity.Property(e => e.Cedula)
                    .HasColumnName("cedula")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellido1)
                    .IsRequired()
                    .HasColumnName("apellido1")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido2)
                    .HasColumnName("apellido2")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Idprovincia).HasColumnName("IDProvincia");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdprovinciaNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.Idprovincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Provincia");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado);

                entity.Property(e => e.IdEmpleado)
                    .HasColumnName("ID_Empleado")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellido1)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido2)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("Fecha_Ingreso")
                    .HasColumnType("date");

                entity.Property(e => e.IdPuesto).HasColumnName("ID_Puesto");

                entity.Property(e => e.IdRol).HasColumnName("ID_Rol");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPuestoNavigation)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.IdPuesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleado_Puesto");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleado_Rol");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura);

                entity.Property(e => e.IdFactura)
                    .HasColumnName("ID_Factura")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdCliente).HasColumnName("ID_Cliente");

                entity.Property(e => e.IdEmpleado).HasColumnName("ID_Empleado");

                entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Factura)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Factura_Cliente");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Factura)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Factura_Empleado");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Factura)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Factura_Producto");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.Property(e => e.IdProducto)
                    .HasColumnName("ID_Producto")
                    .ValueGeneratedNever();

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("Fecha_Ingreso")
                    .HasColumnType("date");

                entity.Property(e => e.IdProveedor).HasColumnName("ID_Proveedor");

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasColumnName("Nombre_Producto")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Proveedor");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.IdProveedor);

                entity.Property(e => e.IdProveedor)
                    .HasColumnName("ID_ Proveedor")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Ubicacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasKey(e => e.IdProvincia);

                entity.Property(e => e.IdProvincia)
                    .HasColumnName("ID_Provincia")
                    .ValueGeneratedNever();

                entity.Property(e => e.NombreProvincia)
                    .IsRequired()
                    .HasColumnName("Nombre_Provincia")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Puesto>(entity =>
            {
                entity.HasKey(e => e.IdPuesto);

                entity.Property(e => e.IdPuesto)
                    .HasColumnName("ID_Puesto")
                    .ValueGeneratedNever();

                entity.Property(e => e.Manager)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.Property(e => e.IdRol)
                    .HasColumnName("ID_Rol")
                    .ValueGeneratedNever();

                entity.Property(e => e.NombreRol)
                    .HasColumnName("Nombre_Rol")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
