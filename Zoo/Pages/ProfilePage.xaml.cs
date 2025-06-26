//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
//using Zoo.Base;
//using QRCoder;
//using System.Drawing;
//using System.IO;
//using Zoo.Pages;
//using System.Xml.Linq;
//using Wpf.Ui.Controls;
//using MessageBox = System.Windows.MessageBox;

//namespace Zoo.Pages
//{
//    public partial class ProfilePage : Page
//    {
//        //public static User user;
//        static MainWindow _mainWindow;
//        public ProfilePage(MainWindow mainWindow, User user) // Добавляем параметр User
//        {
//            _mainWindow = mainWindow;
//            InitializeComponent();

//            if (user != null) // Проверка на null
//            {
//                txtFullName.Text = user.name; // Выводим имя пользователя
//                int userRole = Convert.ToInt32(user.id_role);
//                txtFullName.Text = $"Роль: {userRole}"; // Выводим роль пользователя

//                // Условные действия в зависимости от роли
//                if (userRole == 1)
//                {
//                    // Действия для роли 1
//                }
//                else if (userRole == 2)
//                {
//                    // Действия для роли 2
//                    txtPosition.Visibility = Visibility.Hidden; // Пример
//                }
//            }
//            else
//            {
//                MessageBox.Show("Ошибка: пользователь не найден.");
//            }
//        }




//        private void Button_Reg(object sender, RoutedEventArgs e)
//        {

//        }


//    }
//}


using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot;
using QRCoder;
using System;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Zoo.Base;
using Zoo.Pages;
using ImageFormat = System.Drawing.Imaging.ImageFormat;

namespace Zoo.Pages
{
    public partial class ProfilePage : Page
    {
        static MainWindow _mainWindow;
        Visitor newVisitor;
        int idrole;
        int user_reg;
        int newUser;
        public static User use;
        public ProfilePage(MainWindow mainWindow, User newUser)
        {
            _mainWindow = mainWindow;            
            InitializeComponent();
            if (newUser == null)
            {
                MessageBox.Show("Вы не зарегестрированы!");
            }
            else
            {
                idrole = Convert.ToInt16(newUser.id_role);
                user_reg = newUser.id_user;
                use = newUser;
                // Обновляем интерфейс главного окна
                UpdateMainWindowUserRole();
            }
            QrCodeImage.Source = GenerateQrCodeBitmapImage($"Profile: {idrole}");


            if (newUser != null)
            {
                //if (user.id_user == newVisitor.id_visitor)
                //{
                //     txtFullName.Text = newVisitor.full_name/*user.name*/;
                //    txtPhone.Text = newVisitor.number_phone;
                //}

                //if(newUser.id_role = 3)
                txtFullName.Text = $"Имя: {newUser.name}"; 
                txtPhone.Text = $"Логин: {newUser.login}";
                //txtRole.Text = $"Роль: {newUser.id_role}"; // Используем user.id_role напрямую


                if (newUser.id_role == 3)
                {
                    txtPosition.Visibility = Visibility.Visible;
                    PLV.Visibility = Visibility.Visible;
                }
                else if(newUser.id_role == 2) 
                { 
                    txtPosition.Visibility = Visibility.Visible; 
                }
                else
                {
                    txtPosition.Visibility = Visibility.Hidden;
                    PLV.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                MessageBox.Show("Ошибка: пользователь не найден.");
            }


            // Создание модели графика для статистики посещений
            var plotModel = new PlotModel { Title = "Статистика посещений пользователей" };

            // Получаем статистику посещений для всех пользователей
            var visitStats = connect.db.User
                .Select(u => new
                {
                    Login = u.login,
                    VisitCount = u.count_visit ?? 0
                })
                .OrderByDescending(u => u.VisitCount)
                .Take(10) // Ограничиваем топ-10 пользователей
                .ToList();

            // Создание столбчатой диаграммы
            var barSeries = new BarSeries
            {
                Title = "Количество посещений",
                StrokeColor = OxyColors.Black,
                StrokeThickness = 1,
                FillColor = OxyColors.Green
            };

            // Создание осей
            var categoryAxis = new CategoryAxis
            {
                Position = AxisPosition.Left,
                Key = "LoginAxis",
                Title = "Пользователи"
            };

            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = 0,
                Title = "Количество посещений"
            };

            // Добавление данных в серию и ось категорий
            for (int i = 0; i < visitStats.Count; i++)
            {
                barSeries.Items.Add(new BarItem
                {
                    Value = visitStats[i].VisitCount,
                    Color = OxyColors.Green
                });

                categoryAxis.Labels.Add(visitStats[i].Login);
            }

            // Добавление осей и серии в модель
            plotModel.Axes.Add(categoryAxis);
            plotModel.Axes.Add(valueAxis);
            plotModel.Series.Add(barSeries);

            // Привязка модели к PlotView
            PLV.Model = plotModel;

            

    }

        private BitmapImage GenerateQrCodeBitmapImage(string text)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q); using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    using (Bitmap qrBitmap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            qrBitmap.Save(ms, ImageFormat.Png);
                            ms.Position = 0;
                            BitmapImage bitmapImage = new BitmapImage(); bitmapImage.BeginInit();
                            bitmapImage.CacheOption = BitmapCacheOption.OnLoad; bitmapImage.StreamSource = ms;
                            bitmapImage.EndInit();
                            return bitmapImage;
                        }
                    }
                }
            }
        }


       

        private void Button_Reg_Zoo(object sender, RoutedEventArgs e)
        {
            if (newUser == null)
            {
                MessageBox.Show("Вы не зарегестрированы!");
            }
            else
            {
                if (idrole == 2)
                {
                    Rect_Edit_Oth.Visibility = Visibility.Visible;
                    Redakt_Panel_Oth.Visibility = Visibility.Visible;
                    ButtonAdd_Oth.Visibility = Visibility.Visible;
                    ButtonEdit_Oth.Visibility = Visibility.Visible;
                    ButtonClose_Oth.Visibility = Visibility.Visible;
                    txt_1.Visibility = Visibility.Visible;
                    txt_2.Visibility = Visibility.Visible;
                    txt_5.Visibility = Visibility.Visible;
                    Check_Post.Visibility = Visibility.Visible;

                }
                else if (idrole == 3 || idrole == 1)
                {
                    Rect_Edit_Oth.Visibility = Visibility.Visible;
                    Redakt_Panel_Oth.Visibility = Visibility.Visible;
                    ButtonAdd_Oth.Visibility = Visibility.Visible;
                    ButtonEdit_Oth.Visibility = Visibility.Visible;
                    ButtonClose_Oth.Visibility = Visibility.Visible;
                    txt_1.Visibility = Visibility.Visible;
                    txt_2.Visibility = Visibility.Visible;
                    txt_6.Visibility = Visibility.Visible;
                    txt_7.Visibility = Visibility.Visible;
                }
            }
           
        }
        

        private void Button_Click_Close_Oth(object sender, RoutedEventArgs e)
        {
            Rect_Edit_Oth.Visibility = Visibility.Hidden;
            Redakt_Panel_Oth.Visibility = Visibility.Hidden;
            ButtonAdd_Oth.Visibility = Visibility.Hidden;
            ButtonEdit_Oth.Visibility = Visibility.Hidden;
            ButtonClose_Oth.Visibility = Visibility.Hidden;
            txt_1.Visibility = Visibility.Hidden;
            txt_2.Visibility = Visibility.Hidden;
            txt_5.Visibility = Visibility.Hidden;
            txt_6.Visibility = Visibility.Hidden;
            txt_7.Visibility = Visibility.Hidden;
            Check_Post.Visibility = Visibility.Hidden;
        }

        private void Button_Add_Oth(object sender, RoutedEventArgs e)
        {
            try
            {
                if (idrole == 2)
                {
                    var idvis = user_reg;
                    string full_name = txt_1.Text;
                    var number_phone = txt_2.Text;
                    var check_bool = (bool)Check_Post.IsChecked;
                    var kd_fr = Convert.ToInt32(txt_5.Text);

                    //var Visit = connect.db.Visitor.FirstOrDefault(
                    //    id => id. == id_rod &&
                    //    id.name_family_tree == name_rod &&
                    //    id.count_animal == count_rod &&
                    //    id.date_start_family == date
                    //    );

                    var Visitor = new Visitor()
                    {
                        id_visitor = idvis,
                        full_name = full_name,
                        number_phone = number_phone,
                        Regular_Customer = check_bool
                    };

                    connect.db.Visitor.Add(Visitor);
                    connect.db.SaveChanges();
                    MessageBox.Show("Вы успешно зарегестрировались в Зоопарке!");
                    return;
                }
                else if (idrole == 3 || idrole == 1)
                {

                    var idemp = user_reg;
                    string full_name = txt_1.Text;
                    var number_phone = txt_2.Text;
                    DateTime date_birth = Convert.ToDateTime(txt_6.Text);
                    string mpos = txt_7.Text;

                    //var Visit = connect.db.Visitor.FirstOrDefault(
                    //    id => id. == id_rod &&
                    //    id.name_family_tree == name_rod &&
                    //    id.count_animal == count_rod &&
                    //    id.date_start_family == date
                    //    );

                    var Employee = new Employee()
                    {
                        id_employee = idemp,
                        full_name = full_name,
                        number_phone = number_phone,
                        date_birth = date_birth,
                        position = mpos
                    };

                    connect.db.Employee.Add(Employee);
                    connect.db.SaveChanges();
                    MessageBox.Show("Вы успешно зарегестрировались в Зоопарке!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вы не ввели все данные!");
            }
        }

        private void Button_Edit_Oth(object sender, RoutedEventArgs e)
        {
            try
            {
                if (idrole == 2)
                {
                    var idvis = user_reg;
                    string full_name = txt_1.Text;
                    var number_phone = txt_2.Text;
                    var check_bool = (bool)Check_Post.IsChecked;
                    var kd_fr = Convert.ToInt32(txt_5.Text);

                    //var Visit = connect.db.Visitor.FirstOrDefault(
                    //    id => id. == id_rod &&
                    //    id.name_family_tree == name_rod &&
                    //    id.count_animal == count_rod &&
                    //    id.date_start_family == date
                    //    );

                    var Visitor = new Visitor()
                    {
                        id_visitor = idvis,
                        full_name = full_name,
                        number_phone = number_phone,
                        Regular_Customer = check_bool
                    };

                    connect.db.Visitor.AddOrUpdate(Visitor);
                    connect.db.SaveChanges();
                    MessageBox.Show("Вы изменили данные о себе!");
                    return;
                }
                else if (idrole == 3 || idrole == 1)
                {

                    var idemp = user_reg;
                    string full_name = txt_1.Text;
                    var number_phone = txt_2.Text;
                    DateTime date_birth = Convert.ToDateTime(txt_6.Text);
                    string mpos = txt_7.Text;

                    //var Visit = connect.db.Visitor.FirstOrDefault(
                    //    id => id. == id_rod &&
                    //    id.name_family_tree == name_rod &&
                    //    id.count_animal == count_rod &&
                    //    id.date_start_family == date
                    //    );

                    var Employee = new Employee()
                    {
                        id_employee = idemp,
                        full_name = full_name,
                        number_phone = number_phone,
                        date_birth = date_birth,
                        position = mpos
                    };

                    connect.db.Employee.AddOrUpdate(Employee);
                    connect.db.SaveChanges();
                    MessageBox.Show("Вы изменили данные о себе сотруднике!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вы не ввели все данные!");
            }
        }

        private void UpdateMainWindowUserRole()
        {
            if (_mainWindow != null && use != null)
            {
                _mainWindow.UpdateUIForUserRole(use); // 'use' — это статическое поле с пользователем
            }
        }
    }
}