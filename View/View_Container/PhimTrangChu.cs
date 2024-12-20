﻿using Quan_ly_thu_vien_phim.Controller;
using Quan_ly_thu_vien_phim.Model;
using Quan_ly_thu_vien_phim.View.View_Main;
using Quan_ly_thu_vien_phim.View.View_useControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_thu_vien_phim.View.View_Container
{
    public partial class PhimTrangChu : Form
    {
        private Movie_model movie ;
        private User_model user ;
        private Movie_controller movieController = new Movie_controller();
        private TrangchuUser trangChuUser;
        private FormMainUser formMainUser;
        public PhimTrangChu(TrangchuUser trangChuUser, FormMainUser formMainUser, User_model user)
        { 
            this.user = user;
            this.trangChuUser = trangChuUser;
            this.formMainUser = formMainUser;
            InitializeComponent();
            loadDataPhimdx();
            loadDataPhimbo();
            loadDataPhimle();
            loadDataReview();
            
            this.Size = new Size(999, 1500);
        }
        private void loadDataPhimdx()
        {
            try
            {
                List<Movie_model> dsMovieDx = movieController.GetDeXuat();
                if (dsMovieDx != null && dsMovieDx.Count > 0)
                {
                    pnlPhimdx.Controls.Clear();
                    foreach (Movie_model movie in dsMovieDx)
                    {
                        ItemPhimUser item = new ItemPhimUser(movie, formMainUser,user);
                        pnlPhimdx.Controls.Add(item);
                    }
                    pnlPhimdx.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void loadDataPhimbo()
        {
            try
            {
                List<Movie_model> dsMovieDx = movieController.GetPhimBo();
                if (dsMovieDx != null && dsMovieDx.Count > 0)
                {
                    pnlPhimbo.Controls.Clear();
                    foreach (Movie_model movie in dsMovieDx)
                    {
                        ItemPhimUser item = new ItemPhimUser(movie, formMainUser,user);
                        pnlPhimbo.Controls.Add(item);
                    }
                    pnlPhimbo.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void loadDataPhimle()
        {
            try
            {
                List<Movie_model> dsMovieDx = movieController.GetPhimLe();
                if (dsMovieDx != null && dsMovieDx.Count > 0)
                {
                    pnlPhimLe.Controls.Clear();
                    foreach (Movie_model movie in dsMovieDx)
                    {
                        ItemPhimUser item = new ItemPhimUser(movie, formMainUser,user);
                        pnlPhimLe.Controls.Add(item);
                    }
                    pnlPhimLe.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void loadDataReview()
        {
            try
            {
                List<Movie_model> dsMovieDx = movieController.GetReview();
                if (dsMovieDx != null && dsMovieDx.Count > 0)
                {
                    pnlReview.Controls.Clear();
                    foreach (Movie_model movie in dsMovieDx)
                    {
                        ItemReviewPhim item = new ItemReviewPhim(movie);
                        pnlReview.Controls.Add(item);
                    }
                    pnlReview.Refresh();
                }

                pnlReview.HorizontalScroll.Enabled = false;
                pnlReview.HorizontalScroll.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
