using GCompetidores.Servicios.Servicios;
using GCompetidores.Web.EFF;
using Microsoft.AspNetCore.Mvc;

namespace GCompetidores.Web.Controllers
{
    public class CompetidorController : Controller
    {
        public ICompetidorServicio _competidorServicio;
        public IDeporteServicio _deporteServicio;

        public CompetidorController(ICompetidorServicio competidorServicio, IDeporteServicio deporteServicio)
        {
            _competidorServicio = competidorServicio;
            _deporteServicio = deporteServicio;
        }

        public IActionResult Index(int? idDeporte)
        {
            ViewBag.Deportes = _deporteServicio.Listar();
            ViewBag.IdDeporteEligido = idDeporte;

            if (idDeporte.HasValue)
            {
                var competidores = _competidorServicio.ListarPorDeporte(idDeporte.Value);
                return View(competidores);
            }
            else
            {
                var competidores = _competidorServicio.Listar();
                return View(competidores);
            }
            
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Deportes = _deporteServicio.Listar();
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Competidor competidor)
        {
            ViewBag.Deportes = _deporteServicio.Listar();
            _competidorServicio.crearCompetidor(competidor);
            return RedirectToAction("Index");
        }
    }
}
