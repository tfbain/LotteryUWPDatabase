CREATE TABLE customer
(
custID INTEGER PRIMARY KEY NOT NULL,
email TEXT not null,
custName TEXT not null,
phone TEXT
);
CREATE TABLE ticket(
ticketID INTEGER PRIMARY KEY NOT NULL,
ticketType TEXT not null,
custID INTEGER not null,
ballNumbers blob,
FOREIGN KEY (custID) REFERENCES customer (custID)
); 

CREATE TABLE lotto(
ticketID INTEGER PRIMARY KEY NOT NULL,
bonusBall INTEGER,
retailerCode TEXT,
FOREIGN KEY (ticketID) REFERENCES ticket (ticketID));

CREATE TABLE euro(
ticketID INTEGER PRIMARY KEY NOT NULL,
luckyStar BLOB,
country TEXT,
FOREIGN KEY (ticketID) REFERENCES ticket (ticketID));

	   