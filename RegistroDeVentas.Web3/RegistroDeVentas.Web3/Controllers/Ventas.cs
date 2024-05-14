using Microsoft.AspNetCore.Mvc;
using RegistroDeVentas.Web3.Models;
using RegistroDeVenta.Servicio.Service;

namespace RegistroDeVentas.Web3.Controllers
{
    public class Ventas : Controller
    {
        /*el readonly indica que el valor del campo o propiedad solo pueda ser
        asigando una vez, ya sea en su declaracion o en el contructor de la clase
        y luego no puede ser cambiado*/
        private readonly IVentaService _ventasService;
        public Ventas(IVentaService ventasService)
        {
            _ventasService = ventasService;
        }
        public IActionResult RegistrarVenta()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegistrarVenta(VentaModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            _ventasService.RegistrarVenta(model.MapToEntity());
            return RedirectToAction("Resultado");
        }

        public IActionResult Resultado()
        {
            var ventas = _ventasService.ObtenerVentas();
            var ventasModelLista = VentaModel.MapToListModel(ventas);
            return View(ventasModelLista);
        }
    }
}
