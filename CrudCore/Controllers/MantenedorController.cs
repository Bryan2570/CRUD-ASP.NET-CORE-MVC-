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
            var rpta = _ContactoDatos.Guardar(oContacto);

            if (rpta)
                return RedirectToAction("Listar");
            else
                return View();
        }

     
    }
}
