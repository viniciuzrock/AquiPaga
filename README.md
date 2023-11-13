**README - AquiPaga API RESTful**

## Descrição
Este projeto consiste em uma API RESTful desenvolvida em C# utilizando o framework .NET, com o objetivo de gerenciar tarefas em projetos. A aplicação integra-se a um banco de dados SQL Server utilizando o Dapper para operações de banco de dados.

## Requisitos Obrigatórios
1. **Criação de Tarefas:**
   - Endpoint: `POST /api/task`
   - Permite a criação de uma nova tarefa.

2. **Atualização das Tarefas:**
   - Endpoint: `PUT /api/task/{id}`
   - Permite a atualização do status e demais informações de uma tarefa específica.

3. **Exclusão de Tarefas:**
   - Endpoint: `DELETE /api/task/{id}`
   - Permite a exclusão de uma tarefa específica.

4. **Consulta de Tarefas:**
   - Endpoint: `GET /api/task`
   - Retorna a lista de todas as tarefas.
     
5 **Consulta de uma Tarefa específica**
   - Endpoint: `GET /api/task/{id}`
   - Retorna os detalhes de uma tarefa específica com base no ID fornecido.

6. **Integração com Banco de Dados SQL e Dapper:**
   - Utilização do Dapper para operações de banco de dados, integrado a um banco SQL Server.

7. **Operação que Consome Procedure SQL via Dapper:**
   - Foi criada uma stored procedure `UpdateTask` para atualizar o status de uma tarefa.

## Tecnologias Utilizadas
- ASP.NET Core
- Dapper
- AutoMapper
- SQL Server
- Swagger (para documentação da API)

## Estrutura do Projeto
- **Controllers:** Contêm as classes que definem os endpoints da API.
- **Models:** Definem as entidades do sistema, como `TaskModel`.
- **Resource:** Contêm classes de recursos, como `SaveTaskResource`, utilizadas para mapeamento entre a requisição HTTP e os modelos.
- **Enums:** Enumerações, como `TaskStatus`, são utilizadas para representar o status das tarefas.
- **Repositories:** Classes responsáveis pela interação com o banco de dados, como `TaskRepository`.
- **Interfaces:** Definem os contratos para os repositórios, como `ITaskRepository`.
- **Program.cs:** Configuração do projeto e serviços, incluindo AutoMapper e injeção de dependência.

## Configuração e Execução
1. Clone o repositório: `git clone https://github.com/seu-usuario/AquiPaga-API-RESTful.git`
2. Abra o projeto no Visual Studio ou utilize o comando `dotnet run`.
3. Acesse a documentação da API Swagger em `https://localhost:{porta}/swagger`.

## Configurando banco de dados
1. Crie um banco de dados chamado `AquiPaga`.
```sql
CREATE DATABASE AquiPaga
USE AquiPaga
```
2. Crie a tabela `Tasks`
```
CREATE TABLE Tasks(
	ID INT PRIMARY KEY IDENTITY,
	[NAME] VARCHAR(255) NOT NULL,
	[DESCRIPTION] VARCHAR(255) NOT NULL,
	[STATUS] INT NOT NULL
)
```
3. Insira uma tarefa de exemplo:
```
INSERT Tasks VALUES ('Task1','Desc1','1')
```
4. Crie a stored procedure UpdateTask:
```
CREATE PROCEDURE UpdateTask
	@TaskId INT,
	@NewName VARCHAR(255),
	@NewDescription VARCHAR(255),
	@NewStatus INT
AS
BEGIN
	UPDATE Tasks
	SET [STATUS] = @NewStatus,
	[NAME] = @NewName,
	[Description] = @NewDescription
	WHERE ID = @TaskId
END
```
