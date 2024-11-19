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

namespace Zoo.Pages
{
    public partial class FeedPage : Page
    {
        string loginuser;
        static RegPage _regpage;
        //public static User user;
        static MainWindow _mainWindow;
        public FeedPage(MainWindow mainWindow, RegPage regpage)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _regpage = regpage;
            loginuser = regpage.txtLogin.Text;
            txtUserName.Text = loginuser;
        }


    }
}
