using Students_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Management.Interfaces
{
    public interface ILogin
    {
        void Login(string username, string password);
        void OnSuccess(User user);
        void OnFailure();
    }
}
