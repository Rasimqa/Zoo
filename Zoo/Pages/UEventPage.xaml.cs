using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Zoo.Base;
using System.ComponentModel;
using System.Windows.Data;

namespace Zoo.Pages
{
    public partial class UEventPage : Page
    {
        private MainWindow _mainWindow;
        private ICollectionView EventCollectionView;

        public UEventPage(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            LoadData();
        }

        private void LoadData()
        {
            using (var db = new ZooEntities())
            {
                EventListView.ItemsSource = db.Event.ToList();
                EventCollectionView = CollectionViewSource.GetDefaultView(EventListView.ItemsSource);
                EventCollectionView.Filter = FilterEvent;
            }
        }

        private bool FilterEvent(object item)
        {
            var eventItem = item as Event;
            if (eventItem == null) return false;

            // Search by name
            string searchText = txt_search_name.Text;
            if (!string.IsNullOrEmpty(searchText) && searchText != "Поиск по названию")
            {
                if (!eventItem.name_event.ToLower().Contains(searchText.ToLower()))
                    return false;
            }

            // Filter by date
            if (dp_filter_date.SelectedDate.HasValue)
            {
                if (eventItem.date.HasValue && eventItem.date.Value.Date != dp_filter_date.SelectedDate.Value.Date)
                    return false;
            }

            return true;
        }

        private void Txt_Search_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EventCollectionView != null)
            {
                EventCollectionView.Refresh();
            }
        }

        private void Dp_Filter_Date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EventCollectionView != null)
            {
                EventCollectionView.Refresh();
            }
        }
    }
} 