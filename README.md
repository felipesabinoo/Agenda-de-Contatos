# Agenda de Contatos

Descrição
- Projeto em C# que concentra-se em conceitos de programação orientada a objetos
 	(e.g. definição de classes e encapsulamento) e nas ferramentas idiomáticas do .NET para
 	manipulação de coleções: LINQ e expressões lambda. A aplicação fornece um menu de console
 	para gerenciar contatos, servindo como exemplo prático de como estruturar operações CRUD

	Principais focos técnicos:
	- Classes e abstração: a entidade `Contato` modela os dados e métodos auxiliares, separando
		responsabilidades entre modelo e fluxo de aplicação.
	- LINQ (`System.Linq`): utilizado para consultar e manipular a coleção de contatos de forma
		declarativa e concisa (por exemplo, localizar um contato por Id com `contatos.FirstOrDefault(c => c.Id == id)`).
	- Expressões lambda: funções anônimas curtas que acompanham os métodos de extensão do LINQ
		(como `Where`, `Select`, `Any`, `FirstOrDefault`) e tornam o código mais legível ao trabalhar
		com coleções.
	- Boas práticas introdutórias: tratamento básico de entradas, separação de responsabilidades e
		serialização simples para persistência opcional.

Funcionalidades principais
- Adicionar contato: Id (int), Nome, Telefone, Email.
- Listar todos os contatos.
- Buscar contato por Id.
- Atualizar contato por Id.
- Excluir contato por Id.
- Persistência: a lista de contatos é carregada ao iniciar e salva automaticamente em formato
	JSON ao encerrar o programa (arquivo `contacts.json`).

Persistência (JSON)
- Opcional: o projeto inclui um mecanismo simples que salva/carrega a lista em `contacts.json`
 	(`System.Text.Json`) para manter dados entre execuções. A persistência é intencionalmente
 	básica — o foco didático do projeto são as classes, LINQ e lambdas.

Ferramentas e bibliotecas utilizadas
- Linguagem: C# (.NET).
- SDK/CLI: `dotnet` (utilizado para compilar e executar o projeto).
- LINQ: `System.Linq` — usado para consultas e operações sobre `IEnumerable<T>` / `List<T>`.
- Expressões lambda: sintaxe concisa para definir predicados e funções anônimas que acompanham
  os métodos do LINQ (e.g. `c => c.Id == id`).
- Serialização JSON: `System.Text.Json` (para persistência simples em `contacts.json`).
- Edição/IDE: Visual Studio, VS Code ou outro editor de sua preferência.

Pré-requisitos
- .NET SDK instalado (compatível com o alvo do projeto). Verifique com:

```powershell
dotnet --version
```

Como executar
1. Abra um terminal e navegue até a pasta do projeto:

```powershell
cd CsharpProjects\TestProject
```

2. Execute o projeto:

```powershell
dotnet run
```

Note: ao encerrar o programa pelo menu (opção `0`), será criado/atualizado o arquivo `contacts.json`
na pasta do projeto com os contatos atuais.

Formato do arquivo JSON (exemplo)

```json
[
	{
		"Id": 1,
		"Nome": "João",
		"Telefone": "99999-9999",
		"Email": "joao@example.com"
	}
]
```

Estrutura de arquivos
- [Program.cs](Program.cs) — lógica do menu, carregamento e salvamento de contatos.
- [Classe.cs](Classe.cs) — definição da classe `Contato`.
