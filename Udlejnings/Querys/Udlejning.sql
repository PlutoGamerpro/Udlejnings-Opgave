USE UdlejningsDatabase;


CREATE TABLE BrugerLejer(
ID INT IDENTITY(1,1),
Fornavn VARCHAR(20),
Efternavn VARCHAR(20),
Adgangskode VARCHAR(20),
Salt NVARCHAR(255),
Role NVARCHAR(50),
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


CREATE TABLE Bookings (
    Id INT PRIMARY KEY IDENTITY,
    BrugerId INT,
    SommerhusId INT,
    LejlighedId INT,
    StartDate DATE,
    EndDate DATE,
    Price DECIMAL(18, 2),
    Status VARCHAR(50), -- Kan være "Pending", "Confirmed", "Rejected"
    FOREIGN KEY (BrugerId) REFERENCES BrugerLejer(Id),
    FOREIGN KEY (SommerhusId) REFERENCES Sommerhuse(Id),
    FOREIGN KEY (LejlighedId) REFERENCES Lejlheder(Id)
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
    LejlhederID INT,
    SommerhuseID INT,
    OmrådeID INT,
    BrugerLejerID INT,
    OpsynsmændID INT,
    UdlejerID INT,
    UdlejningskonsulentID INT,
    PrisseasonerID INT,

    CONSTRAINT PrisseasonerID_FK_KEY FOREIGN KEY(PrisseasonerID) REFERENCES Prisseasoner(ID),
    CONSTRAINT Udlejningskonsulent_FK_KEY FOREIGN KEY(UdlejningskonsulentID) REFERENCES Udlejningskonsulent(ID), 
    CONSTRAINT UdLejer_FK_KEY FOREIGN KEY(UdlejerID) REFERENCES Udlejer(ID),
    CONSTRAINT OpsynsmændID_FK_KEY FOREIGN KEY(OpsynsmændID) REFERENCES Opsynsmænd(ID),
    CONSTRAINT BrugerLejer_FK_KEY FOREIGN KEY(BrugerLejerID) REFERENCES BrugerLejer(ID),
    CONSTRAINT Område_FK_KEY FOREIGN KEY(OmrådeID) REFERENCES Områder(ID),
    CONSTRAINT Lejlhed_FK_KEY FOREIGN KEY (LejlhederID) REFERENCES Lejlheder(ID),
    CONSTRAINT Sommerhuse_FK_KEY FOREIGN KEY (SommerhuseID) REFERENCES Sommerhuse(ID)
);



INSERT INTO Prisseasoner (Prisseasoner)
VALUES
('super'),
('hoj'),
('mellem'),
('lav');



