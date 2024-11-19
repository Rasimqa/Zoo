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
using System.Runtime.ConstrainedExecution;
using Zoo.Pages;

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

        private async void Button_Registration(object sender, RoutedEventArgs e)
        {
            User newUser;
            string login_user = txtLogin.Text;
            string password = txtPass.Text;
            // Проверяем, есть ли уже пользователь с таким логином в базе данных
            var login_sql = connect.db.Login.FirstOrDefault(id => id.login1 == login_user);
            if (login_sql != null)
            {
                if (login_sql.password == password)
                {
                    // Пароль верный - переходим в профиль
                    _mainWindow.MainFrame.NavigationService.Navigate(new FeedPage(_mainWindow));
                    login_user = connect.user.Login1.login1;
                    newUser = connect.user
                    connect.user = newUser;
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
                await connect.db.SaveChangesAsync();
                newUser = new User()
                {
                    name = txtName.Text,
                    login = login_user,
                    id_role = 2
                };
                connect.db.User.Add(newUser);
                await connect.db.SaveChangesAsync();
                MessageBox.Show("Пользователь зарегистрирован");
                connect.user = newUser;
                _mainWindow.MainFrame.NavigationService.Navigate(new ProfilePage(_mainWindow));
            }
        }
    }
}
