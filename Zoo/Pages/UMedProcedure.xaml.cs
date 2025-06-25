using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Zoo.Base;
using System.ComponentModel;
using System.Windows.Data;

namespace Zoo.Pages
{
    public partial class UMedProcedure : Page
    {
        private MainWindow _mainWindow;
        private ICollectionView MedProcedureCollectionView;

        public UMedProcedure(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            LoadData();
        }

        private void LoadData()
        {
            using (var db = new Zoo_Pr6Entities())
            {
                MedProcedureListView.ItemsSource = db.Med_Procedure.ToList();
                MedProcedureCollectionView = CollectionViewSource.GetDefaultView(MedProcedureListView.ItemsSource);
                MedProcedureCollectionView.Filter = FilterMedProcedure;
            }
        }

        private bool FilterMedProcedure(object item)
        {
            var medProcedure = item as Med_Procedure;
            if (medProcedure == null) return false;

            // Search by name
            string searchText = txt_search_name.Text;
            if (!string.IsNullOrEmpty(searchText) && searchText != "Поиск по названию")
            {
                if (!medProcedure.name_procedure.ToLower().Contains(searchText.ToLower()))
                    return false;
            }

            // Filter by type
            string filterTypeText = txt_filter_type.Text;
            if (!string.IsNullOrEmpty(filterTypeText) && filterTypeText != "Фильтр по типу процедуры")
            {
                if (!medProcedure.type_procedure.ToLower().Contains(filterTypeText.ToLower()))
                    return false;
            }

            return true;
        }

        private void Txt_Search_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (MedProcedureCollectionView != null)
            {
                MedProcedureCollectionView.Refresh();
            }
        }

        private void Txt_Filter_Type_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (MedProcedureCollectionView != null)
            {
                MedProcedureCollectionView.Refresh();
            }
        }
    }
} 