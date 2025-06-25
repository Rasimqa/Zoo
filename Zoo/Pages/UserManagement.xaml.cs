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
using System.Data.Entity;

namespace Zoo.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserManagement.xaml
    /// </summary>
    public partial class UserManagement : Page
    {
        private Zoo_Pr6Entities _context;
        private List<User> _users;
        static MainWindow _mainWindow;

        public UserManagement(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _context = new Zoo_Pr6Entities(); // Инициализация контекста
            LoadRoles(); // Загружаем роли
            LoadUsers();
            UsersDataGrid.SelectionChanged += UsersDataGrid_SelectionChanged; // Добавляем обработчик события SelectionChanged
        }

        private void LoadUsers()
        {
            _context = new Zoo_Pr6Entities(); // Пересоздаем контекст для обновления данных
            // Нетерпеливая загрузка связанных сущностей Login1 и role
            _users = _context.User.Include(u => u.Login1).Include(u => u.role).ToList();
            UsersDataGrid.ItemsSource = _users;
        }

        private void LoadRoles()
        {
            var roles = _context.role.ToList();
            cmb_role.ItemsSource = roles;
            cmb_role.DisplayMemberPath = "name"; // Свойство для отображения имени роли
            cmb_role.SelectedValuePath = "id_role"; // Свойство для получения значения ID роли
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_name.Text) || string.IsNullOrWhiteSpace(txt_login.Text) || string.IsNullOrWhiteSpace(txt_pass.Text) || cmb_role.SelectedValue == null)
                {
                    MessageBox.Show("Пожалуйста, заполните все поля и выберите роль.");
                    return;
                }

                // Проверяем, существует ли логин в таблице Login
                var existingLogin = _context.Login.FirstOrDefault(l => l.login1 == txt_login.Text);
                if (existingLogin == null)
                {
                    // Если логина нет, создаем новую запись в таблице Login
                    var newLogin = new Login
                    {
                        login1 = txt_login.Text,
                        password = txt_pass.Text
                    }; 
                    _context.Login.Add(newLogin);
                    _context.SaveChanges(); // Сохраняем новую запись Login сразу
                }
                else
                {
                    // Если логин существует, обновляем его пароль, если предоставлен новый
                    if (!string.IsNullOrWhiteSpace(txt_pass.Text))
                    {
                        existingLogin.password = txt_pass.Text;
                    }
                }

                var newUser = new User
                {
                    name = txt_name.Text,
                    login = txt_login.Text,
                    id_role = (int)cmb_role.SelectedValue, 
                    count_visit = 0 
                };

                _context.User.Add(newUser);
                _context.SaveChanges();
                LoadUsers();
                ClearInputFields();
                MessageBox.Show("Новый пользователь успешно добавлен.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении пользователя: " + ex.Message);
            }
        }

        private void SaveUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UsersDataGrid.SelectedItem is User selectedUser)
                {
                    var userInDb = _context.User
                                           .Include(u => u.Login1)
                                           .FirstOrDefault(u => u.id_user == selectedUser.id_user);
                    if (userInDb != null)
                    {
                        userInDb.name = txt_name.Text;
                        userInDb.id_role = (int)cmb_role.SelectedValue;

                        // Обновляем логин пользователя
                        userInDb.login = txt_login.Text;

                        // Обновляем или создаем запись в таблице Login
                        var associatedLogin = _context.Login.FirstOrDefault(l => l.login1 == txt_login.Text);

                        if (associatedLogin == null)
                        {
                            // Если записи Login не существует для этого логина, создаем ее
                            associatedLogin = new Login
                            {
                                login1 = txt_login.Text,
                                password = txt_pass.Text
                            };
                            _context.Login.Add(associatedLogin);
                        }
                        else
                        {
                            // Если запись Login существует, обновляем ее пароль, если предоставлен новый
                            if (!string.IsNullOrWhiteSpace(txt_pass.Text))
                            {
                                associatedLogin.password = txt_pass.Text;
                            }
                        }
                    }
                }
                _context.SaveChanges();
                LoadUsers();
                MessageBox.Show("Изменения сохранены.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message);
            }
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is User selectedUser)
            {
                try
                {
                    var userToRemove = _context.User.Find(selectedUser.id_user);
                    if (userToRemove != null)
                    {
                        // Удаляем связанную запись Login, если это единственный пользователь, связанный с ней
                        var loginToRemove = _context.Login.FirstOrDefault(l => l.login1 == userToRemove.login);
                        _context.User.Remove(userToRemove);
                        if (loginToRemove != null && !_context.User.Any(u => u.login == loginToRemove.login1 && u.id_user != userToRemove.id_user))
                        {
                            _context.Login.Remove(loginToRemove);
                        }
                        _context.SaveChanges();
                        LoadUsers();
                        ClearInputFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователя для удаления.");
            }
        }

        private void UsersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is User selectedUser)
            {
                txt_name.Text = selectedUser.name;
                txt_login.Text = selectedUser.login;
                cmb_role.SelectedValue = selectedUser.id_role;
                txt_pass.Text = selectedUser.Login1?.password; // Отображаем пароль
            }
            else
            {
                ClearInputFields();
            }
        }

        private void ClearInputFields()
        {
            txt_name.Text = string.Empty;
            txt_login.Text = string.Empty;
            txt_pass.Text = string.Empty; // Очищаем поле пароля
            cmb_role.SelectedIndex = -1;
        }
    }
}
