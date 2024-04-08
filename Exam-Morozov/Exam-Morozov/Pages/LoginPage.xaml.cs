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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Exam_Morozov.Models;

namespace Exam_Morozov.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            TBlogin.Focus();
        }

        private void BLogin_Click(object sender, RoutedEventArgs e)
        {
            User user = App.DB.User.FirstOrDefault(x => x.Login == TBlogin.Text && x.Password == TBPassword.Text && x.Secretword == TBSecretW.Text);
            if (user == null)
            {
                MessageBox.Show("Невеный логин или пароль или секретное слово");
                return;
            }
            App.Logineduser = user;
            NavigationService.Navigate(new ManagerPage());
        }
    }
}
