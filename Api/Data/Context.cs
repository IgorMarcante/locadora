using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class Context : DbContext {
        public Context (DbContextOptions options) : base (options) {

        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
        public DbSet<LocacaoFilme> LocacaoesFilmes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}