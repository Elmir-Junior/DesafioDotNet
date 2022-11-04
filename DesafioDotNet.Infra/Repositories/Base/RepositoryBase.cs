using DesafioDotNet.Infra.Infra;
using DesafioDotNet.Infra.Repositories.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DesafioDotNet.Infra.Repositories.Base
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private MSSQLDB _con;

        public RepositoryBase(MSSQLDB con)
        {
            _con = con;
        }

        public virtual void Add(T entity)
        { }

        public virtual IEnumerable<T> GetAll() => throw new NotImplementedException();

        public virtual T GetById(int id) => throw new NotImplementedException();


        public virtual void Remove(int id)
        { }

        public virtual void Update(T entity, int id)
        { }
    }
}
