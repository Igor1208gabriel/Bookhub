using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class Autor

{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Anonasc { get; set; }
    public string Nacionalidade { get; set; }
    public List<int> Livrospublicados { get; set; }
    public override string ToString()
    {
        return $"{Id} - {Nome} - {Anonasc} - {Nacionalidade}";
    }
}

public class NAutor
{
    private List<Autor> objetos = new();
    private readonly string nomeArquivo = "xmls/Autores.xml";

    public void ToXml()
    {
        XmlSerializer xml = new(typeof(List<Autor>));
        StreamWriter f = new(nomeArquivo);
        xml.Serialize(f, objetos);
        f.Close();
    }

    public void FromXml()
    {
        XmlSerializer xml = new(typeof(List<Autor>));
        StreamReader f = new(nomeArquivo);
        objetos = (List<Autor>)xml.Deserialize(f);
        f.Close();
    }

    public void Inserir(Autor p)
    {
        FromXml();
        int id = 0;
        foreach (Autor obj in objetos)
            if (obj.Id > id) id = obj.Id;
        p.Id = id + 1;
        objetos.Add(p);
        ToXml();
    }

    public List<Autor> Listar()
    {
        FromXml();
        return objetos;
    }

    public Autor Listar(int id)
    {
        FromXml();
        foreach (Autor obj in objetos)
            if (obj.Id == id) return obj;
        return default;
    }

    public void Atualizar(Autor p)
    {
        FromXml();
        Autor obj = Listar(p.Id);
        if (obj != null)
        {
            objetos.Remove(obj);
            objetos.Add(p);
        }
        ToXml();
    }

    public void Excluir(Autor p)
    {
        FromXml();
        Autor obj = Listar(p.Id);
        if (obj != null) objetos.Remove(obj);
        ToXml();
    }



}