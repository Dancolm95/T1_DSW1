using System;
using System.Collections.Generic;
using System.Security.Policy;
using DesarrolloServiciosWeb_T1.Models;
using DesarrolloServiciosWeb_T1.Repositories;

namespace DesarrolloServiciosWeb_T1.Services;

public class LibroServices : ILibroServices
{
	private readonly ILibroRepository _libroRepository;

	public LibroServices(ILibroRepository libroRepository)
	{
		_libroRepository = libroRepository;
    }

	public IEnumerable<Libro> recuperarLibros()
	{
		return _libroRepository.RecuperarDatos("usp_ListarLibros", new Dictionary<string, dynamic>());
    }

	public string guardarLibro(Libro libro)
	{ 
		Dictionary<string, dynamic> parametros = new Dictionary<string, dynamic>();
		parametros.Add("@NombreLibro", libro.NombreLibro);
		parametros.Add("@Autor", libro.Autor);
		parametros.Add("@NombreEditorial", libro.NombreEditorial);
		parametros.Add("@ISDN", libro.ISDN);

		return _libroRepository.EnviarDatos("usp_RegistrarLibro", parametros);
	}

	public string actualizarLibro(Libro libro)
	{
		Dictionary<string, dynamic> parametros = new Dictionary<string, dynamic>();
		parametros.Add("@Id", libro.Id);	
		parametros.Add("@NombreLibro", libro.NombreLibro);
		parametros.Add("@Autor", libro.Autor);
		parametros.Add("@NombreEditorial", libro.NombreEditorial);
		parametros.Add("@ISDN", libro.ISDN);

		return _libroRepository.EnviarDatos("usp_ActualizarLibro", parametros);
    }

	public string eliminarLibro(int id)
	{ 
		Dictionary<string, dynamic> parametros = new Dictionary<string, dynamic>();
		parametros.Add("@Id", id);

		return _libroRepository.EnviarDatos("usp_EliminarLibro", parametros);
    }

	public IEnumerable<Libro> ListarLibrosPorAutor(string autor)
	{
		Dictionary<string, dynamic> parametros = new Dictionary<string, dynamic>();
		parametros.Add("@Autor", autor);
		return _libroRepository.RecuperarDatos("usp_ListarLibrosPorAutor", parametros);
    }
}
