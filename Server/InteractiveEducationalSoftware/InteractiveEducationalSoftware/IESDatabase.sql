﻿USE [master]
GO
/****** Object:  Database [IES]    Script Date: 29/09/2022 04:22:15 ******/
CREATE DATABASE [IES]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IES', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\IES.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'IES_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\IES_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [IES] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IES].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IES] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IES] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IES] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IES] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IES] SET ARITHABORT OFF 
GO
ALTER DATABASE [IES] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [IES] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IES] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IES] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IES] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IES] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IES] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IES] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IES] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IES] SET  DISABLE_BROKER 
GO
ALTER DATABASE [IES] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IES] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IES] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IES] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IES] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IES] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [IES] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IES] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [IES] SET  MULTI_USER 
GO
ALTER DATABASE [IES] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IES] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IES] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IES] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [IES] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [IES] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [IES] SET QUERY_STORE = OFF
GO
USE [IES]
GO
/****** Object:  Table [dbo].[Answers]    Script Date: 29/09/2022 04:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answers](
	[AnswerId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](512) NOT NULL,
	[RelatedQuestionId] [int] NOT NULL,
 CONSTRAINT [PK_Answers] PRIMARY KEY CLUSTERED 
(
	[AnswerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chapters]    Script Date: 29/09/2022 04:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chapters](
	[ChapterId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Description] [nvarchar](256) NULL,
 CONSTRAINT [PK_Chapters] PRIMARY KEY CLUSTERED 
(
	[ChapterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lessons]    Script Date: 29/09/2022 04:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lessons](
	[LessonId] [int] IDENTITY(1,1) NOT NULL,
	[ChapterId] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](256) NULL,
	[Material] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 29/09/2022 04:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[QuestionId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](256) NOT NULL,
	[CorrectAnswerId] [int] NOT NULL,
	[Points] [int] NOT NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 29/09/2022 04:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Questions] FOREIGN KEY([RelatedQuestionId])
REFERENCES [dbo].[Questions] ([QuestionId])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Questions]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_CorrectAnswerId_Answers_AnswerId] FOREIGN KEY([CorrectAnswerId])
REFERENCES [dbo].[Answers] ([AnswerId])
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_CorrectAnswerId_Answers_AnswerId]
GO
USE [master]
GO
ALTER DATABASE [IES] SET  READ_WRITE 
GO
