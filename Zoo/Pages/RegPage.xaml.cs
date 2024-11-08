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
using Zoo;

namespace Zoo.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public static User user;  
        static MainWindow _mainWindow;
        public RegPage(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
        }

        private void Button_Registration(object sender, RoutedEventArgs e)
        {

            string login_user = txtLogin.Text;
            string password = txtPass.Text;
            // Проверяем, есть ли уже пользователь с таким логином в базе данных
            var login_sql = connect.db.Login.FirstOrDefault(id => id.login1 == login_user);
            if (login_sql != null)
            {
                if (login_sql.password == password)
                {
                    // Пароль верный - переходим в профиль
                    _mainWindow.MainFrame.NavigationService.Navigate(new ProfilePage(_mainWindow));
                }
                else
                {
                    // Пароль неверный - выводим сообщение об ошибке
                    MessageBox.Show("Неверный пароль!");
                }
            }
            else
            {
                // Пользователь не найден - регистрируем его
                var newLogin = new Login()
                {
                    login1 = login_user,
                    password = password
                };          
                connect.db.Login.Add(newLogin);
                connect.db.SaveChanges();
                var newUser = new User()
                {
                    name = txtName.Text,
                    login = login_user,
                    id_role = 2
                };
                connect.db.User.Add(newUser);
                connect.db.SaveChanges();
                MessageBox.Show("Пользователь зарегистрирован");
                _mainWindow.MainFrame.NavigationService.Navigate(new ProfilePage(_mainWindow));
            }


        }
    }
}
