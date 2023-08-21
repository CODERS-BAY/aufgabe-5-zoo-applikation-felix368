drop database Zoo;
create database Zoo;
use Zoo;


create table konto(
                      id int primary key auto_increment,
                      kontostand double
);


create table kassa(
                      id int primary key auto_increment,
                      kassastand double,
                      kontoId int,
                      foreign key (kontoId) references konto(id)
);





create table shop(
                     id int primary key auto_increment,
                     fläche int,
                     kontoId int,
                     foreign key (kontoId) references konto(id)
);

create table product(
                        id int primary key auto_increment,
                        preis double,
                        name varchar(255),
                        zeitpunkt timestamp not null ,
                        bestand int,
                        kassaId int,
                        foreign key (kassaId) references kassa(id),
                        shopId int,
                        foreign key (shopId) references shop(id)
);


create table mitarbeiter(
                            id int primary key auto_increment,
                            position varchar(255),
                            mitarbeiterAlter int,
                            name varchar(255),
                            shopId int,
                            foreign key (shopId) references shop(id),
                            kassaId int,
                            foreign key (kassaId) references kassa(id)
);


create table gehege(
                       Id int primary key auto_increment,
                       volumen int,
                       standort varchar(255),
                       gehegeart varchar(255),
                       mitarbeiterId int,
                       foreign key (mitarbeiterId) references mitarbeiter(id)
);


create table tiere(
                      id int primary key auto_increment,
                      gattung varchar(255),
                      nahrung varchar(255),
                      gehegeId int,
                      foreign key (gehegeId) references gehege(id)
);



create table Tickets(
                        id int primary key auto_increment,
                        preis double,
                        zeitpunkt timestamp  not null 
);




drop user 'zooUser'@'Zoo';
CREATE USER 'zooUser'@'Zoo' IDENTIFIED BY 'password';

GRANT INSERT, SELECT ON Zoo.* TO 'zooUser'@'zoo';

SHOW GRANTS FOR 'zooUser'@'zoo';




insert into konto(kontostand) value (100);
insert into kassa(kassastand,kontoId) value 
(10,1);
insert into kassa(kassastand,kontoId) value
    (12,1);
insert into shop(fläche, kontoId) VALUE 
(30,1);

insert into product(preis, name, bestand, kassaId) value 
(8.50,'Ticket',1000,1);

insert into mitarbeiter(position, mitarbeiterAlter, name, shopId, kassaId) value 
('Tierpfleger','25','max',1,null);

insert into mitarbeiter(position, mitarbeiterAlter, name, shopId, kassaId) value
    ('Tierpfleger','25','max',null,null);

insert into mitarbeiter(position, mitarbeiterAlter, name, shopId, kassaId) value
    ('Tierpfleger','36','Tim',null,null);

insert into mitarbeiter(position, mitarbeiterAlter, name, shopId, kassaId) value
    ('Kassierer','45','Franz',null,1);


insert into gehege(volumen, standort, gehegeart, mitarbeiterid) value 
(200,'Wald','Käfig',1);
insert into gehege(volumen, standort, gehegeart, mitarbeiterid) value
    (500,'Wald','Käfig',1);


insert into gehege(volumen, standort, gehegeart, mitarbeiterid) value
    (500,'Wald','Käfig',3);

insert into tiere(gattung, nahrung, gehegeId) value 
('Tiger','Fleisch',2);

insert into tiere(gattung, nahrung, gehegeId) value
    ('Tigermücke','Nektar',2);

insert into tiere(gattung, nahrung, gehegeId) value
    ('affen ','Blätter',2);

insert into tiere(gattung, nahrung, gehegeId) value
    ('warzenschwein ','Wurzeln ',5);


insert into Tickets(preis) value 
(8.50);

select * from tiere;
select * from mitarbeiter;
select * from gehege;

select * from Tickets where date(zeitpunkt) = '2023-08-03';


select * from tiere where gattung = "tiger";


select tiere.id,tiere.gattung,tiere.nahrung,tiere.gehegeId from tiere join 
gehege g on g.Id = tiere.gehegeId join 
mitarbeiter m on g.mitarbeiterId = m.id
where mitarbeiterId = "5";

#select tiere.id,tiere.gattung,tiere.nahrung,tiere.gehegeId from tiere join gehege g on g.Id = tiere.gehegeId join mitarbeiter m on g.mitarbeiterId = m.idwhere mitarbeiterId = {Int32.TryParse(pflegerId)};"

update tiere set nahrung ="Fleisch" where id=6;

update gehege set mitarbeiterId=5 where Id= 5;