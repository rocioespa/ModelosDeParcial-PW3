using IslaTesoro.Entidades;

namespace IslaTesoro.Logica
{
    public interface ITesoroService
    {
        void Agregar(Tesoro tesoro);
        List<Tesoro> GetAll();
        public Tesoro Get(int id);
        public void Actualizar(Tesoro tesoro);
        public void Eliminar(int id);
    }
    public class TesoroService : ITesoroService
    {
        private Pw3IslaTesoroContext _context;
        public TesoroService(Pw3IslaTesoroContext context) { 
            _context = context;
        }

        public void Agregar(Tesoro tesoro)
        {
            this._context.Tesoros.Add(tesoro);
            this._context.SaveChanges();
        }

        public List<Tesoro> GetAll()
        {
            return this._context.Tesoros.ToList();
        }

        public Tesoro Get(int id)
        {
            return this._context.Tesoros.Find(id);
        }

        public void Actualizar(Tesoro tesoro)
        {
            this._context.Tesoros.Update(tesoro);
            this._context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var tesoro = this.Get(id);
            if (tesoro == null) return;

            this._context.Tesoros.Remove(tesoro);
            this._context.SaveChanges();
        }
    }
}
