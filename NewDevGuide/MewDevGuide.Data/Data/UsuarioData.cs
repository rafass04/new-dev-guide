using MewDevGuide.Data.DataBase;
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
            conexaobd.Inserir<UsuarioDto>("usuario", usuario);
            return usuario;
        }

        public UsuarioDto Obter(string id, IConexao conexaobd)
        {
            var dic = new Dictionary<string, object>
            {
                {"_id", id }
            };
            var lista = conexaobd.Obter<UsuarioDto>("usuario", dic);
            return lista.FirstOrDefault();
        }

        public UsuarioDto Atulizar(string id, UsuarioDto usuario, IConexao conexaobd)
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
