using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace Bussines
{
    public class Datos
    {
        //public void Update(Models.Tickets tickets)
        public void Update(int IdTicket, string jsonParameter)
        {
         
            if (IdTicket!=null)
            {
                Bussines.PutApi putApi = new Bussines.PutApi();
                putApi.patchApi(IdTicket, jsonParameter);

            }


        }

    }
    
}

//se tiene que poner en lugar de ticekts id el valor de los json
//tickets.Id = IdTicket;
//tickets.Nivel = tickets.Nivel;
//tickets.Tipodeafectacion = tickets.Tipodeafectacion;
//tickets.Reserva = tickets.Reserva;
//tickets.Aerolinea = tickets.Aerolinea;
//tickets.Ruta = tickets.Ruta;
//tickets.Vueloafectado = tickets.Vueloafectado;
//tickets.Prioridad = tickets.Prioridad;
//tickets.Fechadesalida = tickets.Fechadesalida;
//tickets.Tipodeincidencia = tickets.Tipodeincidencia;
//tickets.Numerodepasajeros = tickets.Numerodepasajeros;
//tickets.Tipodeintervencion = tickets.Tipodeintervencion;
//tickets.Grupodeagencia = tickets.Grupodeagencia;