using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableMonitoring.Model;
using TableMonitoring.Repository;
using TableMonitoring.View;
namespace TableMonitoring.Presenter
{


    public class LoginPresenter
    {
        private readonly ILoginView _view;
        private readonly IUserRepository _repository;
        private Lazy<User> _user;
        public LoginPresenter(ILoginView view , IUserRepository repository)
        {
            _view = view;
            _view.Presenter = this;
            _repository = repository;
            _user = new Lazy<User>(() =>
            {
                return createForValidationUser();
            });
        }

        public User createForValidationUser()
        {
            var ret = new User();
            ret.username = _view.username;
            ret.password = _view.password;
            return ret;
        }
        public void validateInput()
        {
            _user.Value.username = _view.username;
            _user.Value.password = _view.password;
            if (_repository.validateUsername(_user.Value) == false)
            {
                _view.invalidLogin("Incorrect username!");
                return;
            }
            else if (_repository.validatePassword(_user.Value) == false)
            {
                _view.invalidLogin("Incorrect password!");
                return;
            }
            _view.successLogin();

        }


    }
}
