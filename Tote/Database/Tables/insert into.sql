insert into Sport values ('Football');
insert into Sport values ('Hockey');
insert into Sport values ('Basketball');

insert into Tournament values ('Seria A',1);
insert into Tournament values ('Bundesliga',1);
insert into Tournament values ('Spain Championship',1);
insert into Tournament values ('Euroliga',3);
insert into Tournament values ('KHL',2);
insert into Tournament values ('Champions League',1);

insert into Country values ('Italy');
insert into Country values ('Belarus');
insert into Country values ('Russia');
insert into Country values ('Germany');
insert into Country values ('Latvia');
insert into Country values ('Spain');

insert into Team values ('AC Milan',1,1);
insert into Team values ('Juventus',1,1);
insert into Team values ('Napoli',1,1);
insert into Team values ('Dinamo Minsk',2,2);
insert into Team values ('AK Bars',2,3);
insert into Team values ('Dinamo Riga',2,5);
insert into Team values ('CSKA Moscow',3,3);
insert into Team values ('Khimki',3,3);
insert into Team values ('Bayern Munich',1,4);
insert into Team values ('Real Madrid',1,6);

insert into Result values ('Win');
insert into Result values ('Loss');
insert into Result values ('Draw');


insert into Match values (1,2,GETDATE(),1,1);
insert into Match values (3,2,GETDATE(),1,2);
insert into Match values (3,1,GETDATE(),1,1);
insert into Match values (4,6,GETDATE(),2,5);
insert into Match values (5,4,GETDATE(),3,5);
insert into Match values (7,8,GETDATE(),2,4);
insert into Match values (9,10,GETDATE(),1,6);
insert into Match values (10,9,GETDATE(),3,6);


	
insert into Bet values (1.5, 3.12, 2.26,1);
insert into Bet values (1.75, 2.12, 3.16,2);
insert into Bet values (1.11, 5.17, 3.17,3);
insert into Bet values (1.25, 3.87, 2.26,3);
insert into Bet values (3.5, 3.72, 1.26,7);
insert into Bet values (2.56, 7.19, 2.76,8);
