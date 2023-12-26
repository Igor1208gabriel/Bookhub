using System;
using System.Collections.Generic;

static class View 
{
  //CRUDS para livros, autores e categorias
  public static void CadastrarLivro(string nome, int anolanc, int paginas, float preco, int nota, int idautor, int idcategoria){
    if (preco < 0) throw new ArgumentOutOfRangeException("Preço inválido");
    if (nota < 0 || nota > 100) throw new ArgumentOutOfRangeException("Nota inválida");
    if (anolanc < 0) throw new ArgumentOutOfRangeException("Ano de lançamento inválido");
    if (paginas < 0) throw new ArgumentOutOfRangeException("Páginas inválidas");
    Livro l = new Livro{Nome = nome, AnoLanc = anolanc, Paginas = paginas, Preco = preco, Nota = nota};
    NLivro nl = new NLivro();
    nl.Inserir(l);
  }

  
  public static List<Livro> ListarLivros(){
    NLivro np = new NLivro();
    return np.Listar();
  }

  
  public static void AtualizarLivro(int idLivro, string titulo, int ano, int paginas, float preco, int nota, int aut, int cat){
    
  }

  
  public static void RemoverLivro(int idLivro){
    Livro l = new Livro{Id = idLivro};
    NLivro nl = new NLivro();
    nl.Excluir(l);
  }





  
  
  public static void CadastrarAutor(string nome, int anonasc, string nacionalidade){
    if(nome.Length < 3 || nome.Length > 25) throw new ArgumentOutOfRangeException("Nome inválido");
    if(anonasc < 0) throw new ArgumentOutOfRangeException("Ano de nascimento inválido");
    if(nacionalidade.Length < 3 || nacionalidade.Length > 25) throw new ArgumentOutOfRangeException("Nacionalidade inválida");
    Autor a = new Autor{Nome = nome, Anonasc = anonasc, Nacionalidade = nacionalidade};
    NAutor na = new NAutor();
    na.Inserir(a);
  }
  
  public static List<Autor> ListarAutores(){
    NAutor na = new NAutor();
    return na.Listar();
  }

  
  public static void AtualizarAutor(int idautor, string nome, int anonasc, string nacionalidade){
    
  }
  
  public static void RemoverAutor(int idAutor){
    Autor a = new Autor{Id = idAutor};
    NAutor na = new NAutor();
    na.Excluir(a);
  }





  

  public static void CadastrarCategoria(string nome, string descricao){
    if(nome.Length > 50 || nome.Length < 3) throw new ArgumentOutOfRangeException("Nome da categoria inválido");
    if(descricao.Length > 200 || descricao.Length < 3) throw new ArgumentOutOfRangeException("Descrição da categoria inválida");
    Categoria cat = new Categoria{Nome = nome, Descricao = descricao};
    NCategoria nc = new NCategoria();
    nc.Inserir(cat);
  }

  
  public static List<Categoria> ListarCategorias(){
    NCategoria nc = new NCategoria();
    return nc.Listar();
  }

  
  public static void AtualizarCategoria(int idcategoria, string nome, string descricao){
    
  }

  
  public static void RemoverCategoria(int idCategoria){
    Categoria c = new Categoria{Id = idCategoria};
    NCategoria nc = new NCategoria();
    nc.Excluir(c);
  }




  

  
  

  public static void CadastrarUsuario(string nome, string email, string senha){
    if(senha.Length < 8) throw new ArgumentOutOfRangeException("Senha inválida");
    Usuario u = new Usuario{Nome = nome, Email = email, Senha = senha};
  }

  
  public static List<Usuario> ListarUsuarios(){
    NUsuario nu = new NUsuario();
    return nu.Listar();
  }

  
  public static void AtualizarUsuario(int idusuario, string nome, string email, string senha){
    
  }

   
  public static void RemoverUsuario(int idUsuario){
    
  }

  public static List<Livro> ListarLivrosFavoritos(int idUsuario){
    
  }

  public static void MarcarLivroFavorito(int idUsuario, int idlivro){
    
  }

  public static void RemoverLivroFavorito(int idUsuario, int idlivro){
    
  }

  
}