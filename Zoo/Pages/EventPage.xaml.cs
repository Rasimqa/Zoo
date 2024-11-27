using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// <summary>
    /// Логика взаимодействия для EventPage.xaml
    /// </summary>
    public partial class EventPage : Page
    {
        static MainWindow _mainWindow;
        public EventPage(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            ListEvent.ItemsSource = connect.db.Event.ToList();
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
            var idev = Convert.ToInt32(txt_idevent.Text);
            string nazv = txt_nazvanie.Text;
            var desc = txt_desc.Text;
            int ceell = Convert.ToInt32(txt_idcell.Text);
            DateTime dataVent = Convert.ToDateTime(txt_dataevent.Text);
            

            var Events = new Event()
            {
                id_event = idev,
                name_event = nazv,
                description = desc,
                id_cell = ceell,
                date = dataVent
            };

            connect.db.Event.Add(Events);
            connect.db.SaveChanges();
            MessageBox.Show("Мероприятие было успешно добавлено");
            return;
        }
        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            var idev = Convert.ToInt32(txt_idevent.Text);
            string nazv = txt_nazvanie.Text;
            var desc = txt_desc.Text;
            int ceell = Convert.ToInt32(txt_idcell.Text);
            DateTime dataVent = Convert.ToDateTime(txt_dataevent.Text);


            var Events = new Event()
            {
                id_event = idev,
                name_event = nazv,
                description = desc,
                id_cell = ceell,
                date = dataVent
            };

            connect.db.Event.AddOrUpdate(Events);
            connect.db.SaveChanges();
            MessageBox.Show("Мероприятие было успешно отредактированно");
            return;
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            var id_event = Convert.ToInt32(txt_idevent.Text);
            if (id_event != null)
            {
                Event even = (from r in connect.db.Event where r.id_event == id_event select r).SingleOrDefault();
                connect.db.Event.Remove(even);
                connect.db.SaveChanges();
                ListEvent.ItemsSource = connect.db.Event.ToList();
                MessageBox.Show("Информация о мероприятии удалена");
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


    }
}
