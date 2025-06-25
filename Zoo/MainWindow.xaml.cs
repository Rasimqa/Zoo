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
using Zoo.Base;
using Zoo.Pages;


namespace Zoo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int a = 0;
        User newUser;        
        int iduser;
        private bool isDragging = false;
        private Point lastMousePosition;
        public MainWindow()
        {
            InitializeComponent();
            //WindowState = WindowState.Maximized;
            //WindowStyle = WindowStyle.None;
            this.WindowStyle = WindowStyle.None;
            this.ResizeMode = ResizeMode.CanResize; // или CanResizeWithGrip
            MainFrame.NavigationService.Navigate(new RegPage(this));
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            lastMousePosition = e.GetPosition(this);
            CaptureMouse();
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            ReleaseMouseCapture();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && this.IsMouseCaptured)
            {
                var currentPos = e.GetPosition(this);
                var delta = currentPos - lastMousePosition;

                this.Left += delta.X;
                this.Top += delta.Y;

                lastMousePosition = currentPos;
            }
        }
        private void HamButton(object sender, RoutedEventArgs e)
        {

                if (Hamburger.Visibility == Visibility.Visible)
                {
                    HambButton.Content = "☰";
                    Hamburger.Visibility = Visibility.Hidden;
                    Rest.Visibility = Visibility.Hidden;
                    Button_Refresh.Visibility = Visibility.Hidden;
                    Button_Closes.Visibility = Visibility.Hidden;
                    HambButton.Margin = new Thickness(1861, 10, 0, 0);
                    Button_Closes.Margin = new Thickness(1758, 10, 0, 0);
                }
                else
                {
                    HambButton.Content = ">";
                    Hamburger.Visibility = Visibility.Visible;
                    Rest.Visibility = Visibility.Visible;
                    Button_Refresh.Visibility = Visibility.Visible;
                    Button_Closes.Visibility = Visibility.Visible;
                    HambButton.Margin = new Thickness(1758, 10, 0, 0);
                    Button_Closes.Margin = new Thickness(1861, 10, 0, 0);
                }
            
            
        }

        private void Button_Profile(object sender, RoutedEventArgs e)
        {
            newUser = new User();
            MainFrame.NavigationService.Navigate(new ProfilePage(this, newUser));
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
                newUser = new User();
                MainFrame.NavigationService.Navigate(new ProfilePage(this, newUser));
            }
            else if (a == 3)
            {
                MainFrame.NavigationService.Navigate(new RegPage(this));
            }
            else if (a == 4)
            {
                MainFrame.NavigationService.Navigate(new FeedPage(this));
            }
            else if (a == 6)
            {
                MainFrame.NavigationService.Navigate(new EventPage(this));
            }
        }

        private void Button_Click_Closes(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            a = 5;
            MainFrame.NavigationService.Navigate(new RegPage(this));
            User user = new User();
            user.id_user = 0; 
        }

        private void Button_Event(object sender, RoutedEventArgs e)
        {
            a = 6;
            MainFrame.NavigationService.Navigate(new EventPage(this));
        }

        private void ButtonProfile_Копировать7_Click(object sender, RoutedEventArgs e)
        {

            MainFrame.NavigationService.Navigate(new UserManagement(this));
        }

        public void UpdateUIForUserRole(User user)
        {
            if (user != null && user.id_role == 1) // Предположим, роль админа = 1
            {
                ButtonProfile_Копировать7.Visibility = Visibility.Visible;
                ButtonPet.Visibility = Visibility.Visible;
                ButtonMedHist.Visibility = Visibility.Visible;
                ButtonMedProcedure.Visibility = Visibility.Visible;
                ButtonHistoryTree.Visibility = Visibility.Visible;
                ButtonEvent.Visibility = Visibility.Visible;
            }
            else if(user != null && user.id_role == 3)
            {
                ButtonPet.Visibility = Visibility.Visible;
                ButtonMedHist.Visibility = Visibility.Visible;
                ButtonMedProcedure.Visibility = Visibility.Visible;
                ButtonHistoryTree.Visibility = Visibility.Visible;
                ButtonEvent.Visibility = Visibility.Visible;
            }
            else
            {
                ButtonProfile_Копировать7.Visibility = Visibility.Hidden;
                ButtonPet.Visibility = Visibility.Hidden;
                ButtonMedHist.Visibility = Visibility.Hidden;
                ButtonMedProcedure.Visibility = Visibility.Hidden;
                ButtonHistoryTree.Visibility = Visibility.Hidden;
                ButtonEvent.Visibility = Visibility.Hidden;
            }
        }

        private void Button_MedHist(object sender, RoutedEventArgs e)
        {

            MainFrame.NavigationService.Navigate(new MedHistory(this));
        }

        private void Button_MedProcedure(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new MedProcedure(this));
        }

        private void Button_HistoryTree(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new HistoryTree(this));
        }

        private void Button_UHistoryTree(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new UHistoryTree(this));
        }

        private void Button_UMedCardPage(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new UMedCardPage(this));
        }

        private void Button_UMedProcedure(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new UMedProcedure(this));
        }

        private void Button_UAnimalPage(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new UAnimalPage(this));
        }

        private void Button_UMedHistory(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new UMedHistory(this));
        }

        private void Button_UEventPage(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new UEventPage(this));
        }

    }
}
