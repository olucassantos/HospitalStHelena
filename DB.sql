﻿CREATE DATABASE hospital;

USE hospital;

CREATE TABLE cargos (
    id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    titulo VARCHAR(255) NOT NULL,
    descricao VARCHAR(255) NULL
);

CREATE TABLE funcionarios(
    id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    data_nascimento DATE NOT NULL,
    cpf VARCHAR(11) NOT NULL,
    email VARCHAR(255) NOT NULL,
    senha VARCHAR(10) NOT NULL,
    cargo_id INT NULL
);