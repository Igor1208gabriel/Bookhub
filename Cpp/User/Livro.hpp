#ifndef USER_LIVRO_H
#define USER_LIVRO_H

#include <string>
#include <vector>
#include <list>
#include <iostream>
#include <assert.h>

#include "String.hpp"

namespace User
{
class Livro
{
private:
	int ISBN;

	String Nome;

	int AnoLanc;

	int Paginas;

	float Preco;

	int Nota;


public:
	void operation0();

};

}  // namespace User
#endif
