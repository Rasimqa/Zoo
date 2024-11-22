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

namespace Zoo.Pages
{
    public partial class ProfilePage : Page
    {
        static MainWindow _mainWindow;
        Visitor newVisitor;
        int idrole;

        public ProfilePage(MainWindow mainWindow, User user)
        {
            _mainWindow = mainWindow;
            InitializeComponent();

            if (user == null)
            {
                MessageBox.Show("Вы не зарегестрированы!");
            }
            else
            {
                idrole = Convert.ToInt16(user.id_role);
            }
            QrCodeImage.Source = GenerateQrCodeBitmapImage($"Profile: {idrole}");


            if (user != null)
            {
                //if (user.id_user == newVisitor.id_visitor)
                //{
                //     txtFullName.Text = newVisitor.full_name/*user.name*/;
                //    txtPhone.Text = newVisitor.number_phone;
                //}


                txtRole.Text = $"Роль: {user.id_role}"; // Используем user.id_role напрямую
                

                if (user.id_role == 2)
                {
                    txtPosition.Visibility = Visibility.Hidden;      
                }
            }
            else
            {
                MessageBox.Show("Ошибка: пользователь не найден.");
            }
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


        private void Button_Reg(object sender, RoutedEventArgs e)
        {

            int idvis = newVisitor.id_visitor;

            var newVis = new Visitor
            {
                id_visitor = idvis, // Получаем id_user из текущего пользователя
                full_name = txtFullName.Text,
                number_phone = Convert.ToString(txtPhone.Text)
            };

            connect.db.Visitor.AddOrUpdate(newVis); // Используем Add вместо AddOrUpdate
            connect.db.SaveChanges();

        }
    }
}