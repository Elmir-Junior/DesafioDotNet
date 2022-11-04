using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DesafioDotNet.Infra.Repositories.Interfaces.Base
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity, int id);
        void Remove(int id);
    }
}
