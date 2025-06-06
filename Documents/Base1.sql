USE [FacturacionMoonflow]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banco](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[DescriptionCode] [varchar](200) NULL,
 CONSTRAINT [PK_Banco] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cargo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Cargo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cbu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdBanco] [int] NOT NULL,
	[NumeroCbu] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Cbu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RazonSocial] [varchar](150) NOT NULL,
	[Cuit] [varchar](50) NOT NULL,
	[Descripcion] [varchar](200) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfiguracionEnvio](
	[Id] [tinyint] NOT NULL,
	[Subject] [varchar](500) NOT NULL,
	[Body] [ntext] NOT NULL,
 CONSTRAINT [PK_ConfiguracionEnvio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdEmpresa] [int] NOT NULL,
	[IdCargo] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Email] [varchar](150) NOT NULL,
	[Telefono] [varchar](50) NULL,
	[IsDisabled] [bit] NULL,
 CONSTRAINT [PK_Contacto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[RazonSocial] [varchar](150) NOT NULL,
	[Cuit] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Empresa_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpresaFactura](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DescriptionCode] [varchar](150) NULL,
	[Nombre] [varchar](150) NOT NULL,
	[Cuit] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Envio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdGrupoEnvio] [int] NOT NULL,
	[IdFactura] [int] NOT NULL,
	[IdMoonflow] [int] NOT NULL,
	[IdMoneda] [int] NOT NULL,
	[Adjunto1] [ntext] NULL,
	[Adjunto2] [ntext] NULL,
	[UsuarioLogueado] [varchar](50) NULL,
	[Comentarios] [nvarchar](4000) NULL,
 CONSTRAINT [PK_Envio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoEnvio](
	[Id] [tinyint] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EstadoEnvio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NroFactura] [varchar](150) NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Vencimiento] [smalldatetime] NOT NULL,
	[IdEmpresaFactura] [int] NOT NULL,
	[IdCbu] [int] NOT NULL,
	[Cuit] [varchar](150) NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[Periodo] [varchar](50) NULL,
	[TotalDescripcion] [varchar](200) NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GrupoEnvio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdEmpresa] [int] NOT NULL,
	[NombreGrupo] [varchar](200) NOT NULL,
 CONSTRAINT [PK_GrupoEnvio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GrupoEnvioContacto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdGrupoEnvio] [int] NOT NULL,
	[IdContacto] [int] NOT NULL,
	[IsCC] [bit] NULL,
	[IsCCO] [bit] NULL,
 CONSTRAINT [PK_GrupoEnvioContacto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorialEnvio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdEnvio] [int] NOT NULL,
	[IdEstadoEnvio] [tinyint] NOT NULL,
	[Fecha] [smalldatetime] NULL,
 CONSTRAINT [PK_HistorialEnvio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Moneda](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [char](3) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Moneda] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Moonflow](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdMonflow] [varchar](200) NOT NULL,
	[ClienteIdMonflow] [varchar](200) NOT NULL,
	[registerDate] [varchar](50) NOT NULL,
	[origin] [varchar](50) NOT NULL,
	[paymentCode] [varchar](50) NOT NULL,
	[currency] [varchar](50) NOT NULL,
	[amount] [decimal](18, 2) NOT NULL,
	[dueDate] [varchar](50) NOT NULL,
	[productName] [varchar](50) NULL,
	[balance] [decimal](18, 2) NOT NULL,
	[quota] [int] NOT NULL,
	[statusDescription] [varchar](50) NULL,
	[feesAndPenalties] [decimal](18, 2) NOT NULL,
	[attachment1] [varchar](50) NULL,
	[attachment2] [varchar](50) NULL,
	[issuedDate] [varchar](50) NULL,
	[description] [varchar](50) NULL,
	[discount] [decimal](18, 2) NULL,
	[externalOrderId] [varchar](50) NULL,
	[customVariables] [varchar](50) NULL,
	[JsonResult] [ntext] NULL,
 CONSTRAINT [PK_Moonflow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[EstadoEnvio] ([Id], [Descripcion]) VALUES (1, N'Enviado')
INSERT [dbo].[EstadoEnvio] ([Id], [Descripcion]) VALUES (2, N'ConError')
INSERT [dbo].[EstadoEnvio] ([Id], [Descripcion]) VALUES (3, N'ReEnviado')
GO
SET IDENTITY_INSERT [dbo].[Moneda] ON 

INSERT [dbo].[Moneda] ([Id], [Code], [Descripcion]) VALUES (1, N'ARS', N'Pesos Argentinos')
INSERT [dbo].[Moneda] ([Id], [Code], [Descripcion]) VALUES (2, N'USD', N'Dolares')
INSERT [dbo].[Moneda] ([Id], [Code], [Descripcion]) VALUES (4, N'PYG', N'Paraguayos')
SET IDENTITY_INSERT [dbo].[Moneda] OFF
GO
ALTER TABLE [dbo].[Contacto] ADD  CONSTRAINT [DF_Contacto_IsDisabled]  DEFAULT ((0)) FOR [IsDisabled]
GO
ALTER TABLE [dbo].[GrupoEnvioContacto] ADD  CONSTRAINT [DF_GrupoEnvioContacto_IsCC]  DEFAULT ((0)) FOR [IsCC]
GO
ALTER TABLE [dbo].[GrupoEnvioContacto] ADD  CONSTRAINT [DF_GrupoEnvioContacto_IsCCO]  DEFAULT ((0)) FOR [IsCCO]
GO
ALTER TABLE [dbo].[HistorialEnvio] ADD  CONSTRAINT [DF_HistorialEnvio_Fecha]  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[Cbu]  WITH CHECK ADD  CONSTRAINT [FK_Cbu_Banco] FOREIGN KEY([IdBanco])
REFERENCES [dbo].[Banco] ([Id])
GO
ALTER TABLE [dbo].[Cbu] CHECK CONSTRAINT [FK_Cbu_Banco]
GO
ALTER TABLE [dbo].[Contacto]  WITH CHECK ADD  CONSTRAINT [FK_Contacto_Cargo] FOREIGN KEY([IdCargo])
REFERENCES [dbo].[Cargo] ([Id])
GO
ALTER TABLE [dbo].[Contacto] CHECK CONSTRAINT [FK_Contacto_Cargo]
GO
ALTER TABLE [dbo].[Contacto]  WITH CHECK ADD  CONSTRAINT [FK_Contacto_Empresa] FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[Empresa] ([Id])
GO
ALTER TABLE [dbo].[Contacto] CHECK CONSTRAINT [FK_Contacto_Empresa]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_Cliente]
GO
ALTER TABLE [dbo].[Envio]  WITH CHECK ADD  CONSTRAINT [FK_Envio_Factura] FOREIGN KEY([IdFactura])
REFERENCES [dbo].[Factura] ([Id])
GO
ALTER TABLE [dbo].[Envio] CHECK CONSTRAINT [FK_Envio_Factura]
GO
ALTER TABLE [dbo].[Envio]  WITH CHECK ADD  CONSTRAINT [FK_Envio_GrupoEnvio] FOREIGN KEY([IdGrupoEnvio])
REFERENCES [dbo].[GrupoEnvio] ([Id])
GO
ALTER TABLE [dbo].[Envio] CHECK CONSTRAINT [FK_Envio_GrupoEnvio]
GO
ALTER TABLE [dbo].[Envio]  WITH CHECK ADD  CONSTRAINT [FK_Envio_Moneda] FOREIGN KEY([IdMoneda])
REFERENCES [dbo].[Moneda] ([Id])
GO
ALTER TABLE [dbo].[Envio] CHECK CONSTRAINT [FK_Envio_Moneda]
GO
ALTER TABLE [dbo].[Envio]  WITH CHECK ADD  CONSTRAINT [FK_Envio_Moonflow] FOREIGN KEY([IdMoonflow])
REFERENCES [dbo].[Moonflow] ([Id])
GO
ALTER TABLE [dbo].[Envio] CHECK CONSTRAINT [FK_Envio_Moonflow]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Cbu] FOREIGN KEY([IdCbu])
REFERENCES [dbo].[Cbu] ([Id])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Cbu]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_EmpresaFactura] FOREIGN KEY([IdEmpresaFactura])
REFERENCES [dbo].[EmpresaFactura] ([Id])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_EmpresaFactura]
GO
ALTER TABLE [dbo].[GrupoEnvio]  WITH CHECK ADD  CONSTRAINT [FK_GrupoEnvio_Empresa] FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[Empresa] ([Id])
GO
ALTER TABLE [dbo].[GrupoEnvio] CHECK CONSTRAINT [FK_GrupoEnvio_Empresa]
GO
ALTER TABLE [dbo].[GrupoEnvioContacto]  WITH CHECK ADD  CONSTRAINT [FK_GrupoEnvioContacto_Contacto] FOREIGN KEY([IdContacto])
REFERENCES [dbo].[Contacto] ([Id])
GO
ALTER TABLE [dbo].[GrupoEnvioContacto] CHECK CONSTRAINT [FK_GrupoEnvioContacto_Contacto]
GO
ALTER TABLE [dbo].[GrupoEnvioContacto]  WITH CHECK ADD  CONSTRAINT [FK_GrupoEnvioContacto_GrupoEnvio] FOREIGN KEY([IdGrupoEnvio])
REFERENCES [dbo].[GrupoEnvio] ([Id])
GO
ALTER TABLE [dbo].[GrupoEnvioContacto] CHECK CONSTRAINT [FK_GrupoEnvioContacto_GrupoEnvio]
GO
ALTER TABLE [dbo].[HistorialEnvio]  WITH CHECK ADD  CONSTRAINT [FK_HistorialEnvio_EstadoEnvio] FOREIGN KEY([IdEstadoEnvio])
REFERENCES [dbo].[EstadoEnvio] ([Id])
GO
ALTER TABLE [dbo].[HistorialEnvio] CHECK CONSTRAINT [FK_HistorialEnvio_EstadoEnvio]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[Factura_Find]
	@Empresa varchar(100)
AS
BEGIN
declare @MsgError varchar(100)

BEGIN TRY
SET NOCOUNT ON; --No necesitamos pedirle al motor que cuente los registos.
SET ANSI_NULLS ON; --Habilitamos que interprete los NULLS 
SET QUOTED_IDENTIFIER ON; --Habilitamos Interpretacion de Comillas y comillas dobles validas
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; --Necesitamos acceder a la info sin que este comiteada
SET ANSI_WARNINGS OFF; --no necesitamos que nos avice los warning, variables sin usar, etc...
SET Language Spanish --Seteamos la lengua independiente del server, asi aparece en espanol.

SELECT
f.[Fecha] ,
f.[NroFactura],
f.[Periodo] ,
f.[SubTotal],
f.[Total] ,
f.[TotalDescripcion],
e.Cuit as EmpresaCuit,
e.Nombre as Empresa,
c.NumeroCbu,
b.Nombre as Banco
FROM Factura f 
inner join Empresa e
	on f.IdEmpresa = e.Id
inner join Cbu c
	on c.Id = f.IdCbu
inner join Banco b
	on c.IdBanco = b.Id
WHERE 
( 
( e.[Nombre] like '%' + @Empresa + '%'  or @Empresa =  ''  )  
) 

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END

SET ANSI_NULLS ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Factura_Get]
@Id int

AS
BEGIN
declare @MsgError varchar(100)

BEGIN TRY
SET NOCOUNT ON; --No necesitamos pedirle al motor que cuente los registos.
SET ANSI_NULLS ON; --Habilitamos que interprete los NULLS 
SET QUOTED_IDENTIFIER ON; --Habilitamos Interpretacion de Comillas y comillas dobles validas
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; --Necesitamos acceder a la info sin que este comiteada
SET ANSI_WARNINGS OFF; --no necesitamos que nos avice los warning, variables sin usar, etc...
SET Language Spanish --Seteamos la lengua independiente del server, asi aparece en espanol.

SELECT TOP 1
f.[Id],
f.[NroFactura],
f.[Fecha] ,
f.[Vencimiento],
f.[IdCbu] ,
f.[IdEmpresa] ,
f.[Periodo] ,
f.[SubTotal] ,
f.[Total] ,
f.[TotalDescripcion] 
FROM Factura f
WHERE 
f.Id = @Id

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END


SET ANSI_NULLS ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*

exec Factura_Insert 
@Fecha=N'1/4/2025 12:00:00 AM',
@Vencimiento=N'1/4/2025 12:00:00 AM',
@NroFactura=N'00012345565656',
@Cbu=N'0170478920000000289171',
@Empresa=N'Dabra Sociedad Anónima',
@Cuit=N'30-63848573-3',
@Banco=N'Banco Bbva Argentina S.A.',
@Periodo=N'Abril 2025',
@SubTotal=N'8626938.04',
@Suss=N'738875.50',
@Total=N'10611133.79',
@TotalDescripcion=N'Son PESOS: Diez millones seiscientos once mil ciento treinta y tres con setenta y nueve centavos.-'

select * from EmpresaFactura
select * from banco
select * from Cbu
select * from Factura

delete factura
delete cbu
delete banco
delete empresaFactura

*/
CREATE PROCEDURE [dbo].[Factura_Insert]
@NroFactura varchar(150),
@Vencimiento smalldatetime,
@Fecha smalldatetime,
@Cbu varchar(200),
@Empresa varchar(200),
@Cuit varchar(100),
@Banco varchar(200),
@Periodo varchar(150),
@SubTotal decimal,
@Total decimal,
@TotalDescripcion varchar(200)
AS
BEGIN
declare @MsgError varchar(100)

BEGIN TRY
SET NOCOUNT ON; --No necesitamos pedirle al motor que cuente los registos.
SET ANSI_NULLS ON; --Habilitamos que interprete los NULLS 
SET QUOTED_IDENTIFIER ON; --Habilitamos Interpretacion de Comillas y comillas dobles validas
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; --Necesitamos acceder a la info sin que este comiteada
SET ANSI_WARNINGS OFF; --no necesitamos que nos avice los warning, variables sin usar, etc...
SET Language Spanish --Seteamos la lengua independiente del server, asi aparece en espanol.

declare @IdCbu int
declare @IdEmpresaFactura int
declare @IdBanco int

BEGIN TRAN 

select @IdEmpresaFactura = e.Id from Empresa e
where 
(
	(e.DescriptionCode = @Empresa) or (e.Nombre = @Empresa)
)

insert into Empresa (Nombre,Cuit,DescriptionCode) 
select @Empresa, @Cuit,@Empresa
where isnull(@IdEmpresaFactura,0) = 0

set @IdEmpresaFactura = case when isnull(@IdEmpresaFactura,0) = 0 then SCOPE_IDENTITY() else @IdEmpresaFactura end 

select @IdBanco = b.Id from Banco b
where b.Nombre = @Banco

insert into Banco (Nombre,DescriptionCode) 
select @Banco,@Banco 
where ISNULL(@IdBanco,0) = 0

set @IdBanco = case when isnull(@IdBanco,0) = 0 then SCOPE_IDENTITY() else @IdBanco end 

select @IdCbu = c.id from Cbu c
where c.NumeroCbu = @Cbu

insert into Cbu (IdBanco,NumeroCbu)
select @IdBanco,@Cbu
where ISNULL(@IdCbu,0) = 0

set @IdCbu = case when isnull(@IdCbu,0) = 0 then SCOPE_IDENTITY() else @IdCbu end 

INSERT INTO Factura (NroFactura,Fecha,Vencimiento,IdEmpresaFactura,IdCbu,Cuit,SubTotal,Total,Periodo,TotalDescripcion) 
			 VALUES (@NroFactura,@Fecha,@Vencimiento,@IdEmpresaFactura,@IdCbu,@Cuit,@SubTotal,@Total,@Periodo,@TotalDescripcion ) 


COMMIT TRAN 


END try

BEGIN CATCH

	ROLLBACK
	
	set @MsgError = convert(varchar,ERROR_NUMBER()) + convert(varchar,ERROR_MESSAGE()) + convert(varchar,ERROR_SEVERITY()) + convert(varchar,ERROR_STATE()) + convert(varchar,ERROR_PROCEDURE()) + convert(varchar,ERROR_LINE())
	
	RAISERROR ( @MsgError ,16, 1 );
	return;

END CATCH;
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Factura_List]
AS
BEGIN
declare @MsgError varchar(100)

BEGIN TRY
SET NOCOUNT ON; --No necesitamos pedirle al motor que cuente los registos.
SET ANSI_NULLS ON; --Habilitamos que interprete los NULLS 
SET QUOTED_IDENTIFIER ON; --Habilitamos Interpretacion de Comillas y comillas dobles validas
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; --Necesitamos acceder a la info sin que este comiteada
SET ANSI_WARNINGS OFF; --no necesitamos que nos avice los warning, variables sin usar, etc...
SET Language Spanish --Seteamos la lengua independiente del server, asi aparece en espanol.

SELECT
f.Id,
f.[NroFactura],
f.[Fecha] ,
f.[Periodo] ,
f.[SubTotal],
f.[Total] ,
f.[TotalDescripcion],
e.Cuit as Cuit,
e.Nombre as Empresa,
c.NumeroCbu as Cbu,
b.Nombre as Banco
FROM Factura f 
inner join Empresa e
	on f.IdEmpresa = e.Id
inner join Cbu c
	on c.Id = f.IdCbu
inner join Banco b
	on c.IdBanco = b.Id


END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END


SET ANSI_NULLS ON
GO
