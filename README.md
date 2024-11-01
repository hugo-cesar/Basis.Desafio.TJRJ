# Desafio

Este projeto é uma aplicação web que foi desenvolvida com uma arquitetura separada entre **backend** e **frontend**.

## Estrutura do Projeto

### Backend

O backend foi desenvolvido utilizando **.NET 8** com uma arquitetura limpa, que promove a separação de preocupações e facilita a manutenção do código.

#### Principais Frameworks e Bibliotecas Utilizadas

- **MediatR**: Para implementação do padrão Mediator, facilitando a comunicação entre diferentes partes do sistema.
- **FluentValidation**: Para validação de dados de forma fluida e fácil de manter.
- **Microsoft.EntityFrameworkCore**: Para acesso a dados e mapeamento objeto-relacional (ORM).
- **xUnit**: Para testes automatizados, garantindo a qualidade do código.

#### Banco de Dados

Para a criação e persistência dos dados, foi utilizado o **SQL Server** com **migrations** do Entity Framework Core, permitindo um gerenciamento eficiente das alterações no esquema do banco de dados.

### Frontend

A camada de frontend foi desenvolvida utilizando **Angular 18**, proporcionando uma interface de usuário dinâmica e responsiva.

## Pré-requisitos

### Backend

- **.NET 8**: Certifique-se de ter o .NET 8 instalado em sua máquina. Você pode baixá-lo [aqui](https://dotnet.microsoft.com/download/dotnet/8.0).
- **SQL Server Express**: É necessário ter o SQL Server Express instalado para usar o LocalDB. Você pode baixá-lo [aqui](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).

### Frontend

- **Angular 18**: Certifique-se de ter o Angular CLI instalado. Você pode instalá-lo globalmente usando o npm:
  ```bash
  npm install -g @angular/cli@18

## Como Executar o Projeto

Para executar o projeto, você pode abrir a solution no **Visual Studio** e clicar em "Start" para iniciar o servidor(backend) e o client(frontend) ou pode executar os comandos abaixo: 

### Backend

1. Navegue até a pasta do backend.
2. Execute `dotnet restore` para restaurar as dependências (se não estiver usando o Visual Studio).
3. Execute `dotnet run` para iniciar o servidor (se não estiver usando o Visual Studio).

### Frontend

1. Navegue até a pasta do frontend.
2. Execute `npm install` para instalar as dependências.
3. Execute `ng serve` para iniciar a aplicação.
