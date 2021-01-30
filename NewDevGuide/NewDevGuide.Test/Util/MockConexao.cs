using MewDevGuide.Data.DataBase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewDevGuide.Test.Util
{
    public class MockConexao<T> : IConexao
    {
        private IList< KeyValuePair<string, IList<object>>> collections = new List<KeyValuePair<string, IList<object>>>();
        public bool Atualizar<T>(string colecao, T dados, string id)
        {
            try
            {
                var coll = GetCollections(colecao);
                var doc = coll.Value.FirstOrDefault(v => v.GetType().GetProperty("Id").GetValue(v).Equals(id));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IConexao Conectar(string dbName)
        {
            return this;
        }

        public bool Deletar<T>(string colecao, string id)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
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
