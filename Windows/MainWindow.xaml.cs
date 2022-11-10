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

namespace ThesisLibrary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnClickLogin(object sender, RoutedEventArgs e)
        {
            Thesis_MainWindow thesisMain = new Thesis_MainWindow();
            thesisMain.Show();
            Close();
        }

        private void OnClickQuit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private void OnClickLoginGuest(object sender, RoutedEventArgs e)
        //{
        //    ThesisPortalMain thesisMain = new ThesisPortalMain();
        //    thesisMain.Show();
        //    Close();
        //}
    }
}
