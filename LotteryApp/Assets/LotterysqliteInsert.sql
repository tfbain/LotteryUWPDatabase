INSERT INTO Customers(CustID, Email, CustName, Phone) 
VALUES ('00000000-0000-0000-0000-000000000001', 'g.starr@basil.com', 'Garry starr', '0131 345678');
INSERT INTO Customers(CustID, Email, CustName, Phone) 
VALUES ('00000000-0000-0000-0000-000000000002', 'i.zwierko@yahoo.com', 'Ilona Zwierko', '0131 345678');

INSERT INTO Tickets(TicketID, TicketType, CustID, BallNumbers)
VALUES(1, 'L', '00000000-0000-0000-0000-000000000001', '{3,44,22,1,7,10}'),
      (2, 'L', '00000000-0000-0000-0000-000000000001', '{2,47,12,40,49,1}'),
	  (3, 'E', '00000000-0000-0000-0000-000000000001', '{22,40,12,46,4,7}'),
	  (4, 'E', '00000000-0000-0000-0000-000000000001', '{22,24,11,46,9,8}'),
	  (5, 'E', '00000000-0000-0000-0000-000000000002', '{25,4,31,41,49,9}');	  

INSERT INTO Euros(TicketID, LuckyStar,Country)
VALUES (3, '{5,6}', 'UK'),
       (4, '{4,3}', 'FR'),
       (5, '{9,6}', 'UK');	  
	   
INSERT INTO Lottos(TicketID, BonusBall, RetailerCode)
VALUES (1, 40, 'TE'),
       (2, 34, 'AS');	   