using System;
using System.Collections.Generic;
using System.Text;

namespace ZData.EntityFrameworkCore.Contracts.Entities
{
    public interface ISoftDeletableEntity
    {
        bool Deleted { get; set; }
    }
}
