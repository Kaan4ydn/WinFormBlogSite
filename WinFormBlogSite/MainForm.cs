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
    public partial class MainForm : Form
    {
        private readonly BlogSiteContext _context;
        private readonly User _user;
        private readonly string imageDirectory;
        public MainForm(BlogSiteContext context, User user)
        {
            InitializeComponent();
            _context = context;
            _user = user;

            imageDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

            if (!Directory.Exists(imageDirectory))
            {
                Directory.CreateDirectory(imageDirectory);
            }

            LoadPosts();
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string content = rtbContent.Text;
            string imagePath = pbPostPicture.ImageLocation;

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Title field cannot be empty..");
                return;
            }
            if (string.IsNullOrWhiteSpace(content))
            {
                MessageBox.Show("Content field cannot be empty..");
                return;
            }

            string savedImagePath = null;
            if (!string.IsNullOrEmpty(imagePath))
            {
                string extension = Path.GetExtension(imagePath);
                string fileName = Guid.NewGuid().ToString() + extension;
                savedImagePath = Path.Combine(imageDirectory, fileName);
                File.Copy(imagePath, savedImagePath);
            }

            Post post = new Post()
            {
                Title = title,
                ImagePath = savedImagePath,
                Content = content,
                UserId = _user.Id
            };
            _context.Posts.Add(post);
            _context.SaveChanges();
            LoadPosts();
        }

        private void pbContent_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Filter = "Image Files |*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Choose Image"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                pbPostPicture.ImageLocation = fileDialog.FileName;
            }
        }

        private List<Post> GetPosts()
        {
            List<Post> posts = new List<Post>();
            return posts = _context.Posts.OrderByDescending(p => p.Id).ToList();
        }

        private void LoadPosts()
        {
            lfpPosts.Controls.Clear();

            List<Post> posts = GetPosts();

            foreach (Post post in posts)
            {
                Panel postPanel = new Panel()
                {
                    Width = lfpPosts.Width - 20,
                    Height = 120,
                    BorderStyle = BorderStyle.FixedSingle
                };

                PictureBox pictureBox = new PictureBox()
                {
                    Width = 100,
                    Height = 100,
                    Location = new Point(10, 10),
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                if (post.ImagePath != null)
                {
                    pictureBox.Image = Image.FromFile(post.ImagePath);
                }

                postPanel.Controls.Add(pictureBox);

                Label lblTitle = new Label()
                {
                    Text = post.Title,
                    Location = new Point(120, 10),
                    AutoSize = true
                };

                postPanel.Controls.Add(lblTitle);

                Label lblContent = new Label()
                {
                    Text = post.Content,
                    Location = new Point(120, 40),
                    AutoSize = true
                };

                postPanel.Controls.Add(lblContent);

                Label lblUsername = new Label()
                {
                    Text = post.User.UserName,
                    Location = new Point(120, 90),
                    AutoSize = true
                };

                postPanel.Controls.Add(lblUsername);
                lfpPosts.Controls.Add(postPanel);
            }
        }
    }
}
