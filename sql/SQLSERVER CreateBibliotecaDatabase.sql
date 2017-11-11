CREATE DATABASE Biblioteca 
GO

USE Biblioteca
GO


CREATE TABLE Estado (
  idEstado INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  Nome NVARCHAR(50) NOT NULL,
  Sigla NVARCHAR(2) NOT NULL,

  CONSTRAINT PK_Estado_IdEstado PRIMARY KEY (IdEstado)
)
GO



CREATE TABLE Cidade (
  idCidade INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  Nome NVARCHAR(50) NOT NULL,
  idEstado INT NOT NULL,

  CONSTRAINT PK_Cidade_IdCidade PRIMARY KEY (idCidade),

  CONSTRAINT FK_Cidade_Estado_IdEstado FOREIGN KEY (idEstado)
  REFERENCES Estado (idEstado)
)


CREATE TABLE Endereco (
  idEndereco INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  Logradouro NVARCHAR(150) NOT NULL,
  Bairro NVARCHAR(50) NOT NULL,
  Cep NVARCHAR(8) NOT NULL,
  Numero INT NOT NULL,
  Complemento NVARCHAR(20) NOT NULL,
  idCidade INT NOT NULL,

  CONSTRAINT PK_Endereco_IdEndereco PRIMARY KEY (idEndereco),

  CONSTRAINT FK_Endereco_Cidade_IdCidade FOREIGN KEY (idCidade)
  REFERENCES Cidade (idCidade)
)

CREATE TABLE TipoTelefone (
  idTipoTelefone INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  Nome NVARCHAR(10) NOT NULL,

  CONSTRAINT PK_TipoTelefone_IdTipoTelefone PRIMARY KEY (idTipoTelefone)
)

CREATE TABLE Pessoa (
  idPessoa INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  Nome NVARCHAR(50) NOT NULL,
  Rg NVARCHAR(15) NOT NULL,
  Cpf NVARCHAR(11) NOT NULL,
  DataNascimento DATETIME NOT NULL,
  idEndereco INT NOT NULL,

  CONSTRAINT PK_Pessoa_IdPessoa PRIMARY KEY (idPessoa),

  CONSTRAINT FK_Pessoa_Endereco_IdEndereco FOREIGN KEY (idEndereco)
  REFERENCES Endereco (idEndereco)
)

CREATE TABLE Usuario (
  idUsuario INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  Email NVARCHAR(50) NOT NULL,
  Senha NVARCHAR(32) NOT NULL,
  idPessoa INT NOT NULL,

  CONSTRAINT PK_Usuario_IdUsuario PRIMARY KEY (idUsuario),

  CONSTRAINT FK_Usuario_Pessoa_IdPessoa FOREIGN KEY (idPessoa)
  REFERENCES Pessoa (idPessoa)
)

CREATE TABLE Telefone (
  idTelefone INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  idPessoa INT NOT NULL,
  idTipoTelefone INT NOT NULL,
  Numero NVARCHAR(20) NOT NULL,

  CONSTRAINT PK_Telefone_IdTelefone PRIMARY KEY (idTelefone),

  CONSTRAINT FK_Telefone_Pessoa_IdPessoa FOREIGN KEY (idPessoa)
  REFERENCES Pessoa (idPessoa),

  CONSTRAINT FK_Telefone_TipoTelefone_idTipoTelefone FOREIGN KEY (idTipoTelefone)
  REFERENCES TipoTelefone (idTipoTelefone)
)

CREATE TABLE Assunto (
  idAssunto INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  Nome NVARCHAR(50) NOT NULL,

  CONSTRAINT PK_Assunto_IdAssunto PRIMARY KEY (idAssunto)
)

CREATE TABLE Editora (
  idEditora INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  Nome NVARCHAR(50) NOT NULL,

  CONSTRAINT PK_Editora_IdEditora PRIMARY KEY (idEditora)
)

CREATE TABLE Material (
  IdMaterial INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  Titulo NVARCHAR(50) NOT NULL,
  idAssunto INT NOT NULL,
  idEditora INT NOT NULL,

  CONSTRAINT PK_Material_IdMaterial PRIMARY KEY (IdMaterial),

  CONSTRAINT FK_Material_Assunto_IdAssunto FOREIGN KEY (idAssunto)
  REFERENCES Assunto (idAssunto),

  CONSTRAINT FK_Material_Editora_IdEditora FOREIGN KEY (idEditora)
  REFERENCES Editora (idEditora)
)

CREATE TABLE Livro (
  IdLivro INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  Edicao NVARCHAR(50) NOT NULL,
  Isbn NVARCHAR(50) NOT NULL,
  IdMaterial INT NOT NULL,

  CONSTRAINT FK_Livro_IdLivro PRIMARY KEY (IdLivro),

  CONSTRAINT FK_Livro_Material_IdMaterial FOREIGN KEY (IdMaterial)
  REFERENCES Material (IdMaterial)
)

CREATE TABLE Revista (
  IdRevista INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  Colecao NVARCHAR(50) NOT NULL,
  IdMaterial INT NOT NULL,

  CONSTRAINT PK_Revista_IdRevista PRIMARY KEY (IdRevista),

  CONSTRAINT FK_Revista_Material_IdMaterial FOREIGN KEY (IdMaterial)
  REFERENCES Material (IdMaterial)   
)



CREATE TABLE Autor (
  IdAutor INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  Nome NVARCHAR(50) NOT NULL,
  Email NVARCHAR(50) NOT NULL,

  CONSTRAINT PK_Autor_IdAutor PRIMARY KEY (IdAutor)
)


CREATE TABLE Artigo (
  IdArtigo INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  IdRevista INT NOT NULL,
  Titulo NVARCHAR(50) NOT NULL,

  CONSTRAINT PK_Artigo_IdArtigo PRIMARY KEY (IdArtigo),

  CONSTRAINT FK_Artigo_Revista_IdRevista FOREIGN KEY (IdRevista)
  REFERENCES Revista (IdRevista)
)



CREATE TABLE Reserva (
  IdReserva INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  DataReserva DATETIME NOT NULL,
  DataValidade DATETIME NOT NULL,
  idUsuario INT NOT NULL,
  IdMaterial INT NOT NULL,

  CONSTRAINT PK_Reserva_IdReserva PRIMARY KEY (IdReserva),

  CONSTRAINT FK_Reserva_Usuario_idUsuario FOREIGN KEY (idUsuario)
  REFERENCES Usuario (idUsuario),

  CONSTRAINT FK_Reserva_Material_IdMaterial FOREIGN KEY (IdMaterial)
  REFERENCES Material (IdMaterial)    
)


CREATE TABLE Emprestimo (
  IdEmprestimo INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  DataEmprestimo DATETIME NOT NULL,
  DataPrevistaRetorno DATETIME NOT NULL,
  DataRetorno DATETIME NOT NULL,
  idUsuario INT NOT NULL,
  IdMaterial INT NOT NULL,

  CONSTRAINT PK_Emprestimo_IdEmprestimo PRIMARY KEY (IdEmprestimo),

  CONSTRAINT FK_Emprestimo_Usuario_idUsuario FOREIGN KEY (idUsuario)
  REFERENCES Usuario (idUsuario),

  CONSTRAINT FK_Emprestimo_Material_IdMaterial FOREIGN KEY (IdMaterial)
  REFERENCES Material (IdMaterial)
)



CREATE TABLE LivroAutor (
  IdLivroAutor INT NOT NULL IDENTITY(1, 1),
  IdLivro INT NOT NULL,
  IdAutor INT NOT NULL,

  CONSTRAINT PK_LivroAutor_IdLivroAutor PRIMARY KEY (IdLivroAutor),

  CONSTRAINT FK_LivroAutor_Livro_IdLivro FOREIGN KEY (IdLivro)
  REFERENCES Livro (IdLivro),

  CONSTRAINT FK_LivroAutor_Autor_IdAutor FOREIGN KEY (IdAutor)
  REFERENCES Autor (IdAutor)    
)


CREATE TABLE ArtigoAutor (
  IdArtigoAutor INT NOT NULL IDENTITY(1, 1),
  IdArtigo INT NOT NULL,
  IdAutor INT NOT NULL,

  CONSTRAINT PK_ArtigoAutor_IdArtigoAutor PRIMARY KEY (IdArtigoAutor),

  CONSTRAINT FK_ArtigAutor_Artigo_IdArtigo FOREIGN KEY (IdArtigo)
  REFERENCES Artigo (IdArtigo),

  CONSTRAINT FK_ArtigoAutor_Autor_IdAutor FOREIGN KEY (IdAutor)
  REFERENCES Autor (IdAutor)
)
