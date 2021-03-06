// <auto-generated />
using System;
using FinanzApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinanzApp.Migrations
{
    [DbContext(typeof(finanzappsdbContext))]
    [Migration("20210819012930_uersss")]
    partial class uersss
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("FinanzApp.Models.GestionEgreso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("IdReglonEgreso")
                        .HasColumnType("int")
                        .HasColumnName("idReglon_Egreso");

                    b.Property<int>("IdTipoEgreso")
                        .HasColumnType("int")
                        .HasColumnName("idTipo_Egreso");

                    b.Property<int>("IdTipoPago")
                        .HasColumnType("int")
                        .HasColumnName("idTipo_Pago");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "IdReglonEgreso" }, "fk_reglonegreso_idx");

                    b.HasIndex(new[] { "IdTipoEgreso" }, "fk_tipoegreso_idx");

                    b.HasIndex(new[] { "IdTipoPago" }, "fk_tipopago_idx");

                    b.ToTable("gestion_egresos");
                });

            modelBuilder.Entity("FinanzApp.Models.GestionIngreso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Fuente")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("IdTipoIngreso")
                        .HasColumnType("int")
                        .HasColumnName("idTipo_Ingreso");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "IdTipoIngreso" }, "fk_tipoingreso_idx");

                    b.ToTable("gestion_ingresos");
                });

            modelBuilder.Entity("FinanzApp.Models.ProcesoCorte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<decimal>("BalanceCorte")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("Balance_Corte");

                    b.Property<decimal>("BalanceInicial")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("Balance_Inicial");

                    b.Property<DateTime>("FechaCorte")
                        .HasColumnType("date")
                        .HasColumnName("Fecha_Corte");

                    b.Property<int>("Mes")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalEgresos")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("Total_Egresos");

                    b.Property<decimal>("TotalIngresos")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("Total_Ingresos");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("proceso_corte");
                });

            modelBuilder.Entity("FinanzApp.Models.RegistroTransaccione", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("date")
                        .HasColumnName("FechaFin");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("date")
                        .HasColumnName("FechaInicio");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("date")
                        .HasColumnName("Fecha_Registro");

                    b.Property<DateTime>("FechaTransaccion")
                        .HasColumnType("date")
                        .HasColumnName("Fecha_Transaccion");

                    b.Property<int>("IdTipoPago")
                        .HasColumnType("int")
                        .HasColumnName("idTipo_Pago");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("idUsuario");

                    b.Property<decimal>("MontoTransaccion")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("Monto_Transaccion");

                    b.Property<int?>("NoTdc")
                        .HasColumnType("int")
                        .HasColumnName("No_TDC");

                    b.Property<string>("TipoTransaccion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("char(255)")
                        .HasColumnName("Tipo_Transaccion")
                        .IsFixedLength(true);

                    b.HasKey("Id");

                    b.HasIndex(new[] { "IdTipoPago" }, "fk_tipopagos_idx");

                    b.HasIndex(new[] { "IdUsuario" }, "fk_usuario_idx");

                    b.ToTable("registro_transacciones");
                });

            modelBuilder.Entity("FinanzApp.Models.RenglonesEgreso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("renglones_egresos");
                });

            modelBuilder.Entity("FinanzApp.Models.TiposEgreso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("tipos_egresos");
                });

            modelBuilder.Entity("FinanzApp.Models.TiposIngreso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("tipos_ingresos");
                });

            modelBuilder.Entity("FinanzApp.Models.TiposPago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("tipos_pagos");
                });

            modelBuilder.Entity("FinanzApp.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaCorte")
                        .HasColumnType("date")
                        .HasColumnName("Fecha_Corte");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("LimiteEgresos")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("Limite_Egresos");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("TipoPersona")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("char(255)")
                        .HasColumnName("Tipo_Persona")
                        .IsFixedLength(true);

                    b.Property<decimal>("balance")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("FinanzApp.Models.GestionEgreso", b =>
                {
                    b.HasOne("FinanzApp.Models.RenglonesEgreso", "IdReglonEgresoNavigation")
                        .WithMany("GestionEgresos")
                        .HasForeignKey("IdReglonEgreso")
                        .HasConstraintName("fk_reglonegreso")
                        .IsRequired();

                    b.HasOne("FinanzApp.Models.TiposEgreso", "IdTipoEgresoNavigation")
                        .WithMany("GestionEgresos")
                        .HasForeignKey("IdTipoEgreso")
                        .HasConstraintName("fk_tipoegreso")
                        .IsRequired();

                    b.HasOne("FinanzApp.Models.TiposPago", "IdTipoPagoNavigation")
                        .WithMany("GestionEgresos")
                        .HasForeignKey("IdTipoPago")
                        .HasConstraintName("fk_tipopago")
                        .IsRequired();

                    b.Navigation("IdReglonEgresoNavigation");

                    b.Navigation("IdTipoEgresoNavigation");

                    b.Navigation("IdTipoPagoNavigation");
                });

            modelBuilder.Entity("FinanzApp.Models.GestionIngreso", b =>
                {
                    b.HasOne("FinanzApp.Models.TiposIngreso", "IdTipoIngresoNavigation")
                        .WithMany("GestionIngresos")
                        .HasForeignKey("IdTipoIngreso")
                        .HasConstraintName("fk_tipoingreso")
                        .IsRequired();

                    b.Navigation("IdTipoIngresoNavigation");
                });

            modelBuilder.Entity("FinanzApp.Models.RegistroTransaccione", b =>
                {
                    b.HasOne("FinanzApp.Models.TiposPago", "IdTipoPagoNavigation")
                        .WithMany("RegistroTransacciones")
                        .HasForeignKey("IdTipoPago")
                        .HasConstraintName("fk_tipopagos")
                        .IsRequired();

                    b.HasOne("FinanzApp.Models.Usuario", "IdUsuarioNavigation")
                        .WithMany("RegistroTransacciones")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("fk_usuario")
                        .IsRequired();

                    b.Navigation("IdTipoPagoNavigation");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("FinanzApp.Models.RenglonesEgreso", b =>
                {
                    b.Navigation("GestionEgresos");
                });

            modelBuilder.Entity("FinanzApp.Models.TiposEgreso", b =>
                {
                    b.Navigation("GestionEgresos");
                });

            modelBuilder.Entity("FinanzApp.Models.TiposIngreso", b =>
                {
                    b.Navigation("GestionIngresos");
                });

            modelBuilder.Entity("FinanzApp.Models.TiposPago", b =>
                {
                    b.Navigation("GestionEgresos");

                    b.Navigation("RegistroTransacciones");
                });

            modelBuilder.Entity("FinanzApp.Models.Usuario", b =>
                {
                    b.Navigation("RegistroTransacciones");
                });
#pragma warning restore 612, 618
        }
    }
}
