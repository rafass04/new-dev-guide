using MewDevGuide.Data.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewDevGuide.Web.Services
{
    public interface IDataBaseService
    {
        IConexao GetConexao();
    }
}
