using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate;
using SaudeEmNuvem.Cadastro.Infrastructure;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SaudeEmNuvem.Cadastro.API.Infrastructure
{
    public class CadastroContextSeed
    {
        public async Task SeedAsync(CadastroContext context, IHostingEnvironment env,
            IOptions<CadastroSettings> settings, ILogger<CadastroContextSeed> logger)
        {
            var policy = CriarPolicy(logger, nameof(CadastroContextSeed));

            await policy.ExecuteAsync(async () =>
            {
                using (context)
                {
                    context.Database.Migrate();

                    if (!context.Cores.Any())
                    {
                        context.Cores.AddRange(Cor.List());

                        await context.SaveChangesAsync();
                    }

                    if (!context.Sexos.Any())
                    {
                        context.Sexos.AddRange(Sexo.List());

                        await context.SaveChangesAsync();
                    }

                    if (!context.TipoSanguineos.Any())
                    {
                        context.TipoSanguineos.AddRange(TipoSanguineo.List());

                        await context.SaveChangesAsync();
                    }

                    if (!context.TipoDocumentos.Any())
                    {
                        context.TipoDocumentos.AddRange(TipoDocumento.List());

                        await context.SaveChangesAsync();
                    }

                    if (!context.TipoTelefones.Any())
                    {
                        context.TipoTelefones.AddRange(TipoTelefone.List());

                        await context.SaveChangesAsync();
                    }

                    await context.SaveChangesAsync();
                }
            });
        }

        #region Importar do arquivo csv
        //private IEnumerable<Cor> BuscarCoresDoArquivo(string contentRootPath, ILogger<CadastroContextSeed> log)
        //{
        //    string csvFile = Path.Combine(contentRootPath, "Setup", "Cor.csv");

        //    if (!File.Exists(csvFile))
        //        return BuscarCoresPredefinidas();

        //    string[] requiredHeaders = { "Cor" };
        //    if (!CabecalhoValido(requiredHeaders, csvFile))
        //        return BuscarCoresPredefinidas();

        //    int id = 1;
        //    return File.ReadAllLines(csvFile)
        //        .Skip(1) // skip header column
        //        .SelectTry(x => CriarCores(x, ref id))
        //        .OnCaughtException(ex => { log.LogError(ex.Message); return null; })
        //        .Where(x => x != null);
        //}

        //private Cor CriarCores(string value, ref int id)
        //{
        //    if (String.IsNullOrEmpty(value))
        //    {
        //        throw new Exception("Cor não pode ser vazia");
        //    }

        //    return new Cor(id++, value.Trim('"').Trim());
        //}

        //private IEnumerable<Cor> BuscarCoresPredefinidas()
        //{
        //    return Cor.List();
        //}

        //private bool CabecalhoValido(string[] requiredHeaders, string csvfile)
        //{
        //    string[] csvheaders = File.ReadLines(csvfile).First().ToLowerInvariant().Split(',');

        //    if (csvheaders.Count() != requiredHeaders.Count())
        //        return false;

        //    foreach (var requiredHeader in requiredHeaders)
        //    {
        //        if (!csvheaders.Contains(requiredHeader))
        //            return false;
        //    }

        //    return true;
        //}
        #endregion

        private Policy CriarPolicy(ILogger<CadastroContextSeed> logger, string prefix, int retries = 3)
        {
            return Policy.Handle<SqlException>().
                WaitAndRetryAsync(
                    retryCount: retries,
                    sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                    onRetry: (exception, timeSpan, retry, ctx) =>
                    {
                        logger.LogTrace($"[{prefix}] Exceção {exception.GetType().Name} com mensagem ${exception.Message} detectado na tentativa {retry} de {retries}");
                    }
                );
        }
    }
}
