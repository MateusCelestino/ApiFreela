using ApiProjetoFreela.Models;
using ApiProjetoVagas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjetoFreela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private List<Cadastro> PegarDados()
        {
            // Criar uma lista de Alunos vazia para receber os dados do arquivo
            List<Cadastro> listaCadastro = new();

            try
            {
                // Pegar arquivo c:\temp\Cadastro.json e trazer para a memória
                string dadosArquivo = System.IO.File.ReadAllText("c:\\temp\\cadastro.json");
                listaCadastro = System.Text.Json.JsonSerializer.Deserialize<List<Cadastro>>(dadosArquivo);
            }
            catch { }

            return listaCadastro;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PegarDados());
        }

        [HttpPost]
        public IActionResult Cadastrar(Cadastro logar)
        {
            List<Cadastro> listaCadastro = PegarDados();
            listaCadastro.Add(logar);
            SalvarArquivo(listaCadastro);
            return Ok(PegarDados());
        }
        [HttpDelete]

        public IActionResult Deletar(int id)
        {
            List<Cadastro> listaCadastro = PegarDados();
            SalvarArquivo(listaCadastro.Where(item => item.Id != id).ToList());
            return Ok();
        }
        [HttpPut]
        public IActionResult Editar(Cadastro logar)
        {
            var listaCadastro = PegarDados();
            listaCadastro = listaCadastro.Where((item => item.Id != logar.Id)).ToList();
            listaCadastro.Add(logar);
            SalvarArquivo(listaCadastro);
            return Ok();
        }
        private void SalvarArquivo(List<Cadastro> listaCadastro)
        {
            string dadosJson = System.Text.Json.JsonSerializer.Serialize(listaCadastro);
            System.IO.File.WriteAllText("c:\\temp\\cadastro.json", dadosJson);
        }

        [HttpPost("logar")]
        public ActionResult<Cadastro> Logar(Logar dados)

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
