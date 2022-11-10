
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
            var  centre = await icenter.GetAll();
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

        //Recuperer les centres selon leur lieu
       // [HttpGet]
        //public IEnumerable<Centre> GetCenterByPlace(string lieu)
       // {
        //    return icenter.GetAll().Where(
        //        centre => string.Equals(centre.Lieu, lieu, StringComparison.OrdinalIgnoreCase));
        //}

        // Creer un centre
        [HttpPost]
     
        public ActionResult<Centre> CreateCenter(Centre centre)
        {
            
            return Ok(icenter.AddC(centre));
          
        }

        // Mettre a jour un centre
        [HttpPut("{id}")]
        public void UpdateCenter(int id, Centre centre)
        {
            centre.NumC = id;
            if (icenter.Update(id,centre) != null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // Supprimer un centre
        [HttpDelete("{id}")]
        public async void DeleteCentre(int id)
        {
            Centre centre =await icenter.Get(id);
            if (centre == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            icenter.Delete(id);
        }
    }
}
