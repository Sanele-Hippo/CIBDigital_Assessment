USE [master]
GO
/****** Object:  Database [CIBDigital]    Script Date: 7/14/2019 9:29:06 PM ******/
CREATE DATABASE [CIBDigital]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CIBDigital', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CIBDigital.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CIBDigital_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CIBDigital_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CIBDigital] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CIBDigital].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CIBDigital] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CIBDigital] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CIBDigital] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CIBDigital] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CIBDigital] SET ARITHABORT OFF 
GO
ALTER DATABASE [CIBDigital] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CIBDigital] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CIBDigital] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CIBDigital] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CIBDigital] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CIBDigital] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CIBDigital] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CIBDigital] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CIBDigital] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CIBDigital] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CIBDigital] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CIBDigital] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CIBDigital] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CIBDigital] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CIBDigital] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CIBDigital] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CIBDigital] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CIBDigital] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CIBDigital] SET  MULTI_USER 
GO
ALTER DATABASE [CIBDigital] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CIBDigital] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CIBDigital] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CIBDigital] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CIBDigital] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CIBDigital]
GO
/****** Object:  Table [dbo].[PhoneBook]    Script Date: 7/14/2019 9:29:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhoneBook](
	[Initial] [nchar](1) NULL,
	[Name] [nvarchar](100) NULL,
	[PhoneNumber] [nchar](10) NULL
) ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[sp_GetPhoneBookEntries]    Script Date: 7/14/2019 9:29:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetPhoneBookEntries]
	-- Add the parameters for the stored procedure here 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM [CIBDigital].[dbo].[PhoneBook] WITH (NOLOCK)
	ORDER BY Initial ASC

END

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertPhoneBookEntry]    Script Date: 7/14/2019 9:29:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertPhoneBookEntry] 
	-- Add the parameters for the stored procedure here
	@Initial nchar,
	@Name nvarchar(100),
	@PhoneNumber nchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [CIBDigital].[dbo].[PhoneBook](Initial,Name,PhoneNumber)
	VALUES(@Initial,@Name,@PhoneNumber)

END

GO
USE [master]
GO
ALTER DATABASE [CIBDigital] SET  READ_WRITE 
GO
