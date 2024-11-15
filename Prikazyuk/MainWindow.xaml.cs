using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prikazyuk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        public string Login { get; set; }
        public string Password { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void SignalChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        private void Auth(object sender, RoutedEventArgs e)
        {
            var user = DB.Instance.Users.FirstOrDefault(s => s.Login == Login && s.Password == Password);
            if (user != null)
            {
                if (user.RoleId == 1)
                {
                    UserWindow userWindow = new UserWindow();
                    userWindow.Show();
                    this.Close();
                }

                else if (user.RoleId == 2)
                {
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void RegisterBtn(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
        }
    }
}