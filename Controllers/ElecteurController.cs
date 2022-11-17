using System.Net;
using ApiELection.Interfaces;
using ApiELection.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiELection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElecteurController : ControllerBase
    {
        private readonly InterfaceElecteur ielecteur;

        public ElecteurController(InterfaceElecteur ielecteur)
        {
            this.ielecteur = ielecteur;
        }


        //Recuperer tous les Electeurx
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Electeur>>> GetAllElecteur()
        {
            var electeur = await ielecteur.GetAll();
            return Ok(electeur);

        }

        // Recuperer un Electeur
        [HttpGet("{id}")]
        public async Task<ActionResult<Electeur>> GetElecteur(int id)
        {
            Electeur electeur = await ielecteur.Get(id);
            if (electeur == null)
            {
                return NotFound();
            }
            return Ok(electeur);
        }

        // Creer un centre
        [HttpPost]

        public Task<ActionResult<Electeur>> CreateElecteur(Electeur electeur)
        {
            var e = await ielecteur.AddE(electeur);
          
            return Ok(e);

        }

        // Mettre a jour un electeur
        [HttpPut("{id}")]
        public void UpdateElecteur(int id, Electeur electeur)
        {
            var e = await ibureau.Update(id, electeur);
            if (e is null)
                return NotFound();
            return Ok(e);
        }

        // Supprimer un centre
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteElecteur(int id)
        {
             await ielecteur.Delete(id);
            return Ok();
        }

    }
}
