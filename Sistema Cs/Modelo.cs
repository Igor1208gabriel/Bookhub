using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public interface IModelo
{
    int Id { get; set; }
}

public class NModelo<T> where T : IModelo
{


    private List<T> objetos = new();
    private readonly string nomeArquivo;


    public NModelo(string nomeArquivo)
    {
        this.nomeArquivo = nomeArquivo;
    }


    public void ToXML()
    {
        XmlSerializer xml = new(typeof(List<T>));
        StreamWriter f = new(nomeArquivo);
        xml.Serialize(f, objetos);
        f.Close();
    }


    public void FromXML()
    {
        try
        {
            XmlSerializer xml = new(typeof(List<T>));
            StreamReader f = new(nomeArquivo);
            objetos = (List<T>)xml.Deserialize(f);
            f.Close();
        }
        catch (FileNotFoundException)
        {
        }
    }


    public void Inserir(T p)
    {
        FromXML();
        int id = 0;
        foreach (T obj in objetos)
            if (obj.Id > id) id = obj.Id;
        p.Id = id + 1;
        objetos.Add(p);
        ToXML();
    }


    public List<T> Listar()
    {
        FromXML();
        return objetos;
    }


    public T? Listar(int id)
    {
        FromXML();
        foreach (T obj in objetos)
            if (obj.Id == id) return obj;
        return default;
    }


    public void Atualizar(T p)
    {
        FromXML();
        T obj = Listar(p.Id);
        if (obj != null)
        {
            objetos.Remove(obj);
            objetos.Add(p);
        }
        ToXML();
    }


    public void Excluir(T p)
    {
        FromXML();
        T obj = Listar(p.Id);
        if (obj != null) objetos.Remove(obj);
        ToXML();
    }
}