using Bussines;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using Newtonsoft.Json.Schema;
//using Newtonsoft.Json.Serialization;
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
        //[Route("api/tickets/Patch/{jsonParameter}")]
        [Route("api/tickets/Patch/")]
        public IActionResult Patch(/*int IdTicket,*/ dynamic jsonParameter)
        {
           


            Bussines.Datos datos = new Bussines.Datos();
            datos.Update(jsonParameter);


            if (datos.Update != null)
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
