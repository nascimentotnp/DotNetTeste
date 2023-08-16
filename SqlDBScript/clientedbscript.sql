DROP DATABASE IF EXISTS cliente;
create database testefullstack;
use cliente;
create table clientes (clienteid integer primary key auto_increment, username varchar(50));

insert into clientes values(1, "cliente1");
insert into clientes(username) values("cliente2");