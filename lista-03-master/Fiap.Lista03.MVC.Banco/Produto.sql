CREATE TABLE [dbo].[Produto]
(
	[ProdutoId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DataCadastro] DATETIME NOT NULL, 
    [Descricao] TEXT NOT NULL, 
    [Nacional] BIT NOT NULL, 
    [Titulo] VARCHAR(25) NOT NULL, 
    [Valor] NUMERIC(4, 2) NOT NULL
)
