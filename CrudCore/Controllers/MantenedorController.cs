using Microsoft.AspNetCore.Mvc;

using CrudCore.Datos;
using CrudCore.Models;

namespace CrudCore.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _ContactoDatos =new ContactoDatos();

        public IActionResult Listar()
        {
            var oLista = _ContactoDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //metodo solo devuelve la vista
            return View();
        }

        [HttpPost]
        //Recibe el objeto para guardarlo en la BD  
        public IActionResult Guardar(ContactoModel oContacto)
        {
            //si algun campo esta vacio : false ; y si no : true ==>> validamos campos obligatorios
            if (!ModelState.IsValid)
                return View();

            var rpta = _ContactoDatos.Guardar(oContacto);

            if (rpta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int IdContacto)
        {
            //metodo solo devuelve la vista
            var oContacto = _ContactoDatos.Obtener(IdContacto);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto)
        {
            //si algun campo esta vacio : false ; y si no : true ==>> validamos campos obligatorios
            if (!ModelState.IsValid)
                return View();

            var rpta = _ContactoDatos.Editar(oContacto);

            if (rpta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdContacto)
        {
            //metodo solo devuelve la vista
            var oContacto = _ContactoDatos.Obtener(IdContacto);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModel oContacto)
        {

            var rpta = _ContactoDatos.Eliminar(oContacto.IdContacto);

            if (rpta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
