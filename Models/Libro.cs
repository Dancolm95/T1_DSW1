using System.ComponentModel.DataAnnotations;
namespace DesarrolloServiciosWeb_T1.Models;

public class Libro
{
	public int Id { get; set; }
	[Required]
	public string NombreLibro { get; set; } = string.Empty;
	[Required]
	public string Autor { get; set; } = string.Empty;
	[Required]
	public string NombreEditorial { get; set; } = string.Empty;
	[Required]
	public string ISDN { get; set; } = string.Empty;
}
