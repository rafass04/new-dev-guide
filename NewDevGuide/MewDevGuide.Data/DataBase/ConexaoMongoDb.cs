using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MewDevGuide.Data.DataBase
{
    public class ConexaoMongoDb
    {
        private MongoClient dbClient;

        private IMongoDatabase db;

        public void Conectar(string dbName)
        {   
            dbClient = new MongoClient($"mongodb+srv://aplicacaocsharp:0Ro8pluyLDOw6lHI@cluster0.ug65e.mongodb.net/{dbName}?retryWrites=true&w=majority");
            db = dbClient.GetDatabase(dbName);
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

        public IList<T> Obter<T>(string colecao, dynamic filtro)
        {
            try
            {
                var lista = db.GetCollection<T>(colecao).Find(new BsonDocument()).ToList<T>();
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
                var filtro = BsonDocument.Parse("{ _id: \"" + id + "\" }");
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
                var filtro = BsonDocument.Parse("{ _id: \"" + id + "\" }");
                db.GetCollection<T>(colecao).DeleteOne(filtro);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
