CREATE TABLE Customers
(
CustID BLOB PRIMARY KEY NOT NULL,
Email TEXT not null,
CustName TEXT not null,
Phone TEXT
);
CREATE TABLE Tickets(
TicketID INTEGER PRIMARY KEY NOT NULL,
TicketType TEXT not null,
CustID BLOB not null,
BallNumbers BLOB,
FOREIGN KEY (CustID) REFERENCES Customers (CustID)
); 

CREATE TABLE Lottos(
TicketID INTEGER PRIMARY KEY NOT NULL,
BonusBall INTEGER,
RetailerCode TEXT,
FOREIGN KEY (TicketID) REFERENCES Tickets (TicketID));

CREATE TABLE Euros(
TicketID INTEGER PRIMARY KEY NOT NULL,
LuckyStar BLOB,
Country TEXT,
FOREIGN KEY (TicketID) REFERENCES Tickets (TicketID));

	   