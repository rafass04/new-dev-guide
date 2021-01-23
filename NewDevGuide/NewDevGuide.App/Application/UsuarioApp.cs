using MewDevGuide.Data.DataBase;
using NewDevGuide.Data.Data;
using NewDevGuide.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewDevGuide.App.Application
{
    public class UsuarioApp
    {
        public UsuarioDto Criar(UsuarioDto usuario, IConexao conexao)
        {
            if (usuario.EnderecoCobranca == null)
            {
                usuario.EnderecoCobranca = usuario.Endereco;
            }
            return new UsuarioData().Criar(usuario, conexao);
        }

        public UsuarioDto Obter(string id, IConexao conexao)
        {
            return new UsuarioData().Obter(id, conexao);
        }

        public IList<UsuarioDto> ObterLista(IConexao conexao)
        {
            return new UsuarioData().ObterLista(conexao);
        }

        public UsuarioDto Atualizar(string id, UsuarioDto usuario, IConexao conexao)
        {
            return new UsuarioData().Atualizar(id, usuario, conexao);
        }

        public void Deletar(string id, IConexao conexao)
        {
            new UsuarioData().Deletar(id, conexao);
        }
    }
}
