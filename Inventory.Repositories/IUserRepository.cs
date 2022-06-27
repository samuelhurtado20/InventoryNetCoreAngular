﻿using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repositories
{
    public interface IUserRepository
    {
       User ValidateUser(string email, string password);
    }
}
