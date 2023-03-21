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
    /// Логика взаимодействия для CRM.xaml
    /// </summary>
    public partial class CRM : Window
    {
        Worker worker;
        public CRM(Worker pworker)
        {

            InitializeComponent();
            worker = pworker;
        }

        private void BntAbo_Click(object sender, RoutedEventArgs e)
        {
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
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
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
            SPReq.Visibility = Visibility.Hidden;
        }

        private void BtnFind_Click(object sender, RoutedEventArgs e)
        {
            var cur = AppD.db.Contract.FirstOrDefault(u => u.Clients.Phone == TBlockPhone.Text);
            if (cur != null)
            {
                SPReq.Visibility = Visibility.Visible;
                var curE = AppD.db.Equipment.FirstOrDefault(u => u.Id_Equipments == cur.Equipment);
                TBlockNumAbo.Text = cur.Id_client;
                TBlockFIO.Text = cur.Clients.FIO_Client;
                TBlockPP.Text = cur.Personal_Account;
                TBlockStatus.Text = "Новый";
                TBlockTypeEq.Text = curE.Types.Type;
                TBlockDateCreate.Text = DateTime.Now.ToString();
                TBlockServ.Text = cur.Services.Name;
            }
          else
            {
                MessageBox.Show("Такого абонента нет");
                SPReq.Visibility = Visibility.Hidden;
            }

        }
    }
}
