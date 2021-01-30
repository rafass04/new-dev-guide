using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewDevGuide.App.Application;
using NewDevGuide.Test.Util;

namespace NewDevGuide.Test
{
    [TestClass]
    public class UsuarioTeste
    {
        [TestMethod]
        public void CriarUsuariosSemEnderecoDeCobranca()
        {   
            var conexao = new MockConexao<DTO.DTO.UsuarioDto>();
            var instancia = new UsuarioApp();
            var usuario = instancia.Criar(new DTO.DTO.UsuarioDto()
            {
                Nome = "Usuario teste",
                Cpf = "000.004.001.12",
                Endereco = new DTO.DTO.EnderecoDto
                {
                    Bairro = "Paraisópolis",
                    Cidade = "São Paulo",
                    Logradouro = "Rua Teste",
                    Numero = 12
                }
            }, conexao);

            var usuarioCriado = instancia.Obter(usuario.Id, conexao);
            Assert.AreEqual(usuario.Endereco.Bairro, usuarioCriado.EnderecoCobranca.Bairro);
            Assert.AreEqual(usuario.Endereco.Cidade, usuarioCriado.EnderecoCobranca.Cidade);
            Assert.AreEqual(usuario.Endereco.Logradouro, usuarioCriado.EnderecoCobranca.Logradouro);
            Assert.AreEqual(usuario.Endereco.Numero, usuarioCriado.EnderecoCobranca.Numero);
        }
    }
}
