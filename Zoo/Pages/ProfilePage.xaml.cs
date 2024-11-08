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

namespace Zoo.Pages
{
    public partial class ProfilePage : Page
    {
        public static User user;
        static MainWindow _mainWindow;
        public ProfilePage(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
        }
    }
}
