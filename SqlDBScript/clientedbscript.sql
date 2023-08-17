DROP DATABASE IF EXISTS clientes;
create database testefullstack;
use cliente;
CREATE TABLE clientes (clienteid CHAR(36) primary key NOT NULL ,
                       username VARCHAR(50));

INSERT INTO clientes (clienteid, username) VALUES ('6fbb1d94-7d45-4f07-bf18-74b5a7a8cfce', 'Exemplo4');


select * from clientes;
delete from clientes where clienteid ='a6a1cd99-7c71-4075-b7a6-be7cab311f24'
