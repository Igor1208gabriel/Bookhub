using System;
using System.Collections.Generic;

static class View
{
    //CRUDS para livros, autores, categorias e usuários
    public static Livro CadastrarLivro(string nome, int anolanc, int paginas, float preco, int nota, int idauto, int idcategoria)
    {
        if (preco < 0) throw new ArgumentOutOfRangeException("Preço inválido");
        if (nota < 0 || nota > 100) throw new ArgumentOutOfRangeException("Nota inválida");
        if (anolanc < 0) throw new ArgumentOutOfRangeException("Ano de lançamento inválido");
        if (paginas < 0) throw new ArgumentOutOfRangeException("Páginas inválidas");
        Livro l = new() { Nome = nome, AnoLanc = anolanc, Paginas = paginas, Preco = preco, Nota = nota, idautor = idauto, idcateg = idcategoria };
        NLivro nl = new();
        nl.Inserir(l);
        return l;
    }

    // public static Livro AcharLivro(string nome, int anolanc, int paginas, int nota, int idautor, int idcategoria)
    // {
    //     NLivro nl = new();
    //     foreach (Livro l in nl.Listar())
    //     {
    //         if (l.Nome == nome && l.AnoLanc == anolanc && l.Paginas == paginas && l.Nota == nota && l.idautor == idautor && l.idcateg == idcategoria)
    //             return l;
    //     }
    //     return default;
    // }


    public static List<Livro> ListarLivros()
    {
        NLivro np = new();
        return np.Listar();
    }


    public static void AtualizarLivro(int idLivro, string titulo, int ano, int paginas, float preco, int nota, int aut, int cat)
    {
        Livro l = new() { Id = idLivro, Nome = titulo, AnoLanc = ano, Paginas = paginas, Preco = preco, Nota = nota, idautor = aut, idcateg = cat };
        NLivro nl = new();
        nl.Atualizar(l);
    }


    public static void RemoverLivro(int idLivro)
    {
        Livro l = new() { Id = idLivro };
        NLivro nl = new();
        nl.Excluir(l);

        NUsuario nu = new();
        foreach(Usuario u in nu.Listar()) u.LivrosFavoritos.Remove(idLivro);
        nu.ToXML();

        NCategoria nc = new();
        foreach(Categoria u in nc.Listar()) u.Livrosde.Remove(idLivro);
        nc.ToXML();

        NAutor na = new();
        foreach(Autor u in na.Listar()) u.Livrospublicados.Remove(idLivro);
        na.ToXml();
    }







    public static void CadastrarAutor(string nome, int anonasc, string nacionalidade)
    {
        if (nome.Length < 3 || nome.Length > 25) throw new ArgumentOutOfRangeException("Nome inválido");
        if (anonasc < 0) throw new ArgumentOutOfRangeException("Ano de nascimento inválido");
        if (nacionalidade.Length < 3 || nacionalidade.Length > 25) throw new ArgumentOutOfRangeException("Nacionalidade inválida");
        Autor a = new() { Nome = nome, Anonasc = anonasc, Nacionalidade = nacionalidade };
        NAutor na = new();
        na.Inserir(a);
    }

    public static List<Autor> ListarAutores()
    {
        NAutor na = new();
        return na.Listar();
    }


    public static void AtualizarAutor(int idautor, string nome, int anonasc, string nacionalidade)
    {
        NAutor na = new();
        Autor a = new() { Id = idautor, Nome = nome, Anonasc = anonasc, Nacionalidade = nacionalidade };
        na.Atualizar(a);
    }

    public static void RemoverAutor(int idAutor)
    {
        NAutor na = new();
        Autor a = na.Listar(idAutor);
        na.Excluir(a);

        NLivro nl = new();
        foreach(Livro l in nl.Listar()) if(l.idautor == idAutor) l.idautor = 0;
    }

    public static void AddLivroPraAutor(int idlivro, int idautor)
    {
        NAutor na = new();
        Autor a = na.Listar(idautor);
        a.Livrospublicados.Add(idlivro);
        NLivro nl = new();
        Livro l = nl.Listar(idlivro);
        l.idautor=idautor;
        na.ToXml();
        nl.ToXML();
    }

    public static void RemoverLivroPraAutor(int idlivro, int idautor){
        NAutor na = new();
        Autor a = na.Listar(idautor);
        a.Livrospublicados.Remove(idlivro);
        NLivro nl = new();
        Livro l = nl.Listar(idlivro);
        l.idautor=0;
        nl.ToXML();
        na.ToXml();
    }








    public static void CadastrarCategoria(string nome, string descricao)
    {
        if (nome.Length > 50 || nome.Length < 3) throw new ArgumentOutOfRangeException("Nome da categoria inválido");
        if (descricao.Length > 200 || descricao.Length < 3) throw new ArgumentOutOfRangeException("Descrição da categoria inválida");
        Categoria cat = new() { Nome = nome, Descricao = descricao };
        NCategoria nc = new();
        nc.Inserir(cat);
    }


    public static List<Categoria> ListarCategorias()
    {
        NCategoria nc = new();
        return nc.Listar();
    }


    public static void AtualizarCategoria(int idcategoria, string nome, string descricao)
    {
        NCategoria nc = new();
        Categoria cat = new() { Id = idcategoria, Nome = nome, Descricao = descricao };
        nc.Atualizar(cat);
    }


    public static void RemoverCategoria(int idCategoria)
    {
        Categoria c = new() { Id = idCategoria };
        NCategoria nc = new();
        nc.Excluir(c);

        NLivro nl = new();
        foreach(Livro l in nl.Listar()) if(l.idcateg == idCategoria) l.idcateg = 0;
    }

    public static void AddLivroPraCategoria(int idlivro, int idcategoria)
    {
        NCategoria nc = new();
        Categoria c = nc.Listar(idcategoria);
        c.Livrosde.Add(idlivro);
        NLivro nl = new();
        Livro l = nl.Listar(idlivro);
        l.idcateg=idcategoria;
        nc.ToXML();
        nl.ToXML();
    }

    public static void RemoverLivroPraCategoria(int idlivro, int idcategoria){
        NCategoria nc = new();
        Categoria c = nc.Listar(idcategoria);
        c.Livrosde.Remove(idlivro);
        NLivro nl = new();
        Livro l = nl.Listar(idlivro);
        l.idcateg=idcategoria;
        nc.ToXML();
        nl.ToXML();
    }









    public static void CadastrarUsuario(string nome, string email, string senha)
    {
        Usuario u = new() { Nome = nome, Email = email, Senha = senha };
        NUsuario nu = new();
        nu.Inserir(u);
    }


    public static List<Usuario> ListarUsuarios()
    {
        NUsuario nu = new();
        return nu.Listar();
    }


    public static void AtualizarUsuario(int idusuario, string nome, string email, string senha)
    {
        NUsuario nu = new();
        Usuario u = new() { Id = idusuario, Nome = nome, Email = email, Senha = senha };
        nu.Atualizar(u);
    }

    public static Usuario ChecarUsuario(string email, string senha)
    {
        NUsuario nu = new();
        Usuario u = new();
        foreach (Usuario x in nu.Listar())
        {
            if (x.Email == email)
            {
                u = x;
                break;
            }
        }
        if (u.Senha == senha) return u;
        return default;
    }


    public static void RemoverUsuario(int idUsuario)
    {
        NUsuario nu = new();
        Usuario u = nu.Listar(idUsuario);
        nu.Excluir(u);
    }

    public static List<Livro> ListarLivrosFavoritos(int idUsuario)
    {
        NUsuario nu = new();
        Usuario u = nu.Listar(idUsuario);
        NLivro nl = new();
        List<Livro> ll = new();
        foreach(int x in u.LivrosFavoritos) ll.Add(nl.Listar(x));
        return ll;
    }

    public static void MarcarLivroFavorito(int idUsuario, int idlivro)
    {
        NUsuario nu = new();
        Usuario ualvo = nu.Listar(idUsuario);
        ualvo.LivrosFavoritos.Add(idlivro);
        nu.ToXML();
    }

    public static void RemoverLivroFavorito(int idUsuario, int idlivro)
    {
        NUsuario nu = new();
        Usuario ualvo = nu.Listar(idUsuario);
        ualvo.LivrosFavoritos.Remove(idlivro);
    }



}