using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaudeEmNuvem.Cadastro.API.Application.Queries
{
    public interface IPacienteQueries
    {
        Task<dynamic> GetPacienteAsync(int id);

        Task<IEnumerable<dynamic>> GetPacientesAsync();
    }
}
