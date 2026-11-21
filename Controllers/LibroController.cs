using Microsoft.AspNetCore.Mvc;
using DesarrolloServiciosWeb_T1.Models;
using DesarrolloServiciosWeb_T1.Services;

namespace DesarrolloServiciosWeb_T1.Controllers
{
    public class LibroController : Controller
    {
        private readonly ILibroServices _libroServices;

        public LibroController(ILibroServices libroServices)
        {
            _libroServices = libroServices;
        }
        public IActionResult Index(int pagina = 1)
        {
            if (pagina < 1)
                pagina = 1;

            int cantidadPorPagina = 5;
            List<Libro> libros = _libroServices.recuperarLibros().ToList();

            ViewBag.Pagina = pagina;
            ViewBag.HaySiguiente = libros.Count > pagina * cantidadPorPagina;
            ViewBag.Mensaje = TempData["Mensaje"];

            return View(libros
                .Skip((pagina - 1) * cantidadPorPagina)
                .Take(cantidadPorPagina));
        }
        //public IActionResult Index()
        //{
        //  IEnumerable<Libro> libros = _libroServices.recuperarLibros();
        //ViewBag.Mensaje = TempData["Mensaje"];
        //return View(libros);
        //}

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return View(libro);
            }

            string resultado = _libroServices.guardarLibro(libro);
            TempData["Mensaje"] = resultado == "Exitoso"
                ? "Libro registrado correctamente."
                : "No se pudo registrar el libro.";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            Libro? libro = _libroServices.recuperarLibros().FirstOrDefault(l => l.Id == id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        [HttpPost]
        public IActionResult Editar(Libro libro)
        {
            if(!ModelState.IsValid)
            {
                return View(libro);
            }

            string resultado = _libroServices.actualizarLibro(libro);
            TempData["Mensaje"] = resultado == "Exitoso"
                ? "Libro actualizado correctamente."
                : "No se pudo actualizar el libro.";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar (int id)
        {
            string resultado = _libroServices.eliminarLibro(id);

            TempData["Mensaje"] = resultado == "Exitoso"
                ? "Libro eliminado correctamente."
                : "No se pudo eliminar el libro.";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Buscar(string autor)
        {
            if (string.IsNullOrWhiteSpace(autor))
            {
                return RedirectToAction("Index");
            }

            ViewBag.Autor = autor;
            IEnumerable<Libro> libros = _libroServices.ListarLibrosPorAutor(autor);

            return View(libros);
        }
    }
}
