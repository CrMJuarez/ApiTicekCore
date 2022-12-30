using Bussines;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using RestSharp;
using System.Security.Cryptography.Xml;
using System.Text.Json;



namespace WebApiTicket.Controllers
{
    //Hace referencia al controlador a ejecutar
    [ApiController]
    [Route("ticket")]
    public class TicketsController : ControllerBase
    {
        private readonly ILogger<TicketsController> _logger;
        //verbo
        [HttpPatch]
        //Se coloco solo en caso de que se llegue a enviar un json con muchos registros
        [RequestSizeLimit(100_000_000)]
        [Route("Patch")]
        //se hace el metodo indicandole que el json se colocara dentro del body
        public IActionResult Patch([FromBody] dynamic jsonParameter)
        {
            //Insatancia de la clase datos para enviarle el json
           

            Result result= Datos.Update(jsonParameter);


            
            if (result.Correct == true)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result.Ex);
            }
        }
    }
}
