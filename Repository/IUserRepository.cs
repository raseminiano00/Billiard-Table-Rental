using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableMonitoring.Model;
namespace TableMonitoring.Repository
{
    public interface IUserRepository
    {
        bool validateUsername(User user);
        bool validatePassword(User user);
           

    }
}
