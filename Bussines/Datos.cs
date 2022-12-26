using Microsoft.VisualBasic;
using Models;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using Newtonsoft.Json.Serialization;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace Bussines
{
    public class Datos
    {
        //public void Update(Models.Tickets tickets)
        public void Update(dynamic jsonParameter)
        {



            Models.Result resultTickets = new Models.Result();
            resultTickets.Objects = new List<Object>();
            Models.Tickets JsonDeserializado = JsonSerializer.Deserialize<Models.Tickets>(jsonParameter);
            resultTickets.Objects.Add(JsonDeserializado);




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


                var fecha_de_salida =DateTime.Parse(tickets.properties.fecha_de_salida).ToString("yyyy-MM-dd");
                //DateTime.TryParse(line.LineCancelledDate, out dtResult)
                //DateTime dt = DateTime.MinValue;

                //DateTime.TryParseExact("20071122", "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out dt);
                var numero_de_pasajeros = tickets.properties.numero_de_pasajeros;
                var tipo_de_intervencion = tickets.properties.tipo_de_intervencion;
                var grupo_de_agencia = tickets.properties.grupo_de_agencia;
                //var subs = (hs_pipeline + hs_ticket_priority).ToString();
                //genBooking.LastModifiedDate = DateTime.Parse(booking.LastModifiedDate, null);
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

                //body.ToString();

                string apiEndPoint = "https://api.hubapi.com/crm/v3/objects/tickets/" + IdTicket;
                string bearerToken = "pat-na1-a0722dd7-5fd1-49fb-bfbd-ab9a65ebc50b";

                //string apiEndPoint = System.Configuration.ConfigurationManager.AppSettings["apiEndPoint"+ IdTicket].ToString();
                //string bearerToken = System.Configuration.ConfigurationManager.AppSettings["bearerToken"].ToString();

                //var body = JsonConvert.SerializeObject(jsonParameter);
                var client = new RestClient(apiEndPoint);
                var request = new RestRequest(String.Empty, Method.Patch);
                request.AddHeader("accept", "application/json");
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("authorization", "Bearer " + bearerToken);
                request.AddParameter("application/json", body, ParameterType.RequestBody);

                //request.AddParameter("application/json", "{\"properties\":{\"hs_pipeline\":\"Pipeline de asistencia técnica\",\"hs_ticket_priority\":\"HIGH\",\"subject\":\"DX2VP5_CANCELACIÓN DE VUELO VIVA**\",\"ruta\":\"MEX\",\"aerolinea\":\"VIVA AEROBUS\",\"tipo_de_incidencia\":\"Afectación\"}}", ParameterType.RequestBody);
                //request.AddParameter("application/json", "{\"properties\":{\"hs_pipeline\":\"Pipeline de asistencia técnica\",\"hs_ticket_priority\":\"HIGH\",\"subject\":\"PRUEBA DE AJUSTE DE VUELO\",\"ruta\":\"MEX-GDL\",\"aerolinea\":\"AEROMAR\",\"tipo_de_incidencia\":\"Afectación\",\"nivel\":\"\",\"tipo_de_afectacion\":\"\",\"reserva\":\"\",\"numero_de_vuelo_afectado\":\"\",\"fecha_de_salida\":\"\",\"numero_de_pasajeros\":\"\",\"tipo_de_intervencion\":\"\",\"grupo_de_agencia\":\"\"}}", ParameterType.RequestBody);

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


