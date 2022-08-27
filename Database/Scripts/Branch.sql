USE [SMS]
GO

/****** Object:  Table [dbo].[Branch_tb]    Script Date: 25/08/2022 11:12:46 am ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


IF NOT (EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'TheSchema' 
                 AND  TABLE_NAME = 'Branch_tb'))
BEGIN
    --Do Stuff--


CREATE TABLE [dbo].[Branch_tb](
	[CompanyId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NULL,
	[Address] [varchar](300) NULL,
	[Email] [varchar](100) NULL,
	[Phone] [varchar](100) NULL,
	[Fax] [nvarchar](50) NULL,
	[Cell] [varchar](50) NULL,
	[RegisterNumber] [varchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,

PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

END

GO