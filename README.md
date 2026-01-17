# 🚀 NanoLink - Encurtador de URL Full Stack

> Um encurtador de URLs minimalista, rápido e persistente, desenvolvido para demonstrar o poder das Minimal APIs do .NET 8.

![Badge .NET 8](https://img.shields.io/badge/.NET%208-512BD4?style=flat&logo=dotnet&logoColor=white)
![Badge SQLite](https://img.shields.io/badge/SQLite-003B57?style=flat&logo=sqlite&logoColor=white)
![Badge HTML5](https://img.shields.io/badge/HTML5-E34F26?style=flat&logo=html5&logoColor=white)
![Badge MIT](https://img.shields.io/badge/License-MIT-green?style=flat)

## 📖 Sobre o Projeto

O **NanoLink** é uma aplicação Full Stack que permite transformar URLs longas em links curtos e gerenciáveis.

Diferente de encurtadores simples que perdem dados ao reiniciar, este projeto utiliza um banco de dados **SQLite** com **Entity Framework Core** para garantir a persistência dos dados. O projeto adota a arquitetura de **Minimal APIs**, resultando em um código backend limpo, performático e sem "boilerplate".

## 🛠 Tecnologias Utilizadas

- **Backend:** C# .NET 8 (Minimal APIs)
- **Banco de Dados:** SQLite
- **ORM:** Entity Framework Core
- **Frontend:** HTML5, CSS3 e JavaScript (Vanilla/Puro)
- **Documentação:** Swagger / OpenAPI

## ⚙️ Funcionalidades

- [x] **Encurtamento de URLs:** Gera códigos únicos de 6 caracteres (alfanúmericos).
- [x] **Redirecionamento:** Redireciona instantaneamente o usuário para o site original.
- [x] **Persistência de Dados:** Os links ficam salvos em um arquivo `.db` local.
- [x] **Validação:** Verificação de integridade da URL (Uri.TryCreate).
- [x] **Interface Web:** UI moderna e responsiva (Dark Mode) na pasta `wwwroot`.
- [x] **API Documentada:** Integração nativa com Swagger para testes.

## 🚀 Como Rodar o Projeto

### Pré-requisitos
- [.NET SDK 8.0](https://dotnet.microsoft.com/download) instalado.

### Passo a Passo

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/otaviotadeu/NanoLink.git
   ```

2. **Entre na pasta do projeto:**
   ```bash
   cd NanoLink
   ```

3. **Restaurar dependências e rodar:**
   O comando abaixo irá baixar os pacotes do NuGet, criar o banco de dados (`banco.db`) se não existir, e iniciar o servidor.
   ```bash
   dotnet run
   ```

4. **Acesse a aplicação:**
   - **Interface Visual:** Abra o navegador em `http://localhost:5000` (ou a porta indicada no terminal).
   - **Documentação API (Swagger):** Acesse `http://localhost:5000/swagger`.

## 📂 Estrutura do Projeto

A estrutura foi mantida simples e direta:

- `Program.cs`: O coração da aplicação. Contém a configuração do servidor, injeção de dependência (DI), conexão com banco e os endpoints da API.
- `wwwroot/`: Pasta de arquivos estáticos. Contém o `index.html` que serve como Frontend.
- `banco.db`: Arquivo do banco de dados SQLite (gerado automaticamente na execução).
- `NanoLink.csproj`: Arquivo de projeto do .NET com as referências de pacotes.

## 🔌 Endpoints da API

| Método | Rota        | Descrição                                  |
|--------|-------------|--------------------------------------------|
| `POST` | `/encurtar` | Recebe JSON `{ "url": "..." }` e retorna o link curto. |
| `GET`  | `/{code}`   | Redireciona para a URL original associada ao código. |

---

## 📄 Licença

Este projeto está sob a licença MIT. Sinta-se livre para usar e modificar.

---
Desenvolvido por **Tadeu** 💻