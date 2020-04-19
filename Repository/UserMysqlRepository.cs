using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableMonitoring.Model;

namespace TableMonitoring.Repository
{
    public class UserMysqlRepository : IUserRepository
    {
        DataAccessLayer _DAL;

        public bool validatePassword(User identity)
        {
            var ret = identity;
            var _DAL = new DataAccessLayer();
            _DAL.clearParameter();
            _DAL.addParameter("_password", DbType.String, ret.password);
            return (_DAL.checkExists("validateUserPassword"));
        }

        public bool validateUsername(User identity)
        {
            var ret = identity;
            var _DAL = new DataAccessLayer();
            _DAL.clearParameter();
            _DAL.addParameter("_username", DbType.String, ret.username);
            return (_DAL.checkExists("validateUsername"));
        }
    }
}
