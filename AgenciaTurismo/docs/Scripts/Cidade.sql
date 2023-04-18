CREATE TABLE [dbo].[Cidade]
(
	[Id] INT identity NOT NULL PRIMARY KEY, 
    [Descricao] VARCHAR(50) NULL, 
    [Dtcadastro] DAte default GetDATE() NULL
)
