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
using ThesisLibrary.DataModel;

namespace ThesisLibrary.Views
{
    /// <summary>
    /// Interaktionslogik für ModalAddUser.xaml
    /// </summary>
    public partial class ModalAddUser : Window
    {
        Users users;
        public ModalAddUser()
        {
            InitializeComponent();
        }

        private void OnClickClose(object sender, RoutedEventArgs e) => this.Close();

        private void OnClickUserAdd(object sender, RoutedEventArgs e)
        {
            users = new Users();
            if (users.ParameterCheck(userFirstName.Text, userSurName.Text, userEMail.Text, password.Text, userClass) == false)
                return;

            string msg = $"Sind die Daten richtig?\n\n{userFirstName.Text}\n{userSurName.Text}\n{userEMail.Text}\n{userClass.SelectedItem.ToString()}";
            if(MessageBox.Show(msg,"Benutzer hinzufügen",MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)            
            {
                UserTB userTB = new();
                userTB.AddUserData(userFirstName.Text.Trim(), userSurName.Text.Trim(), userEMail.Text.Trim(), password.Text.Trim(), (int)userClass.SelectedItem) ;
                userFirstName.Clear();
                userSurName.Clear();
                userEMail.Clear();
                password.Clear();
            }            
        }
    }
}
