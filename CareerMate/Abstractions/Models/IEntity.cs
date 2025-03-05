using System;

namespace FileSource.Abstractions.Models
{
    public interface IEntity
    {
        Guid Id { get; set; }

        DateTime CreatedAt { get; set; }

        DateTime? ModifiedAt { get; set; }
    }
}
