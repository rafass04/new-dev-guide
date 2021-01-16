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
        public UsuarioDto Criar(UsuarioDto usuario)
        {
            using (var conexao = new ConexaoMongoDb().Conectar("Newdevguidedb"))
            {
                return new UsuarioData().Criar(usuario, conexao);
            }
        }

        public UsuarioDto Obter(string id)
        {
            using (var conexao = new ConexaoMongoDb().Conectar("Newdevguidedb"))
            {
                return new UsuarioData().Obter(id, conexao);
            }
        }

        public IList<UsuarioDto> ObterLista()
        {
            using (var conexao = new ConexaoMongoDb().Conectar("Newdevguidedb"))
            {
                return new UsuarioData().ObterLista(conexao);
            }
        }

        public UsuarioDto Atualizar(string id, UsuarioDto usuario)
        {
            using (var conexao = new ConexaoMongoDb().Conectar("Newdevguidedb"))
            {
                return new UsuarioData().Atualizar(id, usuario, conexao);
            }
        }

        public void Deletar(string id)
        {
            using (var conexao = new ConexaoMongoDb().Conectar("Newdevguidedb"))
            {
                new UsuarioData().Deletar(id, conexao);
            }
        }
    }
}
