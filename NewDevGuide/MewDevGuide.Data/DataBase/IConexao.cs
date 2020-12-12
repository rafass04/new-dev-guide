using System;
using System.Collections.Generic;
using System.Text;

namespace MewDevGuide.Data.DataBase
{
    public interface IConexao
    {
        void Conectar(string dbName);
        bool Inserir<T>(string colecao, T dados);
        IList<T> Obter<T>(string colecao, dynamic filtro);
        bool Atualizar<T>(string colecao, T dados, string id);
        bool Deletar<T>(string colecao, string id);
    }
}
