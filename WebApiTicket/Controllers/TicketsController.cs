using Bussines;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System.Security.Cryptography.Xml;
using System.Text.Json;
//using System.Text.Json.Serialization.Metadata;

namespace WebApiTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        [HttpPatch]
        [Route("api/tickets/Patch/{IdTicket}/{jsonParameter}")]

        public IActionResult Patch(int IdTicket, string jsonParameter)
        {
           
            Bussines.Datos datos = new Bussines.Datos();
            datos.Update(IdTicket, jsonParameter);
          

            if (datos!=null)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
