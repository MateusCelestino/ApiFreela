using ApiProjetoVagas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjetoCandidato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatoController : ControllerBase
    {
        private List<Candidato> PegarDados()
        {
            // Criar uma lista de Alunos vazia para receber os dados do arquivo
            List<Candidato> listaCandidato = new();

            try
            {
                // Pegar arquivo c:\temp\candidato.json e trazer para a memória
                string dadosArquivo = System.IO.File.ReadAllText("c:\\temp\\candidato.json");
                listaCandidato = System.Text.Json.JsonSerializer.Deserialize<List<Candidato>>(dadosArquivo);
            }
            catch { }

            return listaCandidato;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PegarDados());
        }

        [HttpPost]
        public IActionResult Cadastrar(Candidato vaga)
        {
            List<Candidato> listaCandidato = PegarDados();
            listaCandidato.Add(vaga);
            SalvarArquivo(listaCandidato);
            return Ok(PegarDados());
        }
        [HttpDelete]

        public IActionResult Deletar(int id)
        {
            List<Candidato> listaCandidato = PegarDados();
            SalvarArquivo(listaCandidato.Where(item => item.Id != id).ToList());
            return Ok();
        }
        [HttpPut]
        public IActionResult Editar(Candidato vaga)
        {
            var listaCandidato = PegarDados();
            listaCandidato = listaCandidato.Where((item => item.Id != vaga.Id)).ToList();
            listaCandidato.Add(vaga);
            SalvarArquivo(listaCandidato);
            return Ok();
        }
        private void SalvarArquivo(List<Candidato> listaCandidato)
        {
            string dadosJson = System.Text.Json.JsonSerializer.Serialize(listaCandidato);
            System.IO.File.WriteAllText("c:\\temp\\candidato.json", dadosJson);

        }
    }
}
