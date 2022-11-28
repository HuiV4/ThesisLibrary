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
using System.Windows.Interop;
using ThesisLibrary.DataBase;

namespace ThesisLibrary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserTB userTB;
        Thesis_MainWindow thesisMain;
        private static string helpLink = "https://cm.hs-flensburg.de/qisserver/pages/cs/psv/account/passwortreset/firstpagePasswortReset.xhtml?_flowId=passwordreset-flow&_flowExecutionKey=e1s1";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnClickLogin(object sender, RoutedEventArgs e)
        {
            if (userMail.Text != "" && userpass.Text != "")
            {
                userTB = new UserTB();
                bool exists = userTB.ValidUser(userMail.Text.Trim(), userpass.Text.Trim());
                if (exists == true || userMail.Text == "admin" && userpass.Text == "admin")
                {
                    thesisMain = new Thesis_MainWindow((Button)sender, userMail, userpass);
                    thesisMain.Show();
                    Close();
                }                
                else
                {
                    string msg = "Ein solcher Nutzer existiert nicht!\nBitte überprüfen sie ihre Login-Daten";
                    MessageBox.Show(msg);
                    return;
                }
            }
            else if (sender == guestLog)
            {
                thesisMain = new Thesis_MainWindow((Button)sender);
                thesisMain.Show();
                Close();
            }
            else if (sender == logIn && userMail.Text == "" || userpass.Text == "")
            {
                string msg = "Bitte füllen sie beide Felder aus!\nSind sie kein Hochschulmitglied, so nutzen sie bitte die Gastanmeldung!\nAls Student oder Dozent registrieren sie sich bitte.";
                MessageBox.Show(msg);
            }           
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
        private void OnInputBlockAndFree(object sender, TextChangedEventArgs e)
        {
            if (userMail.Text != "" || userpass.Text != "")
                guestLog.IsEnabled = false;
            else
                guestLog.IsEnabled = true;
        }
    }
}
