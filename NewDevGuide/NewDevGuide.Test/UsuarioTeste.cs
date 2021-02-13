using MewDevGuide.Data.DataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NewDevGuide.App.Application;
using NewDevGuide.Test.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewDevGuide.Test
{
    [TestClass]
    public class UsuarioTeste
    {
        private readonly IConexao conexao;
        private DTO.DTO.UsuarioDto createdUser = null;
        private IList<DTO.DTO.UsuarioDto> Usuarios = new List<DTO.DTO.UsuarioDto>();

        public UsuarioTeste()
        {
            var conexaoMock = new Mock<IConexao>();
            conexaoMock.Setup(i => i.Inserir(It.IsAny<string>(), It.IsAny<DTO.DTO.UsuarioDto>()))
                .Callback((string colecao, DTO.DTO.UsuarioDto usuario) =>
                {
                    Usuarios.Add(usuario);
                    createdUser = usuario;
                })
                .Returns(() => createdUser);
            conexaoMock.Setup(i => i.Obter<DTO.DTO.UsuarioDto>(It.IsAny<string>(), It.IsAny<IDictionary<string, object>>()))
                .Returns(Usuarios);
            conexaoMock.Setup(i => i.Atualizar<DTO.DTO.UsuarioDto>(It.IsAny<string>(), It.IsAny<DTO.DTO.UsuarioDto>(), It.IsAny<string>()))
                .Callback((string colecao, DTO.DTO.UsuarioDto usuario, string id) =>
                {
                    var pos = Usuarios.Select((Value, Index) => new { Value, Index }).FirstOrDefault(u => u.Value.Id == id)?.Index;
                    if (pos.HasValue) Usuarios[pos.Value] = usuario;
                })
                .Returns(true);
            conexaoMock.Setup(i => i.Deletar<DTO.DTO.UsuarioDto>(It.IsAny<string>(), It.IsAny<string>()))
                .Callback((string colecao, string id) =>
                {
                    var pos = Usuarios.Select((Value, Index) => new { Value, Index }).FirstOrDefault(u => u.Value.Id == id)?.Index;
                    if (pos.HasValue) Usuarios.RemoveAt(pos.Value);
                })
                .Returns(true);

            conexao = conexaoMock.Object;
        }

        [TestCleanup()]
        public void Cleanup()
        {
            createdUser = null;
            Usuarios = new List<DTO.DTO.UsuarioDto>();
        }

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
            }, conexao);

            var usuarioCriado = instancia.Obter(usuario.Id, conexao);
            Assert.AreEqual(usuario.Endereco.Bairro, usuarioCriado.EnderecoCobranca.Bairro);
            Assert.AreEqual(usuario.Endereco.Cidade, usuarioCriado.EnderecoCobranca.Cidade);
            Assert.AreEqual(usuario.Endereco.Logradouro, usuarioCriado.EnderecoCobranca.Logradouro);
            Assert.AreEqual(usuario.Endereco.Numero, usuarioCriado.EnderecoCobranca.Numero);
        }
    }
}
