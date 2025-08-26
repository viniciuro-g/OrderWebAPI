# Budget API - API de Orçamentos

Um projeto de portfólio que demonstra a construção de uma API RESTful robusta e bem arquitetada com ASP.NET Core 8.

## 📋 Tabela de Conteúdos

1.  [Sobre o Projeto](#-sobre-o-projeto)
2.  [Tecnologias Utilizadas](#-tecnologias-utilizadas)
3.  [Funcionalidades](#-funcionalidades)
4.  [Começando](#-começando)
5.  [Uso e Endpoints da API](#-uso-e-endpoints-da-api)
6.  [Arquitetura](#-arquitetura)
7.  [Próximos Passos (Roadmap)](#-próximos-passos-roadmap)
8.  [Contato](#-contato)

## ✨ Sobre o Projeto

**OrderWebAPI** é uma API RESTful completa para um sistema de gerenciamento de clientes e orçamentos. O projeto foi desenvolvido com foco em boas práticas de arquitetura de software, como a **Clean Architecture**, para garantir um código limpo, testável e de fácil manutenção.

O back-end é totalmente desacoplado e pronto para ser consumido por qualquer tipo de aplicação front-end (web, mobile, etc.).

## 🚀 Tecnologias Utilizadas

Este projeto foi construído com as seguintes tecnologias e ferramentas:

### **Back-end**
* **C#** e **.NET 8**
* **ASP.NET Core 8** para a construção da Web API
* **Entity Framework Core 8** como ORM
* **AutoMapper** para mapeamento entre Entidades e DTOs
* **Swashbuckle** para geração da documentação interativa com Swagger/OpenAPI

### **Banco de Dados**
* **Entity Framework Core In-Memory:** Utilizado para agilizar o desenvolvimento e os testes, sem a necessidade de um banco de dados externo.

### **Ferramentas de Desenvolvimento**
* Visual Studio 2022
* Git & GitHub para controle de versão
* Swagger UI para testes e documentação de endpoints

## 🎯 Funcionalidades

-   [x] **Gerenciamento de Clientes (CRUD Completo):**
    -    Criar, Listar, Buscar por ID, Atualizar e Deletar Clientes.
-   [x] **Gerenciamento de Orçamentos (CRUD Completo):**
    -    Criar, Listar, Buscar por ID, Atualizar (status/descrição) e Deletar Orçamentos.
    -    Geração de número sequencial para novos orçamentos.
-   [x] **Gerenciamento de Itens de Orçamento (Sub-Recurso):**
    -    Adicionar, Atualizar e Remover itens de um orçamento já existente.
-   [x] **Consultas Específicas:**
    -    Listar todos os orçamentos de um cliente específico.
    -    Listar todos os orçamentos por status.
-   [x] **Validação de Dados:** Validação robusta de dados de entrada (DTOs) e de regras de negócio (Serviços).
-   [x] **Documentação de API:** Geração automática de documentação interativa com Swagger.

## 🏁 Começando

Para executar este projeto localmente, siga os passos abaixo.

### Pré-requisitos
* [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
* Um editor de código como [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) ou [VS Code](https://code.visualstudio.com/).

### Instalação e Execução

1.  Clone o repositório:
    ```sh
    git clone [https://github.com/viniciusdevr/OrderWebAPI.git]
    ```
2.  Navegue até a pasta do projeto:
    ```sh
    cd BudgetWebAPI 
    ```
3.  Execute a aplicação:
    ```sh
    dotnet run
    ```
4.  O navegador será aberto automaticamente na interface do Swagger, pronta para uso, no endereço `https://localhost:7047` (ou a porta configurada).

## 📝 Uso e Endpoints da API

A documentação completa e interativa da API está disponível via **Swagger** ao executar o projeto. Abaixo está um resumo dos principais endpoints.

| Verbo HTTP | Endpoint | Descrição |
| :--- | :--- | :--- |
| `GET` | `/api/customer` | Retorna todos os clientes. |
| `GET` | `/api/customer/{id}` | Retorna um cliente específico. |
| `POST`| `/api/customer` | Cria um novo cliente. |
| `PUT` | `/api/customer/{id}` | Atualiza um cliente existente. |
| `DELETE`| `/api/customer/{id}` | Exclui um cliente. |
| `GET` | `/api/order` | Retorna todos os orçamentos. |
| `GET` | `/api/order/{id}` | Retorna um orçamento específico. |
| `GET` | `/api/order/by-customer/{customerId}` | Retorna os orçamentos de um cliente. |
| `GET` | `/api/order/by-status/{status}` | Retorna os orçamentos por status. |
| `POST`| `/api/order` | Cria um novo orçamento. |
| `PUT` | `/api/order/{id}` | Atualiza o status/descrição de um orçamento. |
| `DELETE`| `/api/order/{id}` | Exclui um orçamento. |
| `POST`| `/api/order/{orderId}/items` | Adiciona um item a um orçamento. |
| `PUT` | `/api/order/{orderId}/items/{itemId}` | Atualiza um item em um orçamento. |
| `DELETE`| `/api/order/{orderId}/items/{itemId}` | Remove um item de um orçamento. |

## 🏗️ Arquitetura

O projeto utiliza uma arquitetura em camadas inspirada nos princípios da **Clean Architecture** para garantir a separação de responsabilidades:

* **Camada de Domínio (`Models/Entities`):** Contém as entidades principais do negócio (`Order`, `Customer`), que são a fonte da verdade do sistema.
* **Camada de Dados (`Repositories`):** Isola a lógica de acesso ao banco de dados, utilizando o padrão **Repository Pattern** sobre o Entity Framework Core.
* **Camada de Aplicação/Serviço (`Services`):** Orquestra a lógica de negócio, validações e regras do sistema, agindo como intermediário entre os controllers e os repositórios.
* **Camada de Apresentação (`Controllers`, `DTOs`):** Expõe a funcionalidade do sistema através de uma API RESTful. Utiliza o padrão **DTO** para definir os contratos de dados e o **AutoMapper** para as conversões.

A **Injeção de Dependência** é usada extensivamente para desacoplar as camadas e facilitar os testes e a manutenção.

## 🗺️ Próximos Passos (Roadmap)

-   [ ] Implementar autenticação e autorização com JWT (JSON Web Tokens).
-  [ ] Fazer um Front-end do sistema nesse ou em outro repostirório
-   [ ] Testes unitários
-   [ ] Implementar paginação nos endpoints de listagem (`GET`).
-   [ ] Substituir o banco de dados em memória por um banco persistente (ex: SQL Server, PostgreSQL ou SQLite).
-   [ ] Adicionar uma entidade `Product` e um `ProductsController` para um catálogo de produtos.
-   [ ] Implementar sistema de estoque.

## 📧 Contato

Vinícius Rodrigues - [viniciusro741@gmail.com]

[![GitHub](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/viniciusdevr)
[![LinkedIn](https://img.shields.io/badge/linkedin-%230077B5.svg?style=for-the-badge&logo=linkedin&logoColor=white)](www.linkedin.com/in/vinícius-rodrigues-a0a3b1271)
