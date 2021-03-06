USE [master]
GO
/****** Object:  Database [BloggingPlatformDB]    Script Date: 12.07.2018. 21:26:55 ******/
CREATE DATABASE [BloggingPlatformDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BloggingPlatformDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BloggingPlatformDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BloggingPlatformDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BloggingPlatformDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BloggingPlatformDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BloggingPlatformDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BloggingPlatformDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BloggingPlatformDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BloggingPlatformDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BloggingPlatformDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BloggingPlatformDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BloggingPlatformDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BloggingPlatformDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BloggingPlatformDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BloggingPlatformDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BloggingPlatformDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BloggingPlatformDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BloggingPlatformDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BloggingPlatformDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BloggingPlatformDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BloggingPlatformDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BloggingPlatformDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BloggingPlatformDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BloggingPlatformDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BloggingPlatformDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BloggingPlatformDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BloggingPlatformDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BloggingPlatformDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BloggingPlatformDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BloggingPlatformDB] SET  MULTI_USER 
GO
ALTER DATABASE [BloggingPlatformDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BloggingPlatformDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BloggingPlatformDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BloggingPlatformDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BloggingPlatformDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BloggingPlatformDB] SET QUERY_STORE = OFF
GO
USE [BloggingPlatformDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [BloggingPlatformDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12.07.2018. 21:26:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogPost]    Script Date: 12.07.2018. 21:26:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogPost](
	[BlogPostID] [int] IDENTITY(1,1) NOT NULL,
	[Slug] [varchar](110) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[FavoritesCount] [int] NOT NULL,
	[Favorited] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BlogPostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 12.07.2018. 21:26:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
	[BlogPostID] [int] NOT NULL,
	[Body] [nvarchar](500) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostTags]    Script Date: 12.07.2018. 21:26:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostTags](
	[BlogPostID] [int] NOT NULL,
	[TagID] [int] NOT NULL,
 CONSTRAINT [PK_PT] PRIMARY KEY CLUSTERED 
(
	[BlogPostID] ASC,
	[TagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 12.07.2018. 21:26:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[TagID] [int] IDENTITY(1,1) NOT NULL,
	[TagName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BlogPost] ON 

INSERT [dbo].[BlogPost] ([BlogPostID], [Slug], [Title], [Description], [Body], [CreatedAt], [UpdatedAt], [FavoritesCount], [Favorited]) VALUES (5, N'javascript-rocks', N'Javascript Rocks', N'This article disscuses how Javascript rocks', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce rutrum diam fringilla, elementum neque ut, mollis diam. Curabitur ornare vitae orci vitae lobortis. Aliquam vestibulum condimentum orci. Praesent finibus tellus efficitur lacus tincidunt, sit amet egestas purus tristique. Praesent placerat ultricies quam ut dignissim. Nulla facilisi. Maecenas volutpat mattis dolor, eu fringilla neque ornare vel. Morbi quis libero mollis, venenatis libero ac, congue nisl. Morbi congue finibus lacus, ut ultricies quam pulvinar sed. Curabitur facilisis dui malesuada eros eleifend, vel faucibus risus convallis. Cras eget erat a neque dictum semper sit amet eu neque. Suspendisse congue varius magna, porttitor consequat enim lobortis at. Nunc ultrices sem libero, ut ornare magna facilisis nec. Morbi et pellentesque elit, eu aliquet ex. In ultrices arcu sit amet nisl posuere rutrum.', CAST(N'2016-05-22T00:00:00.000' AS DateTime), CAST(N'2018-07-12T21:11:43.410' AS DateTime), 2, 1)
INSERT [dbo].[BlogPost] ([BlogPostID], [Slug], [Title], [Description], [Body], [CreatedAt], [UpdatedAt], [FavoritesCount], [Favorited]) VALUES (10, N'simple-decorator-pattern-tutorial', N'Simple decorator pattern tutorial', N'Explaining the decorator pattern and how you can wrap object into decorators', N'Nulla finibus odio semper feugiat varius. Proin mollis ante nec augue elementum, vitae porttitor libero finibus. Vestibulum porta ante id dui dapibus, in porttitor diam pellentesque. Aenean tincidunt sapien neque, quis bibendum enim commodo sed. Praesent ultricies nisi non lacinia commodo. Curabitur ac justo quis libero semper cursus. Fusce sollicitudin, libero eget pulvinar gravida, ipsum dui finibus nisi, ac finibus sem turpis eget nibh. Etiam rutrum dignissim ullamcorper.', CAST(N'2018-07-12T21:14:32.100' AS DateTime), CAST(N'2018-07-12T21:14:32.100' AS DateTime), 0, 0)
INSERT [dbo].[BlogPost] ([BlogPostID], [Slug], [Title], [Description], [Body], [CreatedAt], [UpdatedAt], [FavoritesCount], [Favorited]) VALUES (11, N'introduction-to-asp-net-core-21', N'Introduction to ASP .NET Core 2.1', N'See what the future of ASP .NET Core holds', N'Nullam lobortis nulla lectus, non congue orci tristique at. Integer nec sapien mattis, tempor libero nec, aliquet neque. Etiam aliquam tellus id lorem cursus ultrices ac ac eros. In gravida vehicula turpis, sed porta dolor rhoncus vitae. Nulla at massa quis nibh tempor consectetur. Maecenas facilisis vehicula odio feugiat auctor. Vestibulum ornare ex nec eros mattis interdum.', CAST(N'2018-07-12T21:18:20.067' AS DateTime), CAST(N'2018-07-12T21:18:20.067' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[BlogPost] OFF
SET IDENTITY_INSERT [dbo].[Comment] ON 

INSERT [dbo].[Comment] ([CommentID], [BlogPostID], [Body], [CreatedAt], [UpdatedAt]) VALUES (2, 5, N'Wow this is such a great post!', CAST(N'2018-07-12T21:12:25.760' AS DateTime), CAST(N'2018-07-12T21:12:25.760' AS DateTime))
INSERT [dbo].[Comment] ([CommentID], [BlogPostID], [Body], [CreatedAt], [UpdatedAt]) VALUES (3, 10, N'I don''t think I agree with your post', CAST(N'2018-07-12T21:15:47.430' AS DateTime), CAST(N'2018-07-12T21:15:47.430' AS DateTime))
INSERT [dbo].[Comment] ([CommentID], [BlogPostID], [Body], [CreatedAt], [UpdatedAt]) VALUES (4, 10, N'Hey I got a question hit me up at email@email.com', CAST(N'2018-07-12T21:16:09.000' AS DateTime), CAST(N'2018-07-12T21:16:09.000' AS DateTime))
INSERT [dbo].[Comment] ([CommentID], [BlogPostID], [Body], [CreatedAt], [UpdatedAt]) VALUES (5, 11, N'I hope they fixed the issue with the tag helper imports', CAST(N'2018-07-12T21:20:28.013' AS DateTime), CAST(N'2018-07-12T21:20:28.013' AS DateTime))
INSERT [dbo].[Comment] ([CommentID], [BlogPostID], [Body], [CreatedAt], [UpdatedAt]) VALUES (6, 11, N'Yey finally!', CAST(N'2018-07-12T21:20:40.203' AS DateTime), CAST(N'2018-07-12T21:20:40.203' AS DateTime))
SET IDENTITY_INSERT [dbo].[Comment] OFF
INSERT [dbo].[PostTags] ([BlogPostID], [TagID]) VALUES (5, 2)
INSERT [dbo].[PostTags] ([BlogPostID], [TagID]) VALUES (10, 3)
INSERT [dbo].[PostTags] ([BlogPostID], [TagID]) VALUES (10, 6)
INSERT [dbo].[PostTags] ([BlogPostID], [TagID]) VALUES (11, 3)
INSERT [dbo].[PostTags] ([BlogPostID], [TagID]) VALUES (11, 5)
SET IDENTITY_INSERT [dbo].[Tag] ON 

INSERT [dbo].[Tag] ([TagID], [TagName]) VALUES (1, N'Android')
INSERT [dbo].[Tag] ([TagID], [TagName]) VALUES (5, N'ASP .NET')
INSERT [dbo].[Tag] ([TagID], [TagName]) VALUES (6, N'Design Patterns')
INSERT [dbo].[Tag] ([TagID], [TagName]) VALUES (2, N'IOS')
INSERT [dbo].[Tag] ([TagID], [TagName]) VALUES (4, N'jQuery')
INSERT [dbo].[Tag] ([TagID], [TagName]) VALUES (3, N'Software')
SET IDENTITY_INSERT [dbo].[Tag] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__BlogPost__BC7B5FB6B0D63F8C]    Script Date: 12.07.2018. 21:26:57 ******/
ALTER TABLE [dbo].[BlogPost] ADD UNIQUE NONCLUSTERED 
(
	[Slug] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Tag__BDE0FD1DF380243B]    Script Date: 12.07.2018. 21:26:57 ******/
ALTER TABLE [dbo].[Tag] ADD UNIQUE NONCLUSTERED 
(
	[TagName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BlogPost] ADD  DEFAULT ((0)) FOR [FavoritesCount]
GO
ALTER TABLE [dbo].[BlogPost] ADD  DEFAULT ((0)) FOR [Favorited]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD FOREIGN KEY([BlogPostID])
REFERENCES [dbo].[BlogPost] ([BlogPostID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PostTags]  WITH CHECK ADD FOREIGN KEY([BlogPostID])
REFERENCES [dbo].[BlogPost] ([BlogPostID])
GO
ALTER TABLE [dbo].[PostTags]  WITH CHECK ADD FOREIGN KEY([TagID])
REFERENCES [dbo].[Tag] ([TagID])
GO
USE [master]
GO
ALTER DATABASE [BloggingPlatformDB] SET  READ_WRITE 
GO
