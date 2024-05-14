using ServiciosFreelance.Entidades;
using System.ComponentModel.DataAnnotations;

namespace ServiciosFreelance.Web3.Models
{
    public class FreelanceModel

    {
        [Required]
        public string NombrePersona { set; get; }

        [Range(0, 161), Required]
        public int HorasTrabajadas { set; get; }

        [Range(1000, 10000), Required]
        public int ValorHora { set; get; }

        public int MontoTotal { set; get; }

        public FreelanceModel(){
            }

        public FreelanceModel(Freelance entidad){
            NombrePersona = entidad.NombrePersona;
            HorasTrabajadas = entidad.HorasTrabajadas;
            ValorHora = entidad.ValorHora;
            MontoTotal = entidad.MontoTotal;
        }

        public static List<FreelanceModel> MapearAListaModel(List<Freelance> freelance)
        {
            return freelance.Select(f => new FreelanceModel(f)).ToList();
        }

        internal Freelance MapToEntity()
        {
            return new Freelance
            {
                NombrePersona = NombrePersona,
                HorasTrabajadas = HorasTrabajadas,
                ValorHora = ValorHora,
                MontoTotal = MontoTotal
            };
        }
    }
}
