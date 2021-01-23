using MewDevGuide.Data.DataBase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewDevGuide.Test.Util
{
    public class MockConexao : IConexao
    {
        private IList< KeyValuePair<string, IList<object>>> collections = new List<KeyValuePair<string, IList<object>>>();
        public bool Atualizar<T>(string colecao, T dados, string id)
        {
            throw new NotImplementedException();
        }

        public IConexao Conectar(string dbName)
        {
            throw new NotImplementedException();
        }

        public bool Deletar<T>(string colecao, string id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T Inserir<T>(string colecao, T dados)
        {
            var coll = GetCollections(colecao);
            coll.Value.Add(dados);
            return dados;
        }

        public IList<T> Obter<T>(string colecao, IDictionary<string, object> filtro)
        {
            var coll = GetCollections(colecao);
            return (IList<T>)coll.Value;
        }
        private KeyValuePair<string, IList<object>> GetCollections(string colecao)
        {
            var coll = collections.FirstOrDefault(coll => coll.Key == colecao);
            if (coll.Equals(default(KeyValuePair<string, IList<object>>)))
            {
                var lista = new List<object>();
                coll = new KeyValuePair<string, IList<object>>(colecao, lista);
                collections.Add(coll);
            }
            return coll;
        }
    }
}
