SET XACT_ABORT ON;  

CREATE DATABASE [Movies];
GO

BEGIN TRANSACTION;

USE [Movies];


CREATE TABLE [Movie] (
	[MovieId] INT NOT NULL IDENTITY,
	[Title] NVARCHAR(100) NOT NULL,
	[Price] DECIMAL(14,2) NOT NULL,
	[PosterUrl] NVARCHAR(256) NULL,
	[VideoUrl] NVARCHAR(256) NULL,
	[VideoPosterUrl] NVARCHAR(256) NULL,
	[Summary] NVARCHAR(1024) NULL,
	[ReleaseDate] DATE NULL,

	CONSTRAINT [PK_Movie] PRIMARY KEY ([MovieId])
);

COMMIT TRANSACTION;

SET IDENTITY_INSERT [dbo].[Movie] ON 

GO
INSERT [dbo].[Movie] ([MovieId], [Title], [Price], [PosterUrl], [VideoUrl], [VideoPosterUrl], [Summary], [ReleaseDate]) VALUES (1, N'The matrix', CAST(5.00 AS Decimal(14, 2)), N'', N'', N'', N'', CAST(N'1999-01-01' AS Date))
GO
INSERT [dbo].[Movie] ([MovieId], [Title], [Price], [PosterUrl], [VideoUrl], [VideoPosterUrl], [Summary], [ReleaseDate]) VALUES (2, N'Inception', CAST(7.00 AS Decimal(14, 2)), N'', N'', N'', N'', CAST(N'2010-01-01' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Movie] OFF
GO
