using Kachalka1.Components;
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

namespace Kachalka1.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        public ServicePage()
        {
            InitializeComponent();
            ServiceList.ItemsSource = DBConnect.db.ListEx.ToList();
            if (Navigation.AutorizateUser.RoleId == 1)
            {
                RoleTxt.Text = "Щегол";
                DBConnect.db.SaveChanges();
            }
            if (Navigation.AutorizateUser.RoleId == 2)
            {
                RoleTxt.Text = "Мастер";
                DBConnect.db.SaveChanges();
            }
            if (Navigation.AutorizateUser.RoleId == 3)
            {
                RoleTxt.Text = "Доставщик";
                DBConnect.db.SaveChanges();
            }


        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectEx = (sender as Button).DataContext as ListEx;
            if (Navigation.AutorizateUser.Xp == null)
                Navigation.AutorizateUser.Xp = 0;

            Navigation.AutorizateUser.Xp += selectEx.Xp;

            var buf = $"{Navigation.AutorizateUser.Name} = {Navigation.AutorizateUser.Xp}";

            if (Navigation.AutorizateUser.Xp == 100)
            {
                Navigation.AutorizateUser.RoleId = 2;
                MessageBox.Show("Вы мастер");
            }
            else if (Navigation.AutorizateUser.Xp == 500)
            {
                Navigation.AutorizateUser.RoleId = 3;
                MessageBox.Show("Вы доставщик");
            }

            MessageBox.Show(buf);
            DBConnect.db.SaveChanges();

        }
    }
}
