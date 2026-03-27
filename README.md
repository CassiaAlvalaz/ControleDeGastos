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
<img width="1222" height="632" alt="image" src="https://github.com/user-attachments/assets/c0d1e270-816f-414e-8122-333ee65400e1" />

Banco de Dados: SqlServer

<img width="186" height="74" alt="image" src="https://github.com/user-attachments/assets/0a83678b-8fd8-4106-bec3-2fe6bd81f888" />
