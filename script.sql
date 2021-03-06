USE [SM]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 5.11.2018 16:02:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SharedComment]    Script Date: 5.11.2018 16:02:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SharedComment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SharedId] [int] NULL,
	[Comment] [nvarchar](50) NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_SharedComment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserFriend]    Script Date: 5.11.2018 16:02:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserFriend](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[FriendId] [int] NULL,
 CONSTRAINT [PK_UserFriend] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Userr]    Script Date: 5.11.2018 16:02:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Userr](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
	[Details] [nvarchar](max) NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Userr_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserShared]    Script Date: 5.11.2018 16:02:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserShared](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[SharedDetails] [nvarchar](max) NULL,
	[SharedTime] [datetime] NULL,
 CONSTRAINT [PK_UserShared] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[SharedComment]  WITH CHECK ADD  CONSTRAINT [FK_SharedComment_Userr] FOREIGN KEY([UserId])
REFERENCES [dbo].[Userr] ([Id])
GO
ALTER TABLE [dbo].[SharedComment] CHECK CONSTRAINT [FK_SharedComment_Userr]
GO
ALTER TABLE [dbo].[SharedComment]  WITH CHECK ADD  CONSTRAINT [FK_SharedComment_UserShared] FOREIGN KEY([SharedId])
REFERENCES [dbo].[UserShared] ([Id])
GO
ALTER TABLE [dbo].[SharedComment] CHECK CONSTRAINT [FK_SharedComment_UserShared]
GO
ALTER TABLE [dbo].[UserFriend]  WITH CHECK ADD  CONSTRAINT [FK_UserFriend_Userr] FOREIGN KEY([UserId])
REFERENCES [dbo].[Userr] ([Id])
GO
ALTER TABLE [dbo].[UserFriend] CHECK CONSTRAINT [FK_UserFriend_Userr]
GO
ALTER TABLE [dbo].[UserFriend]  WITH CHECK ADD  CONSTRAINT [FK_UserFriend_Userr1] FOREIGN KEY([FriendId])
REFERENCES [dbo].[Userr] ([Id])
GO
ALTER TABLE [dbo].[UserFriend] CHECK CONSTRAINT [FK_UserFriend_Userr1]
GO
ALTER TABLE [dbo].[UserShared]  WITH CHECK ADD  CONSTRAINT [FK_UserShared_Userr] FOREIGN KEY([UserId])
REFERENCES [dbo].[Userr] ([Id])
GO
ALTER TABLE [dbo].[UserShared] CHECK CONSTRAINT [FK_UserShared_Userr]
GO
