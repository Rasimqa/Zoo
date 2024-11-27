using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Zoo.Base;
using Zoo.Pages;

namespace Zoo.Pages
{
    public partial class RegPage : Page
    {
        static MainWindow _mainWindow;

        public RegPage(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
        }

        private static void UpUser(User user)
        {
            if (user == null)
            {
                MessageBox.Show("Шок ты лошок!");
            }
            else 
            { 
               int usid = user.id_user;
               int Count = Convert.ToInt32(user.count_visit);
               int Count2;
               Count2 = Count + 1;
                var iuser = new User
                {
                    id_user = user.id_user,
                    name = user.name,
                    login = user.login, 
                    id_role = user.id_role,
                    count_visit = Count2

                };
               connect.db.User.AddOrUpdate(iuser);
               connect.db.SaveChanges();
            }
                       
        }

        private async void Button_Registration(object sender, RoutedEventArgs e)
        {
            string login_user = txtLogin.Text;
            string password = txtPass.Text;
            string userName = txtName.Text;

            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("Пожалуйста, введите имя пользователя.");
                return;
            }

            var login_sql = await Task.Run(() => connect.db.Login.FirstOrDefault(id => id.login1 == login_user));

            try
            {
                if (login_sql != null)
                {
                    if (login_sql.password == password)
                    {
                        // Пользователь существует, переходим на страницу профиля
                        var user = connect.db.User.FirstOrDefault(u => u.login == login_user);
                        if (user != null)
                        {
                            RegPage.UpUser(user);
                            _mainWindow.MainFrame.NavigationService.Navigate(new ProfilePage(_mainWindow, user));
                        }
                        else
                        {
                            MessageBox.Show("Ошибка: Пользователь не найден в таблице User.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль!");
                    }
                }
                else
                {
                    // Регистрируем нового пользователя
                    var newLogin = new Login { login1 = login_user, password = password };
                    connect.db.Login.Add(newLogin);
                    await connect.db.SaveChangesAsync();
                    var newUser = new User { name = userName, login = login_user, id_role = 2, count_visit = 0 };
                    RegPage.UpUser(newUser);
                    
                    // Получаем ID пользователя после сохранения
                    newUser = connect.db.User.FirstOrDefault(u => u.login == login_user);
                    if (newUser != null)
                    {
                        MessageBox.Show("Пользователь зарегистрирован");
                        _mainWindow.MainFrame.NavigationService.Navigate(new ProfilePage(_mainWindow, newUser));
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при получении ID пользователя.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }



        private void Reg_Check_Click(object sender, RoutedEventArgs e)
        {
            bool status = (bool)Reg_Check.IsChecked;
            int a;
            if (status == true)
            {
                a = 1;
            }
            else
            {
                a = 0;
            }

            if (a == 1)
            {
                txtName.Visibility = Visibility.Visible;
                label_name.Visibility = Visibility.Visible;
                Label_Pass.Margin = new Thickness(733, 481, 0, 0);
                txtPass.Margin = new Thickness(733, 519, 0, 0);
                Button_Reg.Content = "Регистрация";
            }
            else if (a == 0)
            {
                txtName.Visibility = Visibility.Hidden;
                label_name.Visibility = Visibility.Hidden;
                Label_Pass.Margin = new Thickness(733, 396, 0, 0);
                txtPass.Margin = new Thickness(733, 434, 0, 0);
                Button_Reg.Content = "Войти";
            }
        }
    }
}



















//using System;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using Zoo.Base;
//using Zoo.Pages;

//namespace Zoo.Pages
//{
//    public partial class RegPage : Page
//    {
//        static MainWindow _mainWindow;

//        public RegPage(MainWindow mainWindow)
//        {
//            _mainWindow = mainWindow;
//            InitializeComponent();

//        }

//        private async void Button_Registration(object sender, RoutedEventArgs e)
//        {
//            string login_user = txtLogin.Text;
//            string password = txtPass.Text;
//            string userName = txtName.Text; // Получаем имя пользователя
//            int IDUser = connect.user.id_user;


//            if (string.IsNullOrWhiteSpace(userName))
//            {
//                MessageBox.Show("Пожалуйста, введите имя пользователя.");
//                return; // Прерываем выполнение, если имя не введено
//            }

//            var login_sql = await Task.Run(() => connect.db.Login.FirstOrDefault(id => id.login1 == login_user));


//                if (login_sql != null)
//                {
//                    if (login_sql.password == password)
//                    {
//                    // Пользователь существует, переходим на страницу профиля
//                    var newVisitor = new Visitor { id_visitor = IDUser };
//                    var user = connect.db.User.FirstOrDefault(u => u.login == login_user); // Получаем пользователя из User таблицы
//                        if (user != null)
//                            _mainWindow.MainFrame.NavigationService.Navigate(new ProfilePage(_mainWindow, user, newVisitor));
//                        else
//                            MessageBox.Show("Ошибка: Пользователь не найден в таблице User.");
//                    }
//                    else
//                    {
//                        MessageBox.Show("Неверный пароль!");
//                    }
//                }
//                else
//                {
//                    // Регистрируем нового пользователя
//                    var newLogin = new Login { login1 = login_user, password = password };
//                    connect.db.Login.Add(newLogin);
//                    await connect.db.SaveChangesAsync();

//                    var newUser = new User { name = userName, login = login_user, id_role = 2 };
//;
//                    connect.db.User.Add(newUser);
//                    await connect.db.SaveChangesAsync();

//                    var newVisitor = new Visitor { id_visitor = IDUser };

//                    MessageBox.Show("Пользователь зарегистрирован");
//                    _mainWindow.MainFrame.NavigationService.Navigate(new ProfilePage(_mainWindow, newUser, newVisitor));
//               }


//        }
//    }
//}