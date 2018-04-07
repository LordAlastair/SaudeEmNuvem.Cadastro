﻿using System;
using System.Threading.Tasks;
using SaudeEmNuvem.Cadastro.Domain.Exceptions;

namespace SaudeEmNuvem.Cadastro.Infrastructure.Idempotency
{
    public class RequestManager : IRequestManager
    {
        private readonly CadastroContext _context;

        public RequestManager(CadastroContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<bool> ExistAsync(Guid id)
        {
            var request = await _context.
                FindAsync<ClientRequest>(id);

            return request != null;
        }

        public async Task CreateRequestForCommandAsync<T>(Guid id)
        {
            var exists = await ExistAsync(id);

            var request = exists ?
                throw new CadastroDomainException ($"Requisição com {id} já existe") :
                new ClientRequest()
                {
                    Id = id,
                    Name = typeof(T).Name,
                    Time = DateTime.UtcNow
                };

            _context.Add(request);

            await _context.SaveChangesAsync();
        }
    }
}