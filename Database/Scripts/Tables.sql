USE [SMS]
GO

/****** Object:  Table [dbo].[Student_tb]    Script Date: 23/08/2022 11:56:25 am ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES
           WHERE TABLE_NAME = 'Company')
BEGIN
	CREATE TABLE [dbo].[Company](
		[Id] varbinary(50) NOT NULL,
		[Name] [varchar](150) NOT NULL,
		[Address] [varchar](250) NOT NULL,
		[Email] [varchar](100) NOT NULL,
		[Phone] [varchar](50) NOT NULL,
		[Fax] [varchar](50),
		[Cell] [nvarchar](50) NOT NULL,
		[RegisterNumber] [nvarchar](50) NOT NULL,
		[CreatedBy] [int] NOT NULL,
		[CreatedDate] [datetime],NULL
		[UpdatedBy] [int] NOT NULL,
		[UpdatedDate] [datetime],

	 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	END
GO


