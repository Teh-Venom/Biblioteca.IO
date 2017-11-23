CREATE DATABASE Biblioteca 
GO

USE Biblioteca
GO


CREATE TABLE Estados (
  idEstado INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  Nome NVARCHAR(50) NOT NULL,
  Sigla NVARCHAR(2) NOT NULL,

  CONSTRAINT PK_Estados_IdEstado PRIMARY KEY (IdEstado)
)
GO



CREATE TABLE Cidades (
  idCidade INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  Nome NVARCHAR(50) NOT NULL,
  idEstado INT NOT NULL,

  CONSTRAINT PK_Cidades_IdCidade PRIMARY KEY (idCidade),

  CONSTRAINT FK_Cidades_Estados_IdEstado FOREIGN KEY (idEstado)
  REFERENCES Estados (idEstado)
)


CREATE TABLE Enderecos (
  idEndereco INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  Logradouro NVARCHAR(150) NOT NULL,
  Bairro NVARCHAR(50) NOT NULL,
  Cep NVARCHAR(8) NOT NULL,
  Numero INT NOT NULL,
  Complemento NVARCHAR(20) NOT NULL,
  idCidade INT NOT NULL,

  CONSTRAINT PK_Enderecos_IdEndereco PRIMARY KEY (idEndereco),

  CONSTRAINT FK_Enderecos_Cidades_IdCidade FOREIGN KEY (idCidade)
  REFERENCES Cidades (idCidade)
)

CREATE TABLE TiposTelefones (
  idTipoTelefone INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  Nome NVARCHAR(10) NOT NULL,

  CONSTRAINT PK_TiposTelefones_IdTipoTelefone PRIMARY KEY (idTipoTelefone)
)

CREATE TABLE Pessoas (
  idPessoa INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  Nome NVARCHAR(50) NOT NULL,
  Rg NVARCHAR(15) NOT NULL,
  DataNascimento DATETIME NOT NULL,
  Cpf NVARCHAR(11) NOT NULL,
  Ativo BIT NOT NULL,
  idEndereco INT NOT NULL,

  CONSTRAINT PK_Pessoas_IdPessoa PRIMARY KEY (idPessoa),

  CONSTRAINT FK_Pessoas_Enderecos_IdEndereco FOREIGN KEY (idEndereco)
  REFERENCES Enderecos (idEndereco)
)

CREATE TABLE Usuarios (
  idUsuario INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  Email NVARCHAR(50) NOT NULL,
  Senha NVARCHAR(32) NOT NULL,
  Ativo BIT NOT NULL,
  idPessoa INT NOT NULL,
  
  CONSTRAINT PK_Usuarios_IdUsuario PRIMARY KEY (idUsuario),

  CONSTRAINT FK_Usuarios_Pessoas_IdPessoa FOREIGN KEY (idPessoa)
  REFERENCES Pessoas (idPessoa)
)

CREATE TABLE Telefones (
  idTelefone INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  idPessoa INT NOT NULL,
  idTipoTelefone INT NOT NULL,
  Numero NVARCHAR(20) NOT NULL,
  Ativo BIT NOT NULL,

  CONSTRAINT PK_Telefones_IdTelefone PRIMARY KEY (idTelefone),

  CONSTRAINT FK_Telefones_Pessoas_IdPessoa FOREIGN KEY (idPessoa)
  REFERENCES Pessoas (idPessoa),

  CONSTRAINT FK_Telefones_TiposTelefones_idTipoTelefone FOREIGN KEY (idTipoTelefone)
  REFERENCES TiposTelefones (idTipoTelefone)
)

CREATE TABLE TelefonesPessoas(
  IdTelefonePessoa INT NOT NULL IDENTITY(1,1),
  DataCadastro DATETIME NOT NULL,
  IdTelefone INT NOT NULL,
  IdPessoa INT NOT NULL,

  CONSTRAINT PK_TelefonesPessoas_IdTelefonePessoa PRIMARY KEY(IdTelefonePessoa),
  
  CONSTRAINT FK_TelefonesPessoas_Pessoas_IdPessoa FOREIGN KEY (idPessoa)
  REFERENCES Pessoas (idPessoa),

  CONSTRAINT FK_TelefonesPessoas_Telefones_IdTelefone FOREIGN KEY (idTelefone)
  REFERENCES Telefones(idTelefone)

)

CREATE TABLE Assuntos (
  idAssunto INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  Nome NVARCHAR(50) NOT NULL,

  CONSTRAINT PK_Assuntos_IdAssunto PRIMARY KEY (idAssunto)
)

CREATE TABLE Editoras (
  idEditora INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  Nome NVARCHAR(50) NOT NULL,

  CONSTRAINT PK_Editoras_IdEditora PRIMARY KEY (idEditora)
)

CREATE TABLE Materiais (
  IdMaterial INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  Titulo NVARCHAR(50) NOT NULL,
  idAssunto INT NOT NULL,
  idEditora INT NOT NULL,
  Ativo BIT NOT NULL,

  CONSTRAINT PK_Materiais_IdMaterial PRIMARY KEY (IdMaterial),

  CONSTRAINT FK_Materiais_Assuntos_IdAssunto FOREIGN KEY (idAssunto)
  REFERENCES Assuntos (idAssunto),

  CONSTRAINT FK_Materiais_Editoras_IdEditora FOREIGN KEY (idEditora)
  REFERENCES Editoras (idEditora)
)

CREATE TABLE Livros (
  IdLivro INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  Edicao NVARCHAR(50) NOT NULL,
  Isbn NVARCHAR(50) NOT NULL,
  IdMaterial INT NOT NULL,

  CONSTRAINT FK_Livros_IdLivro PRIMARY KEY (IdLivro),

  CONSTRAINT FK_Livros_Materiais_IdMaterial FOREIGN KEY (IdMaterial)
  REFERENCES Materiais (IdMaterial)
)

CREATE TABLE Revistas (
  IdRevista INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  Colecao NVARCHAR(50) NOT NULL,
  IdMaterial INT NOT NULL,
  Ativo BIT NOT NULL,

  CONSTRAINT PK_Revistas_IdRevista PRIMARY KEY (IdRevista),

  CONSTRAINT FK_Revistas_Materiais_IdMaterial FOREIGN KEY (IdMaterial)
  REFERENCES Materiais (IdMaterial)   
)



CREATE TABLE Autores (
  IdAutor INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  Nome NVARCHAR(50) NOT NULL,
  Email NVARCHAR(50) NOT NULL,
  

  CONSTRAINT PK_Autores_IdAutor PRIMARY KEY (IdAutor)
)


CREATE TABLE Artigos (
  IdArtigo INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  Titulo NVARCHAR(50) NOT NULL,
  Ativo BIT NOT NULL,

  CONSTRAINT PK_Artigos_IdArtigo PRIMARY KEY (IdArtigo)
)

CREATE TABLE RevistasArtigos(
  IdRevistaArtigo INT NOT NULL IDENTITY(1,1),
  IdRevista INT NOT NULL,
  IdArtigo INT NOT NULL,

  CONSTRAINT PK_RevistasArtigos_IdRevistaArtigo PRIMARY KEY (IdRevistaArtigo),

  CONSTRAINT FK_RevistasArtigos_Revistas_IdRevista FOREIGN KEY (IdRevista)
  REFERENCES Revistas (IdRevista),

  CONSTRAINT FK_RevistasArtigos_Artigos_IdArtigo FOREIGN KEY (IdArtigo)
  REFERENCES Artigos(IdArtigo)


)



CREATE TABLE Reservas (
  IdReserva INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  DataReserva DATETIME NOT NULL,
  DataValidade DATETIME NOT NULL,
  idUsuario INT NOT NULL,
  IdMaterial INT NOT NULL,
  Ativo BIT NOT NULL,

  CONSTRAINT PK_Reservas_IdReserva PRIMARY KEY (IdReserva),

  CONSTRAINT FK_Reservas_Usuarios_idUsuario FOREIGN KEY (idUsuario)
  REFERENCES Usuarios (idUsuario),

  CONSTRAINT FK_Reservas_Materiais_IdMaterial FOREIGN KEY (IdMaterial)
  REFERENCES Materiais (IdMaterial)    
)

CREATE TABLE MateriaisReservas (
  IdMAteriaisReservas INT NOT NULL IDENTITY(1,1),
  IdMaterial INT NOT NULL,
  IdReserva INT NOT NULL,
  

  CONSTRAINT PK_MateriaisReservas_IdMateriaisReservas PRIMARY KEY (IdMateriaisReservas),

  CONSTRAINT FK_MateriaisReservas_Materiais_IdMaterial FOREIGN KEY (IdMaterial)
  REFERENCES Materiais(IdMaterial),

  CONSTRAINT FK_MateriaisReservas_Reservas_IdReserva FOREIGN KEY (IdReserva)
  REFERENCES Reservas(IdReserva)
)


CREATE TABLE Emprestimos (
  IdEmprestimo INT NOT NULL IDENTITY(1, 1),
  DataCadastro DATETIME NOT NULL,
  DataEmprestimo DATETIME NOT NULL,
  DataPrevistaRetorno DATETIME NOT NULL,
  DataRetorno DATETIME NOT NULL,
  idUsuario INT NOT NULL,

  CONSTRAINT PK_Emprestimos_IdEmprestimo PRIMARY KEY (IdEmprestimo),

  CONSTRAINT FK_Emprestimos_Usuarios_idUsuario FOREIGN KEY (idUsuario)
  REFERENCES Usuarios (idUsuario),

)

CREATE TABLE MateriaisEmprestimos(
  IdMaterialEmprestimo INT NOT NULL IDENTITY(1, 1),
  IdMaterial INT NOT NULL,
  IdEmprestimo INT NOT NULL,

  CONSTRAINT PK_MateriaisEmprestimos_IdMaterialemprestimos PRIMARY KEY(IdMaterialEmprestimo),

  CONSTRAINT FK_MateriaisEmprestimos_Emprestimos_IdEmprestimo FOREIGN KEY (IdEmprestimo)
  REFERENCES Emprestimos (IdEmprestimo),

  CONSTRAINT FK_MateriaisEmprestimos_Materiais_IdMaterial FOREIGN KEY (IdMaterial)
  REFERENCES Materiais (IdMaterial)
)



CREATE TABLE LivrosAutores (
  IdLivroAutor INT NOT NULL IDENTITY(1, 1),
  IdLivro INT NOT NULL,
  IdAutor INT NOT NULL,

  CONSTRAINT PK_LivrosAutores_IdLivroAutor PRIMARY KEY (IdLivroAutor),

  CONSTRAINT FK_LivrosAutores_Livros_IdLivro FOREIGN KEY (IdLivro)
  REFERENCES Livros (IdLivro),

  CONSTRAINT FK_LivrosAutores_Autores_IdAutor FOREIGN KEY (IdAutor)
  REFERENCES Autores (IdAutor)    
)


CREATE TABLE ArtigosAutores (
  IdArtigoAutor INT NOT NULL IDENTITY(1, 1),
  IdArtigo INT NOT NULL,
  IdAutor INT NOT NULL,

  CONSTRAINT PK_ArtigosAutores_IdArtigoAutor PRIMARY KEY (IdArtigoAutor),

  CONSTRAINT FK_ArtigosAutores_Artigos_IdArtigo FOREIGN KEY (IdArtigo)
  REFERENCES Artigos (IdArtigo),

  CONSTRAINT FK_ArtigosAutores_Autores_IdAutor FOREIGN KEY (IdAutor)
  REFERENCES Autores (IdAutor)
)
