using Dominio.Models;

namespace Api.Models
{
    public class LocacaoVM
    {
        public Locacao Locacao { get; set; }
        public int[] FilmeId { get; set; }
    }
}