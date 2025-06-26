using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Zoo.Base;

namespace Zoo.Pages
{
    public partial class MedProcedure : Page
    {
        private MainWindow _mainWindow;
        ZooEntities db = new ZooEntities();

        public MedProcedure(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            LoadData();
        }

        private void LoadData()
        {
            using (var db = new ZooEntities())
            {
                MedProcedureGrid.ItemsSource = db.Med_Procedure.ToList();
            }
        }

        private void AddMedProcedure_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var mId = db.Med_Procedure.Max(x=> x.id_med_procedure)+1;
                var medProcedure = new Med_Procedure
                {
                    id_med_procedure = mId,
                    name_procedure = txt_name_procedure.Text,
                    type_procedure = txt_type_procedure.Text
                };

                using (var db = new ZooEntities())
                {
                    db.Med_Procedure.Add(medProcedure);
                    db.SaveChanges();
                }

                LoadData();
                MessageBox.Show("Новая медицинская процедура добавлена.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении: " + ex.Message);
            }
        }

        private void SaveMedProcedure_Click(object sender, RoutedEventArgs e)
        {
            if (MedProcedureGrid.SelectedItem is Med_Procedure selected)
            {
                try
                {
                    using (var db = new ZooEntities())
                    {
                        var procedureInDb = db.Med_Procedure.Find(selected.id_med_procedure);

                        if (procedureInDb != null)
                        {
                            procedureInDb.name_procedure = selected.name_procedure;
                            procedureInDb.type_procedure = selected.type_procedure;

                            db.SaveChanges();
                        }
                    }

                    LoadData();
                    MessageBox.Show("Медицинская процедура сохранена.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для сохранения.");
            }
        }

        private void DeleteMedProcedure_Click(object sender, RoutedEventArgs e)
        {
            if (MedProcedureGrid.SelectedItem is Med_Procedure selected)
            {
                try
                {
                    using (var db = new ZooEntities())
                    {
                        var itemToDelete = db.Med_Procedure.Find(selected.id_med_procedure);
                        if (itemToDelete != null)
                        {
                            db.Med_Procedure.Remove(itemToDelete);
                            db.SaveChanges();
                        }
                    }

                    LoadData();
                    MessageBox.Show("Медицинская процедура удалена.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления.");
            }
        }
    }
} 