using ApiELection.Controllers;
using System.Net;
using ApiELection.Interfaces;
using ApiELection.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ApiELection.Services
{


    public class ServiceBureau : InterfaceBureau
    {

        private readonly ApiContext apiContext;
       
        public ServiceBureau(ApiContext context)
        {
            apiContext = context;
        }

        //Fonction d'ajout
        // Il faut ajouter si le centre n'est pas plein au cas contraire l'affecter a un autre centre
        public async Task<Bureau> AddB( Bureau bureau)
        {
           
            apiContext.Bureau.Add(bureau);
            await apiContext.SaveChangesAsync();
            return bureau;

        }

        //Centre centre = new Centre();
        //if(centre.Bureaux.Count <= centre.NombreBureau) {
        // }
        //else
        //{
        //  throw new HttpResponseException("Centre plein");

        // }

        public async Task Delete(int id)
        {
            var req = apiContext.Bureau.FirstOrDefault(req => req.NumB == id);

            if (req is null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            apiContext.Bureau.Remove(req);
            await apiContext.SaveChangesAsync();



        }

        //
        public async Task<Bureau> Get(int id)
        {
            var b = await apiContext.Bureau.FirstOrDefaultAsync(b => b.NumB == id);
            if (b is null) throw new HttpResponseException(HttpStatusCode.NotFound);

            return b;
        }

        //
        public async Task<IEnumerable<Bureau>> GetAll()
        {
            return await apiContext.Bureau.AsTracking().ToListAsync();
        }

        //
        //
        public async Task<Bureau> Update(int id, Bureau bureau)
        {
            if (id != bureau.NumB)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            apiContext.Update(bureau);
            await apiContext.SaveChangesAsync();

            return bureau;
        }
    }
}
