﻿using BlogSystem.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Services.Contracts
{
    public interface IUserService
    {
        User GetById(string id);
    }
}