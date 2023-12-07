#ifndef USER_LISTA_LIVROS_GERAL_H
#define USER_LISTA_LIVROS_GERAL_H

#include <string>
#include <vector>
#include <list>
#include <iostream>
#include <assert.h>

#include "User/Livro.hpp"

namespace User
{
class ListaLivrosGeral
{
protected:
	void UpdateLivro(Livro obj);

	void DeleteLivro(Livro obj);

public:
	void CreateLivro(Livro obj);

	void ReadLivro(Livro obj);

};

}  // namespace User
#endif
