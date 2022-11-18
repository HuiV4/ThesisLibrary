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
using ThesisLibrary.DataModel;
using ThesisLibrary.Views;
using ThesisLibrary.Windows;

namespace ThesisLibrary
{
    /// <summary>
    /// Interaktionslogik für Thesis_MainWindow.xaml
    /// </summary>
    public partial class Thesis_MainWindow : Window
    {
        public Thesis_MainWindow(Button sender)
        {           
            InitializeComponent();

            if (sender.Content.Equals("Gastanmeldung"))
            {
                editMenu.IsEnabled = false;
                adminMenu.IsEnabled = false;
            }
            Admin admin = new();
            if (Test == null)
                return;
            Test.ItemsSource = admin.LoadAdmins();
        }

        private void OnClickClose(object sender, RoutedEventArgs e) => Close();
        private void OnCLickLogout(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new();
            this.Close();
            mw.Show();
        }
        private void OnCLickAddThesis(object sender, RoutedEventArgs e)
        {
            ThesisRequest tr = new();
            tr.ShowDialog();
        }

        private void OnClickAddUser(object sender, RoutedEventArgs e)
        {
            ModalAddUser mad = new();
            mad.ShowDialog();
        }
    }
}
