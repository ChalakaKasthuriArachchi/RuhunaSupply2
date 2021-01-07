using cmlMySqlStandard;
using RuhunaSupply.Common;
using RuhunaSupply.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RuhunaSupply.Model
{
    public class Faculty : IndexedObject
    {
        public User GetDean(ApplicationDbContext db)
        {
            return db.Users.FirstOrDefault(u => u.FacultyId == Id &&
                            u.Position == MyEnum.UserPositions.Dean);
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Location { get; set; }
        public double BudgetAllocation { get; set; }
        public double UsedAmount { get; set; }
        public bool IsDeleted { get; set; }

        public int Index => Id;
        //public List<Department> Departments { get; set; }
        
    }
}
