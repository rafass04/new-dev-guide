    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using NewDevGuide.App.Application;
    using NewDevGuide.DTO.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewDevGuide.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UsuarioApp _Instance { get; set; }
        public UsuarioController()
        {
            _Instance = new UsuarioApp();
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IList<UsuarioDto> Get()
        {
            var lista = new List<UsuarioDto>();

            var rafa = new UsuarioDto();
            rafa.Cpf = "00000000000";
            rafa.DataNascimento = new DateTime(1998,10,16);
            rafa.Email = "rafa@hotmail.com";
            rafa.Nome = "Rafaela";

            var rafaEndereco = new EnderecoDto();
            rafaEndereco.Bairro = "";
            rafaEndereco.Cep = "";
            rafaEndereco.Cidade = "";
            rafaEndereco.CodCidade = 0;
            rafaEndereco.Complemento = "";
            rafaEndereco.Estado = "";

            rafa.Endereco = rafaEndereco;
            rafa.EnderecoCobranca = rafaEndereco;

            lista.Add(rafa);

            var stefany = new UsuarioDto()
            {
                Cpf = "00000000000",
                DataNascimento = new DateTime(2000, 10, 12),
                Email = "stefany@hotmail.com",
                Nome = "Stefany",
                Endereco = new EnderecoDto()
                {
                    Bairro = "",
                    Cep = "",
                    Cidade = "",
                    CodCidade = 0,
                    Complemento = "",
                    Estado = ""
                }

            };

            lista.Add(stefany);

            return lista;
        }

        /// <summary>
        /// Obtém dados de usuario especifico
        /// </summary>
        /// <param name="id">Informar o id do banco do usuario</param>
        /// <returns>Informação do usuario consultado</returns>
        /// <returns code="500">Mensagem de erro ao consultar o usuario</returns>
        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        public UsuarioDto Get(string id)
        {
            return _Instance.Obter(id);
        }
        
        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult<ResultadoDto<UsuarioDto>> Post([FromBody] UsuarioDto usuario)
        {
            try
            {
                var resultado = _Instance.Criar(usuario);
                var erro = new ErroDto()
                {
                    Codigo = "erro",
                    Mensagem = "Erro ao inserir usuário"
                };

                return new ResultadoDto<UsuarioDto>()
                { 
                    Ok = resultado != null,
                    Dados = resultado,
                    Erro = resultado == null ? erro : null
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultadoDto<UsuarioDto>()
                {
                    Ok = false,
                    Erro = new ErroDto()
                    {
                        Codigo = "Interno",
                        Mensagem = ex.Message
                    }
                });
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public UsuarioDto Put(string id, [FromBody] UsuarioDto usuario)
        {
            return _Instance.Atualizar(id, usuario);
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _Instance.Deletar(id);
        }
    }
}
