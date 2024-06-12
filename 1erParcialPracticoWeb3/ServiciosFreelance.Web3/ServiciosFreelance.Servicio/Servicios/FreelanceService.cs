using ServiciosFreelance.Entidades;

namespace ServiciosFreelance.Servicio
{
    public interface IFreelanceService
    {
        public void CrearServicio(Freelance servicios);
        public List<Freelance> ObtenerServicios();

    }
    public class FreelanceService : IFreelanceService
    {
        private static List<Freelance> _servicios = new List<Freelance>();

        public void CrearServicio(Freelance freelance)
        {
            freelance.MontoTotal = freelance.HorasTrabajadas * freelance.ValorHora;
            _servicios.Add(freelance);
        }

        public List<Freelance> ObtenerServicios()
        {
            return _servicios.OrderBy(s => s.NombrePersona).ToList();
        }
    }
}
