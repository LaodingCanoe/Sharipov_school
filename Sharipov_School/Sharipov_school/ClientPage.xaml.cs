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

namespace Sharipov_school
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();
            var currentClient = SharipovEntities.GetContext().Clients.ToList();
            ClientLV.ItemsSource = currentClient;
            Update();
        }
        public void Update()
        {
            var currentclient = SharipovEntities.GetContext().Clients.ToList();
            if(FilterCB.SelectedIndex == 1)
            {
                currentclient = currentclient.Where(p => p.GenderCode == "м").ToList();
            }
            if (FilterCB.SelectedIndex == 2)
            {
                currentclient = currentclient.Where(p => p.GenderCode == "ж").ToList();
            }
            if (FirstNameRB != null)
            {
                if (FirstNameRB.IsChecked == true)
                {
                    currentclient = currentclient.OrderBy(p => p.FirstName).ToList();
                }
            }            
            if (DateRB != null)
            {
                if (DateRB.IsChecked == true)
                {
                    currentclient = currentclient.OrderByDescending((p) => p.Date).ToList();
                }
            }
            if (CountRB != null)
            {
                if (CountRB.IsChecked == true)
                {
                    currentclient = currentclient.OrderByDescending(p => p.PosCount).ToList();
                }
            }
            currentclient = currentclient.Where(p => p.FirstName.ToString().ToLower().Contains(SearchTB.Text.ToLower()) || p.LastName.ToLower().Contains(SearchTB.Text.ToLower())
                                                || p.Patronymic.ToLower().Contains(SearchTB.Text.ToLower()) || p.Email.ToLower().Contains(SearchTB.Text.ToLower())
                                                || p.Phone.ToLower().Replace("+","").Replace("7","").Replace("-","").Replace("(","").Replace(")","").Contains(SearchTB.Text.ToLower().Replace("+", "").Replace("7", "").Replace("-", "").Replace("(", "").Replace(")", ""))).ToList();
            if (ClientLV != null)
            {
                ClientLV.ItemsSource = currentclient;
            }
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void FilterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void FirstNameRB_Checked(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void DateRB_Checked(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void CountRB_Checked(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
