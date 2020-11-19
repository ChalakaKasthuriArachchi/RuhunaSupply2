using cmlMySqlStandard;
using Microsoft.EntityFrameworkCore;
using RuhunaSupply.Data;
using RuhunaSupply.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuhunaSupply.Common
{
    public static class Cache
    {
        public static IndexedList<Category1> Category1s { get; set; }
        public static IndexedList<Category2> Category2s { get; set; }
        public static IndexedList<Category3> Category3s { get; set; }
        public static IndexedList<Department> Department { get; set; }
        public static IndexedList<Faculty> Faculty { get; set; }
        public static IndexedList<Item> Item { get; set; }
        public static IndexedList<Specification> Specification { get; set; }
        public static IndexedList<SpecificationCategory> SpecificationCategory { get; set; }

        public static bool RefreshCache(ApplicationDbContext db)
        {
            return false;
            //Category1s = IndexedList.Parse<Category1>(db.Category1s.ToArray());
            //Category2s = IndexedList.Parse<Category2>(db.Category2s.
            //     Include(cat => cat.ParentCategory).ToArray());
            //Category3s = IndexedList.Parse<Category3>(db.Category3s.
            //    Include(cat => cat.ParentCategory).
            //    Include(cat => cat.GPCategory).ToArray());
            //Department = IndexedList.Parse<Department>(db.Departments.
            //    Include(dep => dep.Faculty).ToArray());
            //Faculty = IndexedList.Parse<Faculty>(db.Faculties.ToArray());
            //Item = IndexedList.Parse<Item>(db.Items.
            //    Include(item => item.Category1).
            //    Include(item => item.Category2).
            //    Include(item => item.Category3).ToArray());
            //Specification = IndexedList.Parse<Specification>(db.Specification.ToArray());
            //SpecificationCategory = IndexedList.Parse<SpecificationCategory>
            //    (db.SpecificationCategories.ToArray());
        }
    }
}
