using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DAL;

namespace Controllers
{
    public interface IAdminController
    {
        public void CreateAccount();
        public void UpdateAccount();
        public void DeleteAccount();
    }
}
