# TccRewritenCsharp

Este repositório contém a reescrita do projeto TCC em C#. Ele é composto por vários subprojetos que juntos formam a aplicação completa.

## Estrutura do Projeto

- **TccRewritenCsharp.sln**: Solução principal que agrupa todos os projetos.
- **TccRewritenCsharp.API**: Projeto principal da API.
- **TccRewritenCsharp.Application**: Contém os casos de uso da aplicação.
- **TccRewritenCsharp.Communication**: Contém as classes de requisição e resposta usadas na comunicação entre a API e os clientes.
- **TccRewritenCsharp.Exceptions**: Contém as exceções customizadas usadas na aplicação.
- **TccRewritenCsharp.Infrastructure**: Contém a infraestrutura da aplicação, como acesso a dados e serviços externos.
- **TccRewritenCsharp.Test**: Contém os testes unitários e de integração da aplicação.

## Projetos

### TccRewritenCsharp.API

Este projeto contém a API principal da aplicação.

- **Arquivos principais**:
  - `Program.cs`: Ponto de entrada da aplicação.
  - `appsettings.json`: Configurações da aplicação.
  - `Controllers/`: Contém os controladores da API.

### TccRewritenCsharp.Application

Este projeto contém os casos de uso da aplicação.

- **Namespaces principais**:
  - `TccRewritenCsharp.Application.UseCases.Category`: Casos de uso relacionados a categorias.
  - `TccRewritenCsharp.Application.UseCases.User`: Casos de uso relacionados a usuários.
  - `TccRewritenCsharp.Application.UseCases.Product`: Casos de uso relacionados a produtos.
  - `TccRewritenCsharp.Application.UseCases.Order`: Casos de uso relacionados a pedidos.
  - `TccRewritenCsharp.Application.UseCases.OrderItems`: Casos de uso relacionados a itens de pedidos.

### TccRewritenCsharp.Communication

Este projeto contém as classes de requisição e resposta usadas na comunicação entre a API e os clientes.

- **Namespaces principais**:
  - `TccRewritenCsharp.Communication.Requests`: Classes de requisição.
  - `TccRewritenCsharp.Communication.Response`: Classes de resposta.

### TccRewritenCsharp.Exceptions

Este projeto contém as exceções customizadas usadas na aplicação.

### TccRewritenCsharp.Infrastructure

Este projeto contém a infraestrutura da aplicação, como acesso a dados e serviços externos.

### TccRewritenCsharp.Test

Este projeto contém os testes unitários e de integração da aplicação.

- **Namespaces principais**:
  - `TccRewritenCsharp.Test.CategoriesControllerTest`: Testes relacionados ao controlador de categorias.
  - `TccRewritenCsharp.Test.UsersControllerTest`: Testes relacionados ao controlador de usuários.
  - `TccRewritenCsharp.Test.ProductsControllerTest`: Testes relacionados ao controlador de produtos.
  - `TccRewritenCsharp.Test.OrderControllerTest`: Testes relacionados ao controlador de pedidos.
  - `TccRewritenCsharp.Test.OrderItemsControllerTest`: Testes relacionados ao controlador de itens de pedidos.

## Como Executar

1. Clone o repositório:
   ```sh
   git clone https://github.com/seu-usuario/TccRewritenCsharp.git