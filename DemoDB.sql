USE [master]
GO
/****** Object:  Database [DemoDB]    Script Date: 19-11-2021 17:44:54 ******/
CREATE DATABASE [DemoDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DemoDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DemoDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DemoDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DemoDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DemoDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DemoDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DemoDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DemoDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DemoDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DemoDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DemoDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DemoDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DemoDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DemoDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DemoDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DemoDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DemoDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DemoDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DemoDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DemoDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DemoDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DemoDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DemoDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DemoDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DemoDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DemoDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DemoDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DemoDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DemoDB] SET RECOVERY FULL 
GO
ALTER DATABASE [DemoDB] SET  MULTI_USER 
GO
ALTER DATABASE [DemoDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DemoDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DemoDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DemoDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DemoDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DemoDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DemoDB', N'ON'
GO
ALTER DATABASE [DemoDB] SET QUERY_STORE = OFF
GO
USE [DemoDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 19-11-2021 17:44:54 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 19-11-2021 17:44:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[PkDeptId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[PkDeptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 19-11-2021 17:44:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[PkEmpId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Designation] [nvarchar](max) NULL,
	[FkDeptId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[PkEmpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 19-11-2021 17:44:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[PkRoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[PkRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userProfiles]    Script Date: 19-11-2021 17:44:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userProfiles](
	[PkUserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[LastLoginDate] [datetime2](7) NULL,
	[EmailId] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[RegisteredDate] [datetime2](7) NOT NULL,
	[FkRoleId] [int] NOT NULL,
 CONSTRAINT [PK_userProfiles] PRIMARY KEY CLUSTERED 
(
	[PkUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211025055820_MyFirstMigration', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211108064532_added_Userprofile', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211109053555_added_regdate', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211119050844_Added_role', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211119051615_Addedrelation_userprofile', N'5.0.11')
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([PkDeptId], [Name], [IsActive]) VALUES (1, N'HR', 1)
INSERT [dbo].[Departments] ([PkDeptId], [Name], [IsActive]) VALUES (2, N'Account', 1)
INSERT [dbo].[Departments] ([PkDeptId], [Name], [IsActive]) VALUES (4, N'Sales', 1)
INSERT [dbo].[Departments] ([PkDeptId], [Name], [IsActive]) VALUES (5, N'Development', 1)
INSERT [dbo].[Departments] ([PkDeptId], [Name], [IsActive]) VALUES (6, N'Testing', 1)
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([PkEmpId], [Name], [Designation], [FkDeptId], [IsActive]) VALUES (3, N'JhonDoe', N'Developer', 5, 1)
INSERT [dbo].[Employees] ([PkEmpId], [Name], [Designation], [FkDeptId], [IsActive]) VALUES (4, N'jhon', N'Test', 6, 1)
INSERT [dbo].[Employees] ([PkEmpId], [Name], [Designation], [FkDeptId], [IsActive]) VALUES (5, N'Helan', N'Developer', 5, 1)
INSERT [dbo].[Employees] ([PkEmpId], [Name], [Designation], [FkDeptId], [IsActive]) VALUES (7, N'shyam', N'Tester', 6, 1)
INSERT [dbo].[Employees] ([PkEmpId], [Name], [Designation], [FkDeptId], [IsActive]) VALUES (8, N'Subham', N'Marketing', 4, 0)
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([PkRoleId], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([PkRoleId], [RoleName]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[userProfiles] ON 

INSERT [dbo].[userProfiles] ([PkUserId], [UserName], [Password], [Image], [LastLoginDate], [EmailId], [IsActive], [RegisteredDate], [FkRoleId]) VALUES (1, N'Srinivas', N'OvykBE/RV1uRu8eF2xYsoQZujBFUtvMS+AkTg2X0Z6E=', N'/Image/Profile/7552d831-effd-4a9b-9b12-b32edfb63a4b-pokemon.jpg', NULL, N'srinivas.i@deccansoft.net', 1, CAST(N'2021-11-19T12:43:06.1944340' AS DateTime2), 1)
INSERT [dbo].[userProfiles] ([PkUserId], [UserName], [Password], [Image], [LastLoginDate], [EmailId], [IsActive], [RegisteredDate], [FkRoleId]) VALUES (2, N'deepak', N'1Pnp4HoHkI72ALVu9hPCAPvTBhrbm5KcUTfevZHQy64=', N'/Image/Profile/b28e2db5-a4df-407c-88d4-851cdae5114b-pikachu.jpg', NULL, N'deepak24@gmail.com', 1, CAST(N'2021-11-19T14:08:50.7750017' AS DateTime2), 2)
SET IDENTITY_INSERT [dbo].[userProfiles] OFF
GO
/****** Object:  Index [IX_Employees_FkDeptId]    Script Date: 19-11-2021 17:44:54 ******/
CREATE NONCLUSTERED INDEX [IX_Employees_FkDeptId] ON [dbo].[Employees]
(
	[FkDeptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_userProfiles_FkRoleId]    Script Date: 19-11-2021 17:44:54 ******/
CREATE NONCLUSTERED INDEX [IX_userProfiles_FkRoleId] ON [dbo].[userProfiles]
(
	[FkRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[userProfiles] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [RegisteredDate]
GO
ALTER TABLE [dbo].[userProfiles] ADD  DEFAULT ((0)) FOR [FkRoleId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Departments_FkDeptId] FOREIGN KEY([FkDeptId])
REFERENCES [dbo].[Departments] ([PkDeptId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Departments_FkDeptId]
GO
ALTER TABLE [dbo].[userProfiles]  WITH CHECK ADD  CONSTRAINT [FK_userProfiles_Roles_FkRoleId] FOREIGN KEY([FkRoleId])
REFERENCES [dbo].[Roles] ([PkRoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[userProfiles] CHECK CONSTRAINT [FK_userProfiles_Roles_FkRoleId]
GO
USE [master]
GO
ALTER DATABASE [DemoDB] SET  READ_WRITE 
GO
