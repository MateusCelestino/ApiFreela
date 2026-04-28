using System.ComponentModel.DataAnnotations;

namespace ApiProjetoVagas.Models
{
    public class Candidato : Logar
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        public string Experiencia { get; set; }

        public DateTime DataNascimento { get; set; }

        [Required]
        [RegularExpression(@"^\d{10,11}$",
            ErrorMessage = "Telefone deve conter apenas números (DDD + número)")]
        public string Telefone { get; set; }

        public decimal Valor { get; set; }
    }
}