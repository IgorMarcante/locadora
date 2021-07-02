using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Services;
using Dominio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly Context _context;

        public AutenticacaoController(Context context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult<dynamic>> Autenticar([FromBody]Usuario user)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(q => q.Login.ToUpper() == user.Login.ToUpper() && q.Senha == user.Senha);


            // Verifica se o usuário existe
            if (usuario == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(usuario);

            // Oculta a senha
            usuario.Senha = "";

            // Retorna os dados
            return new
            {
                user = usuario,
                token = token
            };
        }


    }
}
