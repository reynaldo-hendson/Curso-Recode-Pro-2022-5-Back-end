using Agencia.Models;

namespace Agencia.Services
{
    public interface IDestinoService
    {
        //Retorno de lista de destinos.
        Task<IEnumerable<Destino>> GetDestinos();

        //Retorna Destino pelo Id.
        Task<Destino> GetDestino(int id);

        //Retorna destino pelo nome.
        Task<IEnumerable<Destino>> GetDestinosByNome(string nome);
        
        //Criar Destino.
        Task CreateDestino(Destino destino);

        //Update Destino.
        Task UpdateDestino(Destino destino);    

        //Update Destino.
        Task DeleteDestino(Destino destino); 

    }
}
