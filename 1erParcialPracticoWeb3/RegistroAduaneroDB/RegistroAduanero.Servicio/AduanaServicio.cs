using RegistroAduanero.Entidad;

namespace RegistroAduanero.Servicio
{
    public interface IAduanaService
    {
        void RegistrarBarco(Barco barco);
        List<Barco> ObtenerListadoBarcos();
    }
    public class AduanaServicio : IAduanaService
    {
        private static List<Barco> _barcos = new List<Barco>();
        public List<Barco> ObtenerListadoBarcos()
        {
            return _barcos.OrderBy(b => b.IdBarco).ToList();
        }

        public void RegistrarBarco(Barco barco)
        {
            barco.Tasa = ((int)((barco.Antiguedad * 0.10) + (barco.TripulacionMaxima / 2)));
            barco.IdBarco = _barcos.Count == 0 ? 1 : _barcos.Max(b => b.IdBarco) + 1;
            _barcos.Add(barco);
        }
    }
}
