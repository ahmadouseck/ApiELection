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

        public ActionResult<Centre> CreateElecteur(Electeur electeur)
        {

            return Ok(ielecteur.AddE(electeur));

        }

        // Mettre a jour un centre
        [HttpPut("{id}")]
        public void UpdateElecteur(int id, Electeur electeur)
        {
            electeur.NumE = id;
            if (ielecteur.Update(id, electeur) != null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // Supprimer un centre
        [HttpDelete("{id}")]
        public async void DeleteElecteur(int id)
        {
            Electeur electeur = await ielecteur.Get(id);
            if (electeur == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            ielecteur.Delete(id);
        }

    }
}
