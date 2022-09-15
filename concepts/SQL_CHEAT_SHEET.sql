create user 'dimas'@'localhost' identified by 'password';

grant all privileges on *.* to 'dimas'@'localhost';

drop schema if exists `play_ground`;

create schema `play_ground`;

show databases;

use `play_ground`;

set FOREIGN_KEY_CHECKS = 0;

create table `YOUR_SIMPLE_TABLE`(
    `id` int(11) not null auto_increment,
    `first_field` varchar(128) default null,
    `second_field` varchar(128) default null,


    primary key(`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;


-- shows table description --
describe `YOUR_SIMPLE_TABLE`;

-- different insert samples --
insert into `YOUR_SIMPLE_TABLE` values(1,'an example of description','intersting');
insert into `YOUR_SIMPLE_TABLE` values(2,'another simple description','awesome');
insert into `YOUR_SIMPLE_TABLE` values(3,'the best ever description','terrific');

insert into `YOUR_SIMPLE_TABLE` (first_field,second_field) values('description with auto_id','versatile');


-- different select samples --
select * from `YOUR_SIMPLE_TABLE`;
select id,second_field from `YOUR_SIMPLE_TABLE`;

-- update samples --
update `YOUR_SIMPLE_TABLE` set first_field = 'a modified description' where id=1;

-- delete samples --
delete from `YOUR_SIMPLE_TABLE` where id=1;


-- one2one samples --
create table `ENTITY_A`(
    `id` int(11) not null auto_increment,
    `important_a` varchar(128) default null,


    primary key(`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

create table `EXTENSION_TABLE_A`(
    `id` int(11) not null auto_increment,
    `not_relevant_field_a` varchar(50) default null,
    `not_relevant_field_b` varchar(50) default null,
    `not_relevant_field_c` varchar(50) default null,
    `entity_A_id` int(11) not null,

    primary key(`id`),
    unique(`entity_A_id`),
    CONSTRAINT `FK_EXTENSIONS_4_ENTITY` FOREIGN KEY (`entity_A_id`) REFERENCES `ENTITY_A` (`id`)

)ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;


-- one2one select samples --

insert into `ENTITY_A` values(1,'sth important for A');
insert into `ENTITY_A` values(2,'sth important for B');


insert into `EXTENSION_TABLE_A` values(1,'sth not so important for A','other unimportant thing for A','unrelevant for A',1);
insert into `EXTENSION_TABLE_A` values(2,'sth not so important for B','other unimportant thing for B','unrelevant for B',2);


select * 
from `ENTITY_A` as entity cross join `EXTENSION_TABLE_A` as entity_data 
where entity.id = entity_data.entity_A_id;

select 
    entity.id, 
    entity.important_a,
    entity_data.not_relevant_field_a,
    entity_data.not_relevant_field_b,
    entity_data.not_relevant_field_c
from `ENTITY_A` as entity cross join `EXTENSION_TABLE_A` as entity_data 
where entity.id = entity_data.entity_A_id;


-- one2many samples --

create table `Person`(
    `id` int(11) not null auto_increment,
    `name` varchar(50) not null,
    `email` varchar(50) not null,

    unique(`email`),

    primary key(`id`)
)ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

create table `Person_Contact_Info`(
    `id` int(11) not null auto_increment,
    `phone` varchar(50) not null,
    `person_id` int(11) not null,

    primary key(`id`),
    CONSTRAINT `FK_CONTACT_4_PERSON` FOREIGN KEY (`person_id`) REFERENCES `Person` (`id`)

)ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

insert into `Person` values(1,'dimas','dimas@gmail.com');
insert into `Person` values(2,'pedro','pedro@gmail.com');
insert into `Person` values(3,'sasha','sasha@gmail.com');
insert into `Person` values(4,'martha','martha@gmail.com');
insert into `Person` values(5,'volde','volde@gmail.com');

insert into `Person_Contact_Info` values(1,'777-777-777',1);
insert into `Person_Contact_Info` values(2,'777-777-778',1);
insert into `Person_Contact_Info` values(3,'777-777-779',1);

insert into `Person_Contact_Info` values(4,'888-777-777',3);
insert into `Person_Contact_Info` values(5,'888-777-777',3);

insert into `Person_Contact_Info` values(6,'999-777-777',5);
insert into `Person_Contact_Info` values(7,'999-777-778',5);
insert into `Person_Contact_Info` values(8,'999-777-779',5);
insert into `Person_Contact_Info` values(9,'999-777-776',5);


select * 
from `Person` as person cross join `Person_Contact_Info` as contact_data 
on person.id = contact_data.person_id;


select * 
from `Person` as person inner join `Person_Contact_Info` as contact_data 
on person.id = contact_data.person_id;


select 
    person.id,
    person.name,
    person.email,
    contact_data.phone
from `Person` as person cross join `Person_Contact_Info` as contact_data 
where person.id = contact_data.person_id;

select 
    person.id,
    person.name,
    person.email,
    contact_data.phone
from `Person` as person inner join `Person_Contact_Info` as contact_data 
on person.id = contact_data.person_id;

-- note about CROSS JOIN vs INNER JOIN --
-- CROSS joins with WHERE condition of id equality between the related entities return 
-- the same result than INNER joins having the ON condition, but
-- CROSS joins are slower, as they perform the cartesian product before the Where.
-- Inner joins have the advantage of adding a where condition
-- after the query. So, use Inner Joins!



-- many2many samples --

create table `citizen`(
    `id` int(11) not null auto_increment,
    `email` varchar(50) not null,

    unique(`email`),

    primary key(`id`)
)ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

create table `Police_Office`(
    `id` int(11) not null auto_increment,
    `address` varchar(50) not null,
    unique(`address`),

    primary key(`id`)
)ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

create table `citizen_Police_visit_History`(
    `id` int(11) not null auto_increment,
    `citizen_id` int(11) not null,
    `police_office_id` int(11) not null,
    `visit_date` datetime default now(),

    unique(`citizen_id`,`police_office_id`,`visit_date`),

    primary key(`id`),
    CONSTRAINT `FK_VISIT_4_citizen` FOREIGN KEY (`citizen_id`) REFERENCES `citizen` (`id`),
    CONSTRAINT `FK_VISIT_4_POLICE` FOREIGN KEY (`police_office_id`) REFERENCES `Police_Office` (`id`)
)ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;


insert into `citizen` values(1,'c1@gmail.com');
insert into `citizen` values(2,'c2@gmail.com');
insert into `citizen` values(3,'c3@gmail.com');


insert into `Police_Office` values(1,'havana');
insert into `Police_Office` values(2,'barcelona');
insert into `Police_Office` values(3,'warsaw');
insert into `Police_Office` values(4,'kiev');


insert into `citizen_Police_visit_History` (id,citizen_id,police_office_id) values(1,1,1);
insert into `citizen_Police_visit_History` (id,citizen_id,police_office_id) values(2,1,2);
insert into `citizen_Police_visit_History` (id,citizen_id,police_office_id) values(3,2,3);
insert into `citizen_Police_visit_History` (id,citizen_id,police_office_id) values(4,2,4);
insert into `citizen_Police_visit_History` (id,citizen_id,police_office_id) values(5,3,1);
insert into `citizen_Police_visit_History` (id,citizen_id,police_office_id) values(6,1,1);
insert into `citizen_Police_visit_History` (id,citizen_id,police_office_id) values(7,3,3);

select 
    citizen.id,
    citizen.email,
    office.address,
    history.visit_date
from `citizen` as citizen
inner join `citizen_Police_visit_History` as history on citizen.id = history.citizen_id
inner join `Police_Office` as office on history.police_office_id = office.id
order by office.address asc;


select 
    distinct office.address,
    office.id,
    count( office.address) as amount_of_visits
from `citizen` as citizen
inner join `citizen_Police_visit_History` as history on citizen.id = history.citizen_id
inner join `Police_Office` as office on history.police_office_id = office.id
group by office.address
order by office.id asc;


set FOREIGN_KEY_CHECKS = 1;
