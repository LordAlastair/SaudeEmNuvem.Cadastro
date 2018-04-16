using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaudeEmNuvem.Cadastro.API.Application.Queries
{
    public interface IPacienteQueries
    {
        Task<dynamic> BuscarPacienteAsync(int id);

        Task<IEnumerable<dynamic>> ListarPacientessAsync();
    }
}
