#ifndef VIEW_H
#define VIEW_H

#include <string>
#include <vector>
#include <list>
#include <iostream>
#include <assert.h>

#include "String.hpp"
#include "Usuário.hpp"
#include "User/Autor.hpp"
#include "User/Livro.hpp"
#include "User/Usuário.hpp"

class View
{
public:
	void AutoresListar();

	void LivroListar();

	void UsuarioListar();

	void CreateAutor(int ID, String nome, int anonasc, String nacionalidade);

	void ReadAutor(User::Autor aut);

	void UpdateAutor(User::Autor aut);

	bool DeleteAutor(User::Autor aut);

	void CreateLivro(int isbn, String nome, int anolanc, int paginas, float preco, int nota);

	void ReadLivro(User::Livro L);

	void UpdateLivro(User::Livro l);

	bool DeleteLivro(User::Livro l);

	void CreateUsuario(int id, String nome, string email, string senha, string fone);

	void ReadUsuario(User::Usuário u);

	void UpdateUsuario(Usuário u);

	void DeleteUsuario(User::Usuário u);

};
#endif
