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

        public async Task<ActionResult<Bureau>> CreateBureau([FromBody] Bureau bureau)
        {
            var b = await ibureau.AddB(bureau);
            return Ok(b);

        }

        // Mettre a jour un centre
        [HttpPut("{id}")]
        public async Task<ActionResult<Bureau>> UpdateBureau(int id, Bureau bureau)
        {
            var b = await ibureau.Update(id, bureau);
            if (b is null)
                return NotFound();
            return Ok(b); 
            
        }

        // Supprimer un centre
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBureau(int id)
        {
            await ibureau.Delete(id);
            return Ok();
        }
    }
}
