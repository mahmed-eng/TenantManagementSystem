USE [SMS]
GO

/****** Object:  Table [dbo].[Company]    Script Date: 25/08/2022 11:06:45 am ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'TheSchema' 
                 AND  TABLE_NAME = 'Lessee_tb'))
BEGIN
    --Do Stuff

CREATE TABLE [dbo].[LessorLessor_tb](
	[BranchId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Cardnumber] [varchar](30) NOT NULL,
	[Name] [varchar](200) NULL,
	[Peneficiary] [varchar](300) NULL,
	[Profession] [varchar](300) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [varchar](300) NULL,
	[Fax] [nvarchar](50) NOT NULL,
	[Telephone] [varchar](50) NOT NULL,
	[POBox] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[NOPR] [int] NOT NULL,
	[CreatedBy] [int]  NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[RecordType] [int] NOT NULL,

PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END

GO


