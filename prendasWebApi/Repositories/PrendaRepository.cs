using Microsoft.EntityFrameworkCore;
using prendasWebApi.Models;
using prendasWebApi.Repositories.IRepositories;

namespace prendasWebApi.Repositories
{
    public class PrendaRepository : IPrendaRepository
    {
        private readonly PrendasDbContext _context;

        public PrendaRepository(PrendasDbContext context)
        {
            _context = context;
        }

        public async Task<Prenda> AddPrenda(Prenda prenda)
        {
            _context.Add(prenda);
            await _context.SaveChangesAsync();
            return prenda;
        }

        public async Task<List<Prenda>> GetAllPrendas()
        {
            return await _context.Prendas
                .Include(x => x.IdMarcaNavigation)
                .ToListAsync();
        }

        public async Task<bool> PrendaByColorExiste(string nombre)
        {
            var prenda = await _context.Prendas.FirstOrDefaultAsync(x=> x.Nombre == nombre);
            if (prenda == null)
            {
                return false;
            }
            var existe = await _context.Prendas.AnyAsync(x=> x.Color.Equals(prenda.Color) 
                                                        && x.Nombre.Equals(prenda.Nombre));
            return existe;
        }

        public async Task<Prenda> GetPrendaById(Guid id)
        {
            var prenda = await _context.Prendas
                .Include(x => x.IdMarcaNavigation)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (prenda == null)
            {
                throw new Exception();
            }
            return prenda;
        }
    }
}
