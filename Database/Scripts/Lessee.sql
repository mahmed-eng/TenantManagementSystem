USE [SMS]
GO

/****** Object:  Table [dbo].[Student_tb]    Script Date: 23/08/2022 3:42:38 pm ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES
           WHERE TABLE_NAME = 'Lessee')
BEGIN
	CREATE TABLE [dbo].[lessee](
		[CompanyId] int NOT NULL,
		[CardNumber] [varchar](30) NOT NULL,
		[Peneficiary] [varchar](300),
		[Nationality] [varchar](100),
		[Profession] [varchar](150),
		[IDNo] [varchar](200) NOT NULL,
	    [Address] [varchar](300),	
		[Fax] [nvarchar](50) NOT NULL,
		[POBox] [varchar](50) NOT NULL,
		[Email] [varchar](100) NOT NULL,
		[NOPR] int NOT NULL,
		[CreatedBy] [int] NOT NULL,
		[CreatedDate] [datetime],
		[UpdatedBy] [int] NOT NULL,
		[UpdatedDate] [datetime],
	 CONSTRAINT [PK_Lessee] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	END
GO



CREATE TABLE Company (

        [CompanyId] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	    [Name] [varchar](200),
		[Address] [varchar](300),
		[Email] [varchar](100) NOT NULL,
		[Phone] [varchar](100) NOT NULL,
		[Fax] [nvarchar](50) NOT NULL,
		[Cell] [varchar](50) NOT NULL,
		RegisterNumber[varchar](50) NOT NULL,
		[CreatedBy] [int] NOT NULL,
		[CreatedDate] [datetime],
		[UpdatedBy] [int] NOT NULL,
		[UpdatedDate] [datetime]
);






