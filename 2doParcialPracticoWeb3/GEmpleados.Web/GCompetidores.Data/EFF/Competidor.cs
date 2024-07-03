using System;
using System.Collections.Generic;

namespace GCompetidores.Web.EFF
{
    public partial class Competidor
    {
        public int IdCompetidor { get; set; }
        public string NombreCompetidor { get; set; } = null!;
        public int IdDeporte { get; set; }

        public virtual Deporte IdDeporteNavigation { get; set; } = null!;
    }
}
