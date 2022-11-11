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
using ThesisLibrary.DataBase;

namespace ThesisLibrary.Views
{
    /// <summary>
    /// Interaktionslogik für ModalAddUser.xaml
    /// </summary>
    public partial class ModalAddUser : Window
    {
        public ModalAddUser()
        {
            InitializeComponent();
        }

        private void OnClickClose(object sender, RoutedEventArgs e) => this.Close();

        private void OnClickUserAdd(object sender, RoutedEventArgs e)
        {
            
            string msg = $"Sind die Daten richtig?\n\n{userFirstName.Text}\n{userSurName.Text}\n{userEMail.Text}\n{userClass.SelectedItem.ToString()}";
            if(MessageBox.Show(msg,"Benutzer hinzufügen",MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)            
            {
                UserTB userTB = new UserTB();
                userTB.AddUserData(userFirstName.Text, userSurName.Text, userEMail.Text, (int)userClass.SelectedItem);
                this.Close();
            }
        }
    }
}
