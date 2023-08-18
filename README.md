markdown
Copy code
# API de Integração para Projeto Next.js

Este repositório contém a API de integração desenvolvida em .NET para o projeto Next.js. A API fornece funcionalidades de Consulta, Inserção, Alteração e Exclusão de registros de clientes.

## Configuração do Banco de Dados MySQL

Certifique-se de ter o MySQL Workbench instalado. Após o download, siga essas etapas:

1. Instale o MySQL Workbench.
2. Abra a pasta `SqlDBScript` neste repositório.
3. Execute os comandos SQL no MySQL Workbench para criar o banco de dados e a tabela:

```sql
DROP DATABASE IF EXISTS clientes;
CREATE DATABASE testefullstack;
USE testefullstack;

CREATE TABLE clientes (
  clienteid CHAR(36) PRIMARY KEY NOT NULL,
  username VARCHAR(50) NOT NULL,
  fone VARCHAR(20),
  email VARCHAR(50)
);
Isso criará o banco de dados e a tabela necessários para o projeto.

Tecnologias Utilizadas
Next.js by Vercel - The React Framework
API: OData - OData Version 4.01: URL Conventions
Linguagem: JavaScript e TypeScript
Framework: .NET
Instruções de Execução
Certifique-se de ter o Node.js instalado.
Clone este repositório e navegue até a pasta do projeto Frontend em Next.js.
Execute o seguinte comando para instalar as dependências:
bash
Copy code
npm install
Inicie o servidor de desenvolvimento do Frontend:
bash
Copy code
npm run dev
Clone a API de Integração (outro repositório) e siga as instruções para executá-la.
Estrutura do Projeto
O projeto está organizado da seguinte forma:

/: Contém o Frontend em Next.js.
/SqlDBScript: Contém os scripts SQL para configuração do banco de dados.
Questões Abordadas
Tela Inicial:

Conteúdo central estático.
Menu com opções de "Início" e "Categoria Cliente".
Desenvolvimento da API:

Funções de Consulta, Inserção, Alteração e Exclusão.
Tecnologia utilizada: .NET.
Banco de Dados:

MySQL utilizado.
Scripts para configuração estão em SqlDBScript.
Tela de Listagem e Cadastro de Categoria de Cliente:

Implementada na interface do Frontend em Next.js.
Edição e Exclusão de Registros:

Adicionadas na listagem de Categoria de Cliente.
Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para abrir uma pull request ou reportar problemas.

Licença
Este projeto está licenciado sob a Licença MIT.
