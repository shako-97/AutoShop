USE [AutoShop]
GO

/****** Object:  Table [dbo].[Cars]    Script Date: 16.03.2022 16:21:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cars](
	[ABS] [bit] NOT NULL,
	[PowerWindows] [bit] NOT NULL,
	[Bluetooth] [bit] NOT NULL,
	[Signalling] [bit] NOT NULL,
	[NavigationSystem] [bit] NOT NULL,
	[Price] [money] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ModelID] [int] NOT NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Models] FOREIGN KEY([ModelID])
REFERENCES [dbo].[Models] ([ID])
GO

ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_Models]
GO

