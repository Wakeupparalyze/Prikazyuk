using System;
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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window 
    {
        private List<Car> cars;
        public UserWindow()
        {
            InitializeComponent();
            GetCars();
            DataContext = this;
        }
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

        private void UserBack(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}