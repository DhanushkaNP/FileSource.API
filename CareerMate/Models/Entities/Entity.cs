using FileSource.Abstractions.Models;
using System;

namespace FileSource.Models.Entities
{
    public class Entity : IEntity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }
    }
}
