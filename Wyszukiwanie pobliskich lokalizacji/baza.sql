/****** Object:  Table [dbo].[Cities]    Script Date: 08/03/2011 22:22:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cities](
	[CityID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PostalCode] [char](6) NOT NULL,
	[Coordinates] [geography] NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[CityID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE SPATIAL INDEX [IX_Cities_Coords] ON [dbo].[Cities] 
(
	[Coordinates]
)USING  GEOGRAPHY_GRID 
WITH (
GRIDS =(LEVEL_1 = MEDIUM,LEVEL_2 = MEDIUM,LEVEL_3 = MEDIUM,LEVEL_4 = MEDIUM), 
CELLS_PER_OBJECT = 16, PAD_INDEX  = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cities] ON
INSERT [dbo].[Cities] ([CityID], [Name], [PostalCode], [Coordinates]) VALUES (1, N'Bytom Odrzański', N'67-115', 0xE6100000010C933A014D84DD4940A1F831E6AEA52F40)
INSERT [dbo].[Cities] ([CityID], [Name], [PostalCode], [Coordinates]) VALUES (2, N'Nowa Sól', N'67-100', 0xE6100000010C3B70CE88D2E64940C976BE9F1A6F2F40)
INSERT [dbo].[Cities] ([CityID], [Name], [PostalCode], [Coordinates]) VALUES (3, N'Zielona Góra', N'65-001', 0xE6100000010CD71533C2DBF7494037FC6EBA65072F40)
INSERT [dbo].[Cities] ([CityID], [Name], [PostalCode], [Coordinates]) VALUES (4, N'Szczecin', N'70-001', 0xE6100000010CC119FCFD62B64A406AFAEC80EB0A2D40)
INSERT [dbo].[Cities] ([CityID], [Name], [PostalCode], [Coordinates]) VALUES (5, N'Warszawa', N'00-001', 0xE6100000010C94347F4C6B1D4A408D0A9C6C03033540)
INSERT [dbo].[Cities] ([CityID], [Name], [PostalCode], [Coordinates]) VALUES (6, N'Głogów', N'67-200', 0xE6100000010C501C40BFEFD349406A6D1ADB6B193040)
INSERT [dbo].[Cities] ([CityID], [Name], [PostalCode], [Coordinates]) VALUES (7, N'Poznań', N'60-001', 0xE6100000010C8A75AA7CCF304A40D34B8C65FAE53040)
INSERT [dbo].[Cities] ([CityID], [Name], [PostalCode], [Coordinates]) VALUES (8, N'Wrocław', N'50-001', 0xE6100000010C0A698D412790494053D0ED258D013140)
INSERT [dbo].[Cities] ([CityID], [Name], [PostalCode], [Coordinates]) VALUES (9, N'Koszalin', N'75-001', 0xE6100000010C21C9ACDEE1184B408751103CBE313040)
INSERT [dbo].[Cities] ([CityID], [Name], [PostalCode], [Coordinates]) VALUES (10, N'Słupsk', N'76-200', 0xE6100000010CE04BE141B33B4B40172D40DB6A063140)
INSERT [dbo].[Cities] ([CityID], [Name], [PostalCode], [Coordinates]) VALUES (11, N'Gdynia', N'81-000', 0xE6100000010CF0332E1C083F4B40778192020B883240)
INSERT [dbo].[Cities] ([CityID], [Name], [PostalCode], [Coordinates]) VALUES (12, N'Gdańsk', N'80-001', 0xE6100000010CF3AB3940302D4B408B321B6492A13240)
INSERT [dbo].[Cities] ([CityID], [Name], [PostalCode], [Coordinates]) VALUES (13, N'Gdańsk', N'82-300', 0xE6100000010CECA529029C144B40F5143944DC683340)
INSERT [dbo].[Cities] ([CityID], [Name], [PostalCode], [Coordinates]) VALUES (14, N'Olsztyn', N'10-001', 0xE6100000010C1A87FA5DD8E24A40815D4D9EB2763440)
INSERT [dbo].[Cities] ([CityID], [Name], [PostalCode], [Coordinates]) VALUES (15, N'Grudziądz', N'86-300', 0xE6100000010C9E95B4E21BBC4A40AB2688BA0FC03240)
INSERT [dbo].[Cities] ([CityID], [Name], [PostalCode], [Coordinates]) VALUES (16, N'Bydgoszcz', N'85-001', 0xE6100000010CEF3CF19C2D904A4038876BB587093240)
INSERT [dbo].[Cities] ([CityID], [Name], [PostalCode], [Coordinates]) VALUES (17, N'Toruń', N'87-100', 0xE6100000010C50FEEE1D35824A400E4B033FAAA13240)
INSERT [dbo].[Cities] ([CityID], [Name], [PostalCode], [Coordinates]) VALUES (18, N'Włocławek', N'87-800', 0xE6100000010C9032E202D0564A401FF64201DB0D3340)
INSERT [dbo].[Cities] ([CityID], [Name], [PostalCode], [Coordinates]) VALUES (19, N'Płock', N'09-400', 0xE6100000010C103CBEBD6B464A40B0CBF09F6EB03340)
INSERT [dbo].[Cities] ([CityID], [Name], [PostalCode], [Coordinates]) VALUES (20, N'Łódź', N'90-001', 0xE6100000010CEC87D860E1E049405322895E467D3340)
INSERT [dbo].[Cities] ([CityID], [Name], [PostalCode], [Coordinates]) VALUES (21, N'Radom', N'26-600', 0xE6100000010C9335EA211AB34940A45016BEBE263540)
INSERT [dbo].[Cities] ([CityID], [Name], [PostalCode], [Coordinates]) VALUES (22, N'Białystok', N'15-001', 0xE6100000010CC170AE6186904A4029CFBC1C76233740)
INSERT [dbo].[Cities] ([CityID], [Name], [PostalCode], [Coordinates]) VALUES (23, N'Lublin', N'20-001', 0xE6100000010C09FD4CBD6E9D4940AB7AF99D268F3640)
INSERT [dbo].[Cities] ([CityID], [Name], [PostalCode], [Coordinates]) VALUES (24, N'Kielce', N'25-001', 0xE6100000010C2FF99FFCDD6D4940580053060E9C3440)
INSERT [dbo].[Cities] ([CityID], [Name], [PostalCode], [Coordinates]) VALUES (25, N'Kraków', N'30-001', 0xE6100000010C84BBB376DB0749400EDB166536F03340)
SET IDENTITY_INSERT [dbo].[Cities] OFF
