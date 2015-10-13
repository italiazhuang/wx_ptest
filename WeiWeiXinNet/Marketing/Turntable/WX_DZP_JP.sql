USE [WXSource]
GO

/****** Object:  Table [dbo].[WX_DZP_JP]    Script Date: 10/08/2013 13:11:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[WX_DZP_JP](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Jp] [nvarchar](50) NULL,
	[Sjh] [nvarchar](50) NULL
) ON [PRIMARY]

GO

