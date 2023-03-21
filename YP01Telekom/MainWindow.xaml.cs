using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.RightsManagement;
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
using System.Windows.Threading;

namespace YP01Telekom
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int i = 10;
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        DispatcherTimer diTi = new DispatcherTimer();
        Worker CuttenClient;
        string code;

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            TBoxIdWorker.Clear();
            TBoxPasswordWorker.Clear();
            TBoxCodeWorker.Clear();
        }
        /// <summary>
        /// Вход в систему через кнопку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnJoin_Click(object sender, RoutedEventArgs e)
        {
            if (TBoxCodeWorker.Text.Length <= 0)
            {
                MessageBox.Show("Введите код");
            }
            else
            {
                if (code == TBoxCodeWorker.Text)
                {
                    InfoWindows iw = new InfoWindows(CuttenClient);
                    string role = CuttenClient.Roles.Role;
                    MessageBox.Show("Вы вошли под ролью " + role);
                    dispatcherTimer.Tick -= new EventHandler(DisTimer_Tick1);
                    diTi.Stop();
                    this.Close();
                    iw.Show();
                }
                else
                {
                    MessageBox.Show("Код неверный");
                    ImageCode.Visibility = Visibility.Visible;
                }
            }
        }
        /// <summary>
        /// Работа с номером пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TBoxIdWorker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (TBoxIdWorker.Text.Length <= 0)
                {
                    MessageBox.Show("Введите номер");
                }
                else
                {
                    CuttenClient = AppD.db.Worker.FirstOrDefault(u => u.Id_Worker.ToString() == TBoxIdWorker.Text.Trim());
                    if (CuttenClient != null)
                    {
                        TBoxPasswordWorker.IsEnabled = true;
                        Keyboard.Focus(TBoxPasswordWorker);
                    }
                    else
                    {
                        MessageBox.Show("Такого номера нет.");
                    }
                }
            }
        }
        /// <summary>
        /// Работа с паролем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TBoxPasswordWorker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if(TBoxPasswordWorker.Password.Length <= 0)
                {
                    MessageBox.Show("Введите пароль");
                }
                else
                {
                    if (CuttenClient.Password == TBoxPasswordWorker.Password && CuttenClient.Id_Worker.ToString() == TBoxIdWorker.Text)
                    {
                        BtnJoin.IsEnabled = true;
                        TBoxCodeWorker.IsEnabled = true;
                        code = RANDOM();
                        MessageBox.Show(code, "Код");
                        Keyboard.Focus(TBoxCodeWorker);

                        dispatcherTimer.Interval = new TimeSpan(0, 0, 15);
                        diTi.Interval = TimeSpan.FromSeconds(1);
                        diTi.Tick += timer1;
                        dispatcherTimer.Tick += new EventHandler(DisTimer_Tick1);
                        diTi.Start();
                        dispatcherTimer.Start();
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль");
                        TBoxPasswordWorker.Clear();
                    }
                }

            }
        }
        /// <summary>
        /// Генератор кода
        /// </summary>
        /// <returns></returns>
        private string RANDOM()
        {
            String allowchar = " ";
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "!,@,#,$,%,^,&,*";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            String[] ar = allowchar.Split(a);
            String pwd = "";
            string temp = "";
            Random randomSym = new Random();
            Random rA = new Random();
            for (int i = 0; i < rA.Next(8,8); i++)
            {
                temp = ar[randomSym.Next(0, ar.Length)];
                pwd += temp;
            }
            return pwd;
        }
        /// <summary>
        /// Работа с кодом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TBoxCodeWorker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (TBoxCodeWorker.Text.Length <= 0)
                {
                    MessageBox.Show("Введите код");
                }
                else
                {
                    if (code == TBoxCodeWorker.Text)
                    {
                        InfoWindows iw = new InfoWindows(CuttenClient);
                        string role = CuttenClient.Roles.Role;
                        MessageBox.Show("Вы вошли под ролью " + role);
                        dispatcherTimer.Tick -= new EventHandler(DisTimer_Tick1);
                        diTi.Stop();
                        this.Close();
                        iw.Show();
                    }
                    else
                    {
                        MessageBox.Show("Код неверный");
                        TBoxCodeWorker.Clear();
                        ImageCode.Visibility = Visibility.Visible;
                    }
                }
            }
        }
        private void timer1(object sender, EventArgs e)
        {
            if (i != 0)
            {
                i--;
            }
            else
            {
                MessageBox.Show("Время вышло");
                dispatcherTimer.Tick -= new EventHandler(DisTimer_Tick1);
                diTi.Stop();
                ImageCode.Visibility = Visibility.Visible;
            }
        }
        private void DisTimer_Tick1(object sender, EventArgs e)
        {
            dispatcherTimer.Tick -= new EventHandler(DisTimer_Tick1);
        }
        /// <summary>
        /// Обновление кода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageCode_MouseDown(object sender, MouseButtonEventArgs e)
        {
            code = RANDOM();
            MessageBox.Show(code, "Код");
            TBoxIdWorker.Clear();
            TBoxPasswordWorker.Clear();
            TBoxCodeWorker.Clear();

            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            diTi.Interval = TimeSpan.FromSeconds(1);
            diTi.Tick += timer1;
            dispatcherTimer.Tick += new EventHandler(DisTimer_Tick1);
            diTi.Start();
            dispatcherTimer.Start();
        }
    }
}
