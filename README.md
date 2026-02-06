# api-client
CRUD API

API REST para gerenciamento de clientes, com validação, paginação, soft delete e auditoria.

---

## Tecnologias utilizadas

- **.NET 8 / ASP.NET Core** – Framework principal da API  
- **Entity Framework Core** – ORM para acesso ao banco  
- **InMemoryDatabase** – Banco de dados temporário para desenvolvimento/testes  
- **Swagger / Swashbuckle** – Documentação e testes da API  
- **C# 12** – Linguagem do projeto  

---

## Como rodar o projeto

### Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) instalado  
- IDE (Visual Studio, VS Code ou Rider)

### Passos

1. Clone o repositório:

```bash
git clone https://github.com/nicolaujoao1/api-client.git
cd api-client

dotnet restore

dotnet run

```

Abrir em navegador o swagger:

https://localhost:7251/swagger/index.html
