USE [master]
GO
/****** Object:  Database [GestionMatriculasDb]    Script Date: 3/05/2025 15:40:45 ******/
CREATE DATABASE [GestionMatriculasDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GestionMatriculasDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\GestionMatriculasDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GestionMatriculasDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\GestionMatriculasDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [GestionMatriculasDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GestionMatriculasDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GestionMatriculasDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GestionMatriculasDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GestionMatriculasDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GestionMatriculasDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GestionMatriculasDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [GestionMatriculasDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GestionMatriculasDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GestionMatriculasDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GestionMatriculasDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GestionMatriculasDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GestionMatriculasDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GestionMatriculasDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GestionMatriculasDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GestionMatriculasDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GestionMatriculasDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GestionMatriculasDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GestionMatriculasDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GestionMatriculasDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GestionMatriculasDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GestionMatriculasDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GestionMatriculasDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [GestionMatriculasDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GestionMatriculasDb] SET RECOVERY FULL 
GO
ALTER DATABASE [GestionMatriculasDb] SET  MULTI_USER 
GO
ALTER DATABASE [GestionMatriculasDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GestionMatriculasDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GestionMatriculasDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GestionMatriculasDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GestionMatriculasDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GestionMatriculasDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'GestionMatriculasDb', N'ON'
GO
ALTER DATABASE [GestionMatriculasDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [GestionMatriculasDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [GestionMatriculasDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/05/2025 15:40:45 ******/
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
/****** Object:  Table [dbo].[Courses]    Script Date: 3/05/2025 15:40:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enrollments]    Script Date: 3/05/2025 15:40:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[EnrollmentDate] [datetime2](7) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Enrollments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 3/05/2025 15:40:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250503154441_Initial', N'9.0.4')
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([Id], [Title]) VALUES (1, N'Matematica')
INSERT [dbo].[Courses] ([Id], [Title]) VALUES (3, N'Ciencia')
INSERT [dbo].[Courses] ([Id], [Title]) VALUES (4, N'Lenguaje')
INSERT [dbo].[Courses] ([Id], [Title]) VALUES (5, N'Biologia')
INSERT [dbo].[Courses] ([Id], [Title]) VALUES (6, N'Quimica')
INSERT [dbo].[Courses] ([Id], [Title]) VALUES (7, N'Historia')
INSERT [dbo].[Courses] ([Id], [Title]) VALUES (8, N'Politica')
INSERT [dbo].[Courses] ([Id], [Title]) VALUES (9, N'calculo')
INSERT [dbo].[Courses] ([Id], [Title]) VALUES (10, N'software')
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[Enrollments] ON 

INSERT [dbo].[Enrollments] ([Id], [StudentId], [CourseId], [EnrollmentDate], [Status]) VALUES (1, 1, 3, CAST(N'2025-05-02T00:00:00.0000000' AS DateTime2), N'Inactiva')
INSERT [dbo].[Enrollments] ([Id], [StudentId], [CourseId], [EnrollmentDate], [Status]) VALUES (3, 1, 1, CAST(N'2025-05-01T00:00:00.0000000' AS DateTime2), N'Activo')
INSERT [dbo].[Enrollments] ([Id], [StudentId], [CourseId], [EnrollmentDate], [Status]) VALUES (4, 2, 3, CAST(N'2025-05-01T00:00:00.0000000' AS DateTime2), N'Activo')
INSERT [dbo].[Enrollments] ([Id], [StudentId], [CourseId], [EnrollmentDate], [Status]) VALUES (5, 1, 5, CAST(N'2025-05-01T00:00:00.0000000' AS DateTime2), N'Activo')
INSERT [dbo].[Enrollments] ([Id], [StudentId], [CourseId], [EnrollmentDate], [Status]) VALUES (6, 1, 6, CAST(N'2025-05-01T00:00:00.0000000' AS DateTime2), N'activo')
INSERT [dbo].[Enrollments] ([Id], [StudentId], [CourseId], [EnrollmentDate], [Status]) VALUES (7, 2, 5, CAST(N'2025-05-01T00:00:00.0000000' AS DateTime2), N'activo')
INSERT [dbo].[Enrollments] ([Id], [StudentId], [CourseId], [EnrollmentDate], [Status]) VALUES (8, 2, 7, CAST(N'2025-05-01T00:00:00.0000000' AS DateTime2), N'activo')
INSERT [dbo].[Enrollments] ([Id], [StudentId], [CourseId], [EnrollmentDate], [Status]) VALUES (9, 2, 4, CAST(N'2025-05-01T00:00:00.0000000' AS DateTime2), N'activo')
INSERT [dbo].[Enrollments] ([Id], [StudentId], [CourseId], [EnrollmentDate], [Status]) VALUES (10, 2, 6, CAST(N'2025-05-02T00:00:00.0000000' AS DateTime2), N'activo')
INSERT [dbo].[Enrollments] ([Id], [StudentId], [CourseId], [EnrollmentDate], [Status]) VALUES (11, 2, 8, CAST(N'2025-05-02T00:00:00.0000000' AS DateTime2), N'activo')
INSERT [dbo].[Enrollments] ([Id], [StudentId], [CourseId], [EnrollmentDate], [Status]) VALUES (12, 2, 9, CAST(N'2025-05-02T00:00:00.0000000' AS DateTime2), N'Activo')
INSERT [dbo].[Enrollments] ([Id], [StudentId], [CourseId], [EnrollmentDate], [Status]) VALUES (13, 1, 10, CAST(N'2025-05-02T00:00:00.0000000' AS DateTime2), N'activo')
INSERT [dbo].[Enrollments] ([Id], [StudentId], [CourseId], [EnrollmentDate], [Status]) VALUES (14, 1, 9, CAST(N'2025-05-02T00:00:00.0000000' AS DateTime2), N'activo')
SET IDENTITY_INSERT [dbo].[Enrollments] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [Name]) VALUES (1, N'Pablo Alberto')
INSERT [dbo].[Students] ([Id], [Name]) VALUES (2, N'Pilar Santiago')
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
/****** Object:  Index [IX_Enrollments_CourseId]    Script Date: 3/05/2025 15:40:45 ******/
CREATE NONCLUSTERED INDEX [IX_Enrollments_CourseId] ON [dbo].[Enrollments]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Enrollments_StudentId_CourseId]    Script Date: 3/05/2025 15:40:45 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Enrollments_StudentId_CourseId] ON [dbo].[Enrollments]
(
	[StudentId] ASC,
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Enrollments]  WITH CHECK ADD  CONSTRAINT [FK_Enrollments_Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Enrollments] CHECK CONSTRAINT [FK_Enrollments_Courses_CourseId]
GO
ALTER TABLE [dbo].[Enrollments]  WITH CHECK ADD  CONSTRAINT [FK_Enrollments_Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Enrollments] CHECK CONSTRAINT [FK_Enrollments_Students_StudentId]
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateEnrollment]    Script Date: 3/05/2025 15:40:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CreateEnrollment]
    @StudentId INT,
    @CourseId INT,
    @EnrollmentDate DATE,
    @Status NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    
    IF NOT EXISTS (SELECT 1 FROM Students WHERE Id = @StudentId)
    BEGIN
        RAISERROR('El estudiante no existe.', 16, 1);
        RETURN;
    END

    
    IF NOT EXISTS (SELECT 1 FROM Courses WHERE Id = @CourseId)
    BEGIN
        RAISERROR('El curso no existe.', 16, 1);
        RETURN;
    END

    
    IF EXISTS (SELECT 1 FROM Enrollments WHERE StudentId = @StudentId AND CourseId = @CourseId)
    BEGIN
        RAISERROR('El estudiante ya está matriculado en este curso.', 16, 1);
        RETURN;
    END

    
    IF @EnrollmentDate > GETDATE()
    BEGIN
        RAISERROR('La fecha de matrícula no puede ser futura.', 16, 1);
        RETURN;
    END

    
    INSERT INTO Enrollments (StudentId, CourseId, EnrollmentDate, Status)
    VALUES (@StudentId, @CourseId, @EnrollmentDate, @Status);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetFilteredEnrollments]    Script Date: 3/05/2025 15:40:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetFilteredEnrollments]
    @StudentId INT = NULL,
    @CourseId INT = NULL,
    @Status NVARCHAR(50) = NULL
AS
BEGIN
    SELECT e.Id, e.StudentId, s.Name AS StudentName,
           e.CourseId, c.Title AS CourseTitle,
           e.EnrollmentDate, e.Status
    FROM Enrollments e
    INNER JOIN Students s ON s.Id = e.StudentId
    INNER JOIN Courses c ON c.Id = e.CourseId
    WHERE (@StudentId IS NULL OR e.StudentId = @StudentId)
      AND (@CourseId IS NULL OR e.CourseId = @CourseId)
      AND (@Status IS NULL OR e.Status = @Status)
END
GO
USE [master]
GO
ALTER DATABASE [GestionMatriculasDb] SET  READ_WRITE 
GO
