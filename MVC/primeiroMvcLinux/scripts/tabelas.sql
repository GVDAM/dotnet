CREATE DATABASE corujaoTeste;

USE corujaoTeste;

CREATE TABLE Alunos
(
	id INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL,
    turma VARCHAR(7) NOT NULL,
    fk_curso INT
);

CREATE TABLE Cursos
(
	id INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL UNIQUE
);

ALTER TABLE Alunos
ADD CONSTRAINT FK_Aluno_curso
FOREIGN KEY (fk_curso)
REFERENCES Cursos(id);

INSERT INTO Cursos
(nome)
VALUES
('Ciencia Da Computacao'),
('Engenharia Da Computacao'),
('Analise e Desenvolvimento de Sistemas'),
('Matematica');

INSERT INTO Alunos
(nome, turma, fk_curso)
VALUES
('Gabriel Vargas Dambroski', 'CI63A', 1),
('William Da Silva Pereira', 'CI63A', 2),
('Andre Buzelli Campones', 'ADS63A', 3),
('Emanuel Dos Santos', 'CM32A', 4);



-- DESC Cursos;
-- DESC Alunos;
SELECT * FROM Cursos;
SELECT * FROM Alunos;
-- DROP DATABASE corujaoTeste;

