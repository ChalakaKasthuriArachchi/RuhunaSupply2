﻿using RuhunaSupply.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuhunaSupply.Services
{
    public interface IAuthenticateService
    {
        string Authenticate(string userName, string password);
    }
}
