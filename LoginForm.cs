using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TableMonitoring.Presenter;
using TableMonitoring.View;
using TableMonitoring.Repository;
namespace TableMonitoring
{
    public partial class LoginForm : Form,ILoginView
    {
        public string username { get => txtUsername.Text; set => txtUsername.Text = value; }
        public string password { get => txtPassword.Text; set => txtPassword.Text = value; }
        public LoginPresenter Presenter { private get; set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.login();
        }

        public void login()
        {
            Presenter.validateInput();
        }
        public void invalidLogin(string promptMess)
        {
            MessageBox.Show(promptMess);
        }

        public void successLogin()
        {
            var tableRepo = new TableMySqlRepository();
            //var tableView = new TableMonitor();
            var tableView = new TableViewMonitor();
            var tablePresenter = new TablePresenter(tableRepo, tableView);
            tableView.Show();
            this.Hide();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            login();
        }
    }
}
