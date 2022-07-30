using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SistemaSeguridad.Entities.Entities;

namespace SistemaSeguridad.Repository.Persistencias
{
    public partial class SistemaSeguridadDBContext : DbContext
    {
        public SistemaSeguridadDBContext()
        {
        }

        public SistemaSeguridadDBContext(DbContextOptions<SistemaSeguridadDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empresa> Empresas { get; set; } = null!;
        public virtual DbSet<EmpresaSistema> EmpresaSistemas { get; set; } = null!;
        public virtual DbSet<Perfil> Perfils { get; set; } = null!;
        public virtual DbSet<PerfilSistema> PerfilSistemas { get; set; } = null!;
        public virtual DbSet<Portal> Portals { get; set; } = null!;
        public virtual DbSet<Recurso> Recursos { get; set; } = null!;
        public virtual DbSet<RecursoPerfil> RecursoPerfils { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<Sistema> Sistemas { get; set; } = null!;
        public virtual DbSet<SistemaRecurso> SistemaRecursos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<UsuarioPerfil> UsuarioPerfils { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=RICHARD\\SQLEXPRESS;Initial Catalog=SistemaSeguridadDB;User ID=sa;Password=sa.1;Application Name=SistemaSeguridad");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("Empresa");

                entity.HasIndex(e => e.IdPortal, "PORTAL_EMPRESA_FK");

                entity.Property(e => e.CorreoAdministrador)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dominio)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Empresa1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Empresa");

                entity.Property(e => e.TelefonoAdministrador)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPortalNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.IdPortal)
                    .HasConstraintName("FK_EMPRESA_PORTAL_EM_PORTAL");
            });

            modelBuilder.Entity<EmpresaSistema>(entity =>
            {
                entity.ToTable("EmpresaSistema");

                entity.HasIndex(e => e.IdEmpresa, "EMPRESA_EMPRESASISTEMA_FK");

                entity.HasIndex(e => e.IdSistema, "SISTEMA_EMPRESASISTEMA_FK");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.EmpresaSistemas)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK_EMPRESAS_EMPRESA_E_EMPRESA");

                entity.HasOne(d => d.IdSistemaNavigation)
                    .WithMany(p => p.EmpresaSistemas)
                    .HasForeignKey(d => d.IdSistema)
                    .HasConstraintName("FK_EMPRESAS_SISTEMA_E_SISTEMA");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.ToTable("Perfil");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PerfilSistema>(entity =>
            {
                entity.ToTable("PerfilSistema");

                entity.HasIndex(e => e.IdPerfil, "PERFIL_PERFILSISTEMA_FK");

                entity.HasIndex(e => e.IdSistema, "SISTEMA_PERFILSISTEMA_FK");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.PerfilSistemas)
                    .HasForeignKey(d => d.IdPerfil)
                    .HasConstraintName("FK_PERFILSI_PERFIL_PE_PERFIL");

                entity.HasOne(d => d.IdSistemaNavigation)
                    .WithMany(p => p.PerfilSistemas)
                    .HasForeignKey(d => d.IdSistema)
                    .HasConstraintName("FK_PERFILSI_SISTEMA_P_SISTEMA");
            });

            modelBuilder.Entity<Portal>(entity =>
            {
                entity.ToTable("Portal");

                entity.Property(e => e.Dominio)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Responsable)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Recurso>(entity =>
            {
                entity.ToTable("Recurso");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Icono)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.URLPath).IsUnicode(false);
            });

            modelBuilder.Entity<RecursoPerfil>(entity =>
            {
                entity.ToTable("RecursoPerfil");

                entity.HasIndex(e => e.IdPerfil, "PERFIL_RECURSOPERFIL_FK");

                entity.HasIndex(e => e.IdRecurso, "RECURSO_RECURSOPERFIL_FK");

                entity.HasIndex(e => e.IdRol, "ROL_RECURSOPERFIL_FK");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.RecursoPerfils)
                    .HasForeignKey(d => d.IdPerfil)
                    .HasConstraintName("FK_RECURSOP_PERFIL_RE_PERFIL");

                entity.HasOne(d => d.IdRecursoNavigation)
                    .WithMany(p => p.RecursoPerfils)
                    .HasForeignKey(d => d.IdRecurso)
                    .HasConstraintName("FK_RECURSOP_RECURSO_R_RECURSO");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.RecursoPerfils)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK_RECURSOP_ROL_RECUR_ROL");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol");
            });

            modelBuilder.Entity<Sistema>(entity =>
            {
                entity.ToTable("Sistema");

                entity.Property(e => e.Dominio)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Subdominio)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SistemaRecurso>(entity =>
            {
                entity.ToTable("SistemaRecurso");

                entity.HasIndex(e => e.IdRecurso, "RECURSO_SISTEMARECURSO_FK");

                entity.HasIndex(e => e.IdSistema, "SISTEMA_SISTEMARECURSO_FK");

                entity.HasOne(d => d.IdRecursoNavigation)
                    .WithMany(p => p.SistemaRecursos)
                    .HasForeignKey(d => d.IdRecurso)
                    .HasConstraintName("FK_SISTEMAR_RECURSO_S_RECURSO");

                entity.HasOne(d => d.IdSistemaNavigation)
                    .WithMany(p => p.SistemaRecursos)
                    .HasForeignKey(d => d.IdSistema)
                    .HasConstraintName("FK_SISTEMAR_SISTEMA_S_SISTEMA");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsuarioPerfil>(entity =>
            {
                entity.ToTable("UsuarioPerfil");

                entity.HasIndex(e => e.IdPerfil, "PERFIL_USUARIOPERFIL_FK");

                entity.HasIndex(e => e.IdUsuario, "USUARIOPERFIL_USUARIO_FK");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.UsuarioPerfils)
                    .HasForeignKey(d => d.IdPerfil)
                    .HasConstraintName("FK_USUARIOP_PERFIL_US_PERFIL");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioPerfils)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_USUARIOP_USUARIOPE_USUARIO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
