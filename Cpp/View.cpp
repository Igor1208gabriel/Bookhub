#include <string>
#include <vector>
#include <list>
#include <iostream>
#include <assert.h>

#include "View.hpp"


void View::AutoresListar()
{
}

void View::LivroListar()
{
}

void View::UsuarioListar()
{
}

void View::CreateAutor(int ID, String nome, int anonasc, String nacionalidade)
{
}

void View::ReadAutor(User::Autor aut)
{
}

void View::UpdateAutor(User::Autor aut)
{
}

bool View::DeleteAutor(User::Autor aut)
{
	return false;
}

void View::CreateLivro(int isbn, String nome, int anolanc, int paginas, float preco, int nota)
{
}

void View::ReadLivro(User::Livro L)
{
}

void View::UpdateLivro(User::Livro l)
{
}

bool View::DeleteLivro(User::Livro l)
{
	return false;
}

void View::CreateUsuario(int id, String nome, std::string email, Std::string senha, std::string fone)
{
}

void View::ReadUsuario(User::Usuário u)
{
}

void View::UpdateUsuario(Usuário u)
{
}

void View::DeleteUsuario(User::Usuário u)
{
}
