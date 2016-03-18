USE [BUSTICKETING]
GO
/****** Object:  Schema [fedalicpos]    Script Date: 9/19/2015 7:24:28 PM ******/
CREATE SCHEMA [fedalicpos]
GO
/****** Object:  Table [dbo].[BUS_ASSIGN]    Script Date: 9/19/2015 7:24:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BUS_ASSIGN](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DateOfDiparture] [date] NULL,
	[UniqueId] [varchar](50) NULL,
	[TimeOfDiparture] [varchar](50) NULL,
	[Sift] [varchar](50) NULL,
	[A1] [varchar](50) NULL,
	[A2] [varchar](50) NULL,
	[A3] [varchar](50) NULL,
	[A4] [varchar](50) NULL,
	[B1] [varchar](50) NULL,
	[B2] [varchar](50) NULL,
	[B3] [varchar](50) NULL,
	[B4] [varchar](50) NULL,
	[C1] [varchar](50) NULL,
	[C2] [varchar](50) NULL,
	[C3] [varchar](50) NULL,
	[C4] [varchar](50) NULL,
	[D1] [varchar](50) NULL,
	[D2] [varchar](50) NULL,
	[D3] [varchar](50) NULL,
	[D4] [varchar](50) NULL,
	[E1] [varchar](50) NULL,
	[E2] [varchar](50) NULL,
	[E3] [varchar](50) NULL,
	[E4] [varchar](50) NULL,
	[F1] [varchar](50) NULL,
	[F2] [varchar](50) NULL,
	[F3] [varchar](50) NULL,
	[F4] [varchar](50) NULL,
	[G1] [varchar](50) NULL,
	[G2] [varchar](50) NULL,
	[G3] [varchar](50) NULL,
	[G4] [varchar](50) NULL,
	[H1] [varchar](50) NULL,
	[H2] [varchar](50) NULL,
	[H3] [varchar](50) NULL,
	[H4] [varchar](50) NULL,
	[I1] [varchar](50) NULL,
	[I2] [varchar](50) NULL,
	[I3] [varchar](50) NULL,
	[I4] [varchar](50) NULL,
	[J1] [varchar](50) NULL,
	[J2] [varchar](50) NULL,
	[J3] [varchar](50) NULL,
	[J4] [varchar](50) NULL,
	[BusNumber] [varchar](50) NULL,
	[Type] [varchar](50) NULL,
	[TicketPrice] [int] NULL,
	[TicketCounter] [nvarchar](50) NULL,
	[LastStop] [nvarchar](50) NULL,
	[ReportingTime] [nvarchar](50) NULL,
 CONSTRAINT [PK_BUS_ASSIGN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DUSER]    Script Date: 9/19/2015 7:24:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DUSER](
	[USER_ID] [int] IDENTITY(1,1) NOT NULL,
	[USER_NAME] [varchar](50) NULL,
	[USER_PASSWORD] [varchar](50) NULL,
	[USER_GROUP_ID] [bigint] NOT NULL,
 CONSTRAINT [PK_DUSER] PRIMARY KEY CLUSTERED 
(
	[USER_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MODULE_PERMISSION]    Script Date: 9/19/2015 7:24:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MODULE_PERMISSION](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MODULE_NAME] [varchar](50) NULL,
	[USER_GROUP_ID] [bigint] NULL,
 CONSTRAINT [PK_MODULE_PERMISSION] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PRE_SETUP]    Script Date: 9/19/2015 7:24:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRE_SETUP](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Time] [nvarchar](50) NULL,
	[BusType] [nvarchar](50) NULL,
	[Sift] [nvarchar](50) NULL,
	[BusNumber] [nvarchar](50) NULL,
	[TicketCounterName] [nvarchar](50) NULL,
 CONSTRAINT [PK_PRE_SETUP] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ROLEWISE_MENU]    Script Date: 9/19/2015 7:24:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ROLEWISE_MENU](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MODULE_ID] [int] NULL,
	[USER_GROUP_ID] [bigint] NOT NULL,
	[PARENT_MENU_NAME] [varchar](50) NULL,
	[PARENT_MENU_CONTENT] [varchar](100) NULL,
	[CHILD_MENU_NAME] [varchar](50) NULL,
	[CHILD_MENU_CONTENT] [varchar](100) NULL,
 CONSTRAINT [PK_ROLEWISE_MENU] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SeatFareDetails]    Script Date: 9/19/2015 7:24:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SeatFareDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JournyFromLocation] [nvarchar](50) NULL,
	[JournyToLocation] [nvarchar](50) NULL,
	[SeatFare] [int] NULL,
 CONSTRAINT [PK_SeatFareDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TICKET_DETAILS]    Script Date: 9/19/2015 7:24:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TICKET_DETAILS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Time] [nvarchar](50) NULL,
	[BusAssingnPKId] [int] NULL,
	[BusUniqueCode] [varchar](50) NULL,
	[ClintId] [int] NULL,
	[ClintName] [nvarchar](50) NULL,
	[Gender] [nvarchar](50) NULL,
	[ClintAddress] [nvarchar](50) NULL,
	[ClintMobile] [nvarchar](50) NULL,
	[BusNo] [nvarchar](50) NULL,
	[BusType] [nvarchar](50) NULL,
	[Sift] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[SeatNo] [nvarchar](50) NULL,
	[EntryDate] [date] NULL,
	[TicketPrice] [int] NULL,
	[TicketPricePaid] [int] NULL,
	[TicketPriceDiscount] [int] NULL,
	[TicketPriceDue] [int] NULL,
	[TicketNo] [nvarchar](50) NULL,
	[BookingNo] [nvarchar](50) NULL,
	[JournyDate] [date] NULL,
	[JournyFrom] [nvarchar](50) NULL,
	[JournyTo] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[UserID] [int] NULL,
	[Age] [int] NULL,
 CONSTRAINT [PK_TICKET_DETAILS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USER_GROUP]    Script Date: 9/19/2015 7:24:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USER_GROUP](
	[GROUP_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GROUP_NAME] [varchar](50) NULL,
 CONSTRAINT [PK_USER_GROUP] PRIMARY KEY CLUSTERED 
(
	[GROUP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[BUS_ASSIGN] ON 

INSERT [dbo].[BUS_ASSIGN] ([ID], [DateOfDiparture], [UniqueId], [TimeOfDiparture], [Sift], [A1], [A2], [A3], [A4], [B1], [B2], [B3], [B4], [C1], [C2], [C3], [C4], [D1], [D2], [D3], [D4], [E1], [E2], [E3], [E4], [F1], [F2], [F3], [F4], [G1], [G2], [G3], [G4], [H1], [H2], [H3], [H4], [I1], [I2], [I3], [I4], [J1], [J2], [J3], [J4], [BusNumber], [Type], [TicketPrice], [TicketCounter], [LastStop], [ReportingTime]) VALUES (5009, CAST(0x583A0B00 AS Date), NULL, N'8:15 AM', N'Day', N'Sold', N'Sold', N'Sold', N'Sold', N'Sold', N'Sold', N'Sold', N'Sold', N'Sold', N'Sold', N'Sold', N'Sold', N'Sold', N'Sold', N'Sold', N'Sold', NULL, NULL, N'Sold', N'Sold', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Sold', N'Dhaka Metro BA- 014545', N'Non-Ac', 500, N'Dhaka', N'Lalmonirhat', N'8:00 AM')
INSERT [dbo].[BUS_ASSIGN] ([ID], [DateOfDiparture], [UniqueId], [TimeOfDiparture], [Sift], [A1], [A2], [A3], [A4], [B1], [B2], [B3], [B4], [C1], [C2], [C3], [C4], [D1], [D2], [D3], [D4], [E1], [E2], [E3], [E4], [F1], [F2], [F3], [F4], [G1], [G2], [G3], [G4], [H1], [H2], [H3], [H4], [I1], [I2], [I3], [I4], [J1], [J2], [J3], [J4], [BusNumber], [Type], [TicketPrice], [TicketCounter], [LastStop], [ReportingTime]) VALUES (5010, CAST(0x5A3A0B00 AS Date), NULL, N'8:15 PM', N'Day', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Dhaka Metro BA- 014545', N'Non-Ac', 500, N'Dhaka', N'Lalmonirhat', N'8:00 AM')
SET IDENTITY_INSERT [dbo].[BUS_ASSIGN] OFF
SET IDENTITY_INSERT [dbo].[DUSER] ON 

INSERT [dbo].[DUSER] ([USER_ID], [USER_NAME], [USER_PASSWORD], [USER_GROUP_ID]) VALUES (1, N'r', N'r', 1)
INSERT [dbo].[DUSER] ([USER_ID], [USER_NAME], [USER_PASSWORD], [USER_GROUP_ID]) VALUES (2, N'a', N'a', 2)
SET IDENTITY_INSERT [dbo].[DUSER] OFF
SET IDENTITY_INSERT [dbo].[MODULE_PERMISSION] ON 

INSERT [dbo].[MODULE_PERMISSION] ([ID], [MODULE_NAME], [USER_GROUP_ID]) VALUES (15, N'Ticketing', 2)
SET IDENTITY_INSERT [dbo].[MODULE_PERMISSION] OFF
SET IDENTITY_INSERT [dbo].[PRE_SETUP] ON 

INSERT [dbo].[PRE_SETUP] ([ID], [Time], [BusType], [Sift], [BusNumber], [TicketCounterName]) VALUES (1, N'8:00 AM', N'AC', N'Day', N'Dhaka Metro BA- 014545', N'Dhaka')
INSERT [dbo].[PRE_SETUP] ([ID], [Time], [BusType], [Sift], [BusNumber], [TicketCounterName]) VALUES (2, N'8:15 AM', N'Non-Ac', N'Morning', N'Dhaka Metro BA- 01454578', N'Lalmonirhat')
INSERT [dbo].[PRE_SETUP] ([ID], [Time], [BusType], [Sift], [BusNumber], [TicketCounterName]) VALUES (3, N'8:30 AM', N'', N'Noon', N'Dhaka Metro BA- 45677', N'Aditmari')
INSERT [dbo].[PRE_SETUP] ([ID], [Time], [BusType], [Sift], [BusNumber], [TicketCounterName]) VALUES (4, N'8:15 PM', NULL, N'', NULL, NULL)
INSERT [dbo].[PRE_SETUP] ([ID], [Time], [BusType], [Sift], [BusNumber], [TicketCounterName]) VALUES (5, N'8:30 PM', NULL, NULL, NULL, NULL)
INSERT [dbo].[PRE_SETUP] ([ID], [Time], [BusType], [Sift], [BusNumber], [TicketCounterName]) VALUES (6, N'8:45 PM', NULL, NULL, NULL, NULL)
INSERT [dbo].[PRE_SETUP] ([ID], [Time], [BusType], [Sift], [BusNumber], [TicketCounterName]) VALUES (7, N'9:00 PM', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[PRE_SETUP] OFF
SET IDENTITY_INSERT [dbo].[ROLEWISE_MENU] ON 

INSERT [dbo].[ROLEWISE_MENU] ([ID], [MODULE_ID], [USER_GROUP_ID], [PARENT_MENU_NAME], [PARENT_MENU_CONTENT], [CHILD_MENU_NAME], [CHILD_MENU_CONTENT]) VALUES (124, 15, 2, N'HomeMenu', N'Home', N'BusAssignMenu', N'Bus Assign')
SET IDENTITY_INSERT [dbo].[ROLEWISE_MENU] OFF
SET IDENTITY_INSERT [dbo].[TICKET_DETAILS] ON 

INSERT [dbo].[TICKET_DETAILS] ([Id], [Time], [BusAssingnPKId], [BusUniqueCode], [ClintId], [ClintName], [Gender], [ClintAddress], [ClintMobile], [BusNo], [BusType], [Sift], [Status], [SeatNo], [EntryDate], [TicketPrice], [TicketPricePaid], [TicketPriceDiscount], [TicketPriceDue], [TicketNo], [BookingNo], [JournyDate], [JournyFrom], [JournyTo], [UserName], [UserID], [Age]) VALUES (3096, N'8:15 AM', 5009, NULL, NULL, N'kayes', N'Female', N'nurjahan Road', N'01717745374', N'Dhaka Metro BA- 014545', N'Non-Ac', N'Day', N'Sold', N'A1', CAST(0x583A0B00 AS Date), 1000, 1000, 0, 0, N'53A6A853276', NULL, CAST(0x583A0B00 AS Date), N'Lalmonirhat', N'Dhaka', N'r', 1, NULL)
INSERT [dbo].[TICKET_DETAILS] ([Id], [Time], [BusAssingnPKId], [BusUniqueCode], [ClintId], [ClintName], [Gender], [ClintAddress], [ClintMobile], [BusNo], [BusType], [Sift], [Status], [SeatNo], [EntryDate], [TicketPrice], [TicketPricePaid], [TicketPriceDiscount], [TicketPriceDue], [TicketNo], [BookingNo], [JournyDate], [JournyFrom], [JournyTo], [UserName], [UserID], [Age]) VALUES (3097, N'8:15 AM', 5009, NULL, NULL, N'kayes', N'Female', N'nurjahan Road', N'01717745374', N'Dhaka Metro BA- 014545', N'Non-Ac', N'Day', N'Sold', N'E3', CAST(0x583A0B00 AS Date), 1000, 1000, 0, 0, N'53A6A853276', NULL, CAST(0x583A0B00 AS Date), N'Lalmonirhat', N'Dhaka', N'r', 1, NULL)
INSERT [dbo].[TICKET_DETAILS] ([Id], [Time], [BusAssingnPKId], [BusUniqueCode], [ClintId], [ClintName], [Gender], [ClintAddress], [ClintMobile], [BusNo], [BusType], [Sift], [Status], [SeatNo], [EntryDate], [TicketPrice], [TicketPricePaid], [TicketPriceDiscount], [TicketPriceDue], [TicketNo], [BookingNo], [JournyDate], [JournyFrom], [JournyTo], [UserName], [UserID], [Age]) VALUES (3098, N'8:15 AM', 5009, NULL, NULL, N'asd', N'N/A', N'asd', N'0178795874', N'Dhaka Metro BA- 014545', N'Non-Ac', N'Day', N'Sold', N'A2', CAST(0x583A0B00 AS Date), 1500, 1500, 0, 0, N'53A6A858366', NULL, CAST(0x583A0B00 AS Date), N'Lalmonirhat', N'Dhaka', N'r', 1, NULL)
INSERT [dbo].[TICKET_DETAILS] ([Id], [Time], [BusAssingnPKId], [BusUniqueCode], [ClintId], [ClintName], [Gender], [ClintAddress], [ClintMobile], [BusNo], [BusType], [Sift], [Status], [SeatNo], [EntryDate], [TicketPrice], [TicketPricePaid], [TicketPriceDiscount], [TicketPriceDue], [TicketNo], [BookingNo], [JournyDate], [JournyFrom], [JournyTo], [UserName], [UserID], [Age]) VALUES (3099, N'8:15 AM', 5009, NULL, NULL, N'asd', N'N/A', N'asd', N'0178795874', N'Dhaka Metro BA- 014545', N'Non-Ac', N'Day', N'Sold', N'A3', CAST(0x583A0B00 AS Date), 1500, 1500, 0, 0, N'53A6A858366', NULL, CAST(0x583A0B00 AS Date), N'Lalmonirhat', N'Dhaka', N'r', 1, NULL)
INSERT [dbo].[TICKET_DETAILS] ([Id], [Time], [BusAssingnPKId], [BusUniqueCode], [ClintId], [ClintName], [Gender], [ClintAddress], [ClintMobile], [BusNo], [BusType], [Sift], [Status], [SeatNo], [EntryDate], [TicketPrice], [TicketPricePaid], [TicketPriceDiscount], [TicketPriceDue], [TicketNo], [BookingNo], [JournyDate], [JournyFrom], [JournyTo], [UserName], [UserID], [Age]) VALUES (3100, N'8:15 AM', 5009, NULL, NULL, N'asd', N'N/A', N'asd', N'0178795874', N'Dhaka Metro BA- 014545', N'Non-Ac', N'Day', N'Sold', N'B3', CAST(0x583A0B00 AS Date), 1500, 1500, 0, 0, N'53A6A858366', NULL, CAST(0x583A0B00 AS Date), N'Lalmonirhat', N'Dhaka', N'r', 1, NULL)
INSERT [dbo].[TICKET_DETAILS] ([Id], [Time], [BusAssingnPKId], [BusUniqueCode], [ClintId], [ClintName], [Gender], [ClintAddress], [ClintMobile], [BusNo], [BusType], [Sift], [Status], [SeatNo], [EntryDate], [TicketPrice], [TicketPricePaid], [TicketPriceDiscount], [TicketPriceDue], [TicketNo], [BookingNo], [JournyDate], [JournyFrom], [JournyTo], [UserName], [UserID], [Age]) VALUES (3101, N'8:15 AM', 5009, NULL, NULL, N'asd', N'Female', N'asd', N'02154889', N'Dhaka Metro BA- 014545', N'Non-Ac', N'Day', N'Sold', N'C4', CAST(0x583A0B00 AS Date), 1500, 1500, 0, 0, N'53A6A86AA6', NULL, CAST(0x583A0B00 AS Date), N'Lalmonirhat', N'Dhaka', N'r', 1, NULL)
INSERT [dbo].[TICKET_DETAILS] ([Id], [Time], [BusAssingnPKId], [BusUniqueCode], [ClintId], [ClintName], [Gender], [ClintAddress], [ClintMobile], [BusNo], [BusType], [Sift], [Status], [SeatNo], [EntryDate], [TicketPrice], [TicketPricePaid], [TicketPriceDiscount], [TicketPriceDue], [TicketNo], [BookingNo], [JournyDate], [JournyFrom], [JournyTo], [UserName], [UserID], [Age]) VALUES (3102, N'8:15 AM', 5009, NULL, NULL, N'asd', N'Female', N'asd', N'02154889', N'Dhaka Metro BA- 014545', N'Non-Ac', N'Day', N'Sold', N'B4', CAST(0x583A0B00 AS Date), 1500, 1500, 0, 0, N'53A6A86AA6', NULL, CAST(0x583A0B00 AS Date), N'Lalmonirhat', N'Dhaka', N'r', 1, NULL)
INSERT [dbo].[TICKET_DETAILS] ([Id], [Time], [BusAssingnPKId], [BusUniqueCode], [ClintId], [ClintName], [Gender], [ClintAddress], [ClintMobile], [BusNo], [BusType], [Sift], [Status], [SeatNo], [EntryDate], [TicketPrice], [TicketPricePaid], [TicketPriceDiscount], [TicketPriceDue], [TicketNo], [BookingNo], [JournyDate], [JournyFrom], [JournyTo], [UserName], [UserID], [Age]) VALUES (3103, N'8:15 AM', 5009, NULL, NULL, N'asd', N'Female', N'asd', N'02154889', N'Dhaka Metro BA- 014545', N'Non-Ac', N'Day', N'Sold', N'B1', CAST(0x583A0B00 AS Date), 1500, 1500, 0, 0, N'53A6A86AA6', NULL, CAST(0x583A0B00 AS Date), N'Lalmonirhat', N'Dhaka', N'r', 1, NULL)
INSERT [dbo].[TICKET_DETAILS] ([Id], [Time], [BusAssingnPKId], [BusUniqueCode], [ClintId], [ClintName], [Gender], [ClintAddress], [ClintMobile], [BusNo], [BusType], [Sift], [Status], [SeatNo], [EntryDate], [TicketPrice], [TicketPricePaid], [TicketPriceDiscount], [TicketPriceDue], [TicketNo], [BookingNo], [JournyDate], [JournyFrom], [JournyTo], [UserName], [UserID], [Age]) VALUES (3104, N'8:15 AM', 5009, NULL, NULL, N'2121', N'N/A', N'asd', N'01212', N'Dhaka Metro BA- 014545', N'Non-Ac', N'Day', N'Sold', N'B2', CAST(0x583A0B00 AS Date), 2000, 2000, 0, 0, N'53A6A862848', NULL, CAST(0x583A0B00 AS Date), N'Lalmonirhat', N'Dhaka', N'r', 1, NULL)
INSERT [dbo].[TICKET_DETAILS] ([Id], [Time], [BusAssingnPKId], [BusUniqueCode], [ClintId], [ClintName], [Gender], [ClintAddress], [ClintMobile], [BusNo], [BusType], [Sift], [Status], [SeatNo], [EntryDate], [TicketPrice], [TicketPricePaid], [TicketPriceDiscount], [TicketPriceDue], [TicketNo], [BookingNo], [JournyDate], [JournyFrom], [JournyTo], [UserName], [UserID], [Age]) VALUES (3105, N'8:15 AM', 5009, NULL, NULL, N'2121', N'N/A', N'asd', N'01212', N'Dhaka Metro BA- 014545', N'Non-Ac', N'Day', N'Sold', N'A4', CAST(0x583A0B00 AS Date), 2000, 2000, 0, 0, N'53A6A862848', NULL, CAST(0x583A0B00 AS Date), N'Lalmonirhat', N'Dhaka', N'r', 1, NULL)
INSERT [dbo].[TICKET_DETAILS] ([Id], [Time], [BusAssingnPKId], [BusUniqueCode], [ClintId], [ClintName], [Gender], [ClintAddress], [ClintMobile], [BusNo], [BusType], [Sift], [Status], [SeatNo], [EntryDate], [TicketPrice], [TicketPricePaid], [TicketPriceDiscount], [TicketPriceDue], [TicketNo], [BookingNo], [JournyDate], [JournyFrom], [JournyTo], [UserName], [UserID], [Age]) VALUES (3106, N'8:15 AM', 5009, NULL, NULL, N'2121', N'N/A', N'asd', N'01212', N'Dhaka Metro BA- 014545', N'Non-Ac', N'Day', N'Sold', N'C2', CAST(0x583A0B00 AS Date), 2000, 2000, 0, 0, N'53A6A862848', NULL, CAST(0x583A0B00 AS Date), N'Lalmonirhat', N'Dhaka', N'r', 1, NULL)
INSERT [dbo].[TICKET_DETAILS] ([Id], [Time], [BusAssingnPKId], [BusUniqueCode], [ClintId], [ClintName], [Gender], [ClintAddress], [ClintMobile], [BusNo], [BusType], [Sift], [Status], [SeatNo], [EntryDate], [TicketPrice], [TicketPricePaid], [TicketPriceDiscount], [TicketPriceDue], [TicketNo], [BookingNo], [JournyDate], [JournyFrom], [JournyTo], [UserName], [UserID], [Age]) VALUES (3107, N'8:15 AM', 5009, NULL, NULL, N'2121', N'N/A', N'asd', N'01212', N'Dhaka Metro BA- 014545', N'Non-Ac', N'Day', N'Sold', N'C1', CAST(0x583A0B00 AS Date), 2000, 2000, 0, 0, N'53A6A862848', NULL, CAST(0x583A0B00 AS Date), N'Lalmonirhat', N'Dhaka', N'r', 1, NULL)
INSERT [dbo].[TICKET_DETAILS] ([Id], [Time], [BusAssingnPKId], [BusUniqueCode], [ClintId], [ClintName], [Gender], [ClintAddress], [ClintMobile], [BusNo], [BusType], [Sift], [Status], [SeatNo], [EntryDate], [TicketPrice], [TicketPricePaid], [TicketPriceDiscount], [TicketPriceDue], [TicketNo], [BookingNo], [JournyDate], [JournyFrom], [JournyTo], [UserName], [UserID], [Age]) VALUES (3108, N'8:15 AM', 5009, NULL, NULL, N'asd', N'N/A', N'asd', N'asdasd', N'Dhaka Metro BA- 014545', N'Non-Ac', N'Day', N'Sold', N'C3', CAST(0x583A0B00 AS Date), 2000, 2000, 0, 0, N'53A6A86A761', NULL, CAST(0x583A0B00 AS Date), N'Lalmonirhat', N'Dhaka', N'r', 1, NULL)
INSERT [dbo].[TICKET_DETAILS] ([Id], [Time], [BusAssingnPKId], [BusUniqueCode], [ClintId], [ClintName], [Gender], [ClintAddress], [ClintMobile], [BusNo], [BusType], [Sift], [Status], [SeatNo], [EntryDate], [TicketPrice], [TicketPricePaid], [TicketPriceDiscount], [TicketPriceDue], [TicketNo], [BookingNo], [JournyDate], [JournyFrom], [JournyTo], [UserName], [UserID], [Age]) VALUES (3109, N'8:15 AM', 5009, NULL, NULL, N'asd', N'N/A', N'asd', N'asdasd', N'Dhaka Metro BA- 014545', N'Non-Ac', N'Day', N'Sold', N'D4', CAST(0x583A0B00 AS Date), 2000, 2000, 0, 0, N'53A6A86A761', NULL, CAST(0x583A0B00 AS Date), N'Lalmonirhat', N'Dhaka', N'r', 1, NULL)
INSERT [dbo].[TICKET_DETAILS] ([Id], [Time], [BusAssingnPKId], [BusUniqueCode], [ClintId], [ClintName], [Gender], [ClintAddress], [ClintMobile], [BusNo], [BusType], [Sift], [Status], [SeatNo], [EntryDate], [TicketPrice], [TicketPricePaid], [TicketPriceDiscount], [TicketPriceDue], [TicketNo], [BookingNo], [JournyDate], [JournyFrom], [JournyTo], [UserName], [UserID], [Age]) VALUES (3110, N'8:15 AM', 5009, NULL, NULL, N'asd', N'N/A', N'asd', N'asdasd', N'Dhaka Metro BA- 014545', N'Non-Ac', N'Day', N'Sold', N'D3', CAST(0x583A0B00 AS Date), 2000, 2000, 0, 0, N'53A6A86A761', NULL, CAST(0x583A0B00 AS Date), N'Lalmonirhat', N'Dhaka', N'r', 1, NULL)
INSERT [dbo].[TICKET_DETAILS] ([Id], [Time], [BusAssingnPKId], [BusUniqueCode], [ClintId], [ClintName], [Gender], [ClintAddress], [ClintMobile], [BusNo], [BusType], [Sift], [Status], [SeatNo], [EntryDate], [TicketPrice], [TicketPricePaid], [TicketPriceDiscount], [TicketPriceDue], [TicketNo], [BookingNo], [JournyDate], [JournyFrom], [JournyTo], [UserName], [UserID], [Age]) VALUES (3111, N'8:15 AM', 5009, NULL, NULL, N'asd', N'N/A', N'asd', N'asdasd', N'Dhaka Metro BA- 014545', N'Non-Ac', N'Day', N'Sold', N'E4', CAST(0x583A0B00 AS Date), 2000, 2000, 0, 0, N'53A6A86A761', NULL, CAST(0x583A0B00 AS Date), N'Lalmonirhat', N'Dhaka', N'r', 1, NULL)
INSERT [dbo].[TICKET_DETAILS] ([Id], [Time], [BusAssingnPKId], [BusUniqueCode], [ClintId], [ClintName], [Gender], [ClintAddress], [ClintMobile], [BusNo], [BusType], [Sift], [Status], [SeatNo], [EntryDate], [TicketPrice], [TicketPricePaid], [TicketPriceDiscount], [TicketPriceDue], [TicketNo], [BookingNo], [JournyDate], [JournyFrom], [JournyTo], [UserName], [UserID], [Age]) VALUES (3112, N'8:15 AM', 5009, NULL, NULL, N'asd', N'Female', N'asd', N'asd', N'Dhaka Metro BA- 014545', N'Non-Ac', N'Day', N'Sold', N'D2', CAST(0x583A0B00 AS Date), 1000, 1000, 0, 0, N'53A6A86781', NULL, CAST(0x583A0B00 AS Date), N'Lalmonirhat', N'Dhaka', N'r', 1, NULL)
INSERT [dbo].[TICKET_DETAILS] ([Id], [Time], [BusAssingnPKId], [BusUniqueCode], [ClintId], [ClintName], [Gender], [ClintAddress], [ClintMobile], [BusNo], [BusType], [Sift], [Status], [SeatNo], [EntryDate], [TicketPrice], [TicketPricePaid], [TicketPriceDiscount], [TicketPriceDue], [TicketNo], [BookingNo], [JournyDate], [JournyFrom], [JournyTo], [UserName], [UserID], [Age]) VALUES (3113, N'8:15 AM', 5009, NULL, NULL, N'asd', N'Female', N'asd', N'asd', N'Dhaka Metro BA- 014545', N'Non-Ac', N'Day', N'Sold', N'D1', CAST(0x583A0B00 AS Date), 1000, 1000, 0, 0, N'53A6A86781', NULL, CAST(0x583A0B00 AS Date), N'Lalmonirhat', N'Dhaka', N'r', 1, NULL)
INSERT [dbo].[TICKET_DETAILS] ([Id], [Time], [BusAssingnPKId], [BusUniqueCode], [ClintId], [ClintName], [Gender], [ClintAddress], [ClintMobile], [BusNo], [BusType], [Sift], [Status], [SeatNo], [EntryDate], [TicketPrice], [TicketPricePaid], [TicketPriceDiscount], [TicketPriceDue], [TicketNo], [BookingNo], [JournyDate], [JournyFrom], [JournyTo], [UserName], [UserID], [Age]) VALUES (4104, N'8:15 AM', 5009, NULL, NULL, N'Md. Abdul Gani', N'Female', N'Lalmonirhat , khatapara', N'01718836939', N'Dhaka Metro BA- 014545', N'Non-Ac', N'Day', N'Sold', N'J4', CAST(0x5A3A0B00 AS Date), 500, 300, 0, 200, N'53A6507A412', NULL, CAST(0x583A0B00 AS Date), N'Dhaka', N'Dhaka', N'r', 1, 65)
SET IDENTITY_INSERT [dbo].[TICKET_DETAILS] OFF
SET IDENTITY_INSERT [dbo].[USER_GROUP] ON 

INSERT [dbo].[USER_GROUP] ([GROUP_ID], [GROUP_NAME]) VALUES (1, N'Super Admin')
INSERT [dbo].[USER_GROUP] ([GROUP_ID], [GROUP_NAME]) VALUES (2, N'Admin')
INSERT [dbo].[USER_GROUP] ([GROUP_ID], [GROUP_NAME]) VALUES (3, N'IT')
SET IDENTITY_INSERT [dbo].[USER_GROUP] OFF
ALTER TABLE [dbo].[DUSER]  WITH CHECK ADD  CONSTRAINT [FK_DUSER_USER_GROUP] FOREIGN KEY([USER_GROUP_ID])
REFERENCES [dbo].[USER_GROUP] ([GROUP_ID])
GO
ALTER TABLE [dbo].[DUSER] CHECK CONSTRAINT [FK_DUSER_USER_GROUP]
GO
ALTER TABLE [dbo].[MODULE_PERMISSION]  WITH CHECK ADD  CONSTRAINT [FK_MODULE_PERMISSION_USER_GROUP] FOREIGN KEY([USER_GROUP_ID])
REFERENCES [dbo].[USER_GROUP] ([GROUP_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MODULE_PERMISSION] CHECK CONSTRAINT [FK_MODULE_PERMISSION_USER_GROUP]
GO
ALTER TABLE [dbo].[ROLEWISE_MENU]  WITH CHECK ADD  CONSTRAINT [FK_ROLEWISE_MENU_MODULE_PERMISSION] FOREIGN KEY([MODULE_ID])
REFERENCES [dbo].[MODULE_PERMISSION] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ROLEWISE_MENU] CHECK CONSTRAINT [FK_ROLEWISE_MENU_MODULE_PERMISSION]
GO
ALTER TABLE [dbo].[ROLEWISE_MENU]  WITH CHECK ADD  CONSTRAINT [FK_ROLEWISE_MENU_USER_GROUP] FOREIGN KEY([USER_GROUP_ID])
REFERENCES [dbo].[USER_GROUP] ([GROUP_ID])
GO
ALTER TABLE [dbo].[ROLEWISE_MENU] CHECK CONSTRAINT [FK_ROLEWISE_MENU_USER_GROUP]
GO
ALTER TABLE [dbo].[TICKET_DETAILS]  WITH CHECK ADD  CONSTRAINT [FK_TICKET_DETAILS_BUS_ASSIGN] FOREIGN KEY([BusAssingnPKId])
REFERENCES [dbo].[BUS_ASSIGN] ([ID])
GO
ALTER TABLE [dbo].[TICKET_DETAILS] CHECK CONSTRAINT [FK_TICKET_DETAILS_BUS_ASSIGN]
GO
ALTER TABLE [dbo].[TICKET_DETAILS]  WITH CHECK ADD  CONSTRAINT [FK_TICKET_DETAILS_DUSER] FOREIGN KEY([UserID])
REFERENCES [dbo].[DUSER] ([USER_ID])
GO
ALTER TABLE [dbo].[TICKET_DETAILS] CHECK CONSTRAINT [FK_TICKET_DETAILS_DUSER]
GO
