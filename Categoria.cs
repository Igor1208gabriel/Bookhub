using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public override string ToString(){
      return $"{Id} - {Nome} - {Descricao}";
      }
}


public class NCategoria {


  private List<Categoria> objetos = new List<Categoria>();
  private string nomeArquivo = "Categorias.xml";  


  public void ToXML() {
    XmlSerializer xml = new XmlSerializer(typeof(List<Categoria>));
    StreamWriter f = new StreamWriter(nomeArquivo);
    xml.Serialize(f, objetos);
    f.Close();
  }


  public void FromXML() {
    try {
      XmlSerializer xml = new XmlSerializer(typeof(List<Categoria>));
      StreamReader f = new StreamReader(nomeArquivo);
      objetos = (List<Categoria>) xml.Deserialize(f);
      f.Close();
    }
    catch (FileNotFoundException)
    {
    }
  }


  public void Inserir(Categoria p) {
    FromXML();
    int id = 0;
    foreach(Categoria obj in objetos) 
      if (obj.Id > id) id = obj.Id;
    p.Id = id + 1;
    objetos.Add(p);
    ToXML();
  }


  public List<Categoria> Listar() {
    FromXML();
    return objetos;
  }


  public Categoria Listar(int id) {
    FromXML();
    foreach(Categoria obj in objetos) 
      if (obj.Id == id) return obj;
    return default(Categoria);
  }


  public void Atualizar(Categoria p) {
    FromXML();
    Categoria obj = Listar(p.Id);
    if (obj != null) {
      objetos.Remove(obj);
      objetos.Add(p);
    }
    ToXML();
  }


  public void Excluir(Categoria p) {
    FromXML();
    Categoria obj = Listar(p.Id);
    if (obj != null) objetos.Remove(obj);
    ToXML();
  }
}