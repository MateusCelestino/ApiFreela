namespace ApiProjetoVagas.Models
{
    public class Candidato:Logar
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Experiencia { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public Decimal valor { get; set; }

    }
}
