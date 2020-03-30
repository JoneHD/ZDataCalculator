using System;
using System.Collections.Generic;
using System.Text;
using ZData.EntityFrameworkCore.Contracts.Entities;

namespace ZData.EntityFrameworkCore.Models
{
    public abstract class EntityBase : ISoftDeletableEntity, IEntityId
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool Deleted { get; set; } = false;
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
