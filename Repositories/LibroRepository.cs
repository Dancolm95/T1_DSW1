using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DesarrolloServiciosWeb_T1.Models;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace DesarrolloServiciosWeb_T1.Repositories;

public class LibroRepository : ILibroRepository
{
	private readonly IConfiguration _configuration;

	public LibroRepository(IConfiguration configuration)
	{
		_configuration = configuration;
    }

	public IEnumerable<Libro> RecuperarDatos(string storeProcedure, Dictionary<string, dynamic> parametros)
	{
		List<Libro> libros = new List<Libro>();

		using (SqlConnection conexion = new SqlConnection(_configuration["ConnectionStrings:BD"]))
		{ 
			conexion.Open();

			SqlCommand comando = new SqlCommand(storeProcedure, conexion);
			comando.CommandType = CommandType.StoredProcedure;

			foreach (KeyValuePair<string, dynamic> parametro in parametros)
			{
				comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
            }

			SqlDataReader lector = comando.ExecuteReader();

			while (lector.Read())
			{
				libros.Add(new Libro()
				{
					Id = lector.GetInt32(0),
					NombreLibro = lector.GetString(1),
					Autor = lector.GetString(2),
					NombreEditorial = lector.GetString(3),
					ISDN = lector.GetString(4)
				});
			}
        }
		return libros;
    }

	public string EnviarDatos(string storeProcedure, Dictionary<string, dynamic> parametros)
	{
		using (SqlConnection conexion = new SqlConnection(_configuration["ConnectionStrings:BD"]))
		{
			conexion.Open();
			SqlCommand comando = new SqlCommand(storeProcedure, conexion);
			comando.CommandType = CommandType.StoredProcedure;
			foreach (KeyValuePair<string, dynamic> parametro in parametros)
			{
				comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
			}
			
			{
				return comando.ExecuteNonQuery() > 0 ? "Exitoso" : "Fallo";
			}
        }
    }
}
