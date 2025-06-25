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
    public partial class AdminPage : Page
    {
        private Zoo_Pr6Entities _context = new Zoo_Pr6Entities(); // Подключение к вашей БД через ADO.NET EF
        private List<User> _users;
        static MainWindow _mainWindow;

        public AdminPage(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainFrame.NavigationService.Navigate(new UserManagement(_mainWindow));
            //Управление пользователями
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //
        }
    }
}
