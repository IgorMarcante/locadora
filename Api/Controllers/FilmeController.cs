using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Api.Data;
using Dominio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class FilmeController : ControllerBase
    {
        private readonly Context _context;

        public FilmeController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filme>>> GetFilmes()
        {
            //Busca todos os filmes com seus respectivos generos
            return await _context.Filmes.Include(q => q.Genero).ToListAsync();
        }

        //Busca de filme por ID, utilizado no retorno do cadastro do filme
        [HttpGet("{id}")]
        public async Task<ActionResult<Filme>> GetFilme(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);

            if (filme == null)
            {
                return NotFound();
            }

            return filme;
        }

        //Metodo de edição de filme, necessario passar o objeto completo para completar a edição.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilme(int id, Filme filme)
        {
            if (id != filme.Id)
            {
                return BadRequest();
            }

            _context.Entry(filme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //Metodo de cadastro de filme, o retorno é o GetFilme, mostrando as informações que foram cadastradas
        [HttpPost]
        public async Task<ActionResult<Filme>> PostFilme(Filme filme)
        {
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilme", new { id = filme.Id }, filme);
        }

        //Deleta um unico filme
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilme(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);

            if (filme == null)
            {
                return NotFound();
            }
            //Verificação se o Id do filme está sendo usado como chame estrangeira nas tabelas que usam.
            if (FilmeUsed(id))
            {
                return NotFound(new { message = "Esse filme já esta vinculado a uma locação, impossivel apaga-lo." });
            }
            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Deleta uma lista de filme, receber uma string do tipo inteiro, contendo os IDs que seram apagados
        [HttpDelete]
        public async Task<IActionResult> DeleteList([FromQuery] int[] id)
        {
            //Transação caso de algum erro, dar rollback
            using (TransactionScope scope = new TransactionScope())
            {
                //Percorre a lista e apaga o filme com o ID correspondente
                for (int i = 0; i < id.Length; i++)
                {
                    var filme = await _context.Filmes.FindAsync(id[i]);
                    if (filme == null)
                    {
                        return NotFound();
                    }
                    //Verifica se o ID de algum filme está vinculado a algua outra tabela, caso sim, 
                    //retorna a mensagem e realiza o rollback dos filmes ja deletados dessa lista.
                    if (FilmeUsed(id[i]))
                    {
                        return NotFound(new { message = "Existem filmes já vinculado a uma locação, impossivel apaga-lo." });
                    }
                    _context.Filmes.Remove(filme);
                }

                await _context.SaveChangesAsync();
                scope.Complete();

                return NoContent();
            }
        }
        private bool FilmeExists(int id)
        {
            return _context.Filmes.Any(e => e.Id == id);
        }

        //Metodo usado
        private bool FilmeUsed(int id)
        {
            return _context.LocacaoesFilmes.Any(e => e.FilmeId == id);
        }
    }
}
