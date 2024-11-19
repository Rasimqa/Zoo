using System;
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

namespace Zoo.Pages
{
    public partial class FeedPage : Page
    {
        string loginuser;
        //public static User user;
        static MainWindow _mainWindow;
        public FeedPage(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            //loginuser = connect.user.Login1.login1;
            txtUserName.Text = loginuser; 
        }

        private void Button_Send(object sender, RoutedEventArgs e)
        {
            Feedback newFeed;
            string description = txtFend.Text;
            string fname = txtUserName.Text;
            decimal score = Convert.ToDecimal(Score.Value);
            newFeed = new Feedback()
            {
                description = description,
                id_visitor = null,
                score = score
            };
            connect.db.Feedback.Add(newFeed);
            connect.db.SaveChangesAsync();
        }
    }
}
