USE rentcar

SELECT * FROM Vendedores
SELECT * FROM Scores
SELECT * FROM Carros
SELECT * FROM Vendas
SELECT * FROM Clientes

-- ================= --

INSERT INTO Vendedores VALUES
('53658542-7B12-4421-9AC1-3C8636B719AC','Marcos PUT',3),
('1AC7A566-4D4F-47A6-8E6B-9D6F4599B204','Andr�',65),
('D23450A4-4FD3-4A59-BD4F-D4D88540C0FC','Gabriel',5)


INSERT INTO Scores VALUES
('0A9F8FB6-DEB3-4EDB-A956-0068863A5152',321,'53658542-7B12-4421-9AC1-3C8636B719AC'),
('11807E32-D85D-4039-9852-4737A25BF698',500,'1AC7A566-4D4F-47A6-8E6B-9D6F4599B204'),
('4DFAA50E-BDB1-4505-A01A-B9E9C2EA578E',12, 'D23450A4-4FD3-4A59-BD4F-D4D88540C0FC')

INSERT INTO Carros VALUES
('3E78A324-9322-478F-9844-47EB7C504287','Golf','Volkswagen','ret',2013,1,151.53,1),
('EEF94B55-6DF3-4779-BE6F-7FAC893B5149','Civic','Honda','sedan',2017,1,6000000.00,1),
('526FE95D-ACEE-4DF4-A7FD-9FBFB2C84290','Celta','Chevrolet','ret',2000,1,15200.00,1)

INSERT INTO Vendas VALUES
('109EBC4B-7A8A-498F-AE69-1539829B6AA6','2020-01-16 10:19:45.0000000',22,'53658542-7B12-4421-9AC1-3C8636B719AC','3E78A324-9322-478F-9844-47EB7C504287','EA01A032-BC93-46DA-B763-DE748B4BD08E')

INSERT INTO Clientes VALUES
('DD0B9008-D598-4A91-83E8-2FE706D9688E','Jo�o PUT',70801326818,'joao@mail.com'),
('F7B75022-4F11-4F6A-852D-89944D9323FA','gabriel PUT',31061934098,'gabriel@mail.com'),
('EA01A032-BC93-46DA-B763-DE748B4BD08E','Samuel',17705612690,'samuel@mail.com'),
('177D9E4D-0E7F-4DEC-A33B-461E4B5D3DC1','William',02783947251,'william@mail.com')


-- ================= --

DROP TABLE Vendedores
DROP TABLE Score
DROP TABLE Carros
DROP TABLE Clientes
DROP TABLE Vendas