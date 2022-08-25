USE [SMS]
GO

/****** Object:  Table [dbo].[Student_tb]    Script Date: 23/08/2022 2:27:43 pm ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES
           WHERE TABLE_NAME = 'Lessor')
BEGIN
	CREATE TABLE [dbo].[lessor](
			[CardNumber] [varchar](30) NOT NULL,
		[Name] [varchar](300),
		[Designation] [varchar](100),
		[Nationality] [varchar](150),
		[Profession] [varchar](200) NOT NULL,
	    [IDNo] [varchar](300),	
		[Address] [nvarchar](50) NOT NULL,
		[Telephone] [varchar](50) NOT NULL,
		[Fax] [varchar](100) NOT NULL,
		[POBox] int NOT NULL,
		[Email] int NOT NULL,
		[CreatedBy] [int] NOT NULL,
		[CreatedDate] [datetime],
		[UpdatedBy] [int] NOT NULL,
		[UpdatedDate] [datetime],
	 CONSTRAINT [PK_Lessor] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	END
GO
