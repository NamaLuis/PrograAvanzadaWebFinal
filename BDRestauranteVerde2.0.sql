drop database restauranteVerde
GO
USE [master]
GO
/****** Object:  Database [restauranteVerde]    Script Date: 06/11/2021 15:39:36 ******/
CREATE DATABASE [restauranteVerde]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'restauranteVerde', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\restauranteVerde.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'restauranteVerde_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\restauranteVerde_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [restauranteVerde] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [restauranteVerde].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [restauranteVerde] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [restauranteVerde] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [restauranteVerde] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [restauranteVerde] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [restauranteVerde] SET ARITHABORT OFF 
GO
ALTER DATABASE [restauranteVerde] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [restauranteVerde] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [restauranteVerde] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [restauranteVerde] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [restauranteVerde] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [restauranteVerde] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [restauranteVerde] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [restauranteVerde] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [restauranteVerde] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [restauranteVerde] SET  DISABLE_BROKER 
GO
ALTER DATABASE [restauranteVerde] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [restauranteVerde] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [restauranteVerde] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [restauranteVerde] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [restauranteVerde] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [restauranteVerde] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [restauranteVerde] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [restauranteVerde] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [restauranteVerde] SET  MULTI_USER 
GO
ALTER DATABASE [restauranteVerde] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [restauranteVerde] SET DB_CHAINING OFF 
GO
ALTER DATABASE [restauranteVerde] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [restauranteVerde] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [restauranteVerde] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [restauranteVerde] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [restauranteVerde] SET QUERY_STORE = OFF
GO
USE [restauranteVerde]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 06/11/2021 15:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[cedula] [int] NOT NULL,
	[nombre] [varchar](40) NOT NULL,
	[apellido1] [varchar](40) NOT NULL,
	[apellido2] [varchar](40) NULL,
	[IDProvincia] [int] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 06/11/2021 15:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[ID_Empleado] [int] NOT NULL,
	[Nombre] [varchar](40) NOT NULL,
	[Apellido1] [varchar](40) NOT NULL,
	[Apellido2] [varchar](40) NOT NULL,
	[Salario] [float] NOT NULL,
	[Fecha_Ingreso] [date] NOT NULL,
	[ID_Puesto] [int] NOT NULL,
	[ID_Rol] [int] NOT NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[ID_Empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 06/11/2021 15:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[ID_Factura] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[ID_Producto] [int] NOT NULL,
	[ID_Cliente] [int] NOT NULL,
	[ID_Empleado] [int] NOT NULL,
	[Monto] [float] NOT NULL,
	[Descuento] [float] NOT NULL,
CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[ID_Factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
)ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 06/11/2021 15:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[ID_Producto] [int] NOT NULL,
	[Nombre_Producto] [varchar](50) NOT NULL,
	[Cantidad] [bigint] NOT NULL,
	[Fecha_Ingreso] [date] NULL,
	[ID_Proveedor] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[ID_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 06/11/2021 15:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[ID_ Proveedor] [int] NOT NULL,
	[Nombre] [varchar](40) NOT NULL,
	[Telefono] [int] NOT NULL,
	[Ubicacion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[ID_ Proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 06/11/2021 15:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincia](
	[ID_Provincia] [int] NOT NULL,
	[Nombre_Provincia] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Provincia] PRIMARY KEY CLUSTERED 
(
	[ID_Provincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puesto]    Script Date: 06/11/2021 15:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puesto](
	[ID_Puesto] [int] NOT NULL,
	[Nombre] [varchar](40) NOT NULL,
	[Manager] [varchar](40) NOT NULL,
 CONSTRAINT [PK_Puesto] PRIMARY KEY CLUSTERED 
(
	[ID_Puesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 06/11/2021 15:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[ID_Rol] [int] NOT NULL,
	[Nombre_Rol] [varchar](50) NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[ID_Rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Provincia] FOREIGN KEY([IDProvincia])
REFERENCES [dbo].[Provincia] ([ID_Provincia])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Provincia]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Puesto] FOREIGN KEY([ID_Puesto])
REFERENCES [dbo].[Puesto] ([ID_Puesto])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Empleado_Puesto]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Rol] FOREIGN KEY([ID_Rol])
REFERENCES [dbo].[Rol] ([ID_Rol])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Empleado_Rol]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Cliente] FOREIGN KEY([ID_Cliente])
REFERENCES [dbo].[Cliente] ([cedula])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Cliente]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Empleado] FOREIGN KEY([ID_Empleado])
REFERENCES [dbo].[Empleado] ([ID_Empleado])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Empleado]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Producto] FOREIGN KEY([ID_Producto])
REFERENCES [dbo].[Producto] ([ID_Producto])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Producto]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Proveedor] FOREIGN KEY([ID_Proveedor])
REFERENCES [dbo].[Proveedor] ([ID_ Proveedor])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Proveedor]
GO
USE [master]
GO
ALTER DATABASE [restauranteVerde] SET  READ_WRITE 
GO
