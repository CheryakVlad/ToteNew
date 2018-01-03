insert into Country values('Italy','False');
insert into Country values('Belarus','False');
insert into Country values('Russia','False');
insert into Country values('Germany','False');
insert into Country values('Latvia','False');
insert into Country values('Spain','False');

insert into Sport values('Football','False');
insert into Sport values('Hockey','False');
insert into Sport values('Basketball','False');

insert into Tournament values('Seria A',1,'False');
insert into Tournament values('Bundesliga',1,'False');
insert into Tournament values('Spain Championship',1,'False');
insert into Tournament values('Euroliga',3,'False');
insert into Tournament values('KHL',2,'False');
insert into Tournament values('Champions League',1,'False');

insert into Team values('AC Milan',1,1,'False');
insert into Team values('Juventus',1,1,'False');
insert into Team values('Napoli',1,1,'False');
insert into Team values('Dinamo Minsk',2,2,'False');
insert into Team values('AK Bars',3,2,'False');
insert into Team values('Dinamo Riga',5,2,'False');
insert into Team values('CSKA Moscow',3,3,'False');
insert into Team values('Khimki',3,3,'False');
insert into Team values('Bayern Munich',4,1,'False');
insert into Team values('FC Real Madrid',6,1,'False');

insert into TeamTournament values(1,1,'False');
insert into TeamTournament values(2,1,'False');
insert into TeamTournament values(3,1,'False');
insert into TeamTournament values(4,5,'False');
insert into TeamTournament values(5,5,'False');
insert into TeamTournament values(6,5,'False');
insert into TeamTournament values(7,4,'False');
insert into TeamTournament values(8,4,'False');
insert into TeamTournament values(9,6,'False');
insert into TeamTournament values(10,6,'False');

insert into Result values('Win');
insert into Result values('Loss');
insert into Result values('Draw');

insert into Match values(CONVERT(datetime,'2017-26-10 21:45:00.000'),1,1,'0:2','False');
insert into Match values(CONVERT(datetime,'2017-30-10 19:30:00.000'),	1,	2,	'2:1',	'False');
insert into Match values(CONVERT(datetime,'2017-05-11 19:30:00.000'),	1,	1,	'3:0',	'False');
insert into Match values(CONVERT(datetime,'2017-14-11 20:45:00.000'),	2,	5,	'4:4',	'False');
insert into Match values(CONVERT(datetime,'2017-26-11 20:45:00.000'),	3,	5,	'2:3',	'False');
insert into Match values(CONVERT(datetime,'2017-01-12 21:45:00.000'),	2,	4,	'0:0',	'False');
insert into Match values(CONVERT(datetime,'2017-05-12 21:45:00.000'),	1,	6,	'0:0',	'False');
insert into Match values(CONVERT(datetime,'2017-17-12 21:45:00.000'),	3,	6,	'0:0',	'False');

insert into TeamMatch values(1,	1,	'True');
insert into TeamMatch values(1,	2,	'False');
insert into TeamMatch values(2,	2,	'False');
insert into TeamMatch values(2,	3,	'True');
insert into TeamMatch values(3,	1,	'False');
insert into TeamMatch values(3,	3,	'True');
insert into TeamMatch values(4,	4,	'True');
insert into TeamMatch values(4,	6,	'False');
insert into TeamMatch values(5,	4,	'False');
insert into TeamMatch values(5,	5,	'True');
insert into TeamMatch values(6,	7,	'True');
insert into TeamMatch values(6,	8,	'False');
insert into TeamMatch values(7,	9,	'True');
insert into TeamMatch values(7,	10,	'False');
insert into TeamMatch values(8,	9,	'False');
insert into TeamMatch values(8,	10,	'True');


insert into Event values('Win');
insert into Event values('Loss');
insert into Event values('Draw');

insert into EventMatch values(1,1,1.5);
insert into EventMatch values(1,2,1.75);
insert into EventMatch values(1,3,1.11);
insert into EventMatch values(1,4,1.25);
insert into EventMatch values(1,5,3.5);
insert into EventMatch values(1,6,2.56);
insert into EventMatch values(1,7,1.61);
insert into EventMatch values(1,8,5.16);
insert into EventMatch values(2,1,3.12);
insert into EventMatch values(2,2,2.12);
insert into EventMatch values(2,3,5.17);
insert into EventMatch values(2,4,3.87);
insert into EventMatch values(2,5,3.72);
insert into EventMatch values(2,6,7.19);
insert into EventMatch values(2,7,4.58);
insert into EventMatch values(2,8,1.84);
insert into EventMatch values(3,1,2.26);
insert into EventMatch values(3,2,3.16);
insert into EventMatch values(3,3,3.17);
insert into EventMatch values(3,4,2.26);
insert into EventMatch values(3,5,1.26);
insert into EventMatch values(3,6,2.76);
insert into EventMatch values(3,7,2.45);
insert into EventMatch values(3,8,3.32);


insert into Role values('Admin');
insert into Role values('Editor');
insert into Role values('User');


insert into User_ values('admin',	'admin',	'admin@mail.ru',	1882.6600,	'Admin',	'123456789',	'False');
insert into User_ values('editor',	'editor',	'editor@mail.ru',	150.0000,	'EditorFIO',	NULL,	'False');
insert into User_ values('user',	'user',	'user@mail.ru',	13797.6800,	'User',	'123',	'False');

insert into RoleUser values(1,1);
insert into RoleUser values(2,2);
insert into RoleUser values(3,3);

insert into Bet values(1,	'True',	1);
insert into Bet values(1,	'True',	1);
insert into Bet values(2,	'True',	1);
insert into Bet values(2,	'False', 2);
insert into Bet values(3,	'True',	1);
insert into Bet values(4,	'False', 1);
insert into Bet values(5,	'False', 1);
insert into Bet values(6,	'False', 1);
insert into Bet values(7,	'True', 1);
insert into Bet values(8,	'False',	1);


insert into Rate values(CONVERT(datetime,'2017-25-10 21:45:00.000'),100.0000,1,'True');
insert into Rate values(CONVERT(datetime,'2017-24-10 19:30:00.000'),600.0000,3,'True');
insert into Rate values(CONVERT(datetime,'2017-28-10 20:45:00.000'),550.0000,3,'True');
insert into Rate values(CONVERT(datetime,'2017-29-10 20:45:00.000'),10.0000,1,'False');
insert into Rate values(CONVERT(datetime,'2017-03-11 20:45:00.000'),10.0000,1,'True');
insert into Rate values(CONVERT(datetime,'2017-10-11 20:45:00.000'),550.0000,3,'False');
insert into Rate values(CONVERT(datetime,'2017-23-11 20:45:00.000'),10.0000,3,'False');
insert into Rate values(CONVERT(datetime,'2017-25-11 20:45:00.000'),10.0000,1,'False');
insert into Rate values(CONVERT(datetime,'2017-23-11 20:45:00.000'),10.0000,3,'True');
insert into Rate values(CONVERT(datetime,'2017-25-11 20:45:00.000'),10.0000,1,'False');

insert into BetRate values(1,1);
insert into BetRate values(2,2);
insert into BetRate values(3,3);
insert into BetRate values(4,4);
insert into BetRate values(5,5);
insert into BetRate values(6,6);
insert into BetRate values(7,7);
insert into BetRate values(8,8);
insert into BetRate values(9,9);
insert into BetRate values(10,10);

