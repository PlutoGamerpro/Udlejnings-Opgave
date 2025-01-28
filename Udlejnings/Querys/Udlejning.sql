USE UdlejningsDatabase;


CREATE TABLE BrugerLejer(
ID INT IDENTITY(1,1),
Fornavn VARCHAR(20),
Efternavn VARCHAR(20),
Adgangskode VARCHAR(20),

CONSTRAINT BrugerLejer_PK_KEY PRIMARY KEY (ID),
);

CREATE TABLE Prisseasoner(
ID INT IDENTITY(1,1),
Prisseasoner NVARCHAR(20),
CONSTRAINT Prisseasoner_PK_KEY PRIMARY KEY(ID),
);

CREATE TABLE Sommerhuse(
ID INT IDENTITY (1,1),
SengeAntal FLOAT,
Kvalitet FLOAT,
Pris FLOAT,

CONSTRAINT Sommerhuse_PK_KEY PRIMARY KEY(ID),
 --- add price here 
);
CREATE TABLE Lejlheder(
ID INT IDENTITY(1,1),
SengeAntal FLOAT,
Kvalitet FLOAT,
Pris FLOAT,

CONSTRAINT Lejlheder_PK_KEY PRIMARY KEY (ID),
);

CREATE TABLE Udlejer(
ID INT IDENTITY (1,1),
Fornavn VARCHAR(20),
Efternavn VARCHAR(20),

CONSTRAINT Udlejer_PK_KEY PRIMARY KEY (ID),
);

CREATE TABLE Opsynsmænd(
ID INT IDENTITY(1,1),
Fornavn VARCHAR(20),
Efternavn VARCHAR(20),

CONSTRAINT Opsynsmænd_PK_KEY PRIMARY KEY (ID),
);

CREATE TABLE Udlejningskonsulent(
ID INT IDENTITY(1,1),
Fornavn VARCHAR(20),
Efternavn VARCHAR(20),

CONSTRAINT Udlejningskonsulent_PK_KEY PRIMARY KEY (ID),
);

CREATE TABLE Områder(
ID INT IDENTITY(1,1),
OmrådeNavn VARCHAR(30),

CONSTRAINT Områder_PK_KEY PRIMARY KEY (ID),
);

INSERT INTO Prisseasoner (Prisseasoner)
VALUES
('Super'),
('Høj'),
('Mellem'),
('Lav');
