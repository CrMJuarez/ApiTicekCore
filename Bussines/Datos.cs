
using Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;


namespace Bussines
{
    public class Datos
    {
        //recibe el json 
        public void Update(dynamic jsonParameter)
        {
            
            Models.Result resultTickets = new Models.Result();
            resultTickets.Objects = new List<Object>();
            //deserealiza el json 
            Models.Tickets JsonDeserializado = JsonSerializer.Deserialize<Models.Tickets>(jsonParameter);
            //agrega el json a una lista de objetos con el fin de descomponerlo 
            resultTickets.Objects.Add(JsonDeserializado);
            //se crea un foreach en vcaso de que reciba varios registros 
            foreach (Models.Tickets tickets in resultTickets.Objects)
            {
                var IdTicket = tickets.id;
                var hs_pipeline = tickets.properties.hs_pipeline;
                var hs_ticket_priority = tickets.properties.hs_ticket_priority;
                var subject = tickets.properties.subject;
                var ruta = tickets.properties.ruta;
                var aerolinea = tickets.properties.aerolinea;
                var tipo_de_incidencia = tickets.properties.tipo_de_incidencia;
                var nivel = tickets.properties.nivel;
                var tipo_de_afectacion = tickets.properties.tipo_de_afectacion;
                var reserva = tickets.properties.reserva;
                var numero_de_vuelo_afectado = tickets.properties.numero_de_vuelo_afectado;
                var fecha_de_salida = DateTime.Parse(tickets.properties.fecha_de_salida).ToString("yyyy-MM-dd");
                var numero_de_pasajeros = tickets.properties.numero_de_pasajeros;
                var tipo_de_intervencion = tickets.properties.tipo_de_intervencion;
                var grupo_de_agencia = tickets.properties.grupo_de_agencia;     
                //formato del body 
                var body = "{\"properties\":" + "{\"hs_pipeline\":\""
                    + hs_pipeline
                    + ("\",\"hs_ticket_priority\":\"")
                    + hs_ticket_priority
                    + ("\",\"subject\":\"")
                    + subject
                    + ("\",\"ruta\":\"")
                    + ruta
                    + ("\",\"aerolinea\":\"")
                    + aerolinea
                    + ("\",\"tipo_de_incidencia\":\"")
                    + tipo_de_incidencia
                    + ("\",\"nivel\":\"")
                    + nivel
                    + ("\",\"tipo_de_afectacion\":\"")
                    + tipo_de_afectacion
                    + ("\",\"reserva\":\"")
                    + reserva
                    + ("\",\"numero_de_vuelo_afectado\":\"")
                    + numero_de_vuelo_afectado
                    + ("\",\"fecha_de_salida\":\"")
                    + fecha_de_salida
                    + ("\",\"numero_de_pasajeros\":\"")
                    + numero_de_pasajeros
                    + ("\",\"tipo_de_intervencion\":\"")
                    + tipo_de_intervencion
                    + ("\",\"grupo_de_agencia\":\"")
                    + grupo_de_agencia
                    + "\"" + "}}";

                //url y credencial
                string apiEndPoint = "https://api.hubapi.com/crm/v3/objects/tickets/" + IdTicket;
                string bearerToken = "pat-na1-a0722dd7-5fd1-49fb-bfbd-ab9a65ebc50b";
                var client = new RestClient(apiEndPoint);
                var request = new RestRequest(String.Empty, Method.Patch);
                request.AddHeader("accept", "application/json");
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("authorization", "Bearer " + bearerToken);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                var response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    Console.WriteLine("Se hizo la peticion correctamente");
                    var respuesta = response.Content;
                    Console.WriteLine(respuesta);
                }
                else
                {
                    Console.WriteLine("Ocurrio un error en la peticion");
                    var respuesta = response.ErrorException;
                    Console.WriteLine(respuesta);
                }
            }
        }
    }
}


