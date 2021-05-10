CREATE TABLE [dbo].[Statements](
	[Id] [BIGINT] IDENTITY(1,1) NOT NULL,
	[AgentId] [BIGINT] NOT NULL,
	[ProductId] [BIGINT] NOT NULL,
	[Quantity] [INT] NOT NULL,
	[IsApproved] [BIT] NOT NULL,
 CONSTRAINT [PK_Statements] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Statements]  WITH CHECK ADD  CONSTRAINT [FK_Statements_Agents] FOREIGN KEY([AgentId])
REFERENCES [dbo].[Agents] ([Id])
GO

ALTER TABLE [dbo].[Statements] CHECK CONSTRAINT [FK_Statements_Agents]
GO

ALTER TABLE [dbo].[Statements]  WITH CHECK ADD  CONSTRAINT [FK_Statements_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO

ALTER TABLE [dbo].[Statements] CHECK CONSTRAINT [FK_Statements_Products]
GO