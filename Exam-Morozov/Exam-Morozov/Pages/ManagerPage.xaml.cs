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

namespace Exam_Morozov.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        public ManagerPage()
        {
            InitializeComponent();
            CBRole.ItemsSource = App.DB.Role.ToList();
        }
        private void Refresh()
        {
            string FSP = TBFsp.Text.ToLower();
            Models.Role role = CBRole.SelectedItem as Models.Role;
            IQueryable<Models.User> filter = App.DB.User;
            if (role != null)
                filter = filter.Where(x => x.Role == role.Id);
            if (!string.IsNullOrWhiteSpace(FSP))
                filter = filter.Where(x => x.Fsp.Contains(FSP));

            DGUser.ItemsSource = filter.ToList();
        } 

        private void CBRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

     

        private void TBFsp_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void BAddUser_Click(object sender, RoutedEventArgs e)
        {
            user = new user();
            NavigationService.Navigate(new EditUserPage(user));
            Refresh();
        }

        private void BEditUser_Click(object sender, RoutedEventArgs e)
        {
            user user = DGUser.SelectedItem as user;
            if (user == null)
            {
                MessageBox.Show("Ничего не выбрано");
                return;
            }
            NavigationService.Navigate(new EditUserPage(user));
            Refresh();
        }

        private void BDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            User user = DGUser.SelectedItem as user;
            if (user == null)
            {
                MessageBox.Show("Ничего не выбрано");
                return;
            }
            App.DB.User.Remove(user);
            App.DB.SaveChanges();
            MessageBox.Show("Удалено");
        }
    }
}
