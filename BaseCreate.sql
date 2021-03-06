USE master
create database Library
go

USE [Library]
GO
ALTER TABLE [dbo].[BooksAuthors] DROP CONSTRAINT [FK_BooksAuthors_BookId]
GO
ALTER TABLE [dbo].[BooksAuthors] DROP CONSTRAINT [FK_BooksAuthors_AuthorId]
GO
/****** Object:  Table [dbo].[BooksAuthors]    Script Date: 12.06.2020 14:15:24 ******/
DROP TABLE [dbo].[BooksAuthors]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 12.06.2020 14:15:24 ******/
DROP TABLE [dbo].[Books]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 12.06.2020 14:15:24 ******/
DROP TABLE [dbo].[Authors]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 12.06.2020 14:15:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorId] [int] IDENTITY(1,1) NOT NULL,
	[AuthorName] [nvarchar](128) NOT NULL,
	[AuthorLastName] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 12.06.2020 14:15:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [nvarchar](128) NOT NULL,
	[PublishYear] [int] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BooksAuthors]    Script Date: 12.06.2020 14:15:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BooksAuthors](
	[AuthorId] [int] NOT NULL,
	[BookId] [int] NOT NULL,
 CONSTRAINT [PK_BooksAuthors] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC,
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([AuthorId], [AuthorName], [AuthorLastName]) VALUES (1, N'Stephen', N'King')
INSERT [dbo].[Authors] ([AuthorId], [AuthorName], [AuthorLastName]) VALUES (2, N'Edgar', N'Poe')
INSERT [dbo].[Authors] ([AuthorId], [AuthorName], [AuthorLastName]) VALUES (3, N'Charles', N'Dickens')
INSERT [dbo].[Authors] ([AuthorId], [AuthorName], [AuthorLastName]) VALUES (4, N'Mark', N'Twain')
INSERT [dbo].[Authors] ([AuthorId], [AuthorName], [AuthorLastName]) VALUES (5, N'Ernest', N'Hemingway')
INSERT [dbo].[Authors] ([AuthorId], [AuthorName], [AuthorLastName]) VALUES (6, N'FEDOR', N'DOSTOYEVSKY')
INSERT [dbo].[Authors] ([AuthorId], [AuthorName], [AuthorLastName]) VALUES (7, N'George', N'Orwell')
INSERT [dbo].[Authors] ([AuthorId], [AuthorName], [AuthorLastName]) VALUES (8, N'Mikhail', N'Bulgakov')
INSERT [dbo].[Authors] ([AuthorId], [AuthorName], [AuthorLastName]) VALUES (9, N'Arkadiy', N'Strugackiy')
INSERT [dbo].[Authors] ([AuthorId], [AuthorName], [AuthorLastName]) VALUES (10, N'Borisy', N'Strugackiy')
SET IDENTITY_INSERT [dbo].[Authors] OFF
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([BookId], [BookName], [PublishYear]) VALUES (1, N'Animal farm', 1945)
INSERT [dbo].[Books] ([BookId], [BookName], [PublishYear]) VALUES (2, N'Idiot', 1869)
INSERT [dbo].[Books] ([BookId], [BookName], [PublishYear]) VALUES (3, N'Devils', 1866)
INSERT [dbo].[Books] ([BookId], [BookName], [PublishYear]) VALUES (4, N'Beetle in the Anthill', 1980)
INSERT [dbo].[Books] ([BookId], [BookName], [PublishYear]) VALUES (5, N'Prisoners of Power', 1969)
INSERT [dbo].[Books] ([BookId], [BookName], [PublishYear]) VALUES (29, N'CreateTest', 1980)
INSERT [dbo].[Books] ([BookId], [BookName], [PublishYear]) VALUES (30, N'CreateTest', 1980)
INSERT [dbo].[Books] ([BookId], [BookName], [PublishYear]) VALUES (31, N'CreateTest', 1980)
INSERT [dbo].[Books] ([BookId], [BookName], [PublishYear]) VALUES (34, N'CreateTest', 1980)
INSERT [dbo].[Books] ([BookId], [BookName], [PublishYear]) VALUES (35, N'TestUpd', 2223)
SET IDENTITY_INSERT [dbo].[Books] OFF
INSERT [dbo].[BooksAuthors] ([AuthorId], [BookId]) VALUES (1, 35)
INSERT [dbo].[BooksAuthors] ([AuthorId], [BookId]) VALUES (2, 35)
INSERT [dbo].[BooksAuthors] ([AuthorId], [BookId]) VALUES (6, 2)
INSERT [dbo].[BooksAuthors] ([AuthorId], [BookId]) VALUES (6, 3)
INSERT [dbo].[BooksAuthors] ([AuthorId], [BookId]) VALUES (7, 1)
INSERT [dbo].[BooksAuthors] ([AuthorId], [BookId]) VALUES (9, 4)
INSERT [dbo].[BooksAuthors] ([AuthorId], [BookId]) VALUES (9, 5)
INSERT [dbo].[BooksAuthors] ([AuthorId], [BookId]) VALUES (9, 29)
INSERT [dbo].[BooksAuthors] ([AuthorId], [BookId]) VALUES (9, 34)
INSERT [dbo].[BooksAuthors] ([AuthorId], [BookId]) VALUES (10, 4)
INSERT [dbo].[BooksAuthors] ([AuthorId], [BookId]) VALUES (10, 5)
INSERT [dbo].[BooksAuthors] ([AuthorId], [BookId]) VALUES (10, 29)
INSERT [dbo].[BooksAuthors] ([AuthorId], [BookId]) VALUES (10, 34)
ALTER TABLE [dbo].[BooksAuthors]  WITH CHECK ADD  CONSTRAINT [FK_BooksAuthors_AuthorId] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([AuthorId])
GO
ALTER TABLE [dbo].[BooksAuthors] CHECK CONSTRAINT [FK_BooksAuthors_AuthorId]
GO
ALTER TABLE [dbo].[BooksAuthors]  WITH CHECK ADD  CONSTRAINT [FK_BooksAuthors_BookId] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([BookId])
GO
ALTER TABLE [dbo].[BooksAuthors] CHECK CONSTRAINT [FK_BooksAuthors_BookId]
GO
