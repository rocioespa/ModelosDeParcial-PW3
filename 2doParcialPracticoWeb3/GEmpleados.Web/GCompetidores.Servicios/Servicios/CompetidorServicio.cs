using GCompetidores.Web.EFF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCompetidores.Servicios.Servicios
{
    public interface ICompetidorServicio
    {
        void crearCompetidor(Competidor c);
        List<Competidor> Listar();
        List<Competidor> ListarPorDeporte(int idDeporte);

    }
    public class CompetidorServicio : ICompetidorServicio
    {
        private Pw3GestionCompetidoresContext _ctx;

        public CompetidorServicio(Pw3GestionCompetidoresContext ctx)
        {
            _ctx = ctx;
        }

        public void crearCompetidor(Competidor c)
        {
            _ctx.Competidors.Add(c);
            _ctx.SaveChanges();
        }

        public List<Competidor> Listar()
        {
           return _ctx.Competidors.ToList();
        }

        public List<Competidor> ListarPorDeporte(int idDeporte)
        {
            return _ctx.Competidors.Where(c=>c.IdDeporte == idDeporte).ToList();
        }
    }
}
