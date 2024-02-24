# Miles CarRental
Sistema de busqueda de vehiculos para Miles Car Rental.

Miles Car Rental, una empresa lider en la industria del alquiler de vehículos, busca implementar un sistema de búsqueda avanzado que permita a sus clientes encontrar vehículos disponibles
de manera eficiente y precisa. Este sistema se diseñará para cumplir con los criterios especificos de búsqueda que requiere la empresa, asegurando una experiencia óptimia para sus usuarios.

## Curls de consumo
| Objeto    | Curl  | 
|---------------|----------------|
| Client   |  curl -X 'GET' \ 'https://localhost:44372/api/Client/GetClients' \ -H 'accept: */*'   |
| Available Vehicles   |  curl -X 'GET' \ 'https://localhost:44372/api/Vehicle/GetAvailableVehicles?pickupLocationCity=Cali&returnLocationCity=Bogota' \ -H 'accept: */*'  |
| Vehicles By Market   |  curl -X 'GET' \ 'https://localhost:44372/api/Market/GetAvailableVehiclesByMarket?cityClientLocation=Bogota&cityReturnLocation=Cali' \  -H 'accept: */*'   |

## Scripts Base Datos

USE [master]
GO
/****** Object:  Database [RentaCar]    Script Date: 24/02/2024 1:52:11 p. m. ******/
CREATE DATABASE [RentaCar]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RentaCar', FILENAME = N'C:\Users\Avis.Torres\RentaCar.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RentaCar_log', FILENAME = N'C:\Users\Avis.Torres\RentaCar_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
USE [RentaCar]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 24/02/2024 1:52:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](255) NOT NULL,
	[LastName] [varchar](255) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[MobilePhone] [varchar](50) NOT NULL,
	[OtherPhone] [varchar](50) NULL,
	[LocationId] [int] NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 24/02/2024 1:52:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[City] [varchar](255) NOT NULL,
	[Country] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Markets]    Script Date: 24/02/2024 1:52:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Markets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientLocationId] [int] NOT NULL,
	[ReturnLocationId] [int] NOT NULL,
	[VehicleId] [int] NOT NULL,
	[MarketArea] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Markets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 24/02/2024 1:52:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Model] [varchar](255) NOT NULL,
	[Brand] [varchar](255) NOT NULL,
	[Colour] [varchar](255) NOT NULL,
	[CarriagePlate] [varchar](50) NOT NULL,
	[PickupLocationId] [int] NOT NULL,
	[ReturnLocationId] [int] NOT NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex-Location]    Script Date: 24/02/2024 1:52:11 p. m. ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-Location] ON [dbo].[Clients]
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex-Client]    Script Date: 24/02/2024 1:52:11 p. m. ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-Client] ON [dbo].[Markets]
(
	[ClientLocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex-ReturnLocation]    Script Date: 24/02/2024 1:52:11 p. m. ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-ReturnLocation] ON [dbo].[Markets]
(
	[ReturnLocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex-VehicleId]    Script Date: 24/02/2024 1:52:11 p. m. ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-VehicleId] ON [dbo].[Markets]
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Locations] ([Id])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Clients_Location]
GO
ALTER TABLE [dbo].[Markets]  WITH CHECK ADD  CONSTRAINT [FK_Markets_ClientLocation] FOREIGN KEY([Id])
REFERENCES [dbo].[Markets] ([Id])
GO
ALTER TABLE [dbo].[Markets] CHECK CONSTRAINT [FK_Markets_ClientLocation]
GO
ALTER TABLE [dbo].[Markets]  WITH CHECK ADD  CONSTRAINT [FK_Markets_ReturnLocation] FOREIGN KEY([ReturnLocationId])
REFERENCES [dbo].[Locations] ([Id])
GO
ALTER TABLE [dbo].[Markets] CHECK CONSTRAINT [FK_Markets_ReturnLocation]
GO
ALTER TABLE [dbo].[Markets]  WITH CHECK ADD  CONSTRAINT [FK_Markets_Vehicle] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([Id])
GO
ALTER TABLE [dbo].[Markets] CHECK CONSTRAINT [FK_Markets_Vehicle]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_Location_Pickup] FOREIGN KEY([PickupLocationId])
REFERENCES [dbo].[Locations] ([Id])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicle_Location_Pickup]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_Location_Return] FOREIGN KEY([ReturnLocationId])
REFERENCES [dbo].[Locations] ([Id])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicle_Location_Return]
GO
USE [master]
GO
ALTER DATABASE [RentaCar] SET  READ_WRITE 
GO


