using System.Net;
using ApiELection.Interfaces;
using ApiELection.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiELection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BureauController : ControllerBase
    {
        private readonly InterfaceBureau ibureau;

        public BureauController(InterfaceBureau ibureau)
        {
            this.ibureau = ibureau;
        }


        //Recuperer tous les bureaux
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bureau>>> GetAllBureau()
        {
            var bureau = await ibureau.GetAll();
            return Ok(bureau);

        }

        // Recuperer un bureau
        [HttpGet("{id}")]
        public async Task<ActionResult<Bureau>> GetBureau(int id)
        {
            Bureau bureau = await ibureau.Get(id);
            if (bureau == null)
            {
                return NotFound();
            }
            return Ok(bureau);
        }

        // Creer un centre
        [HttpPost]

        public ActionResult<Centre> CreateBureau(Bureau bureau)
        {

            return Ok(ibureau.AddB(bureau));

        }

        // Mettre a jour un centre
        [HttpPut("{id}")]
        public void UpdateBureau(int id, Bureau bureau)
        {
            bureau.NumB = id;
            if (ibureau.Update(id, bureau) != null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // Supprimer un centre
        [HttpDelete("{id}")]
        public async void DeleteBureau(int id)
        {
            Bureau bureau = await ibureau.Get(id);
            if (bureau == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            ibureau.Delete(id);
        }
    }
}
