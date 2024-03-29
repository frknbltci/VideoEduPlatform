USE [master]
GO
/****** Object:  Database [MehmetEgitKurumsal]    Script Date: 12/16/2020 11:15:33 AM ******/
CREATE DATABASE [MehmetEgitKurumsal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MehmetEgitKurumsal', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\MehmetEgitKurumsal.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MehmetEgitKurumsal_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\MehmetEgitKurumsal_log.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MehmetEgitKurumsal] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MehmetEgitKurumsal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MehmetEgitKurumsal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET ARITHABORT OFF 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET  MULTI_USER 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MehmetEgitKurumsal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MehmetEgitKurumsal] SET DELAYED_DURABILITY = DISABLED 
GO
USE [MehmetEgitKurumsal]
GO
/****** Object:  Table [dbo].[Announcement]    Script Date: 12/16/2020 11:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Announcement](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NULL,
	[SortNumber] [int] NULL,
	[ActOrPass] [bit] NULL CONSTRAINT [DF_Announcement_ActOrPass]  DEFAULT ((0)),
	[AnContent] [nvarchar](max) NULL,
 CONSTRAINT [PK_Announcement] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Blog]    Script Date: 12/16/2020 11:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[SeoUrl] [nvarchar](max) NULL,
	[BlogName] [nvarchar](250) NULL,
	[MetaTitle] [nvarchar](250) NULL,
	[MetaDescription] [nvarchar](160) NULL,
	[CategoryID] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[BlogContent] [nvarchar](max) NULL,
	[UpdatedAt] [datetime] NULL,
	[Status] [bit] NULL CONSTRAINT [DF_Blog_Status]  DEFAULT ((1)),
 CONSTRAINT [PK_Blog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BlogCategory]    Script Date: 12/16/2020 11:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CatName] [nvarchar](250) NULL,
	[CatSeoUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_BlogCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BlogComment]    Script Date: 12/16/2020 11:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogComment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[AnswerCommentID] [int] NULL,
	[BlogID] [int] NULL,
	[UserID] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_BlogComment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contact]    Script Date: 12/16/2020 11:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NameSurname] [nvarchar](100) NULL,
	[Email] [nvarchar](150) NULL,
	[Phone] [nvarchar](20) NULL,
	[Message] [nvarchar](max) NULL,
	[Topic] [nvarchar](max) NULL,
	[CreatedAt] [datetime] NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContactMain]    Script Date: 12/16/2020 11:15:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactMain](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NameSurname] [nvarchar](250) NULL,
	[Mail] [nvarchar](150) NULL,
	[Phone] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NULL,
 CONSTRAINT [PK_ContactMain] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Galery]    Script Date: 12/16/2020 11:15:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Galery](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ImageUrl] [nvarchar](250) NULL,
 CONSTRAINT [PK_Galery] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GeneralSettings]    Script Date: 12/16/2020 11:15:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralSettings](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MetaTitle] [nvarchar](250) NULL,
	[MetaDescription] [nvarchar](160) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](250) NULL,
	[LogoUrl] [nvarchar](250) NULL,
	[FacebookUrl] [nvarchar](250) NULL,
	[TwitterUrl] [nvarchar](250) NULL,
	[InstagramUrl] [nvarchar](250) NULL,
	[Address] [nvarchar](max) NULL,
	[GoogleMapsCode] [nvarchar](max) NULL,
	[UserCount] [int] NULL,
	[EducationVideoCount] [int] NULL,
	[WatchHour] [int] NULL,
	[FooterNote] [nvarchar](200) NULL,
	[YoutubeUrl] [nvarchar](250) NULL,
 CONSTRAINT [PK_GeneralSettings] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Menu]    Script Date: 12/16/2020 11:15:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Link] [nvarchar](250) NULL,
	[SubID] [int] NULL CONSTRAINT [DF_Menu_SubID]  DEFAULT ((0)),
	[SortNumber] [int] NULL,
	[ActOrPass] [bit] NULL CONSTRAINT [DF_Menu_ActOrPass]  DEFAULT ((0)),
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Packet]    Script Date: 12/16/2020 11:15:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Packet](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PackageName] [nvarchar](max) NULL,
	[PacketDesc] [nvarchar](max) NULL,
	[PacketImgUrl] [nvarchar](max) NULL,
	[SeoUrlLink] [nvarchar](max) NULL,
	[PacketPrice] [float] NULL,
	[ActOrPass] [bit] NULL,
 CONSTRAINT [PK_Packet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Page]    Script Date: 12/16/2020 11:15:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Page](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Text] [nvarchar](max) NULL,
	[SeoUrl] [nvarchar](250) NULL,
	[MetaTitle] [nvarchar](250) NULL,
	[MetaDescription] [nvarchar](160) NULL,
	[ImgUrl] [nvarchar](max) NULL,
	[CreatedAt] [datetime] NULL,
	[Category] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Page] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Purchase]    Script Date: 12/16/2020 11:15:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[PacketID] [int] NULL,
	[UserID] [int] NULL,
	[sOrderID] [nvarchar](100) NULL,
 CONSTRAINT [PK_Purchase] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Slider]    Script Date: 12/16/2020 11:15:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slider](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Text] [nvarchar](250) NULL,
	[ImageUrl] [nvarchar](250) NULL,
	[Link] [nvarchar](250) NULL,
	[ButtonName] [nvarchar](250) NULL,
 CONSTRAINT [PK_Slider] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 12/16/2020 11:15:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](30) NULL,
	[Password] [nvarchar](30) NULL,
	[Name] [nvarchar](30) NULL,
	[Surname] [nvarchar](30) NULL,
	[Phone] [nvarchar](100) NULL,
	[Email] [nvarchar](50) NULL,
	[Resume] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[MemberShipDate] [datetime] NULL,
	[BirthDate] [datetime] NULL,
	[MailKey] [nvarchar](250) NULL,
	[Status] [bit] NULL CONSTRAINT [DF_User_Status]  DEFAULT ((0)),
	[Type] [bit] NULL CONSTRAINT [DF_User_Type]  DEFAULT ((0)),
	[Discount] [float] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Video]    Script Date: 12/16/2020 11:15:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Video](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VideoName] [nvarchar](100) NULL,
	[VideoUrl] [nvarchar](max) NULL,
	[VideoDescription] [nvarchar](max) NULL,
	[Preview] [bit] NULL CONSTRAINT [DF_Video_Preview]  DEFAULT ((0)),
	[UpdateAt] [datetime] NULL,
	[CreatedAt] [datetime] NULL,
	[PacketID] [int] NULL,
	[TeacherID] [int] NULL,
	[VideoLength] [time](7) NULL CONSTRAINT [DF_Video_VideoLength]  DEFAULT (NULL),
 CONSTRAINT [PK_Video] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VideoEducationTeacher]    Script Date: 12/16/2020 11:15:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VideoEducationTeacher](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Surname] [nvarchar](100) NULL,
	[SubTitle] [nvarchar](50) NULL,
	[Description] [nvarchar](250) NULL,
	[TwitterUrl] [nvarchar](max) NULL,
	[InstagramUrl] [nvarchar](max) NULL,
	[FacebookUrl] [nvarchar](max) NULL,
	[LinkedinUrl] [nvarchar](max) NULL,
	[ImgUrl] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](20) NULL,
	[Email] [nvarchar](200) NULL,
 CONSTRAINT [PK_VideoEducationTeacher] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Announcement] ON 

INSERT [dbo].[Announcement] ([ID], [Title], [Description], [SortNumber], [ActOrPass], [AnContent]) VALUES (1, N'Mehmet Eğit ', N'Duyuru 1 Deneme 1', 1, 1, N'duyuru1 ')
INSERT [dbo].[Announcement] ([ID], [Title], [Description], [SortNumber], [ActOrPass], [AnContent]) VALUES (2, N'Mehmet Eğit', N'Duyuru 2 Deneme 2', 2, 1, NULL)
INSERT [dbo].[Announcement] ([ID], [Title], [Description], [SortNumber], [ActOrPass], [AnContent]) VALUES (3, N'Mehmet Eğit ', N'Duyuru 3 Deneme 3', 3, 1, N'DUYURU 3')
INSERT [dbo].[Announcement] ([ID], [Title], [Description], [SortNumber], [ActOrPass], [AnContent]) VALUES (4, N'Mehmet Eğit ', N'Duyuru 4 Deneme 4', 4, 1, N'duyuru 4 ')
INSERT [dbo].[Announcement] ([ID], [Title], [Description], [SortNumber], [ActOrPass], [AnContent]) VALUES (5, N'Mehmet Eğit', N'Duyuru 5 Deneme 5', 5, 1, N'DUYURU 5')
INSERT [dbo].[Announcement] ([ID], [Title], [Description], [SortNumber], [ActOrPass], [AnContent]) VALUES (6, N'Mehmet Eğit', N'Duyuru 6 Deneme 6', 6, 1, NULL)
INSERT [dbo].[Announcement] ([ID], [Title], [Description], [SortNumber], [ActOrPass], [AnContent]) VALUES (7, N'Mehmet Eğit', N'Duyuru Deneme 36', 36, 0, N'dasdadadad')
INSERT [dbo].[Announcement] ([ID], [Title], [Description], [SortNumber], [ActOrPass], [AnContent]) VALUES (8, N'Deneme', N'Deneme Duyuru', 40, 0, N'Merhaba BU İÇERİK SİZİ İLGELENDİRİYORSA OKUMANIZI TAVSİYE EDERİM ')
INSERT [dbo].[Announcement] ([ID], [Title], [Description], [SortNumber], [ActOrPass], [AnContent]) VALUES (9, N'Mehmet Eğit ', N'Duyuru 8', 20, 0, N'Burası İçerik')
SET IDENTITY_INSERT [dbo].[Announcement] OFF
SET IDENTITY_INSERT [dbo].[Blog] ON 

INSERT [dbo].[Blog] ([ID], [ImageUrl], [SeoUrl], [BlogName], [MetaTitle], [MetaDescription], [CategoryID], [CreatedAt], [BlogContent], [UpdatedAt], [Status]) VALUES (1, N'/Assets/Images/BlogImages/e2906750-f63b-4cbb-87b9-e2472064759b.jpg', N'sad', N'Tarih Videoları Hakkında', NULL, NULL, 1, CAST(N'2020-12-10 00:00:00.000' AS DateTime), N'<div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a>  <div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a> ', CAST(N'2020-08-24 18:57:46.260' AS DateTime), 1)
INSERT [dbo].[Blog] ([ID], [ImageUrl], [SeoUrl], [BlogName], [MetaTitle], [MetaDescription], [CategoryID], [CreatedAt], [BlogContent], [UpdatedAt], [Status]) VALUES (2, N'/Assets/Images/BlogImages/e2906750-f63b-4cbb-87b9-e2472064759b.jpg', N'ewsad2', N'Coğrafya Videoları Hakkında', NULL, NULL, 2, CAST(N'2020-12-10 00:00:00.000' AS DateTime), N'<div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a>  <div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a> ', CAST(N'2020-08-24 18:57:46.260' AS DateTime), 1)
INSERT [dbo].[Blog] ([ID], [ImageUrl], [SeoUrl], [BlogName], [MetaTitle], [MetaDescription], [CategoryID], [CreatedAt], [BlogContent], [UpdatedAt], [Status]) VALUES (3, N'/Assets/Images/BlogImages/e2906750-f63b-4cbb-87b9-e2472064759b.jpg', N'sadasd', N'Blog Deneme 1', NULL, NULL, 3, CAST(N'2020-12-10 00:00:00.000' AS DateTime), N'<div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a>  <div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a> ', CAST(N'2020-08-24 18:57:46.260' AS DateTime), 1)
INSERT [dbo].[Blog] ([ID], [ImageUrl], [SeoUrl], [BlogName], [MetaTitle], [MetaDescription], [CategoryID], [CreatedAt], [BlogContent], [UpdatedAt], [Status]) VALUES (4, N'/Assets/Images/BlogImages/e2906750-f63b-4cbb-87b9-e2472064759b.jpg', N'asda', N'Blog Deneme2', NULL, NULL, 3, CAST(N'2020-12-10 00:00:00.000' AS DateTime), N'<div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a>  <div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a> ', CAST(N'2020-08-24 18:57:46.260' AS DateTime), 1)
INSERT [dbo].[Blog] ([ID], [ImageUrl], [SeoUrl], [BlogName], [MetaTitle], [MetaDescription], [CategoryID], [CreatedAt], [BlogContent], [UpdatedAt], [Status]) VALUES (5, N'/Assets/Images/BlogImages/e2906750-f63b-4cbb-87b9-e2472064759b.jpg', N'sadsad', N'Blog Deneme3', NULL, NULL, 3, CAST(N'2020-12-10 00:00:00.000' AS DateTime), N'<div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a>  <div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a> ', CAST(N'2020-08-24 18:57:46.260' AS DateTime), 1)
INSERT [dbo].[Blog] ([ID], [ImageUrl], [SeoUrl], [BlogName], [MetaTitle], [MetaDescription], [CategoryID], [CreatedAt], [BlogContent], [UpdatedAt], [Status]) VALUES (6, N'/Assets/Images/BlogImages/e2906750-f63b-4cbb-87b9-e2472064759b.jpg', N'ddgbx', N'Blog Deneme4', NULL, NULL, 3, CAST(N'2020-12-10 00:00:00.000' AS DateTime), N'<div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a>  <div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a> ', CAST(N'2020-08-24 18:57:46.260' AS DateTime), 1)
INSERT [dbo].[Blog] ([ID], [ImageUrl], [SeoUrl], [BlogName], [MetaTitle], [MetaDescription], [CategoryID], [CreatedAt], [BlogContent], [UpdatedAt], [Status]) VALUES (7, N'/Assets/Images/BlogImages/e2906750-f63b-4cbb-87b9-e2472064759b.jpg', N's', N'Blog Deneme5', NULL, NULL, 3, CAST(N'2020-12-10 00:00:00.000' AS DateTime), N'<div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a>  <div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a> ', CAST(N'2020-08-24 18:57:46.260' AS DateTime), 1)
INSERT [dbo].[Blog] ([ID], [ImageUrl], [SeoUrl], [BlogName], [MetaTitle], [MetaDescription], [CategoryID], [CreatedAt], [BlogContent], [UpdatedAt], [Status]) VALUES (8, N'/Assets/Images/BlogImages/e2906750-f63b-4cbb-87b9-e2472064759b.jpg', N'ddddd', N'Blog Deneme6', NULL, NULL, 3, CAST(N'2020-12-10 00:00:00.000' AS DateTime), N'<div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a>  <div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a> ', CAST(N'2020-08-24 18:57:46.260' AS DateTime), 1)
INSERT [dbo].[Blog] ([ID], [ImageUrl], [SeoUrl], [BlogName], [MetaTitle], [MetaDescription], [CategoryID], [CreatedAt], [BlogContent], [UpdatedAt], [Status]) VALUES (9, N'/Assets/Images/BlogImages/e2906750-f63b-4cbb-87b9-e2472064759b.jpg', N'asdaf', N'Blog Deneme7', NULL, NULL, 1, CAST(N'2020-12-10 00:00:00.000' AS DateTime), N'<div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a>  <div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a> ', CAST(N'2020-08-24 18:57:46.260' AS DateTime), 1)
INSERT [dbo].[Blog] ([ID], [ImageUrl], [SeoUrl], [BlogName], [MetaTitle], [MetaDescription], [CategoryID], [CreatedAt], [BlogContent], [UpdatedAt], [Status]) VALUES (10, N'/Assets/Images/BlogImages/e2906750-f63b-4cbb-87b9-e2472064759b.jpg', N'ggfg', N'Blog Deneme8', NULL, NULL, 1, CAST(N'2020-12-10 00:00:00.000' AS DateTime), N'<div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a>  <div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a> ', CAST(N'2020-08-24 18:57:46.260' AS DateTime), 1)
INSERT [dbo].[Blog] ([ID], [ImageUrl], [SeoUrl], [BlogName], [MetaTitle], [MetaDescription], [CategoryID], [CreatedAt], [BlogContent], [UpdatedAt], [Status]) VALUES (11, N'/Assets/Images/BlogImages/e2906750-f63b-4cbb-87b9-e2472064759b.jpg', N'cxcb', N'Blog Deneme9', NULL, NULL, 2, CAST(N'2020-12-10 00:00:00.000' AS DateTime), N'<div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a>  <div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a> ', CAST(N'2020-08-24 18:57:46.260' AS DateTime), 1)
INSERT [dbo].[Blog] ([ID], [ImageUrl], [SeoUrl], [BlogName], [MetaTitle], [MetaDescription], [CategoryID], [CreatedAt], [BlogContent], [UpdatedAt], [Status]) VALUES (12, N'/Assets/Images/BlogImages/e2906750-f63b-4cbb-87b9-e2472064759b.jpg', N'jhgf', N'Blog Deneme10', NULL, NULL, 2, CAST(N'2020-12-10 00:00:00.000' AS DateTime), N'<div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a>  <div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a> ', CAST(N'2020-08-24 18:57:46.260' AS DateTime), 1)
INSERT [dbo].[Blog] ([ID], [ImageUrl], [SeoUrl], [BlogName], [MetaTitle], [MetaDescription], [CategoryID], [CreatedAt], [BlogContent], [UpdatedAt], [Status]) VALUES (13, N'/Assets/Images/BlogImages/e2906750-f63b-4cbb-87b9-e2472064759b.jpg', N'dhjg', N'Blog Deneme11', NULL, NULL, 3, CAST(N'2020-12-10 00:00:00.000' AS DateTime), N'<div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a>  <div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a> ', CAST(N'2020-08-24 18:57:46.260' AS DateTime), 1)
INSERT [dbo].[Blog] ([ID], [ImageUrl], [SeoUrl], [BlogName], [MetaTitle], [MetaDescription], [CategoryID], [CreatedAt], [BlogContent], [UpdatedAt], [Status]) VALUES (14, N'/Assets/Images/BlogImages/e2906750-f63b-4cbb-87b9-e2472064759b.jpg', N'werrg', N'Blog Deneme12', NULL, NULL, 3, CAST(N'2020-12-10 00:00:00.000' AS DateTime), N'<div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a>  <div>Mehmet Egit Kurumsal <p>Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit </p></div><a>Deneme Yazisi bu bir deneme yazisidir burasi <span>Description kismidir bu bir deneme yazisidir</span></a> ', CAST(N'2020-08-24 18:57:46.260' AS DateTime), 1)
INSERT [dbo].[Blog] ([ID], [ImageUrl], [SeoUrl], [BlogName], [MetaTitle], [MetaDescription], [CategoryID], [CreatedAt], [BlogContent], [UpdatedAt], [Status]) VALUES (15, NULL, N'grgdf', N'deneme', NULL, NULL, 1, CAST(N'2020-08-24 18:57:46.260' AS DateTime), N'<p>Mehmet Eğit<p>', CAST(N'2020-08-24 18:57:46.260' AS DateTime), 1)
INSERT [dbo].[Blog] ([ID], [ImageUrl], [SeoUrl], [BlogName], [MetaTitle], [MetaDescription], [CategoryID], [CreatedAt], [BlogContent], [UpdatedAt], [Status]) VALUES (16, N'/Assets/Images/BlogImages/25bf7392-5144-47f9-bdea-90e2bcf8fbd3.jpg', N'cog-temel-1', N'Coğrafya Temel Konular 1', NULL, NULL, 2, CAST(N'2020-08-24 19:22:40.797' AS DateTime), N'                                    <p>Mehmet Eğit<p>
                            ', CAST(N'2020-09-02 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Blog] ([ID], [ImageUrl], [SeoUrl], [BlogName], [MetaTitle], [MetaDescription], [CategoryID], [CreatedAt], [BlogContent], [UpdatedAt], [Status]) VALUES (17, N'/Assets/Images/BlogImages/a66784e1-0a74-4ede-a770-b2b421017b44.jpg', N'aaaaa', N'deneme deneme', NULL, NULL, 3, CAST(N'2020-09-02 12:40:42.360' AS DateTime), N'<div>sadfsdfsad</div>

<p>dasddasad</p>
', CAST(N'2020-09-02 12:40:42.360' AS DateTime), NULL)
INSERT [dbo].[Blog] ([ID], [ImageUrl], [SeoUrl], [BlogName], [MetaTitle], [MetaDescription], [CategoryID], [CreatedAt], [BlogContent], [UpdatedAt], [Status]) VALUES (18, N'/Assets/Images/BlogImages/47e7e81b-f05c-4835-8dc2-e349536efdd1.jpg', N'deddeme', N'deneme deneme', NULL, NULL, 3, CAST(N'2020-09-02 12:52:17.823' AS DateTime), NULL, CAST(N'2020-09-02 12:52:17.823' AS DateTime), NULL)
INSERT [dbo].[Blog] ([ID], [ImageUrl], [SeoUrl], [BlogName], [MetaTitle], [MetaDescription], [CategoryID], [CreatedAt], [BlogContent], [UpdatedAt], [Status]) VALUES (19, N'/Assets/Images/BlogImages/8f8d6029-3cd6-47c2-9477-f355725ad9f6.jpg', N'devvcv', N'deneme32', NULL, NULL, 3, CAST(N'2020-09-02 12:57:07.767' AS DateTime), N'<p>dasadadada</p>
', CAST(N'2020-09-08 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Blog] ([ID], [ImageUrl], [SeoUrl], [BlogName], [MetaTitle], [MetaDescription], [CategoryID], [CreatedAt], [BlogContent], [UpdatedAt], [Status]) VALUES (20, N'/Assets/Images/BlogImages/90d23e9e-7a8e-4d87-b9bd-79f1c93575a1.jpg', N'tarih-boyledir-istee', N'TARİHH', NULL, NULL, 1, CAST(N'2020-09-02 13:01:12.057' AS DateTime), N'                                    <p>dasdadasdasdasdasdasdsadad</p>

                            ', CAST(N'2020-09-02 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Blog] ([ID], [ImageUrl], [SeoUrl], [BlogName], [MetaTitle], [MetaDescription], [CategoryID], [CreatedAt], [BlogContent], [UpdatedAt], [Status]) VALUES (21, N'/Assets/Images/noImgMan.jpg', N'tarih-boyledir-ist', N'ŞİMDE DENE', NULL, NULL, 1, CAST(N'2020-09-02 13:02:51.140' AS DateTime), N'                                                                                                                                                                                                                        <p>dasdfsadas</p>

                            
                            
                            
                            
                            
                            ', CAST(N'2020-09-03 00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Blog] OFF
SET IDENTITY_INSERT [dbo].[BlogCategory] ON 

INSERT [dbo].[BlogCategory] ([ID], [CatName], [CatSeoUrl]) VALUES (1, N'TARİH EĞİTİMLERİ', N'tarih-egitimleri')
INSERT [dbo].[BlogCategory] ([ID], [CatName], [CatSeoUrl]) VALUES (2, N'COĞRAFYA EĞİTİMLERİ', N'cografya-egitimleri')
INSERT [dbo].[BlogCategory] ([ID], [CatName], [CatSeoUrl]) VALUES (3, N'DİĞER ', N'diger')
SET IDENTITY_INSERT [dbo].[BlogCategory] OFF
SET IDENTITY_INSERT [dbo].[Contact] ON 

INSERT [dbo].[Contact] ([ID], [NameSurname], [Email], [Phone], [Message], [Topic], [CreatedAt]) VALUES (1, N'Furkan Baltacı', N'fbaltaci.34@gmail.com', N'+905348420560', N'DENEM DENEMEDENEMEDENEMEDENEMEDENEMEDENEMEDENEMEDENEMEDENEMEDENEMEDENEMEDENEMEDENEMEDENEMEDENEMEDENEMEDENEMEDENEMEDENEMEDENEMEDENEMEDENEMEE', N'DENEME', CAST(N'2020-09-04 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Contact] OFF
SET IDENTITY_INSERT [dbo].[ContactMain] ON 

INSERT [dbo].[ContactMain] ([ID], [NameSurname], [Mail], [Phone], [CreatedAt]) VALUES (1, N'Furkan Baltacı', N'deneme@gmail.com', N'5010101010', CAST(N'2020-05-24 00:00:00.000' AS DateTime))
INSERT [dbo].[ContactMain] ([ID], [NameSurname], [Mail], [Phone], [CreatedAt]) VALUES (2, N'Furkan', N'fbaltaci.34@gmail.com', N'+905348420560', CAST(N'2020-08-28 15:36:03.243' AS DateTime))
SET IDENTITY_INSERT [dbo].[ContactMain] OFF
SET IDENTITY_INSERT [dbo].[GeneralSettings] ON 

INSERT [dbo].[GeneralSettings] ([ID], [MetaTitle], [MetaDescription], [Phone], [Email], [LogoUrl], [FacebookUrl], [TwitterUrl], [InstagramUrl], [Address], [GoogleMapsCode], [UserCount], [EducationVideoCount], [WatchHour], [FooterNote], [YoutubeUrl]) VALUES (1, NULL, NULL, N'(0551) 054 7547', N'info@mehmetegit.com', N'/Assets/Images/logom.png', N'www.facebook.com', N'www.twitter.com/mehmetEgit', N'www.instagram.com/mehmetEgit', N'Üniversite Mahallesi Sıhhiye Sokak Milim Plaza
No:3 Kat:1 Avcılar / İstanbul', N'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3011.6056504502258!2d28.713755515704634!3d40.99011522849061!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14caa1faefe93f8b%3A0xcbdb286108b3976c!2sYaz%C4%B1l%C4%B1mer%20Teknoloji%20-%20SEO%20-%20Web%20Tasar%C4%B1m%20-%20Web%20Yaz%C4%B1l%C4%B1m!5e0!3m2!1str!2str!4v1599224854056!5m2!1str!2str     ', 5000, 120, 150000, N'Bize Ulaşın', N'www.youtube.com/channel/UCTQHj7_zzc6UKmdxxkHknxQ')
SET IDENTITY_INSERT [dbo].[GeneralSettings] OFF
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([ID], [Title], [Link], [SubID], [SortNumber], [ActOrPass], [Description]) VALUES (1, N'ANASAYFA', N'/', 0, 1, 1, N'MEHMET EĞİT')
INSERT [dbo].[Menu] ([ID], [Title], [Link], [SubID], [SortNumber], [ActOrPass], [Description]) VALUES (2, N'HAKKIMIZDA', N'/hakkimizda', 0, 2, 1, N'BİZ KİMİZ ?')
INSERT [dbo].[Menu] ([ID], [Title], [Link], [SubID], [SortNumber], [ActOrPass], [Description]) VALUES (3, N'VİDEO EĞİTİM PAKETLERİMİZ', N'/VideoEduSystem/Index', 0, 3, 1, N'Sistem Nasıl İşliyor?')
INSERT [dbo].[Menu] ([ID], [Title], [Link], [SubID], [SortNumber], [ActOrPass], [Description]) VALUES (4, N'MEHMET EĞİT FORUM', N'/', 0, 4, 1, N'FORUM ALANI')
INSERT [dbo].[Menu] ([ID], [Title], [Link], [SubID], [SortNumber], [ActOrPass], [Description]) VALUES (5, N'MEHMET EĞİT BLOG', N'/Blog/Index', 0, 5, 1, N'BLOG YAZILARIMIZ')
INSERT [dbo].[Menu] ([ID], [Title], [Link], [SubID], [SortNumber], [ActOrPass], [Description]) VALUES (6, N'İLETİŞİM', N'/Contact/Index', 0, 6, 1, N'BİZE ULAŞINIZ')
SET IDENTITY_INSERT [dbo].[Menu] OFF
SET IDENTITY_INSERT [dbo].[Packet] ON 

INSERT [dbo].[Packet] ([ID], [PackageName], [PacketDesc], [PacketImgUrl], [SeoUrlLink], [PacketPrice], [ActOrPass]) VALUES (1, N'COĞRAFYA EĞİTİMİ ', N'KPSS HAZIRLIK SETİ', N'/Assets/Images/PacketImages/df0c8370-e10e-4ca3-bd45-a791b3ec22c1.jpg', N'cog-egitim', 200.2, 1)
INSERT [dbo].[Packet] ([ID], [PackageName], [PacketDesc], [PacketImgUrl], [SeoUrlLink], [PacketPrice], [ActOrPass]) VALUES (2, N'TARİH EĞİTİMİ', N'ALES HAZIRLIK SETİ', N'/Assets/images/demo.png', N'tarih-egitim', 215.15, 1)
INSERT [dbo].[Packet] ([ID], [PackageName], [PacketDesc], [PacketImgUrl], [SeoUrlLink], [PacketPrice], [ActOrPass]) VALUES (3, N'COĞRAFYA EĞİTİMİ OVALAR', N' KPSS Lisans için; Bu Derste ovalar anlatılmıştır.', N'/Assets/Images/PacketImages/521cbf64-2869-4d6f-bcbf-70259179685d.jpg', N'cografya-egitimi-ovalar', 255.16, 1)
SET IDENTITY_INSERT [dbo].[Packet] OFF
SET IDENTITY_INSERT [dbo].[Page] ON 

INSERT [dbo].[Page] ([ID], [Title], [Text], [SeoUrl], [MetaTitle], [MetaDescription], [ImgUrl], [CreatedAt], [Category], [UpdatedAt], [Status]) VALUES (1, N'Tarih Eğitimi Hakkında Bilgi', N'<div style="text-align: center;"><img alt="" src="https://www.dunyaatlasi.com/wp-content/uploads/2018/09/resim-tablo-nasil-okunur-1280x720.jpg" style="height:72px; width:128px" />DDDDD SADASDADSADSADSAD</div>
', N'tarihin-tozlu-sayfalari', NULL, NULL, N'/Assets/Images/BlogImages/e2906750-f63b-4cbb-87b9-e2472064759b.jpg', CAST(N'2020-10-11 00:00:00.000' AS DateTime), 0, CAST(N'2020-09-03 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Page] ([ID], [Title], [Text], [SeoUrl], [MetaTitle], [MetaDescription], [ImgUrl], [CreatedAt], [Category], [UpdatedAt], [Status]) VALUES (2, N'Coğrafya Eğitimi Hakkında Bilgi', N'<div>Mehmet Egit Kurumsal Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit Deneme Yazisi bu bir</div>', N'asd', NULL, NULL, N'/Assets/Images/BlogImages/e2906750-f63b-4cbb-87b9-e2472064759b.jpg', CAST(N'2020-10-11 00:00:00.000' AS DateTime), 1, CAST(N'2020-10-11 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Page] ([ID], [Title], [Text], [SeoUrl], [MetaTitle], [MetaDescription], [ImgUrl], [CreatedAt], [Category], [UpdatedAt], [Status]) VALUES (3, N'Tarih Eğitimi Nasıl Alınır', N'<div>Mehmet Egit Kurumsal Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit Deneme Yazisi bu bir</div>', N'saddd', NULL, NULL, N'/Assets/Images/BlogImages/e2906750-f63b-4cbb-87b9-e2472064759b.jpg', CAST(N'2020-10-11 00:00:00.000' AS DateTime), 2, CAST(N'2020-10-11 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Page] ([ID], [Title], [Text], [SeoUrl], [MetaTitle], [MetaDescription], [ImgUrl], [CreatedAt], [Category], [UpdatedAt], [Status]) VALUES (4, N'Tarih Eğitimi Nasıl Alınır 2', N'<div>Mehmet Egit Kurumsal Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit Deneme Yazisi bu bir</div>', N'fff', NULL, NULL, N'/Assets/Images/BlogImages/e2906750-f63b-4cbb-87b9-e2472064759b.jpg', CAST(N'2020-10-11 00:00:00.000' AS DateTime), 2, CAST(N'2020-10-11 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Page] ([ID], [Title], [Text], [SeoUrl], [MetaTitle], [MetaDescription], [ImgUrl], [CreatedAt], [Category], [UpdatedAt], [Status]) VALUES (5, N'Coğrafya Eğitimi Nasıl Alınır', N'                                                                                                                                                                                    <div>Mehmet Egit Kurumsal Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit Deneme Yazisi bu bir</div>
                            
                            
                            
                            
                            ', N'sdf-22', NULL, NULL, N'/Assets/Images/BlogImages/e2906750-f63b-4cbb-87b9-e2472064759b.jpg', CAST(N'2020-10-11 00:00:00.000' AS DateTime), 0, CAST(N'2020-09-03 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Page] ([ID], [Title], [Text], [SeoUrl], [MetaTitle], [MetaDescription], [ImgUrl], [CreatedAt], [Category], [UpdatedAt], [Status]) VALUES (6, N'Sistem Bilgi Sayfaları 1', N'<div>Mehmet Egit Kurumsal Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit Deneme Yazisi bu bir</div>', N'sadasdw', NULL, NULL, N'/Assets/Images/BlogImages/e2906750-f63b-4cbb-87b9-e2472064759b.jpg', CAST(N'2020-10-11 00:00:00.000' AS DateTime), 2, CAST(N'2020-10-11 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Page] ([ID], [Title], [Text], [SeoUrl], [MetaTitle], [MetaDescription], [ImgUrl], [CreatedAt], [Category], [UpdatedAt], [Status]) VALUES (7, N'Sistem Bilgi Sayfaları 2', N'<div>Mehmet Egit Kurumsal Mehmet Egit Kurumsal Kaliteli bir egitim i&ccedil;in mehmet egit Deneme Y<img alt="" src="data:image/jpeg;base64,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" style="height:194px; width:259px" />azisi bu bir<strong>asdasdas SFADDASDASDASDSAD</strong></div>
', N'sistem-bilgi-sayfalari2', NULL, NULL, N'/Assets/Images/PageImages/4f38a615-5679-4126-a1e8-d0d00b8c98ae.jpg', CAST(N'2020-10-11 00:00:00.000' AS DateTime), 0, CAST(N'2020-09-03 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Page] ([ID], [Title], [Text], [SeoUrl], [MetaTitle], [MetaDescription], [ImgUrl], [CreatedAt], [Category], [UpdatedAt], [Status]) VALUES (8, N'Bilgi Sayfaları', N'<div>Mehmet Egit Kurumsal Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit Deneme Yazisi bu bir</div>', N'345gfd', NULL, NULL, NULL, CAST(N'2020-10-11 00:00:00.000' AS DateTime), 1, CAST(N'2020-10-11 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Page] ([ID], [Title], [Text], [SeoUrl], [MetaTitle], [MetaDescription], [ImgUrl], [CreatedAt], [Category], [UpdatedAt], [Status]) VALUES (9, N'Bilgi Sayfaları 2', N'<div>Mehmet Egit Kurumsal Mehmet Egit Kurumsal Kaliteli bir egitim için mehmet egit Deneme Yazisi bu bir</div>', N'dsasdh', NULL, NULL, N'/Assets/Images/BlogImages/e2906750-f63b-4cbb-87b9-e2472064759b.jpg', CAST(N'2020-10-11 00:00:00.000' AS DateTime), 1, CAST(N'2020-10-11 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Page] ([ID], [Title], [Text], [SeoUrl], [MetaTitle], [MetaDescription], [ImgUrl], [CreatedAt], [Category], [UpdatedAt], [Status]) VALUES (10, N'casccaa', N'<p>dasdadadasdfafsdfsdfsfsdfsdfcff</p>

<p>&nbsp;</p>

<p><strong>fsdfsfsdfsdfsdfsfsfdsf</strong></p>

<p style="text-align:center"><strong>fdfsdfsf</strong></p>
', N'cografya-ya-merhaba', NULL, NULL, N'/Assets/Images/BlogImages/e2906750-f63b-4cbb-87b9-e2472064759b.jpg', CAST(N'2020-09-03 15:38:22.950' AS DateTime), 1, CAST(N'2020-07-09 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Page] ([ID], [Title], [Text], [SeoUrl], [MetaTitle], [MetaDescription], [ImgUrl], [CreatedAt], [Category], [UpdatedAt], [Status]) VALUES (11, N'Hakkımızda', N'<p><img alt="" src="https://www.google.com/url?sa=i&amp;url=https%3A%2F%2Fwww.mehmetegit.com%2F&amp;psig=AOvVaw0fDRyEnrtOaQKuMyCoe4Kx&amp;ust=1599567321294000&amp;source=images&amp;cd=vfe&amp;ved=0CAIQjRxqFwoTCPCY7uKC1-sCFQAAAAAdAAAAABAD" /><img alt="" src="https://www.google.com/url?sa=i&amp;url=https%3A%2F%2Fwww.mehmetegit.com%2F&amp;psig=AOvVaw0fDRyEnrtOaQKuMyCoe4Kx&amp;ust=1599567321294000&amp;source=images&amp;cd=vfe&amp;ved=0CAIQjRxqFwoTCPCY7uKC1-sCFQAAAAAdAAAAABAD" /><img alt="" src="https://www.mehmetegit.com/app/img/logo.png" style="height:183px; width:150px" />Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas feugiat consequat diam. Maecenas metus. Vivamus diam purus, cursus a, commodo non, facilisis vitae, nulla. Aenean dictum lacinia tortor. Nunc iaculis, nibh non iaculis aliquam, orci felis euismod neque, sed ornare massa mauris sed velit. Nulla pretium mi et risus. Fusce mi pede, tempor id, cursus ac, ullamcorper nec, enim. Sed tortor. Curabitur molestie. Duis velit augue, condimentum at, ultrices a, luctus ut, orci. Donec pellentesque egestas eros. Integer cursus, augue in cursus faucibus, eros pede bibendum sem, in tempus tellus justo quis ligula. Etiam eget tortor. Vestibulum rutrum, est ut placerat elementum, lectus nisl aliquam velit, tempor aliquam eros nunc nonummy metus. In eros metus, gravida a, gravida sed, lobortis id, turpis. Ut ultrices, ipsum at venenatis fringilla, sem nulla lacinia tellus, eget aliquet turpis mauris non enim. Nam turpis. Suspendisse lacinia. Curabitur ac tortor ut ipsum egestas elementum. Nunc imperdiet gravida mauris.</p>
', N'hakkimizda', NULL, NULL, N'/Assets/Images/noImgMan.jpg', CAST(N'2020-07-09 00:00:00.000' AS DateTime), 0, CAST(N'2020-09-07 00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Page] OFF
SET IDENTITY_INSERT [dbo].[Purchase] ON 

INSERT [dbo].[Purchase] ([ID], [StartDate], [EndDate], [PacketID], [UserID], [sOrderID]) VALUES (1, CAST(N'2020-08-27 00:00:00.000' AS DateTime), CAST(N'2021-08-27 00:00:00.000' AS DateTime), 1, 2, NULL)
INSERT [dbo].[Purchase] ([ID], [StartDate], [EndDate], [PacketID], [UserID], [sOrderID]) VALUES (4, CAST(N'2020-05-04 00:00:00.000' AS DateTime), CAST(N'2021-05-04 00:00:00.000' AS DateTime), 2, 6, NULL)
INSERT [dbo].[Purchase] ([ID], [StartDate], [EndDate], [PacketID], [UserID], [sOrderID]) VALUES (5, CAST(N'2020-05-04 00:00:00.000' AS DateTime), CAST(N'2020-05-04 00:00:00.000' AS DateTime), 2, 7, NULL)
INSERT [dbo].[Purchase] ([ID], [StartDate], [EndDate], [PacketID], [UserID], [sOrderID]) VALUES (1002, CAST(N'2020-05-04 00:00:00.000' AS DateTime), CAST(N'2020-05-04 00:00:00.000' AS DateTime), 1, 33, NULL)
INSERT [dbo].[Purchase] ([ID], [StartDate], [EndDate], [PacketID], [UserID], [sOrderID]) VALUES (1003, CAST(N'2020-05-04 00:00:00.000' AS DateTime), CAST(N'2020-05-04 00:00:00.000' AS DateTime), 2, 33, NULL)
INSERT [dbo].[Purchase] ([ID], [StartDate], [EndDate], [PacketID], [UserID], [sOrderID]) VALUES (1004, CAST(N'2020-05-04 00:00:00.000' AS DateTime), CAST(N'2020-05-04 00:00:00.000' AS DateTime), 1, 31, NULL)
SET IDENTITY_INSERT [dbo].[Purchase] OFF
SET IDENTITY_INSERT [dbo].[Slider] ON 

INSERT [dbo].[Slider] ([ID], [Title], [Text], [ImageUrl], [Link], [ButtonName]) VALUES (1, N'Video Eğitim Başarı Salonlarımız Burada', N'Mehmet Eğit Eğitim Dünyasına Hoş Geldiniz', N'/Assets/Images/c49dee09-df5a-4aec-bb10-f0f2425c2166.jpg', N'/VideoEduSystem/Index', N'Video Eğitimlerimiz İçin Tıklayınız')
SET IDENTITY_INSERT [dbo].[Slider] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [UserName], [Password], [Name], [Surname], [Phone], [Email], [Resume], [ImageUrl], [MemberShipDate], [BirthDate], [MailKey], [Status], [Type], [Discount]) VALUES (1, N'furkan', N'furkan', N'Furkan', N'Baltacı2', N'123123    ', N'fbaltaci.334@gmail.com', N'Merhaba Furkan Ben', N'/Assets/Images/AdminImages/2a0f030b-862e-4b62-8b1b-6219eb957663.jpg', CAST(N'2020-08-07 00:00:00.000' AS DateTime), CAST(N'1997-10-21 00:00:00.000' AS DateTime), NULL, 0, 1, NULL)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Name], [Surname], [Phone], [Email], [Resume], [ImageUrl], [MemberShipDate], [BirthDate], [MailKey], [Status], [Type], [Discount]) VALUES (2, N'frkkrpnr', N'faruk123', N'Faruk', N'Karapınar', N'5353533636', N'faruk@gmail.com', N'Faruk Ben', NULL, CAST(N'2019-12-13 00:00:00.000' AS DateTime), CAST(N'1996-12-22 00:00:00.000' AS DateTime), NULL, 0, 0, 2)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Name], [Surname], [Phone], [Email], [Resume], [ImageUrl], [MemberShipDate], [BirthDate], [MailKey], [Status], [Type], [Discount]) VALUES (3, N'adminResimsiz', N'2134', N'Helen', N'Truva', N'21212121  ', N'helen@gmail.com', N'ben helen', N'/Assets/Images/AdminImages/91ea0266-deff-401c-af2e-5986f2009bf0.jpg', CAST(N'2020-08-08 00:00:00.000' AS DateTime), CAST(N'1990-09-09 00:00:00.000' AS DateTime), NULL, 0, 1, NULL)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Name], [Surname], [Phone], [Email], [Resume], [ImageUrl], [MemberShipDate], [BirthDate], [MailKey], [Status], [Type], [Discount]) VALUES (6, N'deneme', N'deneme', N'deneme', N'deneme', N'234234    ', N'deneme', NULL, NULL, CAST(N'2020-08-14 00:00:00.000' AS DateTime), CAST(N'1997-11-12 00:00:00.000' AS DateTime), NULL, 1, 0, 2)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Name], [Surname], [Phone], [Email], [Resume], [ImageUrl], [MemberShipDate], [BirthDate], [MailKey], [Status], [Type], [Discount]) VALUES (7, N'mrtkrtgz', N'21323', N'Murat', N'Kurtgöz', N'213423', N'mrt@gmail.com', NULL, N'/Assets/Images/noImgMan.jpg', CAST(N'2020-08-14 11:31:22.550' AS DateTime), CAST(N'1997-10-21 00:00:00.000' AS DateTime), NULL, 1, 1, 3)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Name], [Surname], [Phone], [Email], [Resume], [ImageUrl], [MemberShipDate], [BirthDate], [MailKey], [Status], [Type], [Discount]) VALUES (9, N'Aykut', N'aykut', N'aykut', N'özer', N'5353985685', N'aykut@gmail.com', NULL, NULL, CAST(N'2020-08-14 12:29:55.943' AS DateTime), CAST(N'1994-10-21 00:00:00.000' AS DateTime), NULL, 1, 0, 2)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Name], [Surname], [Phone], [Email], [Resume], [ImageUrl], [MemberShipDate], [BirthDate], [MailKey], [Status], [Type], [Discount]) VALUES (20, N'serhatAvc', N'123123', N'Serhat', N'Avcı', N'213123', N'emrhnkarabulutt@gmail.com', NULL, NULL, CAST(N'2020-08-28 00:00:00.000' AS DateTime), CAST(N'1994-10-21 00:00:00.000' AS DateTime), N'3a556dca-bf93-40eb-9b82-a8d3dd762bd5', 1, 0, 3)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Name], [Surname], [Phone], [Email], [Resume], [ImageUrl], [MemberShipDate], [BirthDate], [MailKey], [Status], [Type], [Discount]) VALUES (31, N'emirhan', N'123', N'Emirhan', N'Karabulut', N'13231213', N'emrhnkarabuluttt@gmail.com', NULL, NULL, CAST(N'2020-08-28 00:00:00.000' AS DateTime), CAST(N'1994-10-21 00:00:00.000' AS DateTime), N'6dd14888-e35b-4a40-abdd-59dec7297287', 1, 0, NULL)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Name], [Surname], [Phone], [Email], [Resume], [ImageUrl], [MemberShipDate], [BirthDate], [MailKey], [Status], [Type], [Discount]) VALUES (32, N'asdasd', N'123', N'Furkan', N'Baltacı', N'+905348420560', N'furkan@yazilimer.com', NULL, NULL, CAST(N'2020-08-28 00:00:00.000' AS DateTime), CAST(N'1994-10-21 00:00:00.000' AS DateTime), N'1ac28fc3-1fa1-4751-8f21-7e1d6a41bfb3', 1, 0, NULL)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Name], [Surname], [Phone], [Email], [Resume], [ImageUrl], [MemberShipDate], [BirthDate], [MailKey], [Status], [Type], [Discount]) VALUES (33, N'frfrfr', N'123', N'Furkan', N'Baltacı', N'+905348420560', N'fbaltaci.342@gmail.com', NULL, NULL, CAST(N'2020-08-28 00:00:00.000' AS DateTime), CAST(N'1994-10-21 00:00:00.000' AS DateTime), N'5cde9cb5-598f-4f85-8198-cd3d7681ff0b', 1, 0, NULL)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Name], [Surname], [Phone], [Email], [Resume], [ImageUrl], [MemberShipDate], [BirthDate], [MailKey], [Status], [Type], [Discount]) VALUES (34, N'ako', N'3434', N'Aykut ', N'Özer', N'+905348420560', N'aykut.34@gmail.com', NULL, NULL, CAST(N'2020-08-28 00:00:00.000' AS DateTime), CAST(N'1994-10-21 00:00:00.000' AS DateTime), N'54d22055-4c5d-42c6-9583-d471d3f38532', 1, 0, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[Video] ON 

INSERT [dbo].[Video] ([ID], [VideoName], [VideoUrl], [VideoDescription], [Preview], [UpdateAt], [CreatedAt], [PacketID], [TeacherID], [VideoLength]) VALUES (1, N'Hafıza Teknikleri', N'/Assets/Videos/Hafızateknikleri .mp4', N'Bu hafıza teknikleri ile çok hızlı ezberleme çalışması yapacaksınız.', 1, CAST(N'2020-08-27 00:00:00.000' AS DateTime), CAST(N'2020-08-27 00:00:00.000' AS DateTime), 1, 1, CAST(N'04:00:00' AS Time))
INSERT [dbo].[Video] ([ID], [VideoName], [VideoUrl], [VideoDescription], [Preview], [UpdateAt], [CreatedAt], [PacketID], [TeacherID], [VideoLength]) VALUES (2, N'HAYVANCILIK', N'/Assets/Videos/hayvancilik.mp4', N'Hayvancılığın anlatıldığı bir video.', 0, CAST(N'2020-08-27 00:00:00.000' AS DateTime), CAST(N'2020-08-27 00:00:00.000' AS DateTime), 1, 1, CAST(N'04:00:00' AS Time))
INSERT [dbo].[Video] ([ID], [VideoName], [VideoUrl], [VideoDescription], [Preview], [UpdateAt], [CreatedAt], [PacketID], [TeacherID], [VideoLength]) VALUES (3, N'KAPIYI ÇALAN', N'/Assets/Videos/KAPIYICALAN.mp4', N'Coğrafya''nın x konusu hakkında', 0, CAST(N'2020-08-27 00:00:00.000' AS DateTime), CAST(N'2020-08-27 00:00:00.000' AS DateTime), 1, 2, CAST(N'04:00:00' AS Time))
INSERT [dbo].[Video] ([ID], [VideoName], [VideoUrl], [VideoDescription], [Preview], [UpdateAt], [CreatedAt], [PacketID], [TeacherID], [VideoLength]) VALUES (4, N'Heyecandan', N'/Assets/Videos/Heyecandan.webm', N'Heyecandan Klibi', 1, CAST(N'2020-08-27 00:00:00.000' AS DateTime), CAST(N'2020-08-27 00:00:00.000' AS DateTime), 2, 2, CAST(N'04:00:00' AS Time))
INSERT [dbo].[Video] ([ID], [VideoName], [VideoUrl], [VideoDescription], [Preview], [UpdateAt], [CreatedAt], [PacketID], [TeacherID], [VideoLength]) VALUES (5, N'Video Doğa', N'/Assets/Videos/videodoga.mp4', N'Doğa içerikli vide', 0, CAST(N'2020-08-27 00:00:00.000' AS DateTime), CAST(N'2020-08-27 00:00:00.000' AS DateTime), 2, 2, CAST(N'04:00:00' AS Time))
INSERT [dbo].[Video] ([ID], [VideoName], [VideoUrl], [VideoDescription], [Preview], [UpdateAt], [CreatedAt], [PacketID], [TeacherID], [VideoLength]) VALUES (6, N'Video Home', N'/Assets/Videos/videohome.mp4', N'Ev içerisinde çekilmiş olan bir video', 0, CAST(N'2020-08-27 00:00:00.000' AS DateTime), CAST(N'2020-08-27 00:00:00.000' AS DateTime), 2, 1, CAST(N'04:00:00' AS Time))
INSERT [dbo].[Video] ([ID], [VideoName], [VideoUrl], [VideoDescription], [Preview], [UpdateAt], [CreatedAt], [PacketID], [TeacherID], [VideoLength]) VALUES (7, N'Video Örnek', N'/Assets/Videos/videoornek.mp4', N'Örnek Video kısa film gibi bir video', 0, CAST(N'2020-08-27 00:00:00.000' AS DateTime), CAST(N'2020-08-27 00:00:00.000' AS DateTime), 2, 2, CAST(N'04:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[Video] OFF
SET IDENTITY_INSERT [dbo].[VideoEducationTeacher] ON 

INSERT [dbo].[VideoEducationTeacher] ([ID], [Name], [Surname], [SubTitle], [Description], [TwitterUrl], [InstagramUrl], [FacebookUrl], [LinkedinUrl], [ImgUrl], [Address], [Phone], [Email]) VALUES (1, N'MEHMET', N'EĞİT', N'Eğitmen', N'FEN BİLGİSİ ALANINDA YÜKSEK LİSANS DERECESİ VARDIR', N'www.twitter.com/mehmetEgit', NULL, NULL, NULL, N'/Assets/Images/TeacherImages/3cdc59fa-2713-413b-9220-6b37064ca0a4.png', N'denem Adres', N'5555555555', N'deneme@gmail.com')
INSERT [dbo].[VideoEducationTeacher] ([ID], [Name], [Surname], [SubTitle], [Description], [TwitterUrl], [InstagramUrl], [FacebookUrl], [LinkedinUrl], [ImgUrl], [Address], [Phone], [Email]) VALUES (2, N'MEHMET', N'EĞİT', N'Eğitmen', N'FEN BİLGİSİ ALANINDA YÜKSEK LİSANS DERECESİ VARDIR', NULL, NULL, NULL, NULL, N'/Assets/wp-content/uploads/2016/11/avatar-1.png', NULL, NULL, NULL)
INSERT [dbo].[VideoEducationTeacher] ([ID], [Name], [Surname], [SubTitle], [Description], [TwitterUrl], [InstagramUrl], [FacebookUrl], [LinkedinUrl], [ImgUrl], [Address], [Phone], [Email]) VALUES (3, N'DENEME1', N'DENEME1', N'Eğitmen', N'FEN BİLGİSİ ALANINDA YÜKSEK LİSANS DERECESİ VARDIR', NULL, NULL, NULL, NULL, N'/Assets/wp-content/uploads/2016/11/avatar-1.png', NULL, NULL, NULL)
INSERT [dbo].[VideoEducationTeacher] ([ID], [Name], [Surname], [SubTitle], [Description], [TwitterUrl], [InstagramUrl], [FacebookUrl], [LinkedinUrl], [ImgUrl], [Address], [Phone], [Email]) VALUES (4, N'DENEME2', N'DENEME2', N'Eğitmen', N'FEN BİLGİSİ ALANINDA YÜKSEK LİSANS DERECESİ VARDIRFEN BİLGİSİ ALANINDA YÜKSEK LİSANS DERECESİ VARDIRFEN BİLGİSİ ALANINDA YÜKSEK LİSANS DERECESİ VARDIR', NULL, NULL, NULL, NULL, N'/Assets/wp-content/uploads/2016/11/avatar-1.png', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[VideoEducationTeacher] OFF
ALTER TABLE [dbo].[BlogComment] ADD  CONSTRAINT [DF_BlogComment_AnswerCommentID]  DEFAULT ((0)) FOR [AnswerCommentID]
GO
ALTER TABLE [dbo].[BlogComment] ADD  CONSTRAINT [DF_BlogComment_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Blog]  WITH CHECK ADD  CONSTRAINT [FK_Blog_BlogCategory] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[BlogCategory] ([ID])
GO
ALTER TABLE [dbo].[Blog] CHECK CONSTRAINT [FK_Blog_BlogCategory]
GO
ALTER TABLE [dbo].[BlogComment]  WITH CHECK ADD  CONSTRAINT [FK_BlogComment_Blog] FOREIGN KEY([BlogID])
REFERENCES [dbo].[Blog] ([ID])
GO
ALTER TABLE [dbo].[BlogComment] CHECK CONSTRAINT [FK_BlogComment_Blog]
GO
ALTER TABLE [dbo].[BlogComment]  WITH CHECK ADD  CONSTRAINT [FK_BlogComment_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[BlogComment] CHECK CONSTRAINT [FK_BlogComment_User]
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_Packet] FOREIGN KEY([PacketID])
REFERENCES [dbo].[Packet] ([ID])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_Packet]
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_User]
GO
ALTER TABLE [dbo].[Video]  WITH CHECK ADD  CONSTRAINT [FK_Video_Packet] FOREIGN KEY([PacketID])
REFERENCES [dbo].[Packet] ([ID])
GO
ALTER TABLE [dbo].[Video] CHECK CONSTRAINT [FK_Video_Packet]
GO
ALTER TABLE [dbo].[Video]  WITH CHECK ADD  CONSTRAINT [FK_Video_VideoEducationTeacher] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[VideoEducationTeacher] ([ID])
GO
ALTER TABLE [dbo].[Video] CHECK CONSTRAINT [FK_Video_VideoEducationTeacher]
GO
USE [master]
GO
ALTER DATABASE [MehmetEgitKurumsal] SET  READ_WRITE 
GO
