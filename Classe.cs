using System;
using System.Text.Json.Serialization;

public class Contato
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
   

    [JsonIgnore]
    public List<Contato> Contatos { get; set; } = new List<Contato>();


    public void AdicionarContato(Contato contato)
    {
        Contatos.Add(contato); 
    }

    public void ListarContatos()
    {
        foreach (var contato in Contatos)
        {
            Console.WriteLine($"Id: {contato.Id}, Nome: {contato.Nome}, Telefone: {contato.Telefone}, Email: {contato.Email}");
        }
    }

    public void BuscarContatoPorId(int id)
    {
        var contato = Contatos.FirstOrDefault(c => c.Id == id);
        if (contato != null)
        {
            Console.WriteLine("Id: {0}, Nome: {1}, Telefone: {2}, Email: {3}", contato.Id, contato.Nome, contato.Telefone, contato.Email);
        }
        else
        {
            Console.WriteLine("Nenhum contato encontrado com o Id: {0}", id);
        }
    }

    public void AtualizarContato(int id, string nome, string telefone, string email)
    {
        var contatos = Contatos.FirstOrDefault(c => c.Id == id);
        if (contatos != null)
        {
            contatos.Nome = nome;
            contatos.Telefone = telefone;
            contatos.Email = email;
            Console.WriteLine("Contato atualizado com sucesso!");
        }
        else
        {
            Console.WriteLine("Nenhum contato encontrado com o Id: {0}", id);
        }
    }

    public void ExcluirContato(int id)
    {
        var contatos = Contatos.FirstOrDefault(c => c.Id == id);
        if (contatos != null)
        {
            Contatos.Remove(contatos);
            Console.WriteLine("Contato excluído com sucesso!");
        }
        else
        {
            Console.WriteLine("Nenhum contato encontrado com o Id: {0}", id);
        }
    }

}
