﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public interface IAdminController
    {
        public void CreateAccount();
        public void UpdateAccount();
        public void DeleteAccount();
    }
}
