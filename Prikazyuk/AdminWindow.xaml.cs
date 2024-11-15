using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Prikazyuk
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            DataContext = this;
            GetCars();
        }

        private List<Car> cars;
        public List<Car> Cars
        {
            get => cars;
            set
            {
                cars = value;
                PropertyChanged?.Invoke(this, new PropertyChangingEventArgs(nameof(cars)));
            }
        }
        public event PropertyChangingEventHandler? PropertyChanged;
        public List<Car> GetCars()
        {
            Cars = DB.Instance.Cars.ToList();
            return Cars;
        }

        private void AdminBack(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void AddBtn(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Show();
        }

        private void DeleteBtn(object sender, RoutedEventArgs e)
        {
            //Не работает(((
            if (CarListView.SelectedItems.Count > 0)
            {
                CarListView.Items.Remove(CarListView.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("Выберите машину для удаления.");
            }
        }
    }
}