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

namespace YP01Telekom
{
    /// <summary>
    /// Логика взаимодействия для InfoWindows.xaml
    /// </summary>
    public partial class InfoWindows : Window
    {
        Worker worker;
        List<string> users = new List<string>();
        public InfoWindows(Worker pworker)
        {
            InitializeComponent();
            worker = pworker;

            DataContext = this;

            var usr = AppD.db.Worker.ToList();
            foreach (var item in usr)
            {
                string userss = item.Worker_Name;
                users.Add(userss);
            }
            CBoxNameWolker.ItemsSource = users;

            CBoxNameWolker.SelectedIndex = 2;

            string photo = "ID" + worker.Id_Worker.ToString() + ".jpg";
            BitmapImage bi = new BitmapImage(new Uri(photo, UriKind.RelativeOrAbsolute));
            ImageWolker.Source = bi;


        }
        /// <summary>
        /// Загрузка данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DGridPr.ItemsSource = AppD.db.Contract.ToList();
            DGridPrr.ItemsSource = AppD.db.Events.Where(u => u.Id_Role == worker.Role).ToList();
            if(worker.Role == 1)
            {
                BntYOS.Visibility = Visibility.Collapsed;
                BntActS.Visibility = Visibility.Collapsed;
                BntPPS.Visibility = Visibility.Collapsed;
            }
            else if (worker.Role == 2)
            {
                BntYOS.Visibility = Visibility.Collapsed;
                BntActS.Visibility = Visibility.Collapsed;
                BntPPS.Visibility = Visibility.Collapsed;
                BntBilS.Visibility = Visibility.Collapsed;
            }
            else if (worker.Role == 3 || worker.Role == 4)
            {
                BntActS.Visibility = Visibility.Collapsed;
                BntBilS.Visibility = Visibility.Collapsed;
            }
            else if (worker.Role == 5)
            {
                BntYOS.Visibility = Visibility.Collapsed;
                BntCRMS.Visibility = Visibility.Collapsed;
                BntPPS.Visibility = Visibility.Collapsed;
            }
            else if (worker.Role == 7)
            {
                BntBilS.Visibility = Visibility.Collapsed;
                BntPPS.Visibility = Visibility.Collapsed;
            }
        }

        private void TBlocNameWolker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string photo = "ID" + worker.Id_Worker.ToString() + ".jpg";
            BitmapImage bi = new BitmapImage(new Uri(photo, UriKind.RelativeOrAbsolute));
            ImageWolker.Source = bi;
        }

        private void BntAbo_Click(object sender, RoutedEventArgs e)
        {
            AbonentWin aw = new AbonentWin(worker);
            aw.Show();
        }

        private void BntYO_Click(object sender, RoutedEventArgs e)
        {
            YprEqu yprEqu = new YprEqu();
            yprEqu.Show();
        }

        private void BntAct_Click(object sender, RoutedEventArgs e)
        {
            ActiveWin activeWin = new ActiveWin();
            activeWin.Show();
        }

        private void BntBil_Click(object sender, RoutedEventArgs e)
        {
            Billing billing = new Billing();
            billing.Show();
        }

        private void BntPP_Click(object sender, RoutedEventArgs e)
        {
            PUser pUser = new PUser();
            pUser.Show();
        }

        private void BntCRM_Click(object sender, RoutedEventArgs e)
        {
            CRM cRM = new CRM(worker);
            cRM.Show();
            this.Close();
        }
    }
}
