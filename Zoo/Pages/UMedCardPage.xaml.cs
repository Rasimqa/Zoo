using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Zoo.Base;
using System.ComponentModel;
using System.Windows.Data;

namespace Zoo.Pages
{
    public partial class UMedCardPage : Page
    {
        private MainWindow _mainWindow;
        private ICollectionView MedCardCollectionView;
        private ListSortDirection _sortDirection = ListSortDirection.Ascending;

        public UMedCardPage(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            LoadData();
        }

        private void LoadData()
        {
            using (var db = new ZooEntities())
            {
                MedCardListView.ItemsSource = db.MedCard.ToList();
                MedCardCollectionView = CollectionViewSource.GetDefaultView(MedCardListView.ItemsSource);
                MedCardCollectionView.Filter = FilterMedCard;
            }
        }

        private bool FilterMedCard(object item)
        {
            var medCard = item as MedCard;
            if (medCard == null) return false;

            // Filter by Animal ID
            string filterAnimalIdText = txt_filter_animal_id.Text;
            if (!string.IsNullOrEmpty(filterAnimalIdText) && filterAnimalIdText != "Фильтр по ID Животного")
            {
                if (int.TryParse(filterAnimalIdText, out int animalId))
                {
                    if (medCard.id_animal != animalId)
                        return false;
                }
            }

            return true;
        }

        private void Txt_Filter_AnimalId_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (MedCardCollectionView != null)
            {
                MedCardCollectionView.Refresh();
            }
        }

        private void SortByDate_Click(object sender, RoutedEventArgs e)
        {
            MedCardCollectionView.SortDescriptions.Clear();
            SortButton.Content = _sortDirection == ListSortDirection.Ascending
                ? "Сортировать по Дате регистрации ▼"
                : "Сортировать по Дате регистрации ▲";
            _sortDirection = (_sortDirection == ListSortDirection.Ascending)
                ? ListSortDirection.Descending
                : ListSortDirection.Ascending;

            MedCardCollectionView.SortDescriptions.Add(new SortDescription("date_start_account", _sortDirection));
        }
    }
} 