using DesafioDotNet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioDotNet.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product entity);
        void Update(Product entity, int id);
        void Remove(int id);
    }
}
