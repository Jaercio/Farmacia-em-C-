USE [Farmacia]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Fornecedores](
	[fornecedorId] [int] IDENTITY(1,1) NOT NULL,
	[fornecedorNome] [nvarchar](80) NOT NULL,
	[fornecedorEndereco] [nvarchar](50) NOT NULL,
	[fornecedorTelefone] [nvarchar](50) NOT NULL,
	[fornecedorEmail] [nvarchar](80) NOT NULL,
	[fornecedorHome] [nvarchar](100) NULL,
	[categoriaId] [int] NULL,
 CONSTRAINT [PK_Fornecedores] PRIMARY KEY CLUSTERED 
(
	[fornecedorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Fornecedores]  WITH CHECK ADD  CONSTRAINT [FK_Fornecedores_Categorias] FOREIGN KEY([categoriaId])
REFERENCES [dbo].[Categorias] ([categoriaId])
GO

ALTER TABLE [dbo].[Fornecedores] CHECK CONSTRAINT [FK_Fornecedores_Categorias]
GO