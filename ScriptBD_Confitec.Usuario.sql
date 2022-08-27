CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[Sobrenome] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[DataNascimento] [datetime] NOT NULL,
	[EscolaridadeId] [int] NOT NULL,
	[HistoricoEscolarId] [int] NOT NULL
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE PROCEDURE [dbo].[PROC_INCLUIR_USUARIO]
@Nome nvarchar(100),
@Sobrenome nvarchar(100),
@Email nvarchar(100),
@DataNascimento datetime,
@EscolaridadeId int,
@HistoricoEscolarId int
AS
BEGIN   
INSERT INTO [dbo].[Usuarios]
           (Nome,Sobrenome,Email,DataNascimento,EscolaridadeId,HistoricoEscolarId)
     VALUES
           (@Nome,@Sobrenome,@Email,@DataNascimento,@EscolaridadeId,@HistoricoEscolarId)
END

go
CREATE PROCEDURE [dbo].[PROC_EDITAR_USUARIO]
@Id INT,
@Nome nvarchar(100),
@Sobrenome nvarchar(100),
@Email nvarchar(100),
@DataNascimento datetime,
@EscolaridadeId int,
@HistoricoEscolarId int
AS
BEGIN   
  UPDATE [dbo].[Usuarios]
   SET Nome = @Nome, Sobrenome = @Sobrenome, Email = @Email, DataNascimento = @DataNascimento, EscolaridadeId = @EscolaridadeId, HistoricoEscolarId = @HistoricoEscolarId
 WHERE Id = @Id
END
go

CREATE PROCEDURE [dbo].[PROC_BUSCAR_USUARIO]

AS
BEGIN   
  SELECT *
  FROM [dbo].[Usuarios]
END
go

CREATE PROCEDURE [dbo].[PROC_EXCLUIR_USUARIO]
@Id INT
AS
BEGIN   
 DELETE FROM [dbo].[Usuarios] WHERE Id = @Id
END
go

CREATE TABLE [dbo].[Escolaridade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](100) NOT NULL	
 CONSTRAINT [PK_Escolaridade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[Escolaridade]
           ([Descricao])
     VALUES
           ('Infantil')
GO


INSERT INTO [dbo].[Escolaridade]
           ([Descricao])
     VALUES
           ('Fundamental')
GO

INSERT INTO [dbo].[Escolaridade]
           ([Descricao])
     VALUES
           ('Médio')
GO

INSERT INTO [dbo].[Escolaridade]
           ([Descricao])
     VALUES
           ('Superior')
GO


