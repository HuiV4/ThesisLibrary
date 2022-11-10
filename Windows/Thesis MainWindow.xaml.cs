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
using ThesisLibrary.Windows;

namespace ThesisLibrary
{
    /// <summary>
    /// Interaktionslogik für Thesis_MainWindow.xaml
    /// </summary>
    public partial class Thesis_MainWindow : Window
    {
        public Thesis_MainWindow()
        {
            InitializeComponent();
        }

        private void OnClickClose(object sender, RoutedEventArgs e) => Close();
        private void OnCLickLogout(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            mw.Show();
        }
        private void OnCLickAddThesis(object sender, RoutedEventArgs e)
        {
            ThesisRequest tr = new ThesisRequest();
            tr.Show();
            this.Close();
        }
    }
}
