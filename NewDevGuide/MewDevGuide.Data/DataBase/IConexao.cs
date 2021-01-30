using System;
using System.Collections.Generic;
using System.Text;

namespace MewDevGuide.Data.DataBase
{
    public interface IBaseDoc
    {
        public string Id { get; set; }
    }

    public interface IConexao : IDisposable
    {
        IConexao Conectar(string dbName);
        T Inserir<T>(string colecao, T dados);
        IList<T> Obter<T>(string colecao, IDictionary<string, object> filtro);
        bool Atualizar<T>(string colecao, T dados, string id);
        bool Deletar<T>(string colecao, string id);
    }
}
