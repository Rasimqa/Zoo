using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zoo.Base;
using MessageBox = System.Windows.MessageBox;

namespace Zoo.Pages
{
    /// <summary>
    /// Логика взаимодействия для AnimalPage.xaml
    /// </summary>
    public partial class AnimalPage : Page
    {
        public static User user;
        static MainWindow _mainWindow;
        public AnimalPage(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
            ListAnimal.ItemsSource = connect.db.Animal.ToList();
            ListHistory.ItemsSource = connect.db.History_Family_Tree.ToList();
            ListFamily.ItemsSource = connect.db.List_Family_Tree.ToList();
            ListMedHis.ItemsSource = connect.db.Med_History.ToList();
            ListMedCard.ItemsSource = connect.db.MedCard.ToList();
            ListMedProc.ItemsSource = connect.db.Med_Procedure.ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ListAnimal.SelectedItem != null)
            {
                int idSelectedCactus = (ListAnimal.SelectedItem as Animal).id_animal;
                Animal animal = (from r in connect.db.Animal where r.id_animal == idSelectedCactus select r).SingleOrDefault();
                connect.db.Animal.Remove(animal);
                connect.db.SaveChanges();
                ListAnimal.ItemsSource = connect.db.Animal.ToList();
                MessageBox.Show("Информация о животном удалена");
            }
            else
            {
                MessageBox.Show("Для удаления выберите строку");
            }
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Redakt_Panel.Visibility = Visibility.Hidden;
            Rect.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Hidden;
            ButtonClose.Visibility = Visibility.Hidden;
            ButtonDelete.Visibility = Visibility.Hidden;
            ButtonEdit.Visibility = Visibility.Hidden;
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            var idanim = Convert.ToInt32(txt_idanimal.Text);
            string names = txt_name.Text;
            var ages = Convert.ToInt32(txt_age.Text);
            string genders = txt_gender.Text;
            var idmedcard = 0;
            if (txt_idmedcard.Text == "Номер мед.карты")
            {        
                idmedcard = 0;
            }
            else
            {
                idmedcard = Convert.ToInt32(txt_idmedcard.Text);
            }
            string type = txt_type.Text;
            var idcell = 0;
            if (txt_idcell.Text == "Номер вольера")
            {
                idcell = 0;
            }
            else
            {
                idcell = Convert.ToInt32(txt_idcell.Text);
            }

            var animal = connect.db.Animal.FirstOrDefault(
                id => id.id_animal == idanim && 
                id.name == names && 
                id.age == ages && 
                id.gender == genders && 
                id.id_medcard == idmedcard &&
                id.type == type &&
                id.id_cell == idcell
                );
           
            var Animals = new Animal()
            {
                id_animal = idanim,
                name = names,
                gender = genders,
                age = ages,
                id_medcard = idmedcard,
                type = type,
                id_cell = idcell
            };

            connect.db.Animal.Add(Animals);
            connect.db.SaveChanges();
            MessageBox.Show("Животное было успешно добавлено");
            return;
        }
        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            var id_anim = Convert.ToInt32(txt_idanimal.Text);
            string names = txt_name.Text;
            var ages = Convert.ToInt32(txt_age.Text);
            string genders = txt_gender.Text;
            var idmedcard = 0;
            string type = txt_type.Text;
            var idcell = 0;


            if (id_anim != null)
            {
                Animal animalsss = (from r in connect.db.Animal where r.id_animal == id_anim select r).SingleOrDefault();
                connect.db.Animal.Remove(animalsss);
                connect.db.SaveChanges();
                ListAnimal.ItemsSource = connect.db.Animal.ToList();
            }
            else
            {
                MessageBox.Show("Для редактирования информации, впишите ID животного");
            }

            var animal = connect.db.Animal.FirstOrDefault(
                id => id.id_animal == id_anim &&
                id.name == names &&
                id.age == ages &&
                id.gender == genders &&
                id.id_medcard == idmedcard &&
                id.type == type &&
                id.id_cell == idcell
                );

            var Animals = new Animal()
            {
                id_animal = id_anim,
                name = names,
                gender = genders,
                age = ages,
                id_medcard = idmedcard,
                type = type,
                id_cell = idcell
            };

            connect.db.Animal.Add(Animals);
            connect.db.SaveChanges();
            MessageBox.Show("Животное было успешно отредактировано");
            AnimalFrame.NavigationService.Navigate(new AnimalPage(_mainWindow));
            return;
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            var id_anim = Convert.ToInt32(txt_idanimal.Text);
            if (id_anim != null)
            {
                Animal animal = (from r in connect.db.Animal where r.id_animal == id_anim select r).SingleOrDefault();
                connect.db.Animal.Remove(animal);
                connect.db.SaveChanges();
                ListAnimal.ItemsSource = connect.db.Animal.ToList();
                MessageBox.Show("Информация о животном удалена");
            }
            else
            {
                MessageBox.Show("Для удаления впишите ID животного");
            }
        }

        private void Button_Editions(object sender, RoutedEventArgs e)
        {
            Redakt_Panel.Visibility = Visibility.Visible;
            Rect.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Visible;
            ButtonClose.Visibility = Visibility.Visible;
            ButtonDelete.Visibility = Visibility.Visible;
            ButtonEdit.Visibility = Visibility.Visible;
        }

        private void Button_History(object sender, RoutedEventArgs e)
        {
            ListMedProc.Visibility = Visibility.Hidden;
            ListHistory.Visibility = Visibility.Visible;
            ListMedCard.Visibility = Visibility.Hidden;
            ListMedHis.Visibility = Visibility.Hidden;
            ListFamily.Visibility = Visibility.Hidden;
            ButtonMedCard.Visibility = Visibility.Visible;
            ButtonMedHis.Visibility = Visibility.Visible;
            ButtonMedProc.Visibility = Visibility.Visible;
            ButtonFamily.Visibility = Visibility.Visible;
            Rect_His.Visibility = Visibility.Visible;
            ButtonClose_His.Visibility = Visibility.Visible;
        }

        private void Button_Family(object sender, RoutedEventArgs e)
        {
            ListMedProc.Visibility = Visibility.Hidden;
            ListMedCard.Visibility = Visibility.Hidden;
            ListMedHis.Visibility = Visibility.Hidden;
            ListHistory.Visibility = Visibility.Hidden;
            ListFamily.Visibility = Visibility.Visible;
            ButtonMedCard.Visibility = Visibility.Visible;
            ButtonMedHis.Visibility = Visibility.Visible;
            ButtonMedProc.Visibility = Visibility.Visible;
        }

        //private void Button_Back(object sender, RoutedEventArgs e)
        //{
        //    if(ListHistory.Visibility == Visibility.Visible)
        //    {
        //        ListHistory.Visibility = Visibility.Hidden;
        //        ListFamily.Visibility = Visibility.Hidden;
        //        ButtonBack.Visibility = Visibility.Hidden;
        //        ButtonFamily.Visibility = Visibility.Hidden;
        //        Rect_His.Visibility = Visibility.Hidden;
        //        ButtonClose_His.Visibility = Visibility.Hidden;
        //    }
        //    else
        //    {
        //        ListHistory.Visibility = Visibility.Visible;
        //        ListFamily.Visibility = Visibility.Hidden;
        //    }
        //}

        private void Button_Click_Close_His(object sender, RoutedEventArgs e)
        {
            ListMedProc.Visibility = Visibility.Hidden;
            ListMedCard.Visibility = Visibility.Hidden;
            ListMedHis.Visibility = Visibility.Hidden;
            ListHistory.Visibility = Visibility.Hidden;
            ListFamily.Visibility = Visibility.Hidden;
            ButtonFamily.Visibility = Visibility.Hidden;
            Rect_His.Visibility = Visibility.Hidden;
            ButtonClose_His.Visibility = Visibility.Hidden;
            ButtonMedCard.Visibility = Visibility.Hidden;
            ButtonMedHis.Visibility = Visibility.Hidden;
            ButtonMedProc.Visibility = Visibility.Hidden;
        }

        private void Button_Med_His(object sender, RoutedEventArgs e)
        {
            ListMedHis.Visibility = Visibility.Visible;
            ListMedProc.Visibility = Visibility.Hidden;
            ListMedCard.Visibility = Visibility.Hidden;
            ListHistory.Visibility = Visibility.Hidden;
            ListFamily.Visibility = Visibility.Hidden;
            ButtonMedCard.Visibility = Visibility.Visible;
            ButtonMedHis.Visibility = Visibility.Visible;
            ButtonMedProc.Visibility = Visibility.Visible;
            ButtonFamily.Visibility = Visibility.Visible;
            Rect_His.Visibility = Visibility.Visible;
            ButtonClose_His.Visibility = Visibility.Visible;
            
        }

        private void Button_MedCard(object sender, RoutedEventArgs e)
        {
            ListMedCard.Visibility = Visibility.Visible;
            ListMedProc.Visibility = Visibility.Hidden;
            ListMedHis.Visibility = Visibility.Hidden;
            ListHistory.Visibility = Visibility.Hidden;
            ListFamily.Visibility = Visibility.Hidden;
            ButtonMedCard.Visibility = Visibility.Visible;
            ButtonMedHis.Visibility = Visibility.Visible;
            ButtonMedProc.Visibility = Visibility.Visible;
            ButtonFamily.Visibility = Visibility.Visible;
            Rect_His.Visibility = Visibility.Visible;
            ButtonClose_His.Visibility = Visibility.Visible;

        }

        private void Button_MedProc(object sender, RoutedEventArgs e)
        {
            ListMedProc.Visibility = Visibility.Visible;
            ListMedCard.Visibility = Visibility.Hidden;
            ListMedHis.Visibility = Visibility.Hidden;
            ListHistory.Visibility = Visibility.Hidden;
            ListFamily.Visibility = Visibility.Hidden;
            ButtonMedCard.Visibility = Visibility.Visible;
            ButtonMedHis.Visibility = Visibility.Visible;
            ButtonMedProc.Visibility = Visibility.Visible;
            ButtonFamily.Visibility = Visibility.Visible;
            Rect_His.Visibility = Visibility.Visible;
            ButtonClose_His.Visibility = Visibility.Visible;
        }
    }
}
