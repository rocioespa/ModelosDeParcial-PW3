using RegistroDeVentas.Entidades;
using System.ComponentModel.DataAnnotations;

namespace RegistroDeVentas.Web3.Models
{
    public class VentaModel
    {

        public int IdVenta { get; set; }
        [StringLength(50), Required]
        public string Cliente { get; set; }
        [Range(1,300), Required]
        public int CantidadVendida { get; set; }
        [Range(10,1000),Required]
        public int PrecioUnitario { get; set; }
        public int TotalVenta { get; set; }

        //Este es un constructor que toma un objeto Venta
        //y asigna sus propiedades correspondientes a las propiedades de VentaModel.
        public VentaModel(Venta entidad)
        {
            IdVenta = entidad.IdVenta;
            Cliente = entidad.Cliente;
            CantidadVendida = entidad.CantidadVendida;
            PrecioUnitario = entidad.PrecioUnitario;
            TotalVenta = entidad.TotalVenta;
        }

        public VentaModel()
        {
            // Constructor sin parámetros
        }

        //Este método toma una lista de objetos Venta y la convierte en una lista de objetos VentaModel.
        //Para cada objeto Venta en la lista de ventas,
        //crea un nuevo objeto VentaModel y lo agrega a la lista resultante.
        public static List<VentaModel> MapToListModel(List<Venta> ventas)
        {
            return ventas.Select(v => new VentaModel(v)).ToList();
        }

        //Este método crea y devuelve un objeto Venta utilizando las propiedades
        //de la instancia actual de VentaModel.
        //Esencialmente, convierte un objeto VentaModel en un objeto Venta
        public Venta MapToEntity() //paso el model a venta
        {
            return new Venta
            {
                IdVenta = IdVenta,
                Cliente = Cliente,
                CantidadVendida = CantidadVendida,
                PrecioUnitario = PrecioUnitario,
                TotalVenta = TotalVenta
            };
        }
    }
}
