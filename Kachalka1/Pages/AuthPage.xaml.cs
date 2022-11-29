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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTb.Text.Trim().Length <= 0 || PasswordTb.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Заполните поля");
            }
            else
            {
                Navigation.AutorizateUser = DBConnect.db.User.ToList().Find(x => x.Login == LoginTb.Text && x.Password == PasswordTb.Text);

                if (Navigation.AutorizateUser == null)
                {
                    MessageBox.Show("Такого пользователя нет");
                }
                else
                {

                    Navigation.IsAutorizate = true;
                    Navigation.Update(new ServicePage());
                }
            }

        }
    }
}
