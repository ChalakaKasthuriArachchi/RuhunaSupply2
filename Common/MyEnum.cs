﻿using System;
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
            //faculty set eka and administator eka
        }
        public enum Tables
        { 

        }
        public enum Involvements
        { 

        }

        public enum UserPositions
        {
            Dean,
            Head,
            Lecturer,
            Senior_Lecturer,
            Probationary_Lecturer,
            Instructor,
            Clerk,
            TO,
            VC,
            DVC,
            Bursar,
            Assistant_Bursar,
            Store_Keeper
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
