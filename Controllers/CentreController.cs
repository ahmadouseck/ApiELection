
using System.Net;
using ApiELection.Interfaces;
using ApiELection.models;
using ApiELection.Services;
using Microsoft.AspNetCore.Mvc;
namespace ApiELection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentreController : ControllerBase
    {

        //static readonly ServiceCentre serviceCentre = new ServiceCentre();
        private readonly InterfaceCentre icenter;

        public CentreController(InterfaceCentre centreService)
        {
            icenter = centreService;
        }


        //Recuperer tous les centres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Centre>>> GetAllCenter()
        {
            var centre = await icenter.GetAll();
            return Ok(centre);

        }


        // Recuperer un centre
        [HttpGet("{id}")]
        public async Task<ActionResult<Centre>> GetCenter(int id)
        {
            Centre centre = await icenter.Get(id);
            if (centre == null)
            {
                return NotFound();
            }
            return Ok(centre);
        }

        /*
        //Recuperer les centres selon leur lieu
        [HttpGet("lieu/{Lieu}")]
        public IEnumerable<Centre> GetCenterByPlace(string lieu)
         {
            return icenter.GetCentre().Where(
               centre => string.Equals(centre.Lieu, lieu, StringComparison.OrdinalIgnoreCase));
        }*/

        // Creer un centre
        [HttpPost]
        public async Task<ActionResult<Centre>> CreateCenter(Centre centre)
        {
            var c= await icenter.AddC(centre);

            return Ok(c);
        }

        // Mettre a jour un centre
        [HttpPut("{id}")]
        public async Task<ActionResult<Centre>> UpdateCenter(int id, [FromBody] Centre centre)
        {

            var c = await icenter.Update(id, centre);
            if (c is null)
                return NotFound();
            return Ok(c);
        }

        // Supprimer un centre
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCentre(int id)
        {
            await icenter.Delete(id);
            return Ok();

        }
    }
}
