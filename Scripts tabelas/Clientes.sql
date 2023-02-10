USE [Farmacia]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clientes](
	[clienteId] [int] IDENTITY(1,1) NOT NULL,
	[clienteNome] [nvarchar](50) NOT NULL,
	[clienteEndereco] [nvarchar](80) NOT NULL,
	[clienteTelefone] [nvarchar](50) NOT NULL,
	[clienteEmail] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[clienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
