USE UdlejningsDatabase;


CREATE TABLE BrugerLejer(
ID INT IDENTITY(1,1),
Fornavn VARCHAR(20),
Efternavn VARCHAR(20),
Adgangskode VARCHAR(20),
);

CREATE TABLE Prisseasoner(
ID INT IDENTITY(1,1),
Prisseasoner NVARCHAR(20),
);

CREATE TABLE Sommerhuse(
ID INT IDENTITY (1,1),
Seng FLOAT,
Kvalitet FLOAT,
 --- add price here 
);
CREATE TABLE Lejlheder(
ID INT IDENTITY(1,1),
Seng FLOAT,
Kvalitet FLOAT,
);

CREATE TABLE Udlejer(
ID INT IDENTITY (1,1),
Fornavn VARCHAR(20),
Efternavn VARCHAR(20),
);

CREATE TABLE Opsynsmænd(
ID INT IDENTITY(1,1),
Fornavn VARCHAR(20),
Efternavn VARCHAR(20),
);

CREATE TABLE Udlejningskonsulent(
ID INT IDENTITY(1,1),
Fornavn VARCHAR(20),
Efternavn VARCHAR(20),
);

CREATE TABLE Områder(
ID INT IDENTITY(1,1),
OmrådeNavn VARCHAR(30),
);

INSERT INTO Prisseasoner (Prisseasoner)
VALUES
('Super'),
('Høj'),
('Mellem'),
('Lav');
