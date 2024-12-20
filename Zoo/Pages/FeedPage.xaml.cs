﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zoo.Base;
using QRCoder;
using System.Drawing;
using System.IO;
using Zoo.Pages;
using System.Xml.Linq;
using Wpf.Ui.Controls;
using MessageBox = System.Windows.MessageBox;

namespace Zoo.Pages
{
    public partial class FeedPage : Page
    {
        string loginuser;
        int idvisit;
        //public static User user;
        static MainWindow _mainWindow;
        public FeedPage(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            //loginuser = connect.user.Login1.login1;
            txtUserName.Text = loginuser;
            ListFeeds.ItemsSource = connect.db.Feedback.ToList();
        }

        private void Button_Send(object sender, RoutedEventArgs e)
        {
            try
            {
                Feedback newFeed;
                string description = txtFend.Text;
                string fname = txtUserName.Text;
                int score = Convert.ToInt16(Score.Value);
                var dates = DateTime.Today;
                newFeed = new Feedback()
                {
                    description = description,
                    id_visitor = null,
                    score = score,
                    date_feed = dates,
                };
                connect.db.Feedback.Add(newFeed);
                connect.db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вы не ввели все данные!");
            }
        }
    }
}
