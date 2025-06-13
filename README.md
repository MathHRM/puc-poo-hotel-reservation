
# 🏨 Sistema de Reserva de Quartos

Sistema web para reserva e gerenciamento de quartos, desenvolvido para a disciplina de Programação Orientada a Objetos (POO) no curso de Sistemas de Informação da PUC Minas.

## 👥 Participantes

Os membros do grupo são:

- Gustavo Medeiros  
- Leandro Henrique dos Santos  
- Matheus Henrique Resende Magalhães  
- Victor Hugo  
- Saulo Luíz  

---

## 📚 Estrutura do Documento

- [Informações do Projeto](#-sistema-de-reserva-de-quartos)
  - [Participantes](#-participantes)
- [Introdução](#-introdução)  
  - [Problema](#problema)  
  - [Objetivos](#objetivos)  
  - [Justificativa](#justificativa)
- [Especificações do Projeto](#-especificações-do-projeto)  
  - [Requisitos](#requisitos)  
    - [Requisitos Funcionais](#-requisitos-funcionais)  
    - [Requisitos Não Funcionais](#-requisitos-não-funcionais)  
  - [Restrições](#-restrições)
- [Projeto da Solução](#-projeto-da-solução)  
  - [Tecnologias Utilizadas](#-tecnologias-utilizadas)  
  - [Arquitetura da Solução](#-arquitetura-da-solução)  
- [Licença](#-licença)  
- [Referências](#-referências)  

---

## 📌 Introdução

### Problema

Reservar quartos de forma online ainda é uma experiência complexa em diversas plataformas. Muitos usuários enfrentam dificuldades em encontrar opções claras, comparar preços e efetuar reservas de forma rápida e segura.

Além disso, a gestão interna de quartos carece de soluções simples que permitam aos administradores controlar quartos, reservas e disponibilidade com facilidade.

---

## 🎯 Objetivos

### Objetivo Geral

Desenvolver um sistema web orientado a objetos que permita a reserva de quartos por usuários e o gerenciamento eficiente por administradores.

### Objetivos Específicos

- Facilitar a busca e reserva de quartos para clientes.  
- Fornecer ao administrador ferramentas para cadastrar e editar quartos e reservas.  
- Aplicar os princípios da Programação Orientada a Objetos como herança, encapsulamento e abstração.  
- Utilizar tecnologias modernas como .NET e Entity Framework para a construção do backend.  

---

## 💡 Justificativa

Este projeto visa resolver um problema comum e prático, oferecendo uma solução moderna, didática e tecnicamente adequada para reservas de quartos. Além disso, proporciona o aprofundamento nos conceitos de POO e tecnologias como .NET, atendendo aos objetivos da disciplina de forma prática e aplicada.

---

## ▶️ Como Executar

Este projeto utiliza C# com .NET no backend e se conecta a um banco de dados PostgreSQL.

### 1. Clone o repositório

```bash
git clone https://github.com/MathHRM/puc-poo-hotel-reservation
cd puc-poo-hotel-reservation
```

### 2. ⚙️ Configure a string de conexão

No projeto, edite o arquivo `appsettings.Development.json` para apontar para o banco de dados:

```json
"ConnectionStrings": {
  "DefaultConnection": "User Id=postgres.klneytibozywkvlexkvt;Password=PUCHotel1234#;Server=aws-0-sa-east-1.pooler.supabase.com;Port=5432;Database=postgres"
}
```

### 3. Execute o backend

```bash
dotnet run
```

### 4. Acesse a aplicação

Acesse uma das URLs fornecidas no console:

```bash
https://localhost:7239
# ou
http://localhost:5101
```

---

## 📑 Especificações do Projeto

### ✅ Requisitos Funcionais

| ID      | Descrição do Requisito                            | Prioridade |
|---------|----------------------------------------------------|------------|
| RF-001  | Listar quartos disponíveis para reserva           | Alta       |
| RF-002  | Permitir que o usuário realize uma reserva        | Alta       |
| RF-003  | Administrador pode adicionar/editar quartos       | Alta       |
| RF-004  | Administrador pode visualizar e gerenciar reservas| Média      |
| RF-005  | Permitir que o usuário se cadastre                | Alta       |
| RF-006  | Permitir que o usuário faça login/logout          | Alta       |
| RF-007  | Usuário pode visualizar suas próprias reservas    | Média      |
| RF-008  | Usuário pode editar suas próprias reservas        | Média      |
| RF-009  | Usuário pode cancelar suas próprias reservas      | Média      |

### 🚫 Requisitos Não Funcionais

| ID       | Descrição do Requisito                          | Prioridade |
|----------|--------------------------------------------------|------------|
| RNF-001  | O sistema deve ser seguro, com senhas criptografadas | Alta       |
| RNF-002  | Utilizar banco de dados PostgreSQL              | Alta       |
| RNF-003  | Backend deve ser desenvolvido em .NET           | Alta       |
| RNF-004  | Interface deve ser intuitiva e responsiva       | Média      |
| RNF-005  | A API deve ser documentada via Swagger          | Média      |

### 🛑 Restrições

| ID  | Restrição                                                   |
|-----|-------------------------------------------------------------|
| 01  | O projeto deverá ser finalizado até o fim do semestre letivo|
| 02  | Deve ser utilizado .NET como base obrigatória para a lógica de negócio |

---

## 🛠 Projeto da Solução

O sistema é composto por duas interfaces: uma para usuários finais (clientes) e outra para administradores.

---

## 🧰 Tecnologias Utilizadas

- .NET – Backend (ASP.NET Core)  
- Entity Framework Core - ORM para acesso a dados  
- PostgreSQL – Banco de dados relacional  
- Swagger - Documentação da API  
- BCrypt.Net - Hashing de senhas  
- HTML/CSS/JS – Interface web  
- Bootstrap – Estilização  

---

## 🧱 Arquitetura da Solução

A arquitetura da solução utiliza o padrão MVC (Model-View-Controller) para as páginas web e uma API REST para as operações de reserva. O projeto é estruturado em camadas de responsabilidade:

- **Controllers**: Camada de entrada que recebe as requisições HTTP e direciona para os serviços apropriados.  
- **Services**: Camada que orquestra a lógica de negócio da aplicação, validando dados e coordenando as operações.  
- **Repositories**: Camada responsável pela abstração do acesso aos dados, comunicando-se com o banco de dados através do Entity Framework.  

---

## 📝 Licença

Este projeto é acadêmico e não possui fins comerciais.  
Desenvolvido como parte do curso de Sistemas de Informação na PUC Minas — Disciplina de Programação Orientada a Objetos.

---

## 📚 Referências

- Documentação oficial do .NET  
- Documentação do Entity Framework Core  
- PostgreSQL  
- Materiais da disciplina de POO — PUC Minas  
