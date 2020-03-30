using System;
using System.Collections.Generic;
using System.Text;

namespace ZData.EntityFrameworkCore.Contracts.Entities
{
    public interface INamedEntity
    {
        string Name { get; set; }
    }
}
