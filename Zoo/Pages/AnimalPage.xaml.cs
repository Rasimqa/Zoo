using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zoo.Base;
using MessageBox = System.Windows.MessageBox;

namespace Zoo.Pages
{
    /// <summary>
    /// Логика взаимодействия для AnimalPage.xaml
    /// </summary>
    public partial class AnimalPage : Page
    {
        int i = 0;
        public static User user;
        static MainWindow _mainWindow;
        public AnimalPage(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
            ListAnimal.ItemsSource = connect.db.Animal.ToList();
            ListHistory.ItemsSource = connect.db.History_Family_Tree.ToList();
            ListFamily.ItemsSource = connect.db.List_Family_Tree.ToList();
            ListMedHis.ItemsSource = connect.db.Med_History.ToList();
            ListMedCard.ItemsSource = connect.db.MedCard.ToList();
            ListMedProc.ItemsSource = connect.db.Med_Procedure.ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ListAnimal.SelectedItem != null)
            {
                int idSelectedCactus = (ListAnimal.SelectedItem as Animal).id_animal;
                Animal animal = (from r in connect.db.Animal where r.id_animal == idSelectedCactus select r).SingleOrDefault();
                connect.db.Animal.Remove(animal);
                connect.db.SaveChanges();
                ListAnimal.ItemsSource = connect.db.Animal.ToList();
                MessageBox.Show("Информация о животном удалена");
            }
            else
            {
                MessageBox.Show("Для удаления выберите строку");
            }
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Redakt_Panel.Visibility = Visibility.Hidden;
            Rect.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Hidden;
            ButtonClose.Visibility = Visibility.Hidden;
            ButtonDelete.Visibility = Visibility.Hidden;
            ButtonEdit.Visibility = Visibility.Hidden;
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                var idanim = Convert.ToInt32(txt_idanimal.Text);
                string names = txt_name.Text;
                var ages = Convert.ToInt32(txt_age.Text);
                string genders = txt_gender.Text;
                var idmedcard = 0;
                if (txt_idmedcard.Text == "Номер мед.карты")
                {
                    idmedcard = 0;
                }
                else
                {
                    idmedcard = Convert.ToInt32(txt_idmedcard.Text);
                }
                string type = txt_type.Text;
                var idcell = 0;
                if (txt_idcell.Text == "Номер вольера")
                {
                    idcell = 0;
                }
                else
                {
                    idcell = Convert.ToInt32(txt_idcell.Text);
                }

                var animal = connect.db.Animal.FirstOrDefault(
                    id => id.id_animal == idanim &&
                    id.name == names &&
                    id.age == ages &&
                    id.gender == genders &&
                    id.id_medcard == idmedcard &&
                    id.type == type &&
                    id.id_cell == idcell
                    );

                var Animals = new Animal()
                {
                    id_animal = idanim,
                    name = names,
                    gender = genders,
                    age = ages,
                    id_medcard = idmedcard,
                    type = type,
                    id_cell = idcell
                };

                connect.db.Animal.Add(Animals);
                connect.db.SaveChanges();
                MessageBox.Show("Животное было успешно добавлено");
                return;
            }
            catch (Exception ex) {
                MessageBox.Show("Вы не ввели все данные!");
            }
           
        }
        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            try
            {
                var id_anim = Convert.ToInt32(txt_idanimal.Text);
                string names = txt_name.Text;
                var ages = Convert.ToInt32(txt_age.Text);
                string genders = txt_gender.Text;
                var idmedcard = 0;
                string type = txt_type.Text;
                var idcell = 0;


                if (id_anim != null)
                {
                    Animal animalsss = (from r in connect.db.Animal where r.id_animal == id_anim select r).SingleOrDefault();
                    connect.db.Animal.Remove(animalsss);
                    connect.db.SaveChanges();
                    ListAnimal.ItemsSource = connect.db.Animal.ToList();
                }
                else
                {
                    MessageBox.Show("Для редактирования информации, впишите ID животного");
                }

                var animal = connect.db.Animal.FirstOrDefault(
                    id => id.id_animal == id_anim &&
                    id.name == names &&
                    id.age == ages &&
                    id.gender == genders &&
                    id.id_medcard == idmedcard &&
                    id.type == type &&
                    id.id_cell == idcell
                    );

                var Animals = new Animal()
                {
                    id_animal = id_anim,
                    name = names,
                    gender = genders,
                    age = ages,
                    id_medcard = idmedcard,
                    type = type,
                    id_cell = idcell
                };

                connect.db.Animal.Add(Animals);
                connect.db.SaveChanges();
                MessageBox.Show("Животное было успешно отредактировано");
                AnimalFrame.NavigationService.Navigate(new AnimalPage(_mainWindow));
                return;
            }
            
            catch (Exception ex) {
                MessageBox.Show("Вы не ввели все данные!");
            }
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                var id_anim = Convert.ToInt32(txt_idanimal.Text);
                if (id_anim != null)
                {
                    Animal animal = (from r in connect.db.Animal where r.id_animal == id_anim select r).SingleOrDefault();
                    connect.db.Animal.Remove(animal);
                    connect.db.SaveChanges();
                    ListAnimal.ItemsSource = connect.db.Animal.ToList();
                    MessageBox.Show("Информация о животном удалена");
                }
                else
                {
                    MessageBox.Show("Для удаления впишите ID животного");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вы не ввели все данные!");
            }
        }

        private void Button_Editions(object sender, RoutedEventArgs e)
        {
            Redakt_Panel.Visibility = Visibility.Visible;
            Rect.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Visible;
            ButtonClose.Visibility = Visibility.Visible;
            ButtonDelete.Visibility = Visibility.Visible;
            ButtonEdit.Visibility = Visibility.Visible;
        }

        private void Button_History(object sender, RoutedEventArgs e)
        {
            i = 1;
            ListMedProc.Visibility = Visibility.Hidden;
            ListHistory.Visibility = Visibility.Visible;
            ListMedCard.Visibility = Visibility.Hidden;
            ListMedHis.Visibility = Visibility.Hidden;
            ListFamily.Visibility = Visibility.Hidden;
            ButtonMedCard.Visibility = Visibility.Visible;
            ButtonMedHis.Visibility = Visibility.Visible;
            ButtonMedProc.Visibility = Visibility.Visible;
            ButtonFamily.Visibility = Visibility.Visible;
            ButtonHisTree.Visibility = Visibility.Visible;
            Rect_His.Visibility = Visibility.Visible;
            ButtonClose_His.Visibility = Visibility.Visible;
            ButtonRedOth.Visibility = Visibility.Visible;
        }

        private void Button_Family(object sender, RoutedEventArgs e)
        {
            i = 5;
            ListMedProc.Visibility = Visibility.Hidden;
            ListMedCard.Visibility = Visibility.Hidden;
            ListMedHis.Visibility = Visibility.Hidden;
            ListHistory.Visibility = Visibility.Hidden;
            ListFamily.Visibility = Visibility.Visible;
            ButtonHisTree.Visibility = Visibility.Visible;
            ButtonMedCard.Visibility = Visibility.Visible;
            ButtonMedHis.Visibility = Visibility.Visible;
            ButtonMedProc.Visibility = Visibility.Visible;
        }

        //private void Button_Back(object sender, RoutedEventArgs e)
        //{
        //    if(ListHistory.Visibility == Visibility.Visible)
        //    {
        //        ListHistory.Visibility = Visibility.Hidden;
        //        ListFamily.Visibility = Visibility.Hidden;
        //        ButtonBack.Visibility = Visibility.Hidden;
        //        ButtonFamily.Visibility = Visibility.Hidden;
        //        Rect_His.Visibility = Visibility.Hidden;
        //        ButtonClose_His.Visibility = Visibility.Hidden;
        //    }
        //    else
        //    {
        //        ListHistory.Visibility = Visibility.Visible;
        //        ListFamily.Visibility = Visibility.Hidden;
        //    }
        //}

        private void Button_Click_Close_His(object sender, RoutedEventArgs e)
        {
            ListMedProc.Visibility = Visibility.Hidden;
            ListMedCard.Visibility = Visibility.Hidden;
            ListMedHis.Visibility = Visibility.Hidden;
            ListHistory.Visibility = Visibility.Hidden;
            ListFamily.Visibility = Visibility.Hidden;
            ButtonFamily.Visibility = Visibility.Hidden;
            ButtonHisTree.Visibility = Visibility.Visible;
            Rect_His.Visibility = Visibility.Hidden;
            ButtonHisTree.Visibility = Visibility.Hidden;
            ButtonClose_His.Visibility = Visibility.Hidden;
            ButtonMedCard.Visibility = Visibility.Hidden;
            ButtonMedHis.Visibility = Visibility.Hidden;
            ButtonMedProc.Visibility = Visibility.Hidden;
            ButtonRedOth.Visibility = Visibility.Hidden;
        }

        private void Button_Med_His(object sender, RoutedEventArgs e)
        {
            i = 4;
            ListMedHis.Visibility = Visibility.Visible;
            ListMedProc.Visibility = Visibility.Hidden;
            ListMedCard.Visibility = Visibility.Hidden;
            ListHistory.Visibility = Visibility.Hidden;
            ListFamily.Visibility = Visibility.Hidden;
            ButtonMedCard.Visibility = Visibility.Visible;
            ButtonMedHis.Visibility = Visibility.Visible;
            ButtonMedProc.Visibility = Visibility.Visible;
            ButtonHisTree.Visibility = Visibility.Visible;
            ButtonFamily.Visibility = Visibility.Visible;
            Rect_His.Visibility = Visibility.Visible;
            ButtonClose_His.Visibility = Visibility.Visible;           
        }

        private void Button_MedCard(object sender, RoutedEventArgs e)
        {
            i = 3;
            ListMedCard.Visibility = Visibility.Visible;
            ListMedProc.Visibility = Visibility.Hidden;
            ListMedHis.Visibility = Visibility.Hidden;
            ListHistory.Visibility = Visibility.Hidden;
            ListFamily.Visibility = Visibility.Hidden;
            ButtonMedCard.Visibility = Visibility.Visible;
            ButtonMedHis.Visibility = Visibility.Visible;
            ButtonMedProc.Visibility = Visibility.Visible;
            ButtonFamily.Visibility = Visibility.Visible;
            ButtonHisTree.Visibility = Visibility.Visible;
            Rect_His.Visibility = Visibility.Visible;
            ButtonClose_His.Visibility = Visibility.Visible;

        }

        private void Button_MedProc(object sender, RoutedEventArgs e)
        {
            i = 2;
            ListMedProc.Visibility = Visibility.Visible;
            ListMedCard.Visibility = Visibility.Hidden;
            ListMedHis.Visibility = Visibility.Hidden;
            ListHistory.Visibility = Visibility.Hidden;
            ListFamily.Visibility = Visibility.Hidden;
            ButtonMedCard.Visibility = Visibility.Visible;
            ButtonMedHis.Visibility = Visibility.Visible;
            ButtonMedProc.Visibility = Visibility.Visible;
            ButtonFamily.Visibility = Visibility.Visible;
            ButtonHisTree.Visibility = Visibility.Visible;
            Rect_His.Visibility = Visibility.Visible;
            ButtonClose_His.Visibility = Visibility.Visible;
        }

        private void Button_HisTree(object sender, RoutedEventArgs e)
        {
            i = 1;
            ListMedProc.Visibility = Visibility.Hidden;
            ListHistory.Visibility = Visibility.Visible;
            ListMedCard.Visibility = Visibility.Hidden;
            ListMedHis.Visibility = Visibility.Hidden;
            ListFamily.Visibility = Visibility.Hidden;
            ButtonMedCard.Visibility = Visibility.Visible;
            ButtonMedHis.Visibility = Visibility.Visible;
            ButtonMedProc.Visibility = Visibility.Visible;
            ButtonFamily.Visibility = Visibility.Visible;
            ButtonHisTree.Visibility = Visibility.Visible;
            Rect_His.Visibility = Visibility.Visible;
            ButtonClose_His.Visibility = Visibility.Visible;
        }

        private void Button_Add_Oth(object sender, RoutedEventArgs e)
        {
            try
            {
                if (i == 1) // История рода
                {
                    var id_rod = Convert.ToInt32(txt_1.Text);
                    string name_rod = txt_2.Text;
                    var count_rod = Convert.ToInt32(txt_3.Text);
                    DateTime date = DateTime.Today;

                    var hisrod = connect.db.History_Family_Tree.FirstOrDefault(
                        id => id.id_history == id_rod &&
                        id.name_family_tree == name_rod &&
                        id.count_animal == count_rod &&
                        id.date_start_family == date
                        );

                    var History_Rod = new History_Family_Tree()
                    {
                        id_history = id_rod,
                        name_family_tree = name_rod,
                        count_animal = count_rod,
                        date_start_family = date,

                    };

                    connect.db.History_Family_Tree.Add(History_Rod);
                    connect.db.SaveChanges();
                    MessageBox.Show("Род был успешно добавлен!");
                    return;
                }
                else if (i == 2) // Мед.Процедуры
                {
                    var id_proc = Convert.ToInt32(txt_1.Text);
                    string name_proc = txt_2.Text;
                    string type_proc = txt_3.Text;

                    var medproc = connect.db.Med_Procedure.FirstOrDefault(
                        id => id.id_med_procedure == id_proc &&
                        id.name_procedure == name_proc &&
                        id.type_procedure == type_proc
                        );

                    var Med_Proc = new Med_Procedure()
                    {
                        id_med_procedure = id_proc,
                        name_procedure = name_proc,
                        type_procedure = type_proc

                    };

                    connect.db.Med_Procedure.Add(Med_Proc);
                    connect.db.SaveChanges();
                    MessageBox.Show("Процедура была успешно добавлена!");
                    return;
                }
                else if (i == 3) // Мед.Карта
                {
                    var id_card = Convert.ToInt32(txt_1.Text);
                    var id_animal = Convert.ToInt32(txt_2.Text);
                    DateTime date = DateTime.Today;

                    var MedCard = connect.db.MedCard.FirstOrDefault(
                        id => id.id_medcard == id_card &&
                        id.id_animal == id_animal &&
                        id.date_start_account == date
                        );

                    var Med_Card = new MedCard()
                    {
                        id_medcard = id_card,
                        id_animal = id_animal,
                        date_start_account = date

                    };

                    connect.db.MedCard.Add(Med_Card);
                    connect.db.SaveChanges();
                    MessageBox.Show("Мед.Карта была успешно добавлена!");
                    return;
                }
                else if (i == 4) // Мед.История
                {

                    var id_med = Convert.ToInt32(txt_1.Text);
                    var id_card = Convert.ToInt32(txt_2.Text);
                    string cond = txt_3.Text;
                    string desc = txt_4.Text;
                    DateTime date;
                    DateTime date1;
                    if (txt_5.Text == "Дата начала лечения" || txt_5.Text == null)
                    {
                        date = DateTime.Today;
                    }
                    else
                    {
                        date = Convert.ToDateTime(txt_5.Text);
                    }
                    if (txt_6.Text == "Дата конца лечения" || txt_6.Text == null)
                    {
                        date1 = DateTime.Today;
                    }
                    else
                    {
                        date1 = Convert.ToDateTime(txt_6.Text);
                    }
                    int idproc = Convert.ToInt32(txt_7.Text);
                    int idsotr = Convert.ToInt32(txt_8.Text);

                    var MedHis = connect.db.Med_History.FirstOrDefault(
                        id => id.id_med_history == id_med &&
                        id.id_medcard == id_card &&
                        id.condition == cond &&
                        id.description == desc &&
                        id.id_employee == idsotr &&
                        id.id_med_procedure == idproc &&
                        id.date_start_heal == date &&
                        id.date_end_heal == date1
                        );

                    var Med_His = new Med_History()
                    {
                        id_med_history = id_med,
                        id_medcard = id_card,
                        condition = cond,
                        description = desc,
                        id_employee = idsotr,
                        id_med_procedure = idproc,
                        date_start_heal = date,
                        date_end_heal = date1
                    };

                    connect.db.Med_History.Add(Med_His);
                    connect.db.SaveChanges();
                    MessageBox.Show("История была зарегстрирована!");
                    return;
                }
                else if (i == 5) // История семьи
                {
                    var id_list = Convert.ToInt32(txt_1.Text);
                    var id_his = Convert.ToInt32(txt_2.Text);
                    var id_fath = Convert.ToInt32(txt_3.Text);
                    var id_moth = Convert.ToInt32(txt_3.Text);
                    var id_child = Convert.ToInt32(txt_3.Text);

                    var His_Fam = connect.db.List_Family_Tree.FirstOrDefault(
                        id => id.id_list_family == id_list &&
                        id.id_history == id_his &&
                        id.id_animal_father == id_fath &&
                        id.id_animal_mother == id_moth &&
                        id.id_animal_child == id_child);

                    var HisFam = new List_Family_Tree()
                    {
                        id_list_family = id_list,
                        id_history = id_his,
                        id_animal_father = id_fath,
                        id_animal_mother = id_moth,
                        id_animal_child = id_child
                    };
                    connect.db.List_Family_Tree.Add(HisFam);
                    connect.db.SaveChanges();
                    MessageBox.Show("Семья успешно добавлена!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вы не ввели все данные!");
            }
        }

        private void Button_Edit_Oth(object sender, RoutedEventArgs e)
        {
            try
            {
                if (i == 1) // История рода
                {
                    var id_rod = Convert.ToInt32(txt_1.Text);
                    string name_rod = txt_2.Text;
                    var count_rod = Convert.ToInt32(txt_3.Text);
                    DateTime date = DateTime.Today;


                    if (id_rod != null)
                    {
                        History_Family_Tree hft = (from r in connect.db.History_Family_Tree where r.id_history == id_rod select r).SingleOrDefault();
                        connect.db.History_Family_Tree.Remove(hft);
                        connect.db.SaveChanges();
                        ListHistory.ItemsSource = connect.db.History_Family_Tree.ToList();
                    }
                    else
                    {
                        MessageBox.Show("Для редактирования информации, впишите ID");
                    }

                    var hisrod = connect.db.History_Family_Tree.FirstOrDefault(
                        id => id.id_history == id_rod &&
                        id.name_family_tree == name_rod &&
                        id.count_animal == count_rod &&
                        id.date_start_family == date
                        );

                    var History_Rod = new History_Family_Tree()
                    {
                        id_history = id_rod,
                        name_family_tree = name_rod,
                        count_animal = count_rod,
                        date_start_family = date,

                    };

                    connect.db.History_Family_Tree.Add(History_Rod);
                    connect.db.SaveChanges();
                    MessageBox.Show("Род был успешно отредактирован!");
                    return;
                }
                else if (i == 2) // Мед.Процедуры
                {
                    var id_proc = Convert.ToInt32(txt_1.Text);
                    string name_proc = txt_2.Text;
                    string type_proc = txt_3.Text;

                    if (id_proc != null)
                    {
                        Med_Procedure mdp = (from r in connect.db.Med_Procedure where r.id_med_procedure == id_proc select r).SingleOrDefault();
                        connect.db.Med_Procedure.Remove(mdp);
                        connect.db.SaveChanges();
                        ListMedProc.ItemsSource = connect.db.Med_Procedure.ToList();
                    }
                    else
                    {
                        MessageBox.Show("Для редактирования информации, впишите ID");
                    }

                    var medproc = connect.db.Med_Procedure.FirstOrDefault(
                        id => id.id_med_procedure == id_proc &&
                        id.name_procedure == name_proc &&
                        id.type_procedure == type_proc
                        );

                    var Med_Proc = new Med_Procedure()
                    {
                        id_med_procedure = id_proc,
                        name_procedure = name_proc,
                        type_procedure = type_proc
                    };

                    connect.db.Med_Procedure.Add(Med_Proc);
                    connect.db.SaveChanges();
                    MessageBox.Show("Процедура была успешно отредактирована!");
                    return;
                }
                else if (i == 3) // Мед.Карта
                {
                    var id_card = Convert.ToInt32(txt_1.Text);
                    var id_animal = Convert.ToInt32(txt_2.Text);
                    DateTime date = DateTime.Today;

                    if (id_card != null)
                    {
                        MedCard mc = (from r in connect.db.MedCard where r.id_medcard == id_card select r).SingleOrDefault();
                        connect.db.MedCard.Remove(mc);
                        connect.db.SaveChanges();
                        ListMedCard.ItemsSource = connect.db.MedCard.ToList();
                    }
                    else
                    {
                        MessageBox.Show("Для редактирования информации, впишите ID");
                    }

                    var MedCard = connect.db.MedCard.FirstOrDefault(
                        id => id.id_medcard == id_card &&
                        id.id_animal == id_animal &&
                        id.date_start_account == date
                        );

                    var Med_Card = new MedCard()
                    {
                        id_medcard = id_card,
                        id_animal = id_animal,
                        date_start_account = date

                    };

                    connect.db.MedCard.Add(Med_Card);
                    connect.db.SaveChanges();
                    MessageBox.Show("Мед.Карта была успешно отредактирована!");
                    return;
                }
                else if (i == 4) // Мед.История
                {

                    var id_med = Convert.ToInt32(txt_1.Text);
                    var id_card = Convert.ToInt32(txt_2.Text);
                    string cond = txt_3.Text;
                    string desc = txt_4.Text;
                    DateTime date;
                    DateTime date1;

                    if (id_med != null)
                    {
                        Med_History md = (from r in connect.db.Med_History where r.id_med_history == id_med select r).SingleOrDefault();
                        connect.db.Med_History.Remove(md);
                        connect.db.SaveChanges();
                        ListMedHis.ItemsSource = connect.db.Med_History.ToList();
                    }
                    else
                    {
                        MessageBox.Show("Для редактирования информации, впишите ID");
                    }

                    if (txt_5.Text == "Дата начала лечения" || txt_5.Text == null)
                    {
                        date = DateTime.Today;
                    }
                    else
                    {
                        date = Convert.ToDateTime(txt_5.Text);
                    }
                    if (txt_6.Text == "Дата конца лечения" || txt_6.Text == null)
                    {
                        date1 = DateTime.Today;
                    }
                    else
                    {
                        date1 = Convert.ToDateTime(txt_6.Text);
                    }
                    int idproc = Convert.ToInt32(txt_7.Text);
                    int idsotr = Convert.ToInt32(txt_8.Text);

                    var MedHis = connect.db.Med_History.FirstOrDefault(
                        id => id.id_med_history == id_med &&
                        id.id_medcard == id_card &&
                        id.condition == cond &&
                        id.description == desc &&
                        id.id_employee == idsotr &&
                        id.id_med_procedure == idproc &&
                        id.date_start_heal == date &&
                        id.date_end_heal == date1
                        );

                    var Med_His = new Med_History()
                    {
                        id_med_history = id_med,
                        id_medcard = id_card,
                        condition = cond,
                        description = desc,
                        id_employee = idsotr,
                        id_med_procedure = idproc,
                        date_start_heal = date,
                        date_end_heal = date1
                    };

                    connect.db.Med_History.Add(Med_His);
                    connect.db.SaveChanges();
                    MessageBox.Show("История была отредактирована!");
                    return;
                }
                else if (i == 5) // История семьи
                {
                    var id_list = Convert.ToInt32(txt_1.Text);
                    var id_his = Convert.ToInt32(txt_2.Text);
                    var id_fath = Convert.ToInt32(txt_3.Text);
                    var id_moth = Convert.ToInt32(txt_3.Text);
                    var id_child = Convert.ToInt32(txt_3.Text);

                    if (id_list != null)
                    {
                        List_Family_Tree lft = (from r in connect.db.List_Family_Tree where r.id_list_family == id_list select r).SingleOrDefault();
                        connect.db.List_Family_Tree.Remove(lft);
                        connect.db.SaveChanges();
                        ListFamily.ItemsSource = connect.db.List_Family_Tree.ToList();
                    }
                    else
                    {
                        MessageBox.Show("Для редактирования информации, впишите ID");
                    }

                    var His_Fam = connect.db.List_Family_Tree.FirstOrDefault(
                        id => id.id_list_family == id_list &&
                        id.id_history == id_his &&
                        id.id_animal_father == id_fath &&
                        id.id_animal_mother == id_moth &&
                        id.id_animal_child == id_child);


                    var HisFam = new List_Family_Tree()
                    {
                        id_list_family = id_list,
                        id_history = id_his,
                        id_animal_father = id_fath,
                        id_animal_mother = id_moth,
                        id_animal_child = id_child
                    };
                    connect.db.List_Family_Tree.Add(HisFam);
                    connect.db.SaveChanges();
                    MessageBox.Show("Семья успешно отредактирована!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вы не ввели все данные!");
            }
        }

        private void Button_Delete_Oth(object sender, RoutedEventArgs e)
        {
            try
            {
                if (i == 1) // История рода
                {
                    var id_his = Convert.ToInt32(txt_1.Text);
                    if (id_his != null)
                    {
                        History_Family_Tree hisfam = (from r in connect.db.History_Family_Tree where r.id_history == id_his select r).SingleOrDefault();
                        connect.db.History_Family_Tree.Remove(hisfam);
                        connect.db.SaveChanges();
                        ListHistory.ItemsSource = connect.db.History_Family_Tree.ToList();
                        MessageBox.Show("Информация о истории рода удалена!");
                    }
                    else
                    {
                        MessageBox.Show("Для удаления впишите ID рода!");
                    }
                }
                else if (i == 2) // Мед.Процедуры
                {
                    var id_proc = Convert.ToInt32(txt_1.Text);
                    if (id_proc != null)
                    {
                        Med_Procedure medproc = (from r in connect.db.Med_Procedure where r.id_med_procedure == id_proc select r).SingleOrDefault();
                        connect.db.Med_Procedure.Remove(medproc);
                        connect.db.SaveChanges();
                        ListMedProc.ItemsSource = connect.db.Med_Procedure.ToList();
                        MessageBox.Show("Информация о процедуре удалена!");
                    }
                    else
                    {
                        MessageBox.Show("Для удаления впишите ID процедуры!");
                    }
                }
                else if (i == 3) // Мед.Карта
                {
                    var id_card = Convert.ToInt32(txt_1.Text);
                    if (id_card != null)
                    {
                        MedCard medcard = (from r in connect.db.MedCard where r.id_medcard == id_card select r).SingleOrDefault();
                        connect.db.MedCard.Remove(medcard);
                        connect.db.SaveChanges();
                        ListMedCard.ItemsSource = connect.db.MedCard.ToList();
                        MessageBox.Show("Информация о карте удалена!");
                    }
                    else
                    {
                        MessageBox.Show("Для удаления впишите ID карты!");
                    }
                }
                else if (i == 4) // Мед.История
                {
                    var id_med_his = Convert.ToInt32(txt_1.Text);
                    if (id_med_his != null)
                    {
                        Med_History medhis = (from r in connect.db.Med_History where r.id_med_history == id_med_his select r).SingleOrDefault();
                        connect.db.Med_History.Remove(medhis);
                        connect.db.SaveChanges();
                        ListMedHis.ItemsSource = connect.db.Med_History.ToList();
                        MessageBox.Show("Информация о мед.истории удалена!");
                    }
                    else
                    {
                        MessageBox.Show("Для удаления впишите ID истории!");
                    }
                }
                else if (i == 5) // История семьи
                {
                    var id_fam = Convert.ToInt32(txt_1.Text);
                    if (id_fam != null)
                    {
                        List_Family_Tree hisfam = (from r in connect.db.List_Family_Tree where r.id_list_family == id_fam select r).SingleOrDefault();
                        connect.db.List_Family_Tree.Remove(hisfam);
                        connect.db.SaveChanges();
                        ListFamily.ItemsSource = connect.db.List_Family_Tree.ToList();
                        MessageBox.Show("Информация о семьи удалена!");
                    }
                    else
                    {
                        MessageBox.Show("Для удаления впишите ID семьи!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вы не ввели все данные!");
            }
        }

        private void Button_Click_Close_Oth(object sender, RoutedEventArgs e)
        {
            Rect_Edit_Oth.Visibility = Visibility.Hidden;
            Redakt_Panel_Oth.Visibility = Visibility.Hidden;
            ButtonAdd_Oth.Visibility = Visibility.Hidden;
            ButtonEdit_Oth.Visibility = Visibility.Hidden;
            ButtonDelete_Oth.Visibility = Visibility.Hidden;
            ButtonClose_Oth.Visibility = Visibility.Hidden;
            txt_1.Visibility = Visibility.Hidden;
            txt_2.Visibility = Visibility.Hidden;
            txt_3.Visibility = Visibility.Hidden;
            txt_4.Visibility = Visibility.Hidden;
            txt_5.Visibility = Visibility.Hidden;
            txt_6.Visibility = Visibility.Hidden;
            txt_7.Visibility = Visibility.Hidden;
            txt_8.Visibility = Visibility.Hidden;
        }

        private void ButtonRed_Oth(object sender, RoutedEventArgs e)
        {
            Rect_Edit_Oth.Visibility = Visibility.Visible;
            Redakt_Panel_Oth.Visibility = Visibility.Visible;
            ButtonAdd_Oth.Visibility = Visibility.Visible;
            ButtonEdit_Oth.Visibility = Visibility.Visible;
            ButtonDelete_Oth.Visibility = Visibility.Visible;
            ButtonClose_Oth.Visibility = Visibility.Visible;
            txt_1.Visibility = Visibility.Visible;
            txt_2.Visibility = Visibility.Visible;
            txt_3.Visibility = Visibility.Visible;
            txt_4.Visibility = Visibility.Visible;
            txt_5.Visibility = Visibility.Visible;
            txt_6.Visibility = Visibility.Visible;
            txt_7.Visibility = Visibility.Visible;
            txt_8.Visibility = Visibility.Visible;

            if (i == 1)
            {
                txt_1.Text = "Номер рода";
                txt_2.Text = "Наименование рода";
                txt_3.Text = "Количество особей";
                txt_4.Text = "Дата появления рода";
                txt_5.Visibility = Visibility.Hidden;
                txt_6.Visibility = Visibility.Hidden;
                txt_7.Visibility = Visibility.Hidden;
                txt_8.Visibility = Visibility.Hidden;
            }
            else if (i == 2)
            {

                txt_1.Text = "Номер процедуры";
                txt_2.Text = "Наименование процедуры";
                txt_3.Text = "Тип процедуры";
                txt_4.Visibility = Visibility.Hidden;
                txt_5.Visibility = Visibility.Hidden;
                txt_6.Visibility = Visibility.Hidden;
                txt_7.Visibility = Visibility.Hidden;
                txt_8.Visibility = Visibility.Hidden;
            }
            else if (i == 3)
            {
                txt_1.Text = "Номер мед.карты";
                txt_2.Text = "Номер животного";
                txt_3.Text = "Дата начала ведения";
                txt_4.Visibility = Visibility.Hidden;
                txt_5.Visibility = Visibility.Hidden;
                txt_6.Visibility = Visibility.Hidden;
                txt_7.Visibility = Visibility.Hidden;
                txt_8.Visibility = Visibility.Hidden;
            }
            else if (i == 4)
            {
                txt_1.Text = "Номер мед.истории";
                txt_2.Text = "Номер мед.карты";
                txt_3.Text = "Состояние";
                txt_4.Text = "Описание";
                txt_5.Text = "Дата начала лечения";
                txt_6.Text = "Дата конца лечения";
                txt_7.Text = "Номер процедуры";
                txt_8.Text = "Номер сотрудника";
            }
            else if (i == 5)
            {
                txt_1.Text = "Номер семьи";
                txt_2.Text = "Номер истории";
                txt_3.Text = "Номер отца";
                txt_4.Text = "Номер матери";
                txt_5.Text = "Номер ребенка";
                txt_6.Visibility = Visibility.Hidden;
                txt_7.Visibility = Visibility.Hidden;
                txt_8.Visibility = Visibility.Hidden;
            }
            
        }
    }
}
