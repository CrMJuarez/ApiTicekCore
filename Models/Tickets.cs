using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Tickets
    {
        public int? Id { get; set; }
        public string Nivel { get; set; }
        public string Tipodeafectacion { get; set; }
        public string Reserva { get; set; }
        public string Aerolinea { get; set; }
        public string Ruta { get; set; }
        public string Vueloafectado { get; set; }
        public string Prioridad { get; set; }
        public string Fechadesalida { get; set; }
        public string Tipodeincidencia { get; set; }
        public string Numerodepasajeros { get; set; }
        public string Tipodeintervencion { get; set; }
        public string Grupodeagencia { get; set; }
        public List<object> tickets { get; set; }
    }
}
