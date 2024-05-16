using RegistroAduanero.Entidad;
using System.ComponentModel.DataAnnotations;

namespace RegistroAduaneroDeBarcos.Models
{
    public class BarcoModel
    {
        public int IdBarco { get; set; }
        [StringLength(20), Required]
        public string Nombre { get; set; }
        [Range(1, 200), Required]
        public int Antiguedad { get; set; }
        [Range(1, 500), Required]
        public int TripulacionMaxima { get; set; }
        public int Tasa { get; set; }

        public BarcoModel()
        {
            
        }
        
        public BarcoModel(Barco barcoEntidad)
        {
            IdBarco = barcoEntidad.IdBarco;
            Nombre = barcoEntidad.Nombre;
            Antiguedad = barcoEntidad.Antiguedad;
            TripulacionMaxima = barcoEntidad.TripulacionMaxima;
            Tasa = barcoEntidad.Tasa;
        }



        internal static List<BarcoModel> MapToListModel(List<Barco> barcos)
        {
            return barcos.Select(b => new BarcoModel(b)).ToList();
        }

        internal Barco MapToEntity()
        {
            return new Barco
            {
                IdBarco = IdBarco,
                Nombre = Nombre,
                Antiguedad = Antiguedad,
                TripulacionMaxima = TripulacionMaxima,
                Tasa = Tasa
            };
        }
    }
}
