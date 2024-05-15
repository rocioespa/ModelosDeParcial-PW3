using AreasDeFiguras.Entidades;
namespace AreasDeFiguras.Servicios
{
    public interface IFigurasService
    {
        List<RectanguloFigura> ObtenerRectangulos();
        void CalcularArea(RectanguloFigura rectangulo);
    }
    public class FigurasService : IFigurasService
    {
        private static List<RectanguloFigura> _ListaCalculo = new();
        public void CalcularArea(RectanguloFigura rect)
        {
            AsignarID(rect);
            rect.areaFigura = rect.baseFigura * rect.alturaFigura ;
            _ListaCalculo.Add(rect);
        }

        public void AsignarID(RectanguloFigura rectangulo)
        {
            rectangulo.Id = _ListaCalculo.Count == 0
                       ? 1 :
                       _ListaCalculo.Max(r => r.Id) + 1;
        }

        public List<RectanguloFigura> ObtenerRectangulos()
        {
           return _ListaCalculo.ToList();
        }
    }
}
