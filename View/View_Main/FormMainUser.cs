﻿using Quan_ly_thu_vien_phim.Model;
using Quan_ly_thu_vien_phim.View.View_Container;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_thu_vien_phim.View.View_Main
{
    public partial class FormMainUser : Form
    {
        private Form activeForm;
        private FormFavourite formFavourite;
        private TrangUser trangUser;
        private User_model user;
        public FormMainUser()
        {
            InitializeComponent();
            this.Size = new Size(1250, 800);
            pnlHeader.Size = new Size(1250, 40);
            pnlMenu.Size = new Size(250, 760);
            formFavourite = new FormFavourite(this);
            trangUser = new TrangUser();
        }

        public void OpenChidForm(Form childForm, object btnSender)
        {

            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            Panel scrollablePanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(scrollablePanel);
            scrollablePanel.Controls.Add(childForm);
            childForm.Show();
        }
        private void lbExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void lbMinimum_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCaNhan_Click(object sender, EventArgs e)
        {
            OpenChidForm(new View_Container.TrangUser(),sender);
        }

        private void btnFavourite_Click(object sender, EventArgs e)
        {
            OpenChidForm(new View_Container.FormFavourite(this), sender);
            formFavourite.ShowData();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenChidForm(new View_Container.FormTrangChu(), sender);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FormLoginSignup formLoginSignup = new FormLoginSignup();
            this.Hide();
            formLoginSignup.ShowDialog();
            this.Close();
        }
        public FormFavourite GetFavourite()
        {
            if (formFavourite == null)
            {
                formFavourite = new FormFavourite(this);
            }
            return formFavourite;
        }
        public TrangUser getCaNhan()
        {
            return trangUser;
        }
        public void setuserModel(User_model user)
        {
            this.user = user;
        }
    }
}
