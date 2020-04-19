using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableMonitoring.Model
{
    public class User
    {
        public string username { get; set; }

        public string password { get; set; }

        public string name { get; set; }
        public string id { get; set; }
        public bool validationCode { get; set; }

        public override bool Equals(object obj)
        {
            User other = obj as User;
            return base.Equals(obj);
        }

        public bool Equals(User other)
        {
            if (other == null)
                return false;

            return this.username == other.username
                && this.password == other.password
                && this.name == other.name &&
                    this.id == other.id;
        }
    }
}
