using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FinanzApp.Models
{
    public partial class finanzappsdbContext : DbContext
    {
        public finanzappsdbContext()
        {
        }

        public finanzappsdbContext(DbContextOptions<finanzappsdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GestionEgreso> GestionEgresos { get; set; }
        public virtual DbSet<GestionIngreso> GestionIngresos { get; set; }
        public virtual DbSet<ProcesoCorte> ProcesoCortes { get; set; }
        public virtual DbSet<RegistroTransaccione> RegistroTransacciones { get; set; }
        public virtual DbSet<RenglonesEgreso> RenglonesEgresos { get; set; }
        public virtual DbSet<TiposEgreso> TiposEgresos { get; set; }
        public virtual DbSet<TiposIngreso> TiposIngresos { get; set; }
        public virtual DbSet<TiposPago> TiposPagos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root123456;database=financialproject;Convert Zero Datetime=True", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<GestionEgreso>(entity =>
            {
                entity.ToTable("gestion_egresos");

                entity.HasIndex(e => e.IdReglonEgreso, "fk_reglonegreso_idx");

                entity.HasIndex(e => e.IdTipoEgreso, "fk_tipoegreso_idx");

                entity.HasIndex(e => e.IdTipoPago, "fk_tipopago_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.IdReglonEgreso).HasColumnName("idReglon_Egreso");

                entity.Property(e => e.IdTipoEgreso).HasColumnName("idTipo_Egreso");

                entity.Property(e => e.IdTipoPago).HasColumnName("idTipo_Pago");

                entity.HasOne(d => d.IdReglonEgresoNavigation)
                    .WithMany(p => p.GestionEgresos)
                    .HasForeignKey(d => d.IdReglonEgreso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reglonegreso");

                entity.HasOne(d => d.IdTipoEgresoNavigation)
                    .WithMany(p => p.GestionEgresos)
                    .HasForeignKey(d => d.IdTipoEgreso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tipoegreso");

                entity.HasOne(d => d.IdTipoPagoNavigation)
                    .WithMany(p => p.GestionEgresos)
                    .HasForeignKey(d => d.IdTipoPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tipopago");
            });

            modelBuilder.Entity<GestionIngreso>(entity =>
            {
                entity.ToTable("gestion_ingresos");

                entity.HasIndex(e => e.IdTipoIngreso, "fk_tipoingreso_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Fuente)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.IdTipoIngreso).HasColumnName("idTipo_Ingreso");

                entity.HasOne(d => d.IdTipoIngresoNavigation)
                    .WithMany(p => p.GestionIngresos)
                    .HasForeignKey(d => d.IdTipoIngreso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tipoingreso");
            });

            modelBuilder.Entity<ProcesoCorte>(entity =>
            {
                entity.ToTable("proceso_corte");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BalanceCorte)
                    .HasPrecision(8, 2)
                    .HasColumnName("Balance_Corte");

                entity.Property(e => e.BalanceInicial)
                    .HasPrecision(8, 2)
                    .HasColumnName("Balance_Inicial");

                entity.Property(e => e.FechaCorte)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Corte");

                entity.Property(e => e.TotalEgresos)
                    .HasPrecision(8, 2)
                    .HasColumnName("Total_Egresos");

                entity.Property(e => e.TotalIngresos)
                    .HasPrecision(8, 2)
                    .HasColumnName("Total_Ingresos");
            });

            modelBuilder.Entity<RegistroTransaccione>(entity =>
            {
                entity.ToTable("registro_transacciones");

                entity.HasIndex(e => e.IdTipoPago, "fk_tipopagos_idx");

                entity.HasIndex(e => e.IdUsuario, "fk_usuario_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comentario)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Registro");

                entity.Property(e => e.FechaTransaccion)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Transaccion");

                entity.Property(e => e.IdTipoPago).HasColumnName("idTipo_Pago");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.MontoTransaccion)
                    .HasPrecision(8, 2)
                    .HasColumnName("Monto_Transaccion");

                entity.Property(e => e.NoTdc).HasColumnName("No_TDC");

                entity.Property(e => e.TipoTransaccion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("Tipo_Transaccion")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdTipoPagoNavigation)
                    .WithMany(p => p.RegistroTransacciones)
                    .HasForeignKey(d => d.IdTipoPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tipopagos");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.RegistroTransacciones)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuario");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("FechaInicio");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("FechaFin");
            });

            modelBuilder.Entity<RenglonesEgreso>(entity =>
            {
                entity.ToTable("renglones_egresos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<TiposEgreso>(entity =>
            {
                entity.ToTable("tipos_egresos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion).HasMaxLength(255);
            });

            modelBuilder.Entity<TiposIngreso>(entity =>
            {
                entity.ToTable("tipos_ingresos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<TiposPago>(entity =>
            {
                entity.ToTable("tipos_pagos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaCorte)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Corte");

                entity.Property(e => e.Identificacion)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LimiteEgresos)
                    .HasPrecision(8, 2)
                    .HasColumnName("Limite_Egresos");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.TipoPersona)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("Tipo_Persona")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
