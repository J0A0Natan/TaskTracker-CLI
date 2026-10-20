# 📋 Task Tracker CLI

> Um aplicativo de linha de comando (CLI) simples e eficiente para gerenciar tarefas, desenvolvido em **C#** e **.NET** com base no desafio do [roadmap.sh](https://roadmap.sh/projects/task-tracker).

---

## 🚀 Funcionalidades

- **Adicionar tarefas:** Crie novas tarefas com descrições rápidas.
- **Atualizar e Deletar:** Modifique descrições ou remova tarefas existentes informando o ID.
- **Gerenciar Status:** Alterne o status das tarefas entre *A Fazer* (`todo`), *Em Andamento* (`in-progress`) ou *Concluído* (`done`).
- **Listagem e Filtros:** Visualize todas as tarefas ou filtre-as por status (`done`, `todo`, `in-progress`).
- **Persistência de Dados:** Salva e carrega automaticamente as tarefas em um arquivo `tasks.json`.

---

## 🛠️ Tecnologias Utilizadas

- **C# / .NET SDK** (compilado com Visual Studio)
- **System.Text.Json** (para manipulação e serialização dos dados)

---

## 💻 Como Instalar e Executar

### Pré-requisitos
- [.NET SDK](https://dotnet.microsoft.com/download) instalado (versão 6.0 ou superior recomendada) ou [Visual Studio](https://visualstudio.microsoft.com/).

### Opção 1: Pelo Terminal (com a CLI do .NET)

1. Clone o repositório:
   ```bash
   git clone https://github.com/J0A0Natan/TaskTracker-CLI-.git
   cd TaskTracker-CLI-
