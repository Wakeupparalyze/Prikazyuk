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
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
         public decimal Cost { get; set; }
        public string Discription { get; set; }
        public string Mark { get; set; }
        public string Country { get; set; }

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
        private void AddBackBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddCarBtn(object sender, RoutedEventArgs e)
        {
            using (var context = new PrikazyukContext())
            {
                var car = DB.Instance.Cars.FirstOrDefault(s => s.Cost == Cost && s.Discription == Discription && s.Mark == Mark && Country == Country);
                {
                    car = new Car
                    {
                        Name = CarNameTextBox.Text,
                        Cost = Cost,
                        Discription = Discription,
                        Mark = Mark,
                        Country = Country
                       
                    };
                    context.Cars.Add(car);
                    context.SaveChanges();

                    MessageBox.Show($"Экземпляр машины: {CarNameTextBox.Text} создан");
                    this.Close();
                }
            }
        }
    }
}
