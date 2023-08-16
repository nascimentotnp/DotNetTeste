DROP DATABASE IF EXISTS clientes;
create database testefullstack;
use cliente;
CREATE TABLE clientes (id integer primary key auto_increment, clienteid CHAR(36) NOT NULL ,
                       username VARCHAR(50));

INSERT INTO clientes (clienteid, username) VALUES ('6fbb1d94-7d45-4f07-bf18-74b5a7a8cfde', 'Exemplo3');


select * from clientes;
