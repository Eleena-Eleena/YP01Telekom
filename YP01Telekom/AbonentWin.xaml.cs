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
    /// Логика взаимодействия для AbonentWin.xaml
    /// </summary>
    public partial class AbonentWin : Window
    {
        Worker worker;
        public AbonentWin(Worker pworker)
        {
            InitializeComponent();
            worker = pworker;
        }
        /// <summary>
        /// Вывод полной информации о клиенте
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BntEdit_Click(object sender, RoutedEventArgs e)
        {
            var CurrentUser = DGridPr.SelectedItem as Contract;

            TBlockNumAbo.Text = CurrentUser.Clients.Id_Client;
            TBlockFIO.Text = CurrentUser.Clients.FIO_Client;
            TBlockSerPas.Text = CurrentUser.Clients.Passport_Code;
            TBlockNumPas.Text = CurrentUser.Clients.Passport_Number;
            TBlockByPas.Text = CurrentUser.Clients.Passport_Issued_By;
            TBlockDataPas.Text = CurrentUser.Clients.Passport_Date.ToString();

            TBlockNumCont.Text = CurrentUser.Number_Contract;
            TBlockDataCont.Text = CurrentUser.Date_Contract.ToString();
            TBlockDataContD.Text = CurrentUser.Date_Dis_Contract.ToString();
            TBlockReason.Text = CurrentUser.Reason_Dis;
            TBlockLC.Text = CurrentUser.Personal_Account;
            TBlockAddress.Text = CurrentUser.Clients.Address;
            TBlockServis.Text = CurrentUser.Services.Name;
            TBlockEq.Text = CurrentUser.Equipment;
        }
        /// <summary>
        /// ЗАгрузка данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DGridPr.ItemsSource = AppD.db.Contract.ToList();
            if (worker.Role == 1)
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
            CRM cRM = new CRM();
            cRM.Show();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            InfoWindows infoWindows = new InfoWindows(worker);
            this.Close();
            infoWindows.Show();
        }
    }
}
