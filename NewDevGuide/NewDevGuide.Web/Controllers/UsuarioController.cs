    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using NewDevGuide.DTO.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewDevGuide.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
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

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void Post([FromBody] UsuarioDto usuario)
        {
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
