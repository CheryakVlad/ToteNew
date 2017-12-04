insert into Sport values('Football');
insert into Sport values('Hockey');
insert into Sport values('Basketball');

insert into Country values('Italy');
insert into Country values('Belarus');
insert into Country values('Russia');
insert into Country values('Germany');
insert into Country values('Latvia');
insert into Country values('Spain');

insert into Tournament values('Seria A',1);
insert into Tournament values('Bundesliga',1);
insert into Tournament values('Spain Championship',1);
insert into Tournament values('Euroliga',3);
insert into Tournament values('KHL',2);
insert into Tournament values('Champions League',1);

insert into Team values('AC Milan',1,1);
insert into Team values('Juventus',1,1);
insert into Team values('Napoli',1,1);
insert into Team values('Dinamo Minsk',2,2);
insert into Team values('AK Bars',3,2);
insert into Team values('Dinamo Riga',5,2);
insert into Team values('CSKA Moscow',3,3);
insert into Team values('Khimki',3,3);
insert into Team values('Bayern Munich',4,1);
insert into Team values('FC Real Madrid',6,1);

insert into TeamTournament values(1,1);
insert into TeamTournament values(2,1);
insert into TeamTournament values(3,1);
insert into TeamTournament values(4,5);
insert into TeamTournament values(5,5);
insert into TeamTournament values(6,5);
insert into TeamTournament values(7,4);
insert into TeamTournament values(8,4);
insert into TeamTournament values(9,6);
insert into TeamTournament values(10,6);

insert into Result values('Win');
insert into Result values('Loss');
insert into Result values('Draw');

insert into Match values(CONVERT(datetime, '2017-26-10 21:45:00.000'),1,1,'0:2');
insert into Match values(CONVERT(datetime,'2017-30-10 19:30:00.000'),1,2,'2:1');
insert into Match values(CONVERT(datetime,'2017-05-11 19:30:00.000'),1,1,'3:0');
insert into Match values(CONVERT(datetime,'2017-14-11 20:45:00.000'),2,5,'4:4');
insert into Match values(CONVERT(datetime,'2017-26-11 20:45:00.000'),3,5,'2:3');
insert into Match values(CONVERT(datetime,'2017-01-12 21:45:00.000'),2,4,'0:0');
insert into Match values(CONVERT(datetime,'2017-05-12 21:45:00.000'),1,6,'0:0');
insert into Match values(CONVERT(datetime,'2017-17-12 21:45:00.000'),3,6,'0:0');

insert into TeamMatch values(1,1,'True');
insert into TeamMatch values(1,2,'False');
insert into TeamMatch values(2,2,'False');
insert into TeamMatch values(2,3,'True');
insert into TeamMatch values(3,1,'False');
insert into TeamMatch values(3,3,'True');
insert into TeamMatch values(4,4,'True');
insert into TeamMatch values(4,6,'False');
insert into TeamMatch values(5,4,'False');
insert into TeamMatch values(5,5,'True');
insert into TeamMatch values(6,7,'True');
insert into TeamMatch values(6,8,'False');
insert into TeamMatch values(7,9,'True');
insert into TeamMatch values(7,10,'False');
insert into TeamMatch values(8,9,'False');
insert into TeamMatch values(8,10,'True');


insert into dbo.Event values('Win');
insert into dbo.Event values('Loss');
insert into dbo.Event values('Draw');

insert into Bet values(1,'True');
insert into Bet values(1,'True');
insert into Bet values(3,'True');
insert into Bet values(3,'True');
insert into Bet values(7,'True');
insert into Bet values(8,'True');
insert into Bet values(4,'True');
insert into Bet values(5,'True');
insert into Bet values(6,'True');

insert into EventBet values(1,1,1.5);
insert into EventBet values(2,1,3.12);
insert into EventBet values(3,1,2.26);
insert into EventBet values(1,2,1.75);
insert into EventBet values(2,2,2.12);
insert into EventBet values(3,2,3.16);
insert into EventBet values(1,3,1.11);
insert into EventBet values(2,3,5.17);
insert into EventBet values(3,3,3.17);
insert into EventBet values(1,4,1.25);
insert into EventBet values(2,4,3.87);
insert into EventBet values(3,4,2.26);
insert into EventBet values(1,5,3.5);
insert into EventBet values(2,5,3.72);
insert into EventBet values(3,5,1.26);
insert into EventBet values(1,6,2.56);
insert into EventBet values(2,6,7.19);
insert into EventBet values(3,6,2.76);
insert into EventBet values(1,7,1.59);
insert into EventBet values(2,7,4.58);
insert into EventBet values(3,7,2.45);
insert into EventBet values(1,8,5.16);
insert into EventBet values(2,8,1.84);
insert into EventBet values(3,8,3.32);
insert into EventBet values(1,9,1.5);
insert into EventBet values(2,9,3.67);
insert into EventBet values(3,9,9.99);