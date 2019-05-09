use master;

DROP DATABASE projetoES;

CREATE DATABASE projetoES;

use projetoES;

IF OBJECT_ID('projetoES.funcionario') IS NULL
BEGIN
	CREATE TABLE endereco (
	id INTEGER IDENTITY(1,1) PRIMARY KEY,
	logradouro VARCHAR(200),
	numero VARCHAR(200),
	cidade VARCHAR(200),
	estado VARCHAR(200),
	);
END
ELSE
BEGIN
	PRINT 'Tabela já existe'	
END

IF OBJECT_ID('projetoES.funcionario') IS NULL
BEGIN
	CREATE TABLE funcionario (
	id INTEGER IDENTITY(1,1) PRIMARY KEY,
	nome VARCHAR(200),
	cpf VARCHAR(200),
	dataContratacao DATE,
	matricula VARCHAR(200),
	cargo VARCHAR(200),
	setor VARCHAR(200),
	regional VARCHAR(200),
	email VARCHAR(200),
	tipo_status INTEGER,
	codigo INTEGER,
	dataCadastro DATE,
	id_endereco INTEGER FOREIGN KEY REFERENCES endereco(id)
	);

	PRINT 'Tabela criada com sucesso'
END
ELSE
BEGIN
	PRINT 'Tabela já existe'	
END