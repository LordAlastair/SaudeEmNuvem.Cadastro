using Microsoft.AspNetCore.Http;
using System;

namespace SaudeEmNuvem.Cadastro.API.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _context; 

        public IdentityService(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public string BuscarIdentidadeDoUsuario()
        {
            return _context.HttpContext.User.FindFirst("sub").Value;
        }
    }
}
