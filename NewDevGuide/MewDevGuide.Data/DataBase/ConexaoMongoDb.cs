using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MewDevGuide.Data.DataBase
{
    public class ConexaoMongoDb : IConexao, IDisposable
    {
        private MongoClient dbClient;

        private IMongoDatabase db;

        public IConexao Conectar(string dbName)
        {
            dbClient = new MongoClient(Environment.GetEnvironmentVariable("MONGODB_URL"));
            db = dbClient.GetDatabase(dbName);
            return this;
        }

        public bool Inserir<T>(string colecao, T dados)
        {
            try
            {
                db.GetCollection<T>(colecao).InsertOne(dados);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IList<T> Obter<T>(string colecao, IDictionary<string, object> filtro)
        {
            try
            {
                var filtroDb = new BsonDocument().AddRange(filtro);
                var lista = db.GetCollection<T>(colecao).Find(filtroDb).ToList<T>();
                return lista;
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }

        public bool Atualizar<T>(string colecao, T dados, string id)
        {
            try
            {
                var objectId = ObjectId.Parse(id);
                var filtro = new BsonDocument() { { "_id", objectId } };
                db.GetCollection<T>(colecao).ReplaceOne(filtro, dados);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Deletar<T>(string colecao, string id)
        {
            try
            {
                var objectId = ObjectId.Parse(id);
                var filtro = new BsonDocument() { { "_id", objectId } };
                db.GetCollection<T>(colecao).DeleteOne(filtro);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            //No Mongo não é necessario desconectar
        }


    }
}
