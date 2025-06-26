using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Zoo.Base;

namespace Zoo.Pages
{
    public partial class HistoryTree : Page
    {
        ZooEntities db = new ZooEntities();
        private MainWindow _mainWindow;

        public HistoryTree(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            LoadData();
        }

        private void LoadData()
        {
            using (var db = new ZooEntities())
            {
                HistoryTreeGrid.ItemsSource = db.History_Family_Tree.ToList();
            }
        }

        private void AddHistoryTree_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var mId = db.History_Family_Tree.Max(x=> x.id_history)+1;
                var historyTree = new History_Family_Tree
                {
                    id_history = mId,
                    name_family_tree = txt_name_family_tree.Text,
                    count_animal = int.Parse(txt_count_animal.Text),
                    date_start_family = DateTime.Parse(txt_date_start_family.Text)
                };

                using (var db = new ZooEntities())
                {
                    db.History_Family_Tree.Add(historyTree);
                    db.SaveChanges();
                }

                LoadData();
                MessageBox.Show("Новая запись об истории рода добавлена.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении: " + ex.Message);
            }
        }

        private void SaveHistoryTree_Click(object sender, RoutedEventArgs e)
        {
            if (HistoryTreeGrid.SelectedItem is History_Family_Tree selected)
            {
                try
                {
                    using (var db = new ZooEntities())
                    {
                        var treeInDb = db.History_Family_Tree.Find(selected.id_history);

                        if (treeInDb != null)
                        {
                            treeInDb.name_family_tree = selected.name_family_tree;
                            treeInDb.count_animal = selected.count_animal;
                            treeInDb.date_start_family = selected.date_start_family;

                            db.SaveChanges();
                        }
                    }

                    LoadData();
                    MessageBox.Show("Запись об истории рода сохранена.");
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

        private void DeleteHistoryTree_Click(object sender, RoutedEventArgs e)
        {
            if (HistoryTreeGrid.SelectedItem is History_Family_Tree selected)
            {
                try
                {
                    using (var db = new ZooEntities())
                    {
                        var itemToDelete = db.History_Family_Tree.Find(selected.id_history);
                        if (itemToDelete != null)
                        {
                            db.History_Family_Tree.Remove(itemToDelete);
                            db.SaveChanges();
                        }
                    }

                    LoadData();
                    MessageBox.Show("Запись об истории рода удалена.");
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