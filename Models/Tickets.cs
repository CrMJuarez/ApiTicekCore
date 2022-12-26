using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{

    public class Tickets
    {
        public string id { get; set; }
        public Properties properties { get; set; }
    }

    public class Properties
    {
        public string hs_pipeline { get; set; }
        public string hs_ticket_priority { get; set; }
        public string subject { get; set; }
        public string ruta { get; set; }
        public string aerolinea { get; set; }
        public string tipo_de_incidencia { get; set; }
        public string nivel { get; set; }
        public string tipo_de_afectacion { get; set; }
        public string reserva { get; set; }
        public string numero_de_vuelo_afectado { get; set; }
        public string fecha_de_salida { get; set; }
        public string numero_de_pasajeros { get; set; }
        public string tipo_de_intervencion { get; set; }
        public string grupo_de_agencia { get; set; }

    }
}
