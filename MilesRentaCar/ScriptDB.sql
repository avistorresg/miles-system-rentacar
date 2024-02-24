USE [RentaCar]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 24/02/2024 2:06:24 p. m. ******/
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
/****** Object:  Table [dbo].[Locations]    Script Date: 24/02/2024 2:06:24 p. m. ******/
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
/****** Object:  Table [dbo].[Markets]    Script Date: 24/02/2024 2:06:24 p. m. ******/
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
/****** Object:  Table [dbo].[Vehicles]    Script Date: 24/02/2024 2:06:24 p. m. ******/
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
