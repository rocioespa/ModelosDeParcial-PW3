using IslaTesoro.Entidades;
using IslaTesoro.Logica;
using Microsoft.AspNetCore.Mvc;

namespace IslaTesoro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IslaTesoroController : ControllerBase
    {
        private readonly ITesoroService _tesoroService;

        public IslaTesoroController(ITesoroService tesoroService)
        {
            _tesoroService = tesoroService;
        }

        [HttpGet]
        public List<Tesoro> GetAll()
        {
            return _tesoroService.GetAll();
        }

        [HttpGet("{id}")]
        public Tesoro Get(int id)
        {
            return _tesoroService.Get(id);
            
            /*var response = new TesoroResponseModel
            {
                Id = tesoro.Id,
                ImagenRuta = tesoro.ImagenRuta,
                Nombre = tesoro.Nombre,
                Ubicacion = tesoro.IdUbicacionNavigation?.Id == null ? null : new UbicacionResponseModel { Id = tesoro.IdUbicacionNavigation.Id, Nombre = tesoro.IdUbicacionNavigation.Nombre }
            };

            return Ok(response);*/
        }

        [HttpPost]
        public void Post([FromBody] Tesoro tesoro) {
        _tesoroService.Agregar(tesoro);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Tesoro tesoro)
        {
            tesoro.Id = id;
            _tesoroService.Actualizar(tesoro);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _tesoroService.Eliminar(id);
        }

    }
}
