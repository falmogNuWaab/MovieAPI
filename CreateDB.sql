create database movie;
use movie;
create table movies
(
`id` int not null auto_increment primary key,
`title` nvarchar(50) not null,
`category` nvarchar(20) not null,
runtime int
);

insert into movies values(0,"Harry Potter 1","Fantasy",350),(0,"Harry Potter 2","Fantasy",180),(0,"Harry Potter 3","Fantasy",188);