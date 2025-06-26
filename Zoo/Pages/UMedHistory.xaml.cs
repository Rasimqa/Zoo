using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Zoo.Base;
using System.ComponentModel;
using System.Windows.Data;

namespace Zoo.Pages
{
    public partial class UMedHistory : Page
    {
        private MainWindow _mainWindow;
        private ICollectionView MedHistoryCollectionView;

        public UMedHistory(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            LoadData();
        }

        private void LoadData()
        {
            using (var db = new ZooEntities())
            {
                MedHistoryListView.ItemsSource = db.Med_History.ToList();
                MedHistoryCollectionView = CollectionViewSource.GetDefaultView(MedHistoryListView.ItemsSource);
                MedHistoryCollectionView.Filter = FilterMedHistory;
            }
        }

        private bool FilterMedHistory(object item)
        {
            var medHistory = item as Med_History;
            if (medHistory == null) return false;

            // Search by description
            string searchText = txt_search_description.Text;
            if (!string.IsNullOrEmpty(searchText) && searchText != "Поиск по описанию")
            {
                if (!medHistory.description.ToLower().Contains(searchText.ToLower()))
                    return false;
            }

            // Filter by Procedure ID
            if (num_filter_procedure_id.Value.HasValue)
            {
                if (medHistory.id_med_procedure != num_filter_procedure_id.Value.Value)
                    return false;
            }

            // Filter by Medical Card ID
            if (num_filter_medcard_id.Value.HasValue)
            {
                if (medHistory.id_medcard != num_filter_medcard_id.Value.Value)
                    return false;
            }

            // Filter by Employee ID
            if (num_filter_employee_id.Value.HasValue)
            {
                if (medHistory.id_employee != num_filter_employee_id.Value.Value)
                    return false;
            }

            return true;
        }

        private void Txt_Search_Description_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (MedHistoryCollectionView != null)
            {
                MedHistoryCollectionView.Refresh();
            }
        }

        private void Num_Filter_ProcedureId_ValueChanged(object sender, RoutedEventArgs e)
        {
            if (MedHistoryCollectionView != null)
            {
                MedHistoryCollectionView.Refresh();
            }
        }

        private void Num_Filter_MedcardId_ValueChanged(object sender, RoutedEventArgs e)
        {
            if (MedHistoryCollectionView != null)
            {
                MedHistoryCollectionView.Refresh();
            }
        }

        private void Num_Filter_EmployeeId_ValueChanged(object sender, RoutedEventArgs e)
        {
            if (MedHistoryCollectionView != null)
            {
                MedHistoryCollectionView.Refresh();
            }
        }
    }
} 