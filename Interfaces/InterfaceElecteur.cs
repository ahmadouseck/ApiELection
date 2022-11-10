using ApiELection.models;
using System.Collections.Generic;

namespace ApiELection.Interfaces
{
    public interface InterfaceElecteur
    {
        //recuperer tous les electeurs
        Task<IEnumerable<Electeur>> GetAll();

        //ajouter un electeur
        Task<Electeur> AddE(Electeur electeur);

        //Recuperer un electeur
        Task<Electeur> Get(int id);

        //Mettre a jour un electeur
        Task Update(int id, Electeur electeur);

        //supprimer un electeur
        Task Delete(int id);


    }
}
