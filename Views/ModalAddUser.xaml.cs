using System.Collections.Generic;
using System.Windows;
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
        Department dept;
        DegreeCourse degree;
        public ModalAddUser()
        {
            InitializeComponent();
            userClass.SelectedItem = 3;
        }
        private void OnClickClose(object sender, RoutedEventArgs e) => this.Close();
        private void OnClickUserAdd(object sender, RoutedEventArgs e)
        {
            users = new Users();
            if (users.ParameterCheck(userFirstName.Text, userSurName.Text, userEMail.Text, password.Password.ToString(), passwordCheck.Password.ToString() ,userClass) == false)
                return;

            string msg = $"Sind die Daten richtig?\n\n{userFirstName.Text}\n{userSurName.Text}\n{userEMail.Text}\n{userClass.SelectedItem.ToString()}";
            if(MessageBox.Show(msg,"Benutzer hinzufügen",MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)            
            {
                UserTB userTB = new();
                userTB.AddUserData(userFirstName.Text.Trim(), userSurName.Text.Trim(), userEMail.Text.Trim(), password.Password.ToString().Trim(), (int)userClass.SelectedItem);
                int userID = userTB.GetUserID(userEMail.Text, password.Password.ToString());

                if ((string)dynamicLabel.Content == "Fachbereich")
                    userTB.AddProfessor(userID, dynamicCombobox.SelectedItem.ToString());
                else if ((string)dynamicLabel.Content == "Studiengang")
                    userTB.AddStudent(userID, dynamicCombobox.SelectedItem.ToString());

                userTB.ResetValues(userFirstName, userSurName, userEMail, password, passwordCheck, userClass, dynamicCombobox);
            }            
        }
        /// <summary>
        /// WORKTITLE!!!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLostFocusChange(object sender, RoutedEventArgs e)
        {
            dynamicLabel.Content = "";
            dynamicCombobox.IsEnabled = true;
            if (userClass.Text == "Professor")
            {
                dynamicLabel.Content = "Fachbereich";

                dept = new Department();
                List<Department> deptList = dept.LoadDepartments();
                dynamicCombobox.ItemsSource = deptList;
            }
            else if (userClass.Text == "Student")
            {
                dynamicLabel.Content = "Studiengang";

                degree = new DegreeCourse();
                List<DegreeCourse> degreeList = degree.LoadDegreeCourses();
                dynamicCombobox.ItemsSource = degreeList;
            }
            else
            {
                dynamicLabel.Content = "Keine Auswahl";
                dynamicCombobox.IsEnabled = false;
            }
        }  
    }
}
