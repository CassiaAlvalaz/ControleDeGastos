# 💰 Controle de Gastos

Sistema desenvolvido para gerenciamento de gastos pessoais, permitindo o cadastro e controle de **pessoas**, **categorias** e **transações**.

O projeto foi estruturado utilizando **arquitetura em camadas**, com separação entre **API**, **Application**, **Domain** e **Infrastructure**, facilitando a manutenção, organização e evolução da aplicação.
Utilizando EF e banco de dados SqlServer.

---

## 📌 Funcionalidades

Atualmente o sistema permite:

- Cadastro de **Pessoas**
- Edição de **Pessoas**
- Exclusão de **Pessoas**
- Listagem de **Pessoas**
- Listagem de **Pessoa por ID**
- Listagem de **Totais Financeiros por Pessoa**
- Cadastro de **Categorias**
- Listagem de **Categorias**
- Listagem de **Categoria por ID**
- Cadastro de **Transações**
- Listagem de **Transações**

---

## 📂 Start do Projeto

Alterar a string de conexão:

Arquivo: appsettings.json
```
  "ConnectionStrings": {
    "SqlConnection": "Server= ;Database=ControleDeGastos;User Id= ;Password= ;TrustServerCertificate=True;"
  },
```

Swagger:
<img width="1228" height="630" alt="image" src="https://github.com/user-attachments/assets/61791efd-4f3d-4a17-b77b-b8f25fa13d13" />


Banco de Dados: SqlServer

<img width="186" height="74" alt="image" src="https://github.com/user-attachments/assets/cc3e60c9-363d-440a-944a-d9e4f25de654" />

