
# 🏨 Sistema de Reserva de Hotéis

Sistema web para reserva e gerenciamento de hotéis, desenvolvido para a disciplina de **Programação Orientada a Objetos (POO)** no curso de **Sistemas de Informação** da **PUC Minas**.

---

## 👥 Participantes

Os membros do grupo são:
- Gustavo Medeiros  
- Leandro Henrique dos Santos  
- Matheus Henrique Resende Magalhães  
- Victor Hugo  
- Saulo Luíz  

---

# Estrutura do Documento

- [Informações do Projeto](#🏨-sistema-de-reserva-de-hotéis)  
  - [Participantes](#👥-participantes)  
- [Como executar](#como-executar)
- [Introdução](#introdução)  
  - [Problema](#problema)  
  - [Objetivos](#objetivos)  
  - [Justificativa](#justificativa)
- [Especificações do Projeto](#especificações-do-projeto)  
  - [Requisitos](#requisitos)  
    - [Requisitos Funcionais](#requisitos-funcionais)  
    - [Requisitos Não Funcionais](#requisitos-não-funcionais)  
  - [Restrições](#restrições)
- [Projeto da Solução](#projeto-da-solução)  
  - [Tecnologias Utilizadas](#tecnologias-utilizadas)  
  - [Arquitetura da Solução](#arquitetura-da-solução)  
- [Licença](#📝-licença)  
- [Referências](#referências)  

---

# Introdução

## Problema

Reservar hotéis de forma online ainda é uma experiência complexa em diversas plataformas. Muitos usuários enfrentam dificuldades em encontrar opções claras, comparar preços e efetuar reservas de forma rápida e segura.

Além disso, a gestão interna de hotéis carece de soluções simples que permitam aos administradores controlar quartos, reservas e disponibilidade com facilidade.

## Objetivos

### Objetivo Geral

Desenvolver um sistema web orientado a objetos que permita a reserva de hotéis por usuários e o gerenciamento eficiente por administradores.

### Objetivos Específicos

- Facilitar a busca e reserva de hotéis para clientes.
- Fornecer ao administrador ferramentas para cadastrar e editar quartos e reservas.
- Aplicar os princípios da Programação Orientada a Objetos como herança, encapsulamento e abstração.
- Utilizar Docker e PostgreSQL para facilitar o deploy e o gerenciamento do ambiente.

## Justificativa

Este projeto visa resolver um problema comum e prático, oferecendo uma solução moderna, didática e tecnicamente adequada para reservas hoteleiras. Além disso, proporciona o aprofundamento nos conceitos de POO e tecnologias como .NET e Docker, atendendo aos objetivos da disciplina de forma prática e aplicada.

---

# Como executar

Este projeto utiliza **C# com .NET** no backend e **Docker** apenas para o banco de dados.


## 1. Clone o repositório

```bash
git clone [https://github.com/seu-usuario/seu-projeto.git](https://github.com/MathHRM/puc-poo-hotel-reservation)
cd puc-poo-hotel-reservation
````


## 2. Suba o banco de dados com Docker

Certifique-se de que o Docker esteja instalado e em execução.

> Docker Desktop: [https://www.docker.com/products/docker-desktop](https://www.docker.com/products/docker-desktop)

Execute:

```bash
docker-compose up -d
```


## 3. ⚙️ Configure a string de conexão

No projeto backend (C#), edite o arquivo `appsettings.json` apontar para o banco de dados.

Exemplo (PostgreSQL):

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=sandbox;Port=5432;Database=sandbox;Username=sandbox;Password=sandbox"
}
````


## 4. Execute o backend

Navegue até a pasta do projeto e execute:

```bash
cd backend
dotnet run
```


## 5. Acesse a aplicação

Após iniciar o backend, abra o navegador e acesse:

```bash
https://localhost:7239
ou
http://localhost:5101
```

*(Ou a porta definida no `launchSettings.json`)*

---

# Especificações do Projeto

## Requisitos

### Requisitos Funcionais

|ID    | Descrição do Requisito                                     | Prioridade |
|------|------------------------------------------------------------|------------|
|RF-001| Listar hotéis disponíveis para reserva                     | Alta       |
|RF-002| Permitir que o usuário realize uma reserva                 | Alta       |
|RF-003| Administrador pode adicionar/quartos                       | Alta       |
|RF-004| Administrador pode visualizar e gerenciar reservas         | Média      |

### Requisitos Não Funcionais

|ID     | Descrição do Requisito                                    | Prioridade |
|--------|-----------------------------------------------------------|------------|
|RNF-001| Sistema deve rodar em ambiente Docker                      | Alta       |
|RNF-002| Utilizar banco de dados PostgreSQL                         | Alta       |
|RNF-003| Backend deve ser desenvolvido em .NET                      | Alta       |
|RNF-004| Interface deve ser intuitiva e responsiva                  | Média      |

## Restrições

|ID| Restrição                                                                 |
|--|---------------------------------------------------------------------------|
|01| O projeto deverá ser finalizado até o fim do semestre letivo             |
|02| Deve ser utilizado .NET como base obrigatória para a lógica de negócio   |

---

# Projeto da Solução

O sistema é composto por duas interfaces: uma para **usuários finais** (clientes) e outra para **administradores do hotel**.

## Tecnologias Utilizadas

- **.NET** – Backend (C#)
- **Docker** – Para containerização e execução local
- **PostgreSQL** – Banco de dados relacional
- **HTML/CSS/JS** – Interface web
- **Bootstrap** – Estilização

## Arquitetura da Solução

- Arquitetura MVC com camadas de **Model**, **View** e **Controller**
- Separação entre lógicas de negócio, apresentação e persistência de dados
- Integração com PostgreSQL via Entity Framework

---

## 📝 Licença

Este projeto é acadêmico e não possui fins comerciais.  
Desenvolvido como parte do curso de Sistemas de Informação na **PUC Minas** — Disciplina de Programação Orientada a Objetos.

---

## Referências

- Documentação oficial do [.NET](https://dotnet.microsoft.com/)
- [Docker](https://www.docker.com/)
- [PostgreSQL](https://www.postgresql.org/)
- Materiais da disciplina de POO — PUC Minas
