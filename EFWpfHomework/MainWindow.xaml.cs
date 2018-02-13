using EFWpfHomework.Model;
using System.Linq;
using System.Windows;

namespace EFWpfHomework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MCSEntities db = new MCSEntities();

        public MainWindow()
        {
            InitializeComponent();

            TableManufacturerList.ItemsSource = db.TablesManufacturer.ToList();
        }


        private void EditBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (intManufacturerIDBox.Text == "" || strNameBox.Text == "")
            {
                MessageBox.Show("Чтобы изменить данные, выберите их из списка!");
            }
            else
            {
                TablesManufacturer tm = new TablesManufacturer();

                tm.intManufacturerID = int.Parse(intManufacturerIDBox.Text);
                tm.strManufacturerChecklistId = strManufacturerChecklistIdBox.Text;
                tm.strName = strNameBox.Text;

                db.TablesManufacturer.Add(tm);
                db.SaveChanges();
                Clear();
                MessageBox.Show("Объекты изменены");

            }
        }

        private void AddBtn_OnClick(object sender, RoutedEventArgs e)
        {
            TablesManufacturer tm = new TablesManufacturer();

            tm.intManufacturerID = int.Parse(intManufacturerIDBox.Text);
            tm.strManufacturerChecklistId = strManufacturerChecklistIdBox.Text;
            tm.strName = strNameBox.Text;

            db.TablesManufacturer.Add(tm);
            db.SaveChanges();
            Clear();
            MessageBox.Show("Объекты добавлены");

        }

        private void DeleteBtn_OnClick(object sender, RoutedEventArgs e)
        {

            //var data = db.TablesManufacturer
            //    .Where(w => w.intManufacturerID == int.Parse(intManufacturerIDBox.Text)).ToList();

            //TablesManufacturer tm = new TablesManufacturer();

            //foreach (var it in data)
            //{
            //    tm.intManufacturerID = it.intManufacturerID;
            //    tm.strManufacturerChecklistId = it.strManufacturerChecklistId;
            //    tm.strName = it.strName;
            //}




            if (intManufacturerIDBox.Text == "" || strNameBox.Text == "")
            {
                MessageBox.Show("Чтобы удалить данные, выберите их из списка!");
            }
            else
            {
                TablesManufacturer tt = db.TablesManufacturer.Find(int.Parse(intManufacturerIDBox.Text));

                db.TablesManufacturer.Remove(tt);
                db.SaveChanges();
                Clear();
                MessageBox.Show("Объекты удалены");
            }
        }


        private void Clear()
        {
            intManufacturerIDBox.Clear();
            strManufacturerChecklistIdBox.Clear();
            strNameBox.Clear();
        }
    }
}
