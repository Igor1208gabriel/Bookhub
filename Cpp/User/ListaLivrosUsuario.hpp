#ifndef USER_LISTA_LIVROS_USUARIO_H
#define USER_LISTA_LIVROS_USUARIO_H

#include <string>
#include <vector>
#include <list>
#include <iostream>
#include <assert.h>

namespace User
{
class ListaLivrosUsuario
{
private:
	int IdUsuario;


public:
	void MarcarLido();

	void MarcarFavorito();

	void Avaliar();

};

}  // namespace User
#endif
