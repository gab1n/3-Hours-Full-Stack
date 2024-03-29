USE [CodeChallenge]
GO
/****** Object:  Table [dbo].[Advertisers]    Script Date: 9/13/2019 1:23:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advertisers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShortTitle] [nvarchar](250) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[ShortDescription] [nvarchar](250) NOT NULL,
	[Content] [nvarchar](250) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[Slug] [nvarchar](250) NOT NULL,
	[EntityTypeId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
	[MetaDataId] [int] NOT NULL,
 CONSTRAINT [PK_Advertisers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 9/13/2019 1:23:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
	[ZipCode] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MetaDatas]    Script Date: 9/13/2019 1:23:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MetaDatas](
	[DateStart] [datetime2](7) NULL,
	[DateEnd] [datetime2](7) NULL,
	[LocationId] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Advertisers] ADD  CONSTRAINT [DF_Advertisers_DateCreated]  DEFAULT (getutcdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Advertisers] ADD  CONSTRAINT [DF_Advertisers_DateModified]  DEFAULT (getutcdate()) FOR [DateModified]
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_Delete]    Script Date: 9/13/2019 1:23:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Advertisers_Delete]
	@Id INT
AS

BEGIN

/*

DECLARE @Id INT = 5

SELECT *
FROM dbo.Advertisers
WHERE Id = @Id

EXECUTE dbo.Advertisers_Delete
		@Id

SELECT *
FROM dbo.Advertisers
WHERE Id = @Id

*/



DELETE FROM [dbo].[Advertisers]
      WHERE Id= @Id

END


GO
/****** Object:  StoredProcedure [dbo].[Advertisers_Insert]    Script Date: 9/13/2019 1:23:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Advertisers_Insert]
	@ShortTitle NVARCHAR(250),
           @Title NVARCHAR(250), 
           @ShortDescription NVARCHAR(250), 
           @Content NVARCHAR(250), 
           @CreatedBy INT, 
           @Slug NVARCHAR(250), 
           @EntityTypeId INT, 
           @StatusId INT, 
           @MetaDataId INT,
		   @Id INT OUTPUT
AS

BEGIN
/*
		DECLARE @Id INT
		DECLARE @ShortTitle NVARCHAR(250) = 'First TItle',
           @Title NVARCHAR(250) = 'Title',
           @ShortDescription NVARCHAR(250) = 'Descrip', 
           @Content NVARCHAR(250) = 'content',
           @CreatedBy INT = 1,
           @Slug NVARCHAR(250) = 'slug1',

           @EntityTypeId INT = 1,
           @StatusId INT = 1,
           @MetaDataId INT = 1

		EXECUTE dbo.Advertisers_Insert
			@ShortTitle ,
           @Title,  
           @ShortDescription, 
           @Content , 
           @CreatedBy , 
           @Slug , 
           @EntityTypeId, 
           @StatusId , 
           @MetaDataId,
		   @Id OUTPUT

		   SELECT *
		   FROM dbo.Advertisers
		   WHERE Id = @Id
*/

INSERT INTO [dbo].[Advertisers]
           ([ShortTitle]
           ,[Title]
           ,[ShortDescription]
           ,[Content]
           ,[CreatedBy]
           ,[Slug]
           ,[EntityTypeId]
           ,[StatusId]
           ,[MetaDataId])
     VALUES
           (@ShortTitle,
           @Title, 
           @ShortDescription, 
           @Content, 
           @CreatedBy, 
           @Slug, 
           @EntityTypeId, 
           @StatusId, 
           @MetaDataId)

		   SET @Id = SCOPE_IDENTITY()
END


GO
/****** Object:  StoredProcedure [dbo].[Advertisers_SelectAll]    Script Date: 9/13/2019 1:23:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Advertisers_SelectAll]
		
AS

BEGIN

/*
	EXECUTE dbo.Advertisers_SelectAll
*/

SELECT Id,
		ShortTitle,
		Title,
		ShortDescription,
		[Content],
		CreatedBy,
		Slug,
		EntityTypeId,
		StatusId,
		DateCreated,
		DateModified,
		MetaDataId

FROM dbo.Advertisers

END
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_SelectById]    Script Date: 9/13/2019 1:23:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Advertisers_SelectById]
	@Id INT

AS

BEGIN

/*
Declare @Id int = 1

Execute dbo.Advertisers_SelectById
		@Id
	
*/


SELECT [Id]
      ,[ShortTitle]
      ,[Title]
      ,[ShortDescription]
      ,[Content]
      ,[CreatedBy]
      ,[Slug]
      ,[EntityTypeId]
      ,[StatusId]
      ,[DateCreated]
      ,[DateModified]
      ,[MetaDataId]
  FROM [dbo].[Advertisers]
  WHERE Id = @Id


  END


GO
/****** Object:  StoredProcedure [dbo].[Advertisers_Update]    Script Date: 9/13/2019 1:23:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Advertisers_Update]
			@Id int
			,@ShortTitle nvarchar(250)
			,@Title nvarchar(250)
			,@ShortDescription nvarchar(250)
			,@Content nvarchar(250)
			,@CreatedBy Int
			,@Slug nvarchar(250)
			,@EntityTypeId INT
			,@StatusId int
			,@MetaDataId INT
AS

BEGIN

/*
Declare @Id int = 1;

Declare		
			@ShortTitle nvarchar(250) = '1shorty'
			,@Title nvarchar(250) = '1titley'
			,@ShortDescription nvarchar(250) = '1descipry'
			,@Content nvarchar(250) = '1contenty'
			,@CreatedBy Int = 11
			,@Slug nvarchar(250) = 'slugy1'
			,@EntityTypeId INT = 11
			,@StatusId int = 11
			,@MetaDataId INT = 11

Select *
From dbo.Advertisers
Where Id = @Id

Execute dbo.Advertisers_Update
			@Id
			,@ShortTitle 
			,@Title
			,@ShortDescription 
			,@Content 
			,@CreatedBy 
			,@Slug 
			,@EntityTypeId 
			,@StatusId 
			,@MetaDataId 
						

Select *
From dbo.Advertisers
Where Id = @Id
*/


UPDATE [dbo].[Advertisers]
   SET
      [ShortTitle] = @ShortTitle
	  ,[Title] = @Title
      ,[ShortDescription] = @ShortDescription
      ,[Content] = @Content
	  ,CreatedBy = @CreatedBy
	  ,[Slug] = @Slug
      ,EntityTypeId = @EntityTypeId
      ,[StatusId] = @StatusId
      ,[DateModified] = GETUTCDATE()
	  ,[MetaDataId] = @MetaDataId

 WHERE Id =@Id


 END


GO
