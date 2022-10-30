using Agencia.Context;
using Agencia.Models;
using Microsoft.EntityFrameworkCore;

namespace Agencia.Services
{
    public class DestinoService : IDestinoService
    {
        private readonly AppDbContext _context;

        public DestinoService(AppDbContext context)
        {
            _context = context;
        }

        //Retorna todos os destinos.
        public async Task<IEnumerable<Destino>> GetDestinos()
        {
            try
            {
                return await _context.destino.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        //Retorna o destino por nome, se em banco retorna todos.
        public async Task<IEnumerable<Destino>> GetDestinosByNome(string nome)
        {
            IEnumerable<Destino> destinos;
            if (!string.IsNullOrWhiteSpace(nome))
            {
                destinos = await _context.destino.Where(n => n.CidadeNome.Contains(nome)).ToListAsync();
            }
            else
            {
                destinos = await GetDestinos();
            }
            return destinos;
        }

        //Retorno pelo Id.
        public async Task<Destino> GetDestino(int id)
        {
            var destino = await _context.destino.FindAsync(id);
            return destino;
        }
        
        //Cria.
        public async Task CreateDestino(Destino destino)
        {
            _context.destino.Add(destino);
            await _context.SaveChangesAsync();
        }

        //Atualizar.
        public async Task UpdateDestino(Destino destino)
        {
            _context.Entry(destino).State = EntityState.Modified;
            await _context.SaveChangesAsync();  
        }

        //Apagar.
        public async Task DeleteDestino(Destino destino)
        {
            _context.destino.Remove(destino);
            await _context.SaveChangesAsync();
        }
    }
}
