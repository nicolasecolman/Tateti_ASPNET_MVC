using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP2.Models;

namespace TP2.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult Guardar(String ganador)
        {
            //Instancio un objeto de la clase Estadisticas
            var oEstadisticas = new Estadisticas();
            
            //Actualizo estadísticas
            oEstadisticas.setEstadisticas(ganador);

            //Devuelvo vista con estadísticas
            /**
            **Nota: podría usar RedirectToAction pero uso una vista asociada al método Guardar 
            **para probar el helper @Html.Partial 
            **/
            return View(oEstadisticas.getEstadisticas());
        }

        public ActionResult Estadisticas()
        {
            //Instancio un objeto de la clase Estadisticas
            var oEstadisticas = new Estadisticas();

            //Obtengo la lista de jugadores con sus respectivas posiciones y se la paso a la vista
            return View(oEstadisticas.getEstadisticas());
        }

        public ActionResult Reiniciar()
        {
            //Instancio un objeto de la clase Estadisticas
            var oEstadisticas = new Estadisticas();

            //Reinicio estadísticas
            oEstadisticas.restartEstadisticas();
            
            /**
            ** Llamo al método Estadisticas para probar una alternativa diferente a 
            ** la sintáxis usada en el método Guardar
            **/
            return RedirectToAction("Estadisticas");
        }
    }
}
