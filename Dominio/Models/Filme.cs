using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Models
{
    public class Filme
    {

        public Filme(){  }

        public Filme(string Nome, DateTime DataCriacao, bool Ativo, int GeneroId){ 
            this.Nome = Nome;
            this.DataCriacao = DataCriacao;
            this.Ativo = Ativo;
            this.GeneroId = GeneroId;
         }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
        public void AtualizaFilme(string Nome, bool Ativo)
        {
            this.Nome = Nome;
            this.Ativo = Ativo;
        }
    }

}