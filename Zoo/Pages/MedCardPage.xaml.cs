using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Zoo.Base;

namespace Zoo.Pages
{
    public partial class MedCardPage : Page
    {
        private MainWindow _mainWindow;
        ZooEntities db = new ZooEntities();
        public MedCardPage(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            LoadData();
        }

        private void LoadData()
        {
            using (var db = new ZooEntities())
            {
                MedCardGrid.ItemsSource = db.MedCard.ToList();
            }
        }

        private void AddMedCard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var mId = db.MedCard.Max(x=> x.id_medcard)+1;
                var card = new MedCard
                {
                    id_medcard = mId,
                    id_animal = int.Parse(txt_id_animal.Text),
                    date_start_account = DateTime.Parse(txt_date_start_account.Text)
                };

                using (var db = new ZooEntities())
                {
                    db.MedCard.Add(card);
                    db.SaveChanges();
                }

                LoadData();
                MessageBox.Show("Новая мед.карта добавлена.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении: " + ex.Message);
            }
        }

        private void SaveMedCard_Click(object sender, RoutedEventArgs e)
        {
            if (MedCardGrid.SelectedItem is MedCard selected)
            {
                try
                {
                    using (var db = new ZooEntities())
                    {
                        var cardInDb = db.MedCard.Find(selected.id_medcard);
                        if (cardInDb != null)
                        {
                            cardInDb.id_animal = selected.id_animal;
                            cardInDb.date_start_account = selected.date_start_account;

                            db.SaveChanges();
                        }
                    }

                    LoadData();
                    MessageBox.Show("Мед.Карта обновлена.");
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

        private void DeleteMedCard_Click(object sender, RoutedEventArgs e)
        {
            if (MedCardGrid.SelectedItem is MedCard selected)
            {
                try
                {
                    using (var db = new ZooEntities())
                    {
                        var cardToDelete = db.MedCard.Find(selected.id_medcard);
                        if (cardToDelete != null)
                        {
                            db.MedCard.Remove(cardToDelete);
                            db.SaveChanges();
                        }
                    }

                    LoadData();
                    MessageBox.Show("Мед.Карта удалена.");
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