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
    public partial class SignUpForm : Form
    {
        private readonly BlogSiteContext _context;
        public SignUpForm(BlogSiteContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                lblErrorMessage.Text = "The username field can't be empty..";
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblErrorMessage.Text = "The password field can't be empty..";
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPasswordAgain.Text))
            {
                lblErrorMessage.Text = "The confirm password field can't be empty..";
                return;
            }

            var existUserName = _context.Users.Where(u => u.UserName == txtUsername.Text).FirstOrDefault();
            if (existUserName != null)
            {
                lblErrorMessage.Text = "The username already exists. Please choose a different username..";
                return;
            }
            if (txtPassword.Text != txtPasswordAgain.Text)
            {
                lblErrorMessage.Text = "The passwords don't match. Please try again..";
                return;
            }
            User user = new User()
            {
                UserName = this.txtUsername.Text,
                Password = this.txtPassword.Text,
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            lblErrorMessage.Text = "The user has been successfully added.";
        }
    }
}
