using ApiELection.models;

namespace ApiELection.Interfaces
{
    public interface InterfaceCentre
    {
        Task <IEnumerable<Centre>> GetAll();
        Task<Centre> Get(int id);
        Task<Centre> AddC(Centre centre);
        Task Delete(int id);
        Task Update(int id,Centre centre);
    }
}
