using System;
using System.Collections.Generic;

class Program
{
  static string Bemvindo()
  {
    Console.WriteLine("Bem-vindo ao BookHub!");
    Console.Write("Login: ");
    string login = Console.ReadLine();
    Console.Write("Senha: ");
    string senha = Console.ReadLine();
    Console.WriteLine("Bem-vindo, " + login + "!");
    if (login == "admin" && senha == "admin")
      return "admin";
    else
      return "user";
  }

  static int MenuUsuario()
  {
    Console.WriteLine("Escolha uma opção:");
    Console.WriteLine("1 - Listar livros favoritos");
    Console.WriteLine("2 - Marcar livro como favorito");
    Console.WriteLine("3 - Sair");
    int opcao = int.Parse(Console.ReadLine());
    return opcao;
  }
  static int MenuAdmin()
  {
    //CRUD: Cadastrar, Listar, Atualizar, Remover para Livro, Autor, Categoria, Usuario
    Console.WriteLine("Escolha algo para Cadastrar, atualizar, listar ou remover:\n1-Livro\n2-Autor\n3-Categoria\n4-Usuario\n5-Sair");
    int opcao = int.Parse(Console.ReadLine());
    int ans = 0;
    switch (opcao)
    {
      case 1: ans = 0; break;
      case 2: ans = 4; break;
      case 3: ans = 8; break;
      case 4: ans = 12; break;
      case 5: return -1;
    }
    Console.WriteLine("Escolha uma opção:\n1 - Cadastrar\n2 - Atualizar\n3- Listar\n4 - Remover");
    opcao = int.Parse(Console.ReadLine());
    return ans + opcao;
    //    Cadastrar Listar Atualizar Remover
    //Liv    1       2       3       4
    //aut    5       6       7       8
    //cat    9       10      11      12
    //usu    13      14      15      16
  }

  static void Main(string[] args)
  {
    string tipo = Bemvindo();
    if (tipo == "admin")
    {
      int op = 0;
      while (op != 5)
      {
        int opcao = MenuAdmin();
        switch (opcao)
        {
          case 1: CadastroLivro(); break;
          case 2: ListarLivros(); break;
          case 3: AtualizarLivro(); break;
          case 4: RemoverLivro(); break;
          case 5: CadastroAutor(); break;
          case 6: ListarAutores(); break;
          case 7: AtualizarAutor(); break;
          case 8: RemoverAutor(); break;
          case 9: CadastroCategoria(); break;
          case 10: ListarCategorias(); break;
          case 11: AtualizarCategoria(); break;
          case 12: RemoverCategoria(); break;
          case 13: CadastroUsuario(); break;
          case 14: ListarUsuarios(); break;
          case 15: AtualizarUsuario(); break;
          case 16: RemoverUsuario(); break;
        }
      }
      Console.WriteLine("Saindo...");
    }
    else
    {
      int idusuario = 0;
      int op = 0;
      while (op != 3)
      {
        int opcao = MenuUsuario();
        switch (opcao)
        {
          case 1: ListarLivrosFavoritos(idusuario); break;
          case 2: MarcarLivroFavorito(idusuario); break;
        }
      }
      Console.WriteLine("Saindo...");
    }
  }

  static void CadastroLivro()
  {
    Console.WriteLine("Digite o título do livro: ");
    string titulo = Console.ReadLine();
    Console.WriteLine("Digite o ano de lançamento do livro: ");
    int ano = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite o número de páginas do livro: ");
    int paginas = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite o preço do livro: ");
    float preco = float.Parse(Console.ReadLine());
    Console.WriteLine("Digite a nota do livro: ");
    int nota = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite o id do Autor do livro: ");
    int aut = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite o id da categoria do livro: ");
    int cat = int.Parse(Console.ReadLine());
    View.CadastrarLivro(titulo, ano, paginas, preco, nota, aut, cat);
  }

  static void ListarLivros()
  {
    List<Livro> ll = View.ListarLivros();
    Console.WriteLine("Livros cadastrados:");
    foreach (Livro l in ll)
    {
      Console.WriteLine(l);
    }

  }

  static void AtualizarLivro()
  {
    ListarLivros();
    Console.WriteLine("Digite o ID do livro que deseja atualizar: ");
    int isbn = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite o novo título do livro: ");
    string titulo = Console.ReadLine();
    Console.WriteLine("Digite o novo ano de lançamento: ");
    int ano = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite o novo número de páginas: ");
    int paginas = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite o novo preço: ");
    float preco = float.Parse(Console.ReadLine());
    Console.WriteLine("Digite a nova nota: ");
    int nota = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite o novo ID de Autor: ");
    int aut = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite o novo ID de Categoria: ");
    int cat = int.Parse(Console.ReadLine());
    View.AtualizarLivro(isbn, titulo, ano, paginas, preco, nota, aut, cat);
  }

  static void RemoverLivro()
  {
    Console.WriteLine("Digite o código do livro que deseja remover: ");
    int isbn = int.Parse(Console.ReadLine());
    View.RemoverLivro(isbn);
  }

  static void ListarLivrosFavoritos(int idusuario)
  {
    List<Livro> ll = View.ListarLivrosFavoritos(idusuario);
    Console.WriteLine("Livros favoritos:");
    foreach (Livro l in ll)
    {
      Console.WriteLine(l);
    }
  }

  static void MarcarLivroFavorito(int idusuario)
  {
    Console.WriteLine("Digite o código do livro que deseja marcar como favorito: ");
    int isbn = int.Parse(Console.ReadLine());
    View.MarcarLivroFavorito(idusuario, isbn);
  }





  static void CadastroAutor()
  {
    Console.WriteLine("Digite o nome do autor: ");
    string nome = Console.ReadLine();
    Console.WriteLine("Digite o ano de nascimento do autor: ");
    int ano = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite a nacionalidade do autor");
    string nacionalidade = Console.ReadLine();
    View.CadastrarAutor(nome, ano, nacionalidade);
  }

  static void ListarAutores()
  {
    List<Autor> la = View.ListarAutores();
    Console.WriteLine("Autores Cadastrados:");
    foreach (Autor a in la)
    {
      Console.WriteLine(a);
    }
  }

  static void AtualizarAutor()
  {
    ListarAutores();
    Console.WriteLine("Digite o ID do autor que deseja atualizar: ");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite o novo nome do autor: ");
    string nome = Console.ReadLine();
    Console.WriteLine("Digite o novo ano de nascimento do autor: ");
    int ano = int.Parse(Console.ReadLine());
    Console.WriteLine("Digite a nova nacionalidade do autor");
    string nacionalidade = Console.ReadLine();
    View.AtualizarAutor(id, nome, ano, nacionalidade);
  }

  static void RemoverAutor()
  {
    Console.WriteLine("Digite o ID do autor que deseja remover: ");
    int id = int.Parse(Console.ReadLine());
    View.RemoverAutor(id);
  }

  static void CadastroCategoria()
  {
    Console.WriteLine("Digite o nome da nova categoria");
    string nome = Console.ReadLine();
    Console.WriteLine("Digite a descrição da categoria");
    string descricao = Console.ReadLine();
    View.CadastrarCategoria(nome, descricao);
  }

    static void ListarCategorias()
    {
      NCategoria nc = new NCategoria();
      List<Categoria> lc = nc.Listar();
      foreach (Categoria l in lc)
      {
        Console.WriteLine(l);
      }
    }
    static void AtualizarCategoria() { }
    static void RemoverCategoria() { }





    static void CadastroUsuario() { }
    static void ListarUsuarios() { }
    static void AtualizarUsuario() { }
    static void RemoverUsuario() { }

  }