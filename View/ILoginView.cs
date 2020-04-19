using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableMonitoring.Presenter;
namespace TableMonitoring.View
{
    public interface ILoginView
    {
        string username { get; set; }

        string password { get; set; }

        LoginPresenter Presenter { set; }

        void invalidLogin(string promptMess);

        void successLogin();
    }
}
