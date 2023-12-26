using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;


public class Livro {
    public int Id      { get; set; }
    public string Nome { get; set; }
    public int AnoLanc { get; set; }
    public int Paginas { get; set; }
    public float Preco { get; set; }
    public int Nota    { get; set; }
    public int idautor { get; set; }
    public int idcateg { get; set; }
    public override string ToString(){
      return $"{Id} - {Nome} - {AnoLanc} - {Paginas} - {Preco} - {idautor} - {idcateg}";
    }
}

public class NLivro{

  
  private List<Livro> objetos = new List<Livro>();
  private string nomeArquivo = "Livros.xml";
  

  public void ToXML() {
    XmlSerializer xml = new XmlSerializer(typeof(List<Livro>));
    StreamWriter f = new StreamWriter(nomeArquivo);
    xml.Serialize(f, objetos);
    f.Close();
  }


  public void FromXML() {
      XmlSerializer xml = new XmlSerializer(typeof(List<Livro>));
      StreamReader f = new StreamReader(nomeArquivo);
      objetos = (List<Livro>) xml.Deserialize(f);
      f.Close();
  }


  public void Inserir(Livro p) {
    FromXML();
    int id = 0;
    foreach(Livro obj in objetos) 
      if (obj.Id > id) id = obj.Id;
    p.Id = id + 1;
    objetos.Add(p);
    ToXML();
  }


  public List<Livro> Listar() {
    FromXML();
    return objetos;
  }


  public Livro Listar(int id) {
    FromXML();
    foreach(Livro obj in objetos) 
      if (obj.Id == id) return obj;
    return default(Livro);
  }


  public void Atualizar(Livro p) {
    FromXML();
    Livro obj = Listar(p.Id);
    if (obj != null) {
      objetos.Remove(obj);
      objetos.Add(p);
    }
    ToXML();
  }


  public void Excluir(Livro p) {
    FromXML();
    Livro obj = Listar(p.Id);
    if (obj != null) objetos.Remove(obj);
    ToXML();
  }
}