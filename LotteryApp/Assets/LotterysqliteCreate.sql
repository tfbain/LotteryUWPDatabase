CREATE TABLE Customers
(
custID INTEGER PRIMARY KEY NOT NULL,
email TEXT not null,
custName TEXT not null,
phone TEXT
);
CREATE TABLE Tickets(
ticketID INTEGER PRIMARY KEY NOT NULL,
ticketType TEXT not null,
custID INTEGER not null,
ballNumbers blob,
FOREIGN KEY (custID) REFERENCES Customers (custID)
); 

CREATE TABLE Lottos(
ticketID INTEGER PRIMARY KEY NOT NULL,
bonusBall INTEGER,
retailerCode TEXT,
FOREIGN KEY (ticketID) REFERENCES Tickets (ticketID));

CREATE TABLE Euros(
ticketID INTEGER PRIMARY KEY NOT NULL,
luckyStar BLOB,
country TEXT,
FOREIGN KEY (ticketID) REFERENCES Tickets (ticketID));

	   