using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormBlogSite.Context;
using WinFormBlogSite.Entities;

namespace WinFormBlogSite
{
    public partial class LoginForm : Form
    {
        private readonly BlogSiteContext _context;
        public LoginForm(BlogSiteContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void lnlSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUpForm signUp = new SignUpForm(_context);

            signUp.ShowDialog();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = this.txtUsername.Text;
            string password = this.txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblErrorMessage.Text = "Username or password fields can't be empty..";
            }

            var user = _context.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);

            if (user != null)
            {
                MainForm form = new MainForm(_context, user);
                form.ShowDialog();
                this.Hide();
            }
            else
            {
                lblErrorMessage.Text = "Incorrect username or password. Please try again..";
                return;
            }

        }
    }
}
