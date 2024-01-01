using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public List<int> LivrosFavoritos { get; set; }
    public override string ToString()
    {
        return $"{Id} - {Nome} - {Email}";
    }
}

public class NUsuario
{


    private List<Usuario> objetos = new();
    private readonly string nomeArquivo = "xmls/Usuarios.xml";

    public void ToXML()
    {
        XmlSerializer xml = new(typeof(List<Usuario>));
        StreamWriter f = new(nomeArquivo);
        xml.Serialize(f, objetos);
        f.Close();
    }


    public void FromXML()
    {
        try
        {
            XmlSerializer xml = new(typeof(List<Usuario>));
            StreamReader f = new(nomeArquivo);
            objetos = (List<Usuario>)xml.Deserialize(f);
            f.Close();
        }
        catch (FileNotFoundException)
        {
        }
    }


    public void Inserir(Usuario p)
    {
        FromXML();
        int id = 0;
        foreach (Usuario obj in objetos)
            if (obj.Id > id) id = obj.Id;
        p.Id = id + 1;
        objetos.Add(p);
        ToXML();
    }


    public List<Usuario> Listar()
    {
        FromXML();
        return objetos;
    }


    public Usuario Listar(int id)
    {
        FromXML();
        foreach (Usuario obj in objetos)
            if (obj.Id == id) return obj;
        return default;
    }


    public void Atualizar(Usuario p)
    {
        FromXML();
        Usuario obj = Listar(p.Id);
        if (obj != null)
        {
            objetos.Remove(obj);
            objetos.Add(p);
        }
        ToXML();
    }



    public void Excluir(Usuario p)
    {
        FromXML();
        Usuario obj = Listar(p.Id);
        if (obj != null) objetos.Remove(obj);
        ToXML();
    }
}