INSERT INTO Customers(custID, email, custName, phone) 
VALUES (1, 'g.starr@basil.com', 'Garry starr', '0131 345678');
INSERT INTO Customers(custID, email, custName, phone) 
VALUES (2, 'i.zwierko@yahoo.com', 'Ilona Zwierko', '0131 345678');

INSERT INTO Tickets(ticketID, ticketType, custID, ballNumbers)
VALUES(1, 'L', 1, '{3,44,22,1,7,10}'),
      (2, 'L', 1, '{2,47,12,40,49,1}'),
	  (3, 'E', 1, '{22,40,12,46,4,7}'),
	  (4, 'E', 1, '{22,24,11,46,9,8}'),
	  (5, 'E', 2, '{25,4,31,41,49,9}');
	  
INSERT INTO Euros(ticketID, luckyStar,country)
VALUES (3, '{5,6}', 'UK'),
       (4, '{4,3}', 'FR'),
       (5, '{9,6}', 'UK');	  
	   
INSERT INTO Lottos(ticketID, bonusBall, retailerCode)
VALUES (1, 40, 'TE'),
       (2, 34, 'AS');	   