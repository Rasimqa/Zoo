using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Zoo.Base;

namespace Zoo.Pages
{
    public partial class MedHistory : Page
    {
        private MainWindow _mainWindow;
        Zoo_Pr6Entities db = new Zoo_Pr6Entities();
        public MedHistory(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            LoadData();
        }

        private void LoadData()
        {
            using (var db = new Zoo_Pr6Entities())
            {
                MedHistoryGrid.ItemsSource = db.Med_History.ToList();
            }
        }

        private void AddMedHis_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var mId = db.Med_History.Max(x=> x.id_med_history)+1;
                var medHis = new Med_History
                {
                    id_medcard = mId,
                    condition = txt_id_medcard.Text,
                    description = txt_description.Text,
                    date_start_heal = DateTime.Parse(txt_date_start_heal.Text),
                    date_end_heal = DateTime.Parse(txt_date_end_heal.Text),
                    id_med_procedure = int.Parse(txt_id_med_procedure.Text),
                    id_employee = int.Parse(txt_id_employee.Text)
                };

                using (var db = new Zoo_Pr6Entities())
                {
                    db.Med_History.Add(medHis);
                    db.SaveChanges();
                }

                LoadData();
                MessageBox.Show("Новая мед.история добавлена.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении: " + ex.Message);
            }
        }

        private void SaveMedHis_Click(object sender, RoutedEventArgs e)
        {
            if (MedHistoryGrid.SelectedItem is Med_History selected)
            {
                try
                {
                    using (var db = new Zoo_Pr6Entities())
                    {
                        var historyInDb = db.Med_History.Find(selected.id_med_history);

                        if (historyInDb != null)
                        {
                            // Обновляем значения из UI
                            historyInDb.id_medcard = selected.id_medcard;
                            historyInDb.condition = selected.condition;
                            historyInDb.description = selected.description;
                            historyInDb.date_start_heal = selected.date_start_heal;
                            historyInDb.date_end_heal = selected.date_end_heal;
                            historyInDb.id_med_procedure = selected.id_med_procedure;
                            historyInDb.id_employee = selected.id_employee;

                            db.SaveChanges();
                        }
                    }

                    LoadData();
                    MessageBox.Show("Мед.История сохранена.");
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

        private void DeleteMedHis_Click(object sender, RoutedEventArgs e)
        {
            if (MedHistoryGrid.SelectedItem is Med_History selected)
            {
                try
                {
                    using (var db = new Zoo_Pr6Entities())
                    {
                        var itemToDelete = db.Med_History.Find(selected.id_med_history);
                        if (itemToDelete != null)
                        {
                            db.Med_History.Remove(itemToDelete);
                            db.SaveChanges();
                        }
                    }

                    LoadData();
                    MessageBox.Show("Мед.История удалена.");
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