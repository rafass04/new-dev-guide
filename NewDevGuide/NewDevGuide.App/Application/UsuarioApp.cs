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
    }
}
