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
    /// Логика взаимодействия для Billing.xaml
    /// </summary>
    public partial class Billing : Window
    {
        public Billing()
        {
            InitializeComponent();
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
            CRM cRM = new CRM();
            cRM.Show();
        }
    }
}
