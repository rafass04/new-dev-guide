using MewDevGuide.Data.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewDevGuide.Web.Services
{
    public class MongoDbService : IDataBaseService
    {
        private readonly IConexao _conexao;
        public MongoDbService()
        {
            _conexao = new ConexaoMongoDb().Conectar("Newdevguidedb");
        }
        public IConexao GetConexao()
        {
            return _conexao;
        }
    }
}
