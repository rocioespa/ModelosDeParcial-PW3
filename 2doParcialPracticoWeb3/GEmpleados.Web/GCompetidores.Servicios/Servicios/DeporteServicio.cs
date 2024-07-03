using GCompetidores.Web.EFF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCompetidores.Servicios.Servicios
{
    public interface IDeporteServicio
    {
        List<Deporte> Listar();
    }
    public class DeporteServicio : IDeporteServicio
    {
        public Pw3GestionCompetidoresContext _ctx;

        public DeporteServicio(Pw3GestionCompetidoresContext ctx)
        {
            _ctx = ctx;
        }

        public List<Deporte> Listar()
        {
           return _ctx.Deportes.OrderBy(d=>d.NombreDeporte).ToList();   
        }
    }
}
