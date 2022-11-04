using System;

namespace DesafioDotNet.Domain.Models.Base
{
    public class Entity
    {
        public Entity()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
