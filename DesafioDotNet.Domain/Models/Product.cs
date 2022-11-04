using DesafioDotNet.Domain.Models.Base;

namespace DesafioDotNet.Domain.Models
{
    public class Product:Entity
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Brand { get; set; }
    }
}
