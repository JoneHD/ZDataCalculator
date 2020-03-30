using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ZData.EntityFrameworkCore.Contracts.Entities;
using ZData.EntityFrameworkCore.Models;

namespace ZData.LoanCalculator.Models.Entities.LoanTypes
{
    [Table("LoanType", Schema = "ZData")]
    public class LoanType : EntityBase, INamedEntity
    {
        public string Name { get; set; }
        [Column(TypeName = "decimal(6,8)")]
        public decimal InterestRate { get; set; }

        public void Update(LoanType loanType)
        {
            if (Id != loanType.Id)
            {
                throw new ArgumentException("Cannot update LoanType with wrong Id");
            }
            Name = loanType.Name;
            InterestRate = loanType.InterestRate;
        }
    }
}
