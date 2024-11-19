using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Zoo.Pages;


namespace Zoo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new RegPage(this));
        }
        int a = 0;
        private void HamButton(object sender, RoutedEventArgs e)
        {
            if (Hamburger.Visibility == Visibility.Visible)
            {
                HambButton.Content = "☰";
                Hamburger.Visibility = Visibility.Hidden;
                Rest.Visibility = Visibility.Hidden;
                HambButton.Margin = new Thickness(1170, 10, 0, 0);
            }
            else
            {
                HambButton.Content = ">";
                Hamburger.Visibility = Visibility.Visible;
                Rest.Visibility = Visibility.Visible;
                HambButton.Margin = new Thickness(1060, 10, 0, 0);
            }
        }

        private void Button_Profile(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new ProfilePage(this));
            a = 2;
        }

        private void ButtonAnimal_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new AnimalPage(this));
            a = 1;
        }

        private void Button_Feedback(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new FeedPage(this));
            a = 4;
        }
        private void Button_Click_Restart(object sender, RoutedEventArgs e)
        {
            if (a == 1)
            {
                MainFrame.NavigationService.Navigate(new AnimalPage(this));
            }
            else if (a == 2)
            {
                MainFrame.NavigationService.Navigate(new ProfilePage(this));
            }
            else if (a == 3)
            {
                MainFrame.NavigationService.Navigate(new RegPage(this));
            }
            else if (a == 4)
            {
                MainFrame.NavigationService.Navigate(new FeedPage(this));
            }
        }

       


    }
}
