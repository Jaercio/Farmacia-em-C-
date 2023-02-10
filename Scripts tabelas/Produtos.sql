USE [Farmacia]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Produtos](
	[produtoId] [int] IDENTITY(1,1) NOT NULL,
	[produtoNome] [nvarchar](100) NOT NULL,
	[produtoPreco] [money] NOT NULL,
	[produtoDesconto] [money] NOT NULL,
	[produtoImagem] [varbinary](max) NULL,
	[produtoCategoriaId] [int] NULL,
 CONSTRAINT [PK_Produtos] PRIMARY KEY CLUSTERED 
(
	[produtoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Produtos]  WITH CHECK ADD  CONSTRAINT [FK_Produtos_Categorias] FOREIGN KEY([produtoCategoriaId])
REFERENCES [dbo].[Categorias] ([categoriaId])
GO

ALTER TABLE [dbo].[Produtos] CHECK CONSTRAINT [FK_Produtos_Categorias]
GO


