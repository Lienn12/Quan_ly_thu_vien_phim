﻿using Quan_ly_thu_vien_phim.View.View_Container;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_thu_vien_phim.View
{
    public partial class FormMain : Form
    {
        private SuaPhim suaPhim ;
        private XemChiTiet xemChiTiet;
        private Form activeForm;
        public FormMain()
        {
            suaPhim = new SuaPhim(this);
            xemChiTiet = new XemChiTiet(this);
            InitializeComponent();
            lbMinimum.Click += btnMinimum_Click;
            lbExit.Click += btnExit_Click;
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenChidForm(new View_Container.FormTrangChu(), sender);
        }

        private void btnFilm_Click(object sender, EventArgs e)
        {
            OpenChidForm(new View_Container.FormDSPhim(this), sender);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            OpenChidForm(new View_Container.FormDSNguoiDung(), sender);
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            OpenChidForm(new View_Container.FormDanhGia(this), sender);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            OpenChidForm(new View_Main.FormLoginSignup(), sender);
        }
        private void btnMinimum_Click (object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        public SuaPhim GetSuaPhim()
        {
            return suaPhim;
        }
        public XemChiTiet getChiTiet()
        {
            return xemChiTiet;
        }
    }
}
