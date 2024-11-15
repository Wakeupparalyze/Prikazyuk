using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string Login { get; set; }
        public string Password { get; set; }

        private void RegisterBackBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RegisterBtn(object sender, RoutedEventArgs e)
        {
            using (var context = new PrikazyukContext())
            {
                var user = DB.Instance.Users.FirstOrDefault(s => s.Login == Login && s.Password == Password && s.Name == Name);
                {
                    user = new User
                    {
                        Name = NameTextBox.Text,
                        Login = Login,
                        Password = Password,
                        RoleId = 1
                    };
                    context.Users.Add(user);
                    context.SaveChanges();

                    MessageBox.Show($"Пользователь: {NameTextBox.Text} зарегистрирован");
                    this.Close();
                }
            }
        }
    }
}
