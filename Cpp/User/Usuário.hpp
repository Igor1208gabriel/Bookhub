#ifndef USER_USUÁRIO_H
#define USER_USUÁRIO_H

#include <string>
#include <vector>
#include <list>
#include <iostream>
#include <assert.h>

#include "String.hpp"

namespace User
{
class Usuário
{
private:
	int ID;

	String Nome;

	String email;

	String Senha;

	String Fone;


public:
	void GerenciarAutores();

	void GerenciarLivros();

};

}  // namespace User
#endif
