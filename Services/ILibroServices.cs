using System;
using System.Collections;
using DesarrolloServiciosWeb_T1.Models;

public interface ILibroServices
{
	IEnumerable<Libro> recuperarLibros();
	string guardarLibro(Libro libro);
	string actualizarLibro(Libro libro);
	string eliminarLibro(int id);
	IEnumerable<Libro> ListarLibrosPorAutor(string autor);
}
