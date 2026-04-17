using ApiProjetoVagas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjetocandidato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private List<Candidato> PegarDados()
        {
            // Criar uma lista de Alunos vazia para receber os dados do arquivo
            List<Candidato> listacandidato = new();

            try
            {
                // Pegar arquivo c:\temp\alunos.json e trazer para a memória
                string dadosArquivo = System.IO.File.ReadAllText("c:\\temp\\candidato.json");
                listacandidato = System.Text.Json.JsonSerializer.Deserialize<List<Candidato>>(dadosArquivo);
            }
            catch { }

            return listacandidato;
        }
        [HttpPost]
        public ActionResult<Logar> Logar(Logar dados)

        {
            var listaUsuario = PegarDados();
            var usuario = listaUsuario.Where(item => item.Email == dados.Email && item.Senha == dados.Senha).FirstOrDefault();
            if (usuario != null)
            {
                return Ok(usuario);
            }
            return Unauthorized();
        }
    }
}
