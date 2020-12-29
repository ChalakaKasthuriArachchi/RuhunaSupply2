//using cmlMySqlStandard;
using cmlMySqlStandard;
using Microsoft.EntityFrameworkCore;
using RuhunaSupply.Data;
using RuhunaSupply.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuhunaSupply.Common
{
    public static class Cache
    {
        private static IndexedList<Specification> Specification { get; set; }
        //public static bool RefreshCache(ApplicationDbContext db)
        //{
        //    return false;
        //    //Category1s = IndexedList.Parse<Category1>(db.Category1s.ToArray());
        //    //Category2s = IndexedList.Parse<Category2>(db.Category2s.
        //    //     Include(cat => cat.ParentCategory).ToArray());
        //    //Category3s = IndexedList.Parse<Category3>(db.Category3s.
        //    //    Include(cat => cat.ParentCategory).
        //    //    Include(cat => cat.GPCategory).ToArray());
        //    //Department = IndexedList.Parse<Department>(db.Departments.
        //    //    Include(dep => dep.Faculty).ToArray());
        //    //Faculty = IndexedList.Parse<Faculty>(db.Faculties.ToArray());
        //    //Item = IndexedList.Parse<Item>(db.Items.
        //    //    Include(item => item.Category1).
        //    //    Include(item => item.Category2).
        //    //    Include(item => item.Category3).ToArray());
        //    //Specification = IndexedList.Parse<Specification>(db.Specification.ToArray());
        //    //SpecificationCategory = IndexedList.Parse<SpecificationCategory>
        //    //    (db.SpecificationCategories.ToArray());
        //}
        #region Category 1
        private static IndexedList<Category1> Category1s { get; set; } =
            new IndexedList<Category1>(1);
        public static Category1 GetCategory1(int id,bool notNull)
        {
            lock (Category1s)
            {
                Category1 cat = Category1s[id];
                if (cat != null)
                    return cat;
                if (notNull)
                    return new Category1() { Id = -1 ,Name = "(Not Found)" };
                return cat;
            }
        }
        public static void RefreshCategory1(ApplicationDbContext db)
        {
            lock (Category1s)
            {
                Category1[] ary = db.Category1s.ToArray();
                if (ary.Length > 0)
                {
                    int limit = ary[ary.Length - 1].Id + 1;
                    Category1s = IndexedList.Parse(ary, limit);
                }
            }
        }
        #endregion

        #region Category 2 
        private static IndexedList<Category2> Category2s { get; set; }
            = new IndexedList<Category2>(1);
        public static Category2 GetCategory2(int id, bool notNull)
        {
            lock (Category2s)
            {
                Category2 cat = Category2s[id];
                if (cat != null)
                    return cat;
                if (notNull)
                    return new Category2() { Id = -1, Name = "(Not Found)" };
                return cat;
            }
        }
        public static void RefreshCategory2(ApplicationDbContext db)
        {
            lock (Category2s)
            {
                Category2[] ary = db.Category2s.ToArray();
                if (ary.Length > 0)
                {
                    int limit = ary[ary.Length - 1].Id + 1;
                    Category2s = IndexedList.Parse(ary, limit);
                }
            }
        }
        #endregion

        #region Category 3
        private static IndexedList<Category3> Category3s { get; set; }
            = new IndexedList<Category3>(1);
        public static Category3 GetCategory3(int id, bool notNull)
        {
            lock (Category3s)
            {
                Category3 cat = Category3s[id];
                if (cat != null)
                    return cat;
                if (notNull)
                    return new Category3() { Id = -1, Name = "(Not Found)" };
                return cat;
            }
        }
        public static void RefreshCategory3(ApplicationDbContext db)
        {
            lock (Category3s)
            {
                Category3[] ary = db.Category3s.ToArray();
                if (ary.Length > 0)
                {
                    int limit = ary[ary.Length - 1].Id + 1;
                    Category3s = IndexedList.Parse(ary, limit);
                }
            }
        }
        #endregion

        #region Faculty
        private static IndexedList<Faculty> Faculties { get; set; }
            = new IndexedList<Faculty>(1);
        public static Faculty GetFaculty(int id, bool notNull)
        {
            lock (Faculties)
            {
                Faculty cat = Faculties[id];
                if (cat != null)
                    return cat;
                if (notNull)
                    return new Faculty() { Id = -1, Name = "-" };
                return cat;
            }
        }
        public static void RefreshFaculties(ApplicationDbContext db)
        {
            lock (Faculties)
            {
                Faculty[] ary = db.Faculties.ToArray();
                if (ary.Length > 0)
                {
                    int limit = ary[ary.Length - 1].Id + 1;
                    Faculties = IndexedList.Parse(ary, limit);
                }
            }
        }
        #endregion

        #region Department
        private static IndexedList<Department> Departments { get; set; }
            = new IndexedList<Department>(1);
        public static Department GetDepartment(int id, bool notNull)
        {
            lock (Departments)
            {
                Department cat = Departments[id];
                if (cat != null)
                    return cat;
                if (notNull)
                    return new Department() { Id = -1, Name = "-" };
                return cat;
            }
        }
        public static void RefreshDepartments(ApplicationDbContext db)
        {
            lock (Departments)
            {
                Department[] ary = db.Departments.ToArray();
                if (ary.Length > 0)
                {
                    int limit = ary[ary.Length - 1].Id + 1;
                    Departments = IndexedList.Parse(ary, limit);
                }
            }
        }
        #endregion

        #region User
        public static IndexedList<User> Users { get; set; }
            = new IndexedList<User>(1);
        public static User[] GetUsers(ApplicationDbContext db, Department department, MyEnum.UserPositions position)
        {
            return db.Users.Where(u => u.DepartmentId == department.Id && u.Position == position).ToArray();
        }
        public static User[] GetUsers(ApplicationDbContext db, Faculty department, MyEnum.UserPositions position)
        {
            return db.Users.Where(u => u.DepartmentId == department.Id && u.Position == position).ToArray();
        }
        public static User GetUser(int id, bool notNull)
        {
            lock (Users)
            {
                User user = Users[id];
                if (user == null)
                    if (notNull)
                        return new User() { ShortName = "(Not Found)", Id = -1 };
                    else
                        return null;
                if (user.Merged == null)
                    return user;
                User mUser = user.Merged;
                StringBuilder permissionList = new StringBuilder(user.PermissionList.Length);
                for (int i = 0; i < user.PermissionList.Length; i++)
                {
                    permissionList.Append(
                        (user.PermissionList[i] == '1' || mUser.PermissionList[i] == '1')
                         ? "1" : "0");
                }
                return mUser;
            }
        }
        public static void RefreshUsers(ApplicationDbContext db)
        {
            lock (Users)
            {
                User[] ary = db.Users.ToArray();
                if (ary.Length > 0)
                {
                    int limit = ary[ary.Length - 1].Id + 1;
                    Users = IndexedList.Parse(ary, limit);
                }
            }
        }
        #endregion

        #region UserAccount
        public static IndexedList<UserAccount> UserAccounts { get; set; }
            = new IndexedList<UserAccount>(1);
        public static UserAccount GetUserUserAccount(int id, bool notNull)
        {
            lock (UserAccounts)
            {
                UserAccount user = UserAccounts[id];
                if (user == null)
                    if (notNull)
                        return new UserAccount() { ShortName = "(Not Found)", Id = -1 };
                    else
                        return null;
                return user;
            }
        }
        public static void RefreshUserAccounts(ApplicationDbContext db)
        {
            lock (UserAccounts)
            {
                UserAccount[] ary = db.UserAccounts.ToArray();
                if (ary.Length > 0)
                {
                    int limit = ary[ary.Length - 1].Id + 1;
                    UserAccounts = IndexedList.Parse(ary, limit);
                }
            }
        }
        #endregion

        #region Items
        private static IndexedList<Item> Items { get; set; }
            = new IndexedList<Item>(1);
        public static Item GetItem(int id, bool notNull)
        {
            lock (Items)
            {
                Item cat = Items[id];
                if (cat != null)
                    return cat;
                if (notNull)
                    return new Item() { Id = -1, Name = "(Not Found)" };
                return cat;
            }
        }
        public static void RefreshItems(ApplicationDbContext db)
        {
            lock (Items)
            {
                Item[] ary = db.Items.ToArray();
                if (ary.Length > 0)
                {
                    int limit = ary[ary.Length - 1].Id + 1;
                    Items = IndexedList.Parse(ary, limit);
                }
            }
        }
        #endregion

        #region Specification Category
        private static IndexedList<SpecificationCategory> SpecificationCategories { get; set; } 
            = new IndexedList<SpecificationCategory>(1);
        public static SpecificationCategory GetSpecificationCategory(int id, bool notNull)
        {
            lock (Items)
            {
                SpecificationCategory cat = SpecificationCategories[id];
                if (cat != null)
                    return cat;
                if (notNull)
                    return new SpecificationCategory() { Id = -1, Title = "(Not Found)" };
                return cat;
            }
        }
        public static void RefreshSpecificationCategories(ApplicationDbContext db)
        {
            lock (Items)
            {
                SpecificationCategory[] ary = db.SpecificationCategories.ToArray();
                if (ary.Length > 0)
                {
                    int limit = ary[ary.Length - 1].Id + 1;
                    SpecificationCategories = IndexedList.Parse(ary, limit);
                }
            }
        }
        #endregion

        #region Common
        public static void RefreshCache(ApplicationDbContext db)
        {
            RefreshCategory1(db);
            RefreshCategory2(db);
            RefreshCategory3(db);
            RefreshFaculties(db);
            RefreshDepartments(db);
            RefreshUsers(db);
            RefreshItems(db);
            RefreshSpecificationCategories(db);
        }
        #endregion
    }
}
