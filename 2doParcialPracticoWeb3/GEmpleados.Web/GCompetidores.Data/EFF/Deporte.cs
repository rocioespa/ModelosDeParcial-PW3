using System;
using System.Collections.Generic;

namespace GCompetidores.Web.EFF
{
    public partial class Deporte
    {
        public Deporte()
        {
            Competidors = new HashSet<Competidor>();
        }

        public int IdDeporte { get; set; }
        public string NombreDeporte { get; set; } = null!;

        public virtual ICollection<Competidor> Competidors { get; set; }
    }
}
