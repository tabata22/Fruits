﻿CREATE TABLE [dbo].[Agents](
	[Id] [BIGINT] IDENTITY(1,1) NOT NULL,
	[ParentId] [BIGINT] NULL,
	[FirstName] [NVARCHAR](50) NOT NULL,
	[LastName] [NVARCHAR](50) NOT NULL,
	[PersonalId] [CHAR](11) NOT NULL,
	[BirthDate] [DATETIME] NULL,
	[DeletedAt] [DATETIME] NULL,
 CONSTRAINT [PK_Agents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Agents]  WITH CHECK ADD  CONSTRAINT [FK_Agents_Agents] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Agents] ([Id])
GO

ALTER TABLE [dbo].[Agents] CHECK CONSTRAINT [FK_Agents_Agents]
GO