﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
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
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {

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
    }
}
