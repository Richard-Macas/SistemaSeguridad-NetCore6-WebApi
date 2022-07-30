/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2016                    */
/* Created on:     27/7/2022 11:07:43                           */
/*==============================================================*/


/*==============================================================*/
/* Table: Empresa                                               */
/*==============================================================*/
create table Empresa (
   Id                   int              identity,
   IdPortal             int                  null,
   Empresa              varchar(50)          not null,
   CorreoAdministrador  varchar(100)         null,
   TelefonoAdministrador varchar(15)          null,
   Dominio              varchar(200)         not null,
   EstaHabilitado       bit                  null,
   constraint PK_EMPRESA primary key (Id)
)
go

/*==============================================================*/
/* Index: PORTAL_EMPRESA_FK                                     */
/*==============================================================*/




create nonclustered index PORTAL_EMPRESA_FK on Empresa (IdPortal ASC)
go

/*==============================================================*/
/* Table: EmpresaSistema                                        */
/*==============================================================*/
create table EmpresaSistema (
   Id                   int              identity,
   IdSistema            int                  null,
   IdEmpresa            int                  null,
   EstaHabilitado       bit                  null,
   constraint PK_EMPRESASISTEMA primary key (Id)
)
go

/*==============================================================*/
/* Index: SISTEMA_EMPRESASISTEMA_FK                             */
/*==============================================================*/




create nonclustered index SISTEMA_EMPRESASISTEMA_FK on EmpresaSistema (IdSistema ASC)
go

/*==============================================================*/
/* Index: EMPRESA_EMPRESASISTEMA_FK                             */
/*==============================================================*/




create nonclustered index EMPRESA_EMPRESASISTEMA_FK on EmpresaSistema (IdEmpresa ASC)
go

/*==============================================================*/
/* Table: Perfil                                                */
/*==============================================================*/
create table Perfil (
   Id                   int              identity,
   Nombre               varchar(100)         not null,
   constraint PK_PERFIL primary key (Id)
)
go

/*==============================================================*/
/* Table: PerfilSistema                                         */
/*==============================================================*/
create table PerfilSistema (
   Id                   int              identity,
   IdSistema            int                  null,
   IdPerfil             int                  null,
   EstaHabilitado       bit                  null,
   constraint PK_PERFILSISTEMA primary key (Id)
)
go

/*==============================================================*/
/* Index: SISTEMA_PERFILSISTEMA_FK                              */
/*==============================================================*/




create nonclustered index SISTEMA_PERFILSISTEMA_FK on PerfilSistema (IdSistema ASC)
go

/*==============================================================*/
/* Index: PERFIL_PERFILSISTEMA_FK                               */
/*==============================================================*/




create nonclustered index PERFIL_PERFILSISTEMA_FK on PerfilSistema (IdPerfil ASC)
go

/*==============================================================*/
/* Table: Portal                                                */
/*==============================================================*/
create table Portal (
   Id                   int              identity,
   Nombre               varchar(50)          not null,
   Responsable          varchar(200)         not null,
   Dominio              varchar(200)         not null,
   EstaHabilitado       bit                  null,
   constraint PK_PORTAL primary key (Id)
)
go

/*==============================================================*/
/* Table: Recurso                                               */
/*==============================================================*/
create table Recurso (
   Id                   int              identity,
   Nivel                int                  not null,
   Descripcion          varchar(50)          not null,
   IdPadre              int                  null,
   URLPath              varchar(MAX)         not null,
   Icono                varchar(50)          null,
   EstaHabilitado       bit                  null,
   constraint PK_RECURSO primary key (Id)
)
go

/*==============================================================*/
/* Table: RecursoPerfil                                         */
/*==============================================================*/
create table RecursoPerfil (
   Id                   int              identity,
   IdRecurso            int                  null,
   IdPerfil             int                  null,
   IdRol                int                  null,
   EstaHabilitado       bit                  null,
   constraint PK_RECURSOPERFIL primary key (Id)
)
go

/*==============================================================*/
/* Index: RECURSO_RECURSOPERFIL_FK                              */
/*==============================================================*/




create nonclustered index RECURSO_RECURSOPERFIL_FK on RecursoPerfil (IdRecurso ASC)
go

/*==============================================================*/
/* Index: PERFIL_RECURSOPERFIL_FK                               */
/*==============================================================*/




create nonclustered index PERFIL_RECURSOPERFIL_FK on RecursoPerfil (IdPerfil ASC)
go

/*==============================================================*/
/* Index: ROL_RECURSOPERFIL_FK                                  */
/*==============================================================*/




create nonclustered index ROL_RECURSOPERFIL_FK on RecursoPerfil (IdRol ASC)
go

/*==============================================================*/
/* Table: Rol                                                   */
/*==============================================================*/
create table Rol (
   Id                   int              identity,
   "Create"             bit                  null,
   "Read"               bit                  null,
   "Update"             bit                  null,
   "Delete"             bit                  null,
   constraint PK_ROL primary key (Id)
)
go

/*==============================================================*/
/* Table: Sistema                                               */
/*==============================================================*/
create table Sistema (
   Id                   int              identity,
   Nombre               varchar(20)          not null,
   Dominio              varchar(255)         not null,
   Subdominio           varchar(255)         null,
   EstaHabilitado       bit                  null,
   constraint PK_SISTEMA primary key (Id)
)
go

/*==============================================================*/
/* Table: SistemaRecurso                                        */
/*==============================================================*/
create table SistemaRecurso (
   Id                   int              identity,
   IdSistema            int                  null,
   IdRecurso            int                  null,
   constraint PK_SISTEMARECURSO primary key (Id)
)
go

/*==============================================================*/
/* Index: SISTEMA_SISTEMARECURSO_FK                             */
/*==============================================================*/




create nonclustered index SISTEMA_SISTEMARECURSO_FK on SistemaRecurso (IdSistema ASC)
go

/*==============================================================*/
/* Index: RECURSO_SISTEMARECURSO_FK                             */
/*==============================================================*/




create nonclustered index RECURSO_SISTEMARECURSO_FK on SistemaRecurso (IdRecurso ASC)
go

/*==============================================================*/
/* Table: Usuario                                               */
/*==============================================================*/
create table Usuario (
   Id                   int              identity,
   Username             varchar(50)          not null,
   Password             varchar(MAX)         not null,
   constraint PK_USUARIO primary key (Id)
)
go

/*==============================================================*/
/* Table: UsuarioPerfil                                         */
/*==============================================================*/
create table UsuarioPerfil (
   Id                   int              identity,
   IdUsuario            int                  null,
   IdPerfil             int                  null,
   constraint PK_USUARIOPERFIL primary key (Id)
)
go

/*==============================================================*/
/* Index: PERFIL_USUARIOPERFIL_FK                               */
/*==============================================================*/




create nonclustered index PERFIL_USUARIOPERFIL_FK on UsuarioPerfil (IdPerfil ASC)
go

/*==============================================================*/
/* Index: USUARIOPERFIL_USUARIO_FK                              */
/*==============================================================*/




create nonclustered index USUARIOPERFIL_USUARIO_FK on UsuarioPerfil (IdUsuario ASC)
go

alter table Empresa
   add constraint FK_EMPRESA_PORTAL_EM_PORTAL foreign key (IdPortal)
      references Portal (Id)
go

alter table EmpresaSistema
   add constraint FK_EMPRESAS_EMPRESA_E_EMPRESA foreign key (IdEmpresa)
      references Empresa (Id)
go

alter table EmpresaSistema
   add constraint FK_EMPRESAS_SISTEMA_E_SISTEMA foreign key (IdSistema)
      references Sistema (Id)
go

alter table PerfilSistema
   add constraint FK_PERFILSI_PERFIL_PE_PERFIL foreign key (IdPerfil)
      references Perfil (Id)
go

alter table PerfilSistema
   add constraint FK_PERFILSI_SISTEMA_P_SISTEMA foreign key (IdSistema)
      references Sistema (Id)
go

alter table RecursoPerfil
   add constraint FK_RECURSOP_PERFIL_RE_PERFIL foreign key (IdPerfil)
      references Perfil (Id)
go

alter table RecursoPerfil
   add constraint FK_RECURSOP_RECURSO_R_RECURSO foreign key (IdRecurso)
      references Recurso (Id)
go

alter table RecursoPerfil
   add constraint FK_RECURSOP_ROL_RECUR_ROL foreign key (IdRol)
      references Rol (Id)
go

alter table SistemaRecurso
   add constraint FK_SISTEMAR_RECURSO_S_RECURSO foreign key (IdRecurso)
      references Recurso (Id)
go

alter table SistemaRecurso
   add constraint FK_SISTEMAR_SISTEMA_S_SISTEMA foreign key (IdSistema)
      references Sistema (Id)
go

alter table UsuarioPerfil
   add constraint FK_USUARIOP_PERFIL_US_PERFIL foreign key (IdPerfil)
      references Perfil (Id)
go

alter table UsuarioPerfil
   add constraint FK_USUARIOP_USUARIOPE_USUARIO foreign key (IdUsuario)
      references Usuario (Id)
go

