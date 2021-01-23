using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewDevGuide.App.Application;

namespace NewDevGuide.Test
{
    [TestClass]
    public class UsuarioTeste
    {
        [TestMethod]
        public void CriarUsuariosSemEnderecoDeCobranca()
        {
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
            });
        }
    }
}
