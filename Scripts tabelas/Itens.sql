USE [Farmacia]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Itens](
	[itemId] [int] IDENTITY(1,1) NOT NULL,
	[pedidoId] [int] NOT NULL,
	[produtoId] [int] NOT NULL,
	[itemValor] [money] NULL,
	[itemQuantidade] [int] NULL,
 CONSTRAINT [PK_Itens] PRIMARY KEY CLUSTERED 
(
	[itemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Itens]  WITH CHECK ADD  CONSTRAINT [FK_Itens_Pedidos] FOREIGN KEY([pedidoId])
REFERENCES [dbo].[Pedidos] ([pedidoId])
GO

ALTER TABLE [dbo].[Itens] CHECK CONSTRAINT [FK_Itens_Pedidos]
GO

ALTER TABLE [dbo].[Itens]  WITH CHECK ADD  CONSTRAINT [FK_Itens_Produtos] FOREIGN KEY([produtoId])
REFERENCES [dbo].[Produtos] ([produtoId])
GO

ALTER TABLE [dbo].[Itens] CHECK CONSTRAINT [FK_Itens_Produtos]
GO


