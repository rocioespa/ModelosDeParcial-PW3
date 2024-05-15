using AreasDeFiguras.Entidades;

namespace AreasDeFiguras.Web3.Models
{
    public class RectanguloModel : FiguraModel
    {
        public RectanguloModel() { }

        public RectanguloModel(RectanguloFigura rectangulo) {
            Id = rectangulo.Id;
            baseFigura = rectangulo.baseFigura;
            alturaFigura = rectangulo.alturaFigura;
            areaFigura = rectangulo.areaFigura;
        }


        internal static object MapearAListaModel(List<RectanguloFigura> rectangulos)
        {
            return rectangulos.Select(r => new RectanguloModel(r)).ToList();
        }

        internal RectanguloFigura MapToEntity()
        {
            return new RectanguloFigura
            {
                Id = Id,
                baseFigura = baseFigura,
                alturaFigura = alturaFigura,
                areaFigura = areaFigura
            };
        }
    }
}
