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

CREATE TABLE CombineTable(
INT LejlhederID,
INT SommehuseID,
INT OmrådeID,
INT BrugerLejerID,
INT OpsynsmændID,
INT UdlejerID,
INT UdlejningskonsulentID,
INT PrisseasonerID,

CONSTRAINT PrisseasonerID_FK_KEY FOREIGN KEY(PrisseasonerID) REFERENCES Prisseasoner(Prisseasoner_PK_KEY),
CONSTRAINT Udlejningskonsulent_FK_KEY FOREIGN KEY(UdlejningskonsulentID) REFERENCES Udlejningskonsulent(Udlejningskonsulent_PK_KEY), 
CONSTRAINT UdLejer_FK_KEY FOREIGN KEY(UdlejerID) REFERENCES Udlejer(Udlejer_PK_KEY),
CONSTRAINT OpsynsmændID_FK_KEY FOREIGN KEY(OpsynsmændID) REFERENCES Opsynsmænd(Opsynsmænd_PK_KEY),
CONSTRAINT BrugerLejer_FK_KEY FOREIGN KEY(BrugerLejerID) REFERENCES BrugerLejer(BrugerLejer_PK_KEY),
CONSTRAINT Område_FK_KEY FOREIGN KEY(OmrådeID) REFERENCES Områder(Områder_PK_KEY),
CONSTRAINT Lejlhed_FK_KEY FOREIGN KEY (LejlhederID) REFERENCES Lejlheder(Lejlheder_PK_KEY),
CONSTRAINT Sommehuse_FK_KEY FOREIGN KEY (SommehuseID) REFERENCES Sommerhuse(Sommerhuse_PK_KEY)
);


INSERT INTO Prisseasoner (Prisseasoner)
VALUES
('Super'),
('Høj'),
('Mellem'),
('Lav');
