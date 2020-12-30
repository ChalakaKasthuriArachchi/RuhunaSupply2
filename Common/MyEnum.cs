using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuhunaSupply.Common
{
    public static class MyEnum
    {
        public enum QuatationStatus
        { 
            //pending done wge eawa   
        }
        public enum Faculties
        { 
            Administration,
            Faculty_Of_Science,
            Faculty_Of_Humanities_and_Social_Sciences
        }
        public enum DepartmentsAdmin
        {
            //admin
            Supply_Branch
        }
        public enum DepartmentsSC
        {
            Department_Of_Computer_Science,
            Department_Of_Mathematics
        }
        public enum DepartmentsHSS
        {
            Department_Of_IT
        }
        public enum Tables
        { 

        }
        public enum Involvements
        {
            Submitted
        }

        public enum UserPositions
        {
            Dean,
            Head,
            VC,
            DVC,
            SAB,
            Lecturer,
            Instructor,
            TO,
            Cleark
        }
        public enum UserTypes
        { 
            Internal,Supplier
        }
        public enum BusinessCategories
        {
            Sole_Proprietorship,
            Partnership,
            Limited_Liability_Company,
            Public_Limited_Company,
            Overseas_Company,
            Offshore_Company
        }
        public enum Purposes
        {
            Normal, Fast_Track, Urgent
        }
        public enum PurchaseRequestStatus
        {
            On_Approval, Rejected, 
        }
    }
}
