# Gerenciador de Transações Financeiras - API Backend

Este é um projeto backend desenvolvido em **C#** com **ASP.NET Core** em **.NET 8** e utilizando a abordagem **Minimal API**. A aplicação tem como objetivo gerenciar transações financeiras, permitindo o cadastro de usuários e transações no sistema. A API é documentada e testada através do **Swagger**.

## Tecnologias

- **ASP.NET Core**: Framework utilizado para a construção da API.
- **.NET 8**: Versão do .NET utilizada.
- **Minimal API**: Estrutura simplificada de endpoints no ASP.NET Core.
- **Swagger**: Ferramenta para gerar documentação interativa e realizar testes diretamente na interface web.
- **C#**: Linguagem de programação utilizada.

## Funcionalidades

- Cadastro de usuários, com as operações:
  - **POST**: Cadastrar novo usuário.
  - **GET**: Listar todos os usuários.
  - **GET (id)**: Buscar um usuário específico pelo ID.
  - **DELETE**: Remover um usuário e todas as transações vinculadas ao seu ID.

- Cadastro de transações, com as operações:
  - **POST**: Criar uma nova transação.
  - **GET**: Listar transações.

- Consulta de Totais, com a operação:
  - **GET**: Lista os usuários com o total de receitas, despesas e saldo final de cada um individualmente
  e ao final informa o total de receitas, despesas e o saldo total cadastrado na plataforma.
  
- **Swagger** para fácil visualização, documentação e testes da API.

- **Armazenamento de Dados** em memória com o uso de listas para representar um registro.

## Requisitos

Antes de rodar o projeto, verifique se você tem as seguintes ferramentas instaladas:

- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou outra IDE(com suporte) de sua preferência
- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet)

## Instalação

1. **Clone o repositório:**
    ```bash
    git clone https://github.com/Jabusan/TesteTecnicoCsharp.git
    cd TesteTecnicoCsharp
    ```

2. **Instale as dependências:**
    O projeto já vem com as dependências necessárias definidas no arquivo `csproj`, então basta restaurar as dependências:
    ```bash
    dotnet restore
    ```

3. **Execute a aplicação:**
    Para rodar o projeto em modo de desenvolvimento:
    ```bash
    dotnet run
    ```

    Isso iniciará o servidor da API no endereço padrão: `https://localhost:5028/swagger`.


## Testando a API

Com o Swagger, você pode facilmente testar todos os endpoints da API. Após iniciar o host, basta acessar a interface na porta especificada em seu `localhost` e clicar sobre os endpoints para ver a documentação detalhada e enviar requisições diretamente.


## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).
