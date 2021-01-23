using MewDevGuide.Data.DataBase;
using Microsoft.AspNetCore.Mvc;
using NewDevGuide.App.Application;
using NewDevGuide.Web.Services;
using NewDevGuide.DTO.DTO;
using System;
using System.Collections.Generic;

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
        public ActionResult<ResultadoDto<IList<UsuarioDto>>> Get([FromServices]IDataBaseService db)
        {
            try
            {
                var resultado = _Instance.ObterLista(db.GetConexao());
                var erro = new ErroDto()
                {
                    Codigo = "erro",
                    Mensagem = "Erro ao obter lista de usuários"
                };

                return new ResultadoDto<IList<UsuarioDto>>()
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

        /// <summary>
        /// Obtém dados de usuario especifico
        /// </summary>
        /// <param name="id">Informar o id do banco do usuario</param>
        /// <returns>Informação do usuario consultado</returns>
        /// <returns code="500">Mensagem de erro ao consultar o usuario</returns>
        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        public ActionResult<ResultadoDto<UsuarioDto>> Get(string id, [FromServices] IDataBaseService db)
        {
            try
            {
                var resultado = _Instance.Obter(id, db.GetConexao());
                var erro = new ErroDto()
                {
                    Codigo = "erro",
                    Mensagem = "Erro ao obter usuários"
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
        
        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult<ResultadoDto<UsuarioDto>> Post([FromBody] UsuarioDto usuario, [FromServices] IDataBaseService db)
        {
            try
            {
                var resultado = _Instance.Criar(usuario, db.GetConexao());
                var erro = new ErroDto()
                {
                    Codigo = "erro",
                    Mensagem = "Erro ao criar usuário"
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
        public ActionResult<ResultadoDto<UsuarioDto>> Put(string id, [FromBody] UsuarioDto usuario, [FromServices] IDataBaseService db)
        {
            try
            {
                var resultado = _Instance.Atualizar(id, usuario, db.GetConexao());
                var erro = new ErroDto()
                {
                    Codigo = "erro",
                    Mensagem = "Erro ao atualizar usuário"
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

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult<ResultadoDto<UsuarioDto>> Delete(string id, [FromServices] IDataBaseService db)
        {
            try
            {
                _Instance.Deletar(id, db.GetConexao());
                var erro = new ErroDto()
                {
                    Codigo = "erro",
                    Mensagem = "Erro ao deletar usuário"
                };

                return new ResultadoDto<UsuarioDto>()
                {
                    Ok = true,
                    Dados = null,
                    Erro = null
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
    }
}
