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
using System.Diagnostics;

namespace ThesisLibrary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string helpLink = "https://cm.hs-flensburg.de/qisserver/pages/cs/psv/account/passwortreset/firstpagePasswortReset.xhtml?_flowId=passwordreset-flow&_flowExecutionKey=e1s1";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnClickLogin(object sender, RoutedEventArgs e)
        {

            Thesis_MainWindow thesisMain = new Thesis_MainWindow((Button)sender);
            thesisMain.Show();
            Close();
        }

        private void OnClickQuit(object sender, RoutedEventArgs e) => Close();

        private void OnClickOpenWeb(object sender, MouseButtonEventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = helpLink,
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        //private void OnClickLoginGuest(object sender, RoutedEventArgs e)
        //{
        //    ThesisPortalMain thesisMain = new ThesisPortalMain();
        //    thesisMain.Show();
        //    Close();
        //}
    }
}
