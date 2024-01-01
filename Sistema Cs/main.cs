using System;
using System.Collections.Generic;

class Program
{
    static Usuario Bemvindo()
    {
        Console.WriteLine("Bem-vindo ao BookHub!\nDeseja criar um usuário(1) ou logar como usuário existente(2)?");
        string escolha = Console.ReadLine();

        if (escolha == "1")
        {
            CadastroUsuario();
            Console.WriteLine("Agora já é possível logar.");
        }

        try{
        Console.Write("Login: ");
        string login = Console.ReadLine();
        Console.Write("Senha: ");
        string senha = Console.ReadLine();

        if (login == "admin" && senha == "admin")
            return new Usuario { Id = 0 };

        Usuario user = View.ChecarUsuario(login, senha);
        if (user != default(Usuario))
        {
            Console.WriteLine("Bem-vindo, " + user.Nome + "!");
            return user;
        }
        return new Usuario { Id = -1 };

        }
        catch{
            Console.WriteLine("Informações inválidas");
            return Bemvindo();
        }


    }

    static int MenuUsuario()
    {
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1 - Listar livros favoritos");
        Console.WriteLine("2 - Marcar livro como favorito");
        Console.WriteLine("3 - Atualizar as informações de cadastro");
        Console.WriteLine("4 - Sair");
        int opcao = int.Parse(Console.ReadLine());
        return opcao;
    }
    static int MenuAdmin()
    {
        //CRUD: Cadastrar, Listar, Atualizar, Remover para Livro, Autor, Categoria, Usuario
        Console.WriteLine("Escolha algo para Cadastrar, atualizar, listar ou remover:\n1-Livro\n2-Autor\n3-Categoria\n4-Usuario\n5-Outro\n6-Sair");
        int opcao = int.Parse(Console.ReadLine());
        int ans = 0;
        switch (opcao)
        {
            case 1: ans = 0; break;
            case 2: ans = 4; break;
            case 3: ans = 8; break;
            case 4: ans = 12; break;
            case 5: ans = 50; break;
            case 6: return -1;
        }
        if(ans !=50){
        Console.WriteLine("Escolha uma opção:\n1 - Cadastrar\n2 - Listar\n3 - Atualizar\n4 - Remover");
        opcao = int.Parse(Console.ReadLine());
        return ans + opcao;
        //    Cadastrar Listar Atualizar Remover
        //Liv    1       2       3       4
        //aut    5       6       7       8
        //cat    9       10      11      12
        //usu    13      14      15      16
        }

        else{
            Console.WriteLine("Outras Opções\n1-Adicionar livro para autor\n2-Remover livro de autor\n3-Adicionar livro para categoria\n4-Remover livro de categoria\n5-Voltar\n6-Sair");
            opcao = int.Parse(Console.ReadLine());
            ans = 0;
            switch (opcao){
                case 1: ans = 17; break;
                case 2: ans = 18; break;
                case 3: ans = 19; break;
                case 4: ans = 20; break;
                case 5: return MenuAdmin();
                case 6: return -1;

            }
            return ans;
        }

    }

    static void Main(string[] args)
    {
        while (true)
        {
            Usuario us = Bemvindo();
            if (us.Id == 0)
            {
                int opcao = 0;
                while (opcao != -1)
                {
                    opcao = MenuAdmin();
                    switch (opcao)
                    {
                        case 1 : CadastroLivro(); break;
                        case 2 : ListarLivros(); break;
                        case 3 : AtualizarLivro(); break;
                        case 4 : RemoverLivro(); break;
                        case 5 : CadastroAutor(); break;
                        case 6 : ListarAutores(); break;
                        case 7 : AtualizarAutor(); break;
                        case 8 : RemoverAutor(); break;
                        case 9 : CadastroCategoria(); break;
                        case 10: ListarCategorias(); break;
                        case 11: AtualizarCategoria(); break;
                        case 12: RemoverCategoria(); break;
                        case 13: CadastroUsuario(); break;
                        case 14: ListarUsuarios(); break;
                        case 15: AtualizarUsuario(); break;
                        case 16: RemoverUsuario(); break;
                        case 17: AddLivroPraAutor(); break;
                        case 18: RemoverLivroDeAutor(); break;
                        case 19: AddLivroPraCategoria(); break;
                        case 20: RemoverLivroDeCategoria(); break;
                    }
                }
                Console.WriteLine("Saindo...");
                Environment.Exit(0);
            }
            else if (us.Id > 0)
            {
                int opcao = 0;
                while (opcao != 4)
                {
                    opcao = MenuUsuario();
                    switch (opcao)
                    {
                        case 1: ListarLivrosFavoritos(us.Id); break;
                        case 2: MarcarLivroFavorito(us.Id); break;
                        case 3: AtualizarUsuario(us.Id); break;
                    }
                }
                Console.WriteLine("Saindo...");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Usuario ou senha incorretos");
            }
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
        ListarAutores();
        int aut = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite o id da categoria do livro: ");
        ListarCategorias();
        int cat = int.Parse(Console.ReadLine());
        try
        {
            Livro x = View.CadastrarLivro(titulo, ano, paginas, preco, nota, aut, cat);
            View.AddLivroPraAutor(x.Id, aut);
            View.AddLivroPraCategoria(x.Id, cat);
        }
        catch (ArgumentOutOfRangeException zx)
        {
            Console.WriteLine(zx);
            CadastroLivro();
        }
    }

    static void ListarLivros()
    {
        List<Livro> ll = View.ListarLivros();
        Console.WriteLine("Livros cadastrados:");
        Console.WriteLine("ID - Título - Ano - Páginas - Preço - Nota - Autor - Categoria");
        foreach (Livro l in ll)
        {
            Console.WriteLine(l);
        }

    }

    static void AtualizarLivro()
    {
        ListarLivros();
        Console.WriteLine("Digite o ID do livro que deseja atualizar: ");
        int idlivro = int.Parse(Console.ReadLine());
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

        ListarAutores();
        Console.WriteLine("Digite o novo ID de Autor: ");
        int aut = int.Parse(Console.ReadLine());

        ListarCategorias();
        Console.WriteLine("Digite o novo ID de Categoria: ");
        int cat = int.Parse(Console.ReadLine());

        View.AtualizarLivro(idlivro, titulo, ano, paginas, preco, nota, aut, cat);
    }

    static void RemoverLivro()
    {
        ListarLivros();
        Console.WriteLine("Digite o código do livro que deseja remover: ");
        int idlivro = int.Parse(Console.ReadLine());
        View.RemoverLivro(idlivro);
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
        ListarLivros();
        Console.WriteLine("Digite o código do livro que deseja marcar como favorito: ");
        int idlivro = int.Parse(Console.ReadLine());
        View.MarcarLivroFavorito(idusuario, idlivro);

    }












    static void CadastroAutor()
    {
        Console.WriteLine("Digite o nome do autor: ");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite o ano de nascimento do autor: ");
        int ano = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite a nacionalidade do autor");
        string nacionalidade = Console.ReadLine();

        try
        {
            View.CadastrarAutor(nome, ano, nacionalidade);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex);
            CadastroAutor();
        }
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
        ListarAutores();
        Console.WriteLine("Digite o ID do autor que deseja remover: ");
        int id = int.Parse(Console.ReadLine());
        View.RemoverAutor(id);
    }

    static void AddLivroPraAutor(){
        ListarLivros();
        Console.WriteLine("Digite o Id do livro");
        int idlivro = int.Parse(Console.ReadLine());
        ListarAutores();
        Console.WriteLine("Digite o Id do autor");
        int idautor = int.Parse(Console.ReadLine());
        try{
            View.AddLivroPraAutor(idlivro, idautor);
        }
        catch{
            Console.WriteLine("Valores inválidos");
            AddLivroPraAutor();
        }
    }

    static void RemoverLivroDeAutor(){
        ListarLivros();
        Console.WriteLine("Digite o Id do livro");
        int idlivro = int.Parse(Console.ReadLine());

        ListarAutores();
        Console.WriteLine("Digite o Id do autor");
        int idautor = int.Parse(Console.ReadLine());

        try{
            View.RemoverLivroPraAutor(idlivro, idautor);
        }
        catch{
            Console.WriteLine("Informações inválidas");
            RemoverLivroDeAutor();
        }
    }









    static void CadastroCategoria()
    {
        Console.WriteLine("Digite o nome da nova categoria");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite a descrição da categoria");
        string descricao = Console.ReadLine();

        try
        {
            View.CadastrarCategoria(nome, descricao);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex);
            CadastroCategoria();
        }
    }

    static void ListarCategorias()
    {
        NCategoria nc = new();
        List<Categoria> lc = nc.Listar();
        Console.WriteLine("Categorias Cadastradas: ");
        Console.WriteLine("ID - Nome - Descrição");
        foreach (Categoria l in lc)
        {
            Console.WriteLine(l);
        }
    }
    static void AtualizarCategoria()
    {
        ListarCategorias();
        Console.WriteLine("Digite o ID da categoria que deseja atualizar: ");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite o novo nome da categoria: ");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite a nova descrição da categoria: ");
        string descricao = Console.ReadLine();
        View.AtualizarCategoria(id, nome, descricao);
    }

    static void RemoverCategoria()
    {
        ListarCategorias();
        Console.WriteLine("Digite o ID da categoria que deseja remover: ");
        int id = int.Parse(Console.ReadLine());
        View.RemoverCategoria(id);
    }

    static void AddLivroPraCategoria(){
        ListarLivros();
        Console.WriteLine("Digite o Id do livro");
        int idlivro = int.Parse(Console.ReadLine());

        ListarCategorias();
        Console.WriteLine("Digite o Id da categoria");
        int idcategoria = int.Parse(Console.ReadLine());

        try{
            View.AddLivroPraCategoria(idlivro, idcategoria);
        }
        catch{
            Console.WriteLine("Informações inválidas");
            AddLivroPraCategoria();
        }

    }

    static void RemoverLivroDeCategoria(){
        ListarLivros();
        Console.WriteLine("Digite o Id do livro");
        int idlivro = int.Parse(Console.ReadLine());

        ListarCategorias();
        Console.WriteLine("Digite o Id da categoria");
        int idcategoria = int.Parse(Console.ReadLine());

        try{
            View.AddLivroPraCategoria(idlivro, idcategoria);
        }
        catch{
            Console.WriteLine("Informações inválidas");
            AddLivroPraCategoria();
        }
    }











    static void CadastroUsuario()
    {
        Console.WriteLine("Digite o nome do novo usuário: ");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite o email do novo usuário: ");
        string email = Console.ReadLine();
        Console.WriteLine("Digite a senha do novo usuário: ");
        string senha = Console.ReadLine();

        try
        {
            View.CadastrarUsuario(nome, email, senha);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex);
            CadastroUsuario();
        }
    }

    static void ListarUsuarios()
    {
        List<Usuario> lu = View.ListarUsuarios();
        Console.WriteLine("Usuários cadastrados:");
        foreach (Usuario u in lu)
        {
            Console.WriteLine(u);
        }
    }
    static void AtualizarUsuario()
    {
        Console.WriteLine("Digite o Id do usuário alvo");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite o novo nome do usuário: ");
        string nomenovo = Console.ReadLine();
        Console.WriteLine("Digite o novo email do usuário: ");
        string emailnovo = Console.ReadLine();
        Console.WriteLine("Digite a nova senha do usuário: ");
        string senhanovo = Console.ReadLine();
        View.AtualizarUsuario(id, nomenovo, emailnovo, senhanovo);
    }
    static void AtualizarUsuario(int id)
    {
        Console.WriteLine("Digite o novo nome do usuário: ");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite o novo email do usuário: ");
        string email = Console.ReadLine();
        Console.WriteLine("Digite a senha antiga do usuário: ");
        string senha1 = Console.ReadLine();
        Console.WriteLine("Digite a nova senha do usuário: ");
        string senha2 = Console.ReadLine();
        if(senha1 == senha2)
            View.AtualizarUsuario(id, nome, email, senha1);
        else{
            Console.WriteLine("Senha errada");
            AtualizarUsuario();
        } 
    }
    static void RemoverUsuario()
    {
        ListarUsuarios();
        Console.WriteLine("Digite o ID do usuário que deseja remover: ");
        int id = int.Parse(Console.ReadLine());
        View.RemoverUsuario(id);
    }


}