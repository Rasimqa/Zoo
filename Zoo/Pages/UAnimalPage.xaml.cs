using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Zoo.Base;
using System.ComponentModel;
using System.Windows.Data;

namespace Zoo.Pages
{
    public partial class UAnimalPage : Page
    {
        private MainWindow _mainWindow;
        private ICollectionView AnimalCollectionView;

        public UAnimalPage(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            LoadData();
        }

        private void LoadData()
        {
            using (var db = new ZooEntities())
            {
                AnimalListView.ItemsSource = db.Animal.ToList();
                AnimalCollectionView = CollectionViewSource.GetDefaultView(AnimalListView.ItemsSource);
                AnimalCollectionView.Filter = FilterAnimal;
            }
        }

        private bool FilterAnimal(object item)
        {
            var animal = item as Animal;
            if (animal == null) return false;

            // Search by name
            string searchText = txt_search_name.Text;
            if (!string.IsNullOrEmpty(searchText) && searchText != "Поиск по имени")
            {
                if (!animal.name.ToLower().Contains(searchText.ToLower()))
                    return false;
            }

            // Filter by Age
            if (num_filter_age.Value.HasValue)
            {
                if (animal.age != num_filter_age.Value.Value)
                    return false;
            }

            // Filter by Medical Card ID
            if (num_filter_medcard.Value.HasValue)
            {
                if (animal.id_medcard != num_filter_medcard.Value.Value)
                    return false;
            }

            // Filter by Cell ID
            if (num_filter_cell.Value.HasValue)
            {
                if (animal.id_cell != num_filter_cell.Value.Value)
                    return false;
            }

            return true;
        }

        private void Txt_Search_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (AnimalCollectionView != null)
            {
                AnimalCollectionView.Refresh();
            }
        }

        private void Num_Filter_Age_ValueChanged(object sender, RoutedEventArgs e)
        {
            if (AnimalCollectionView != null)
            {
                AnimalCollectionView.Refresh();
            }
        }

        private void Num_Filter_Medcard_ValueChanged(object sender, RoutedEventArgs e)
        {
            if (AnimalCollectionView != null)
            {
                AnimalCollectionView.Refresh();
            }
        }

        private void Num_Filter_Cell_ValueChanged(object sender, RoutedEventArgs e)
        {
            if (AnimalCollectionView != null)
            {
                AnimalCollectionView.Refresh();
            }
        }
    }
} 