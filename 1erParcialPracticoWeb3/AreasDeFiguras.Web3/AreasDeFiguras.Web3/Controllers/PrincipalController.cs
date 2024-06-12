using AreasDeFiguras.Entidades;
using AreasDeFiguras.Servicios;
using AreasDeFiguras.Web3.Models;
using Microsoft.AspNetCore.Mvc;

namespace AreasDeFiguras.Web3.Controllers
{
    public class PrincipalController : Controller
    {
        public readonly IFigurasService _figuraService;

        public PrincipalController(IFigurasService figuraService)
        {
            _figuraService = figuraService;
        }
        public IActionResult Bienvenido()
        {
            return View();
        }

        public IActionResult Resultados()
        {
            var rectangulos = _figuraService.ObtenerRectangulos();
            var rectangulosListaModel = RectanguloModel.MapearAListaModel(rectangulos);
            return View(rectangulosListaModel);
        }

        public IActionResult CalcularAreaDeFiguras()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalcularAreaDeFiguras(RectanguloModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _figuraService.CalcularArea(model.MapToEntity());
            return RedirectToAction("Resultados");
        }
    }
}
