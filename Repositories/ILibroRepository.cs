using System;
using System.Collections;
using DesarrolloServiciosWeb_T1.Models;
namespace DesarrolloServiciosWeb_T1.Repositories;

public interface ILibroRepository
{
	IEnumerable<Libro> RecuperarDatos(string storeProcedure, Dictionary<string, dynamic> parametros);

	string EnviarDatos(string storeProcedure,Dictionary<string, object> parametros);
}
