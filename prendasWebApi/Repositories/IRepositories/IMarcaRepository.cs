

using prendasWebApi.Models;

namespace prendasWebApi.Repositories.IRepositories
{
    public interface IMarcaRepository
    {
        Task<List<Marca>> GetAllMarcas();
    }
}
