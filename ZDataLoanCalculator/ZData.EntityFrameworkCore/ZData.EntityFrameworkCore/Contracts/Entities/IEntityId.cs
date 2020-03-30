using System;
using System.Collections.Generic;
using System.Text;

namespace ZData.EntityFrameworkCore.Contracts.Entities
{
    public interface IEntityId
    {
        Guid Id { get; set; }
    }
}
