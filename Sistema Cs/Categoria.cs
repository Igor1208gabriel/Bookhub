using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public List<int> Livrosde { get; set; }
    public override string ToString()
    {
        return $"{Id} - {Nome} - {Descricao}";
    }
}


public class NCategoria
{


    private List<Categoria> objetos = new();
    private readonly string nomeArquivo = "xmls/Categorias.xml";


    public void ToXML()
    {
        XmlSerializer xml = new(typeof(List<Categoria>));
        StreamWriter f = new(nomeArquivo);
        xml.Serialize(f, objetos);
        f.Close();
    }


    public void FromXML()
    {
        try
        {
            XmlSerializer xml = new(typeof(List<Categoria>));
            StreamReader f = new(nomeArquivo);
            objetos = (List<Categoria>)xml.Deserialize(f);
            f.Close();
        }
        catch (FileNotFoundException)
        {
        }
    }


    public void Inserir(Categoria p)
    {
        FromXML();
        int id = 0;
        foreach (Categoria obj in objetos)
            if (obj.Id > id) id = obj.Id;
        p.Id = id + 1;
        objetos.Add(p);
        ToXML();
    }


    public List<Categoria> Listar()
    {
        FromXML();
        return objetos;
    }


    public Categoria Listar(int id)
    {
        FromXML();
        foreach (Categoria obj in objetos)
            if (obj.Id == id) return obj;
        return default;
    }


    public void Atualizar(Categoria p)
    {
        FromXML();
        Categoria obj = Listar(p.Id);
        if (obj != null)
        {
            objetos.Remove(obj);
            objetos.Add(p);
        }
        ToXML();
    }


    public void Excluir(Categoria p)
    {
        FromXML();
        Categoria obj = Listar(p.Id);
        if (obj != null) objetos.Remove(obj);
        ToXML();
    }
}