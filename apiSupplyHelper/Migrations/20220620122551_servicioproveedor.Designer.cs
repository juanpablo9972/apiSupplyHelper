﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apiSupplyHelper.Helpers;

#nullable disable

namespace apiSupplyHelper.Migrations
{
    [DbContext(typeof(SqliteDataContext))]
    [Migration("20220620122551_servicioproveedor")]
    partial class servicioproveedor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("apiSupplyHelper.Categorias.Modelos.CategoriaProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CategoriaProductos");
                });

            modelBuilder.Entity("apiSupplyHelper.Categorias.Modelos.CategoriaServicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CategoriaServicios");
                });

            modelBuilder.Entity("apiSupplyHelper.ContactoExterno.Modelos.Agente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProveedorId");

                    b.ToTable("Agentes");
                });

            modelBuilder.Entity("apiSupplyHelper.Data.Models.Auth.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("apiSupplyHelper.DetalleProveedor.Modelos.ProductoProveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Presentacion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("cantidadMinima")
                        .HasColumnType("REAL");

                    b.Property<double>("pesoUnitario")
                        .HasColumnType("REAL");

                    b.Property<double>("precioUnitario")
                        .HasColumnType("REAL");

                    b.Property<string>("unidadMedida")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.HasIndex("ProveedorId");

                    b.ToTable("ProductoProveedores");
                });

            modelBuilder.Entity("apiSupplyHelper.DetalleProveedor.Modelos.ServicioProveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ServiciosssId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("precio")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ProveedorId");

                    b.HasIndex("ServiciosssId");

                    b.ToTable("ServicioProveedores");
                });

            modelBuilder.Entity("apiSupplyHelper.Productos.Modelos.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriaProductoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaProductoId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("apiSupplyHelper.Proveedores.Modelos.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CodigoPostal")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Proveedoress");
                });

            modelBuilder.Entity("apiSupplyHelper.Servicios.Modelos.Serviciosss", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriaServicioId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaServicioId");

                    b.ToTable("Servicess");
                });

            modelBuilder.Entity("apiSupplyHelper.ContactoExterno.Modelos.Agente", b =>
                {
                    b.HasOne("apiSupplyHelper.Proveedores.Modelos.Proveedor", "Proveedor")
                        .WithMany("Agentes")
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("apiSupplyHelper.DetalleProveedor.Modelos.ProductoProveedor", b =>
                {
                    b.HasOne("apiSupplyHelper.Productos.Modelos.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apiSupplyHelper.Proveedores.Modelos.Proveedor", "Proveedor")
                        .WithMany()
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("apiSupplyHelper.DetalleProveedor.Modelos.ServicioProveedor", b =>
                {
                    b.HasOne("apiSupplyHelper.Proveedores.Modelos.Proveedor", "Proveedor")
                        .WithMany()
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apiSupplyHelper.Servicios.Modelos.Serviciosss", "Serviciosss")
                        .WithMany()
                        .HasForeignKey("ServiciosssId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");

                    b.Navigation("Serviciosss");
                });

            modelBuilder.Entity("apiSupplyHelper.Productos.Modelos.Producto", b =>
                {
                    b.HasOne("apiSupplyHelper.Categorias.Modelos.CategoriaProducto", "CategoriaProducto")
                        .WithMany("Productos")
                        .HasForeignKey("CategoriaProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaProducto");
                });

            modelBuilder.Entity("apiSupplyHelper.Servicios.Modelos.Serviciosss", b =>
                {
                    b.HasOne("apiSupplyHelper.Categorias.Modelos.CategoriaServicio", "CategoriaServicio")
                        .WithMany("Serviciosss")
                        .HasForeignKey("CategoriaServicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaServicio");
                });

            modelBuilder.Entity("apiSupplyHelper.Categorias.Modelos.CategoriaProducto", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("apiSupplyHelper.Categorias.Modelos.CategoriaServicio", b =>
                {
                    b.Navigation("Serviciosss");
                });

            modelBuilder.Entity("apiSupplyHelper.Proveedores.Modelos.Proveedor", b =>
                {
                    b.Navigation("Agentes");
                });
#pragma warning restore 612, 618
        }
    }
}
