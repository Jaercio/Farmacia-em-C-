USE [Farmacia]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pedidos](
	[pedidoId] [int] IDENTITY(1,1) NOT NULL,
	[clienteId] [int] NOT NULL,
	[pedidoData] [datetime] NOT NULL,
	[pedidoEntrega] [datetime] NULL,
	[pedidoValor] [money] NULL,
	[pedidoStatus] [nchar](10) NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[pedidoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Clientes] FOREIGN KEY([clienteId])
REFERENCES [dbo].[Clientes] ([clienteId])
GO

ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Clientes]
GO