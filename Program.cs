using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;


class Program
{
    static void Main(string[] args)
    {
        List<Contato> contatos = new List<Contato>();
        Menu(contatos);
        List<Contato> contatosCarregados = CarregarContatos();
        Menu(contatosCarregados);
        SalvarContatos(contatosCarregados);

    }

    static void Menu(List<Contato> contatos)
    {
        int opcao;
        do
        {
            Console.WriteLine("1 - Adicionar contato");
            Console.WriteLine("2 - Listar contatos");
            Console.WriteLine("3 - Buscar contato por Id");
            Console.WriteLine("4 - Atualizar contato");
            Console.WriteLine("5 - Excluir contato");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
                opcao = -1;

            Console.WriteLine();

            switch (opcao)
            {
                case 1:
                    AdicionarContato(contatos);
                    break;
                case 2:
                    ListarContatos(contatos);
                    break;
                case 3:
                    BuscarContatoPorId(contatos);
                    break;
                case 4:
                    AtualizarContato(contatos);
                    break;
                case 5:
                    ExcluirContato(contatos);
                    break;
                case 0:
                    Console.WriteLine("Saindo do programa...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
            Console.WriteLine();
        } while (opcao != 0);
    }

    static void AdicionarContato(List<Contato> contatos)
    {
        Contato novo = new Contato();

        Console.Write("Digite o ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido!");
            return;
        }
        novo.Id = id;

        Console.Write("Digite o nome: ");
        novo.Nome = Console.ReadLine() ?? "";

        Console.Write("Digite o telefone: ");
        novo.Telefone = Console.ReadLine() ?? "";

        Console.Write("Digite o email: ");
        novo.Email = Console.ReadLine() ?? "";

        contatos.Add(novo);
        Console.WriteLine("Contato adicionado com sucesso!");
    }

    static void ListarContatos(List<Contato> contatos)
    {
        if (contatos.Count == 0)
        {
            Console.WriteLine("Nenhum contato cadastrado.");
            return;
        }

        foreach (var c in contatos)
        {
            Console.WriteLine($"Id: {c.Id}, Nome: {c.Nome}, Telefone: {c.Telefone}, Email: {c.Email}");
        }
    }

    static void BuscarContatoPorId(List<Contato> contatos)
    {
        Console.Write("Digite o Id: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Id inválido!");
            return;
        }

        var contato = contatos.FirstOrDefault(c => c.Id == id);
        if (contato != null)
            Console.WriteLine($"Id: {contato.Id}, Nome: {contato.Nome}, Telefone: {contato.Telefone}, Email: {contato.Email}");
        else
            Console.WriteLine("Contato não encontrado.");
    }

    static void AtualizarContato(List<Contato> contatos)
    {
        Console.Write("Digite o Id do contato a atualizar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Id inválido!");
            return;
        }

        var contato = contatos.FirstOrDefault(c => c.Id == id);
        if (contato != null)
        {
            Console.Write("Novo nome: ");
            contato.Nome = Console.ReadLine() ?? "";

            Console.Write("Novo telefone: ");
            contato.Telefone = Console.ReadLine() ?? "";

            Console.Write("Novo email: ");
            contato.Email = Console.ReadLine() ?? "";

            Console.WriteLine("Contato atualizado com sucesso!");
        }
        else
        {
            Console.WriteLine("Contato não encontrado.");
        }
    }

    static void ExcluirContato(List<Contato> contatos)
    {
        Console.Write("Digite o Id do contato a excluir: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Id inválido!");
            return;
        }

        var contato = contatos.FirstOrDefault(c => c.Id == id);
        if (contato != null)
        {
            contatos.Remove(contato);
            Console.WriteLine("Contato excluído com sucesso!");
        }
        else
        {
            Console.WriteLine("Contato não encontrado.");
        }
    }
    static void SalvarContatos(List<Contato> contatos)
    {
    string json = JsonSerializer.Serialize(contatos);
    File.WriteAllText("contatos.json", json);
    }

    static List<Contato> CarregarContatos()
    {
        if (File.Exists("contatos.json"))
        {
            string json = File.ReadAllText("contatos.json");
            return JsonSerializer.Deserialize<List<Contato>>(json) ?? new List<Contato>();
        }
        return new List<Contato>();
    }


    
}
