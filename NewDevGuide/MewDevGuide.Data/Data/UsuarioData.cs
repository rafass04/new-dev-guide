using MewDevGuide.Data.DataBase;
using MongoDB.Bson;
using NewDevGuide.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewDevGuide.Data.Data
{
    public class UsuarioData
    {
        public UsuarioDto Criar(UsuarioDto usuario, IConexao conexaobd)
        {
            var usuarioNovo = conexaobd.Inserir<UsuarioDto>("usuario", usuario);
            return usuarioNovo;
        }

        public UsuarioDto Obter(string id, IConexao conexaobd)
        {
            var dic = new Dictionary<string, object>
            {
                {"_id", ObjectId.Parse(id) }
            };
            var lista = conexaobd.Obter<UsuarioDto>("usuario", dic);
            return lista.FirstOrDefault();
        }

        public UsuarioDto Atualizar(string id, UsuarioDto usuario, IConexao conexaobd)
        {
            conexaobd.Atualizar<UsuarioDto>("usuario", usuario, id);
            return usuario;
        }

        public void Deletar(string id, IConexao conexaobd)
        {
            conexaobd.Deletar<UsuarioDto>("usuario", id);
        }
    }
}