using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Zoo.Base;
using System.ComponentModel;
using System.Windows.Data;

namespace Zoo.Pages
{
    public partial class UHistoryTree : Page
    {
        private MainWindow _mainWindow;
        private ICollectionView HistoryTreeCollectionView;

        // Флаг для переключения направления сортировки
        private ListSortDirection _sortDirection = ListSortDirection.Ascending;
        public UHistoryTree(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            LoadData();
        }

        private void LoadData()
        {
            using (Zoo_Pr6Entities db = new Zoo_Pr6Entities())
            {
                HistoryTreeListView.ItemsSource = db.History_Family_Tree.ToList();
                HistoryTreeCollectionView = CollectionViewSource.GetDefaultView(HistoryTreeListView.ItemsSource);
                HistoryTreeCollectionView.Filter = FilterHistoryTree;
            }
        }

        private bool FilterHistoryTree(object item)
        {
            var historyTree = item as History_Family_Tree;
            if (historyTree == null) return false;

            // Search by name
            string searchText = txt_search_name.Text;
            if (!string.IsNullOrEmpty(searchText) && searchText != "Поиск по названию")
            {
                if (!historyTree.name_family_tree.ToLower().Contains(searchText.ToLower()))
                    return false;
            }

            // Filter by count
            string filterCountText = txt_filter_count.Text;
            if (!string.IsNullOrEmpty(filterCountText) && filterCountText != "Фильтр по кол-ву животных (мин)")
            {
                if (int.TryParse(filterCountText, out int minCount))
                {
                    if (historyTree.count_animal < minCount)
                        return false;
                }
            }

            return true;
        }

        private void Txt_Search_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (HistoryTreeCollectionView != null)
            {
                HistoryTreeCollectionView.Refresh();
            }
        }

        

        private void Txt_Filter_Count_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (HistoryTreeCollectionView != null)
            {
                HistoryTreeCollectionView.Refresh();
            }
        }

        private void SortByDate_Click(object sender, RoutedEventArgs e)
        {
            // Очищаем предыдущие сортировки
            HistoryTreeCollectionView.SortDescriptions.Clear();
            SortButton.Content = _sortDirection == ListSortDirection.Ascending
    ? "Сортировать по дате ▼"
    : "Сортировать по дате ▲";
            // Меняем направление сортировки
            _sortDirection = (_sortDirection == ListSortDirection.Ascending)
                ? ListSortDirection.Descending
                : ListSortDirection.Ascending;

            // Применяем новую сортировку
            HistoryTreeCollectionView.SortDescriptions.Add(
                new SortDescription("date_start_family", _sortDirection));
        }

        private void txt_filter_count_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            HistoryTreeCollectionView?.Refresh();
        }
    }
} 