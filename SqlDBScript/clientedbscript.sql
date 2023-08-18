DROP DATABASE IF EXISTS clientes;
create database testefullstack;
use cliente;
DROP TABLE clientes;
CREATE TABLE clientes (clienteid CHAR(36) primary key NOT NULL ,
                       username VARCHAR(50) NOT NULL, fone VARCHAR(20) ,email VARCHAR(50));

INSERT INTO clientes (username, fone, email) VALUES ('Thiago', '992629982', 'nascimentotnp@gmail.com');


select * from clientes;
delete from clientes where clienteid ='a6a1cd99-7c71-4075-b7a6-be7cab311f24'
