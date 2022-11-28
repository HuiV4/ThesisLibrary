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
using ThesisLibrary.Views;
using ThesisLibrary.Windows;

namespace ThesisLibrary
{
    /// <summary>
    /// Interaktionslogik für Thesis_MainWindow.xaml
    /// </summary>
    public partial class Thesis_MainWindow : Window
    {
        Student student;
        Professor prof;
        Users currentUser;
        public Thesis_MainWindow(Button sender)
        {
            InitializeComponent();

            editMenu.IsEnabled = false;
            adminMenu.IsEnabled = false;
        }
        public Thesis_MainWindow(Button sender, TextBox email, TextBox password)
        {           
            InitializeComponent();
            
            if (sender.Content.Equals("Einloggen"))
            {
                UserTB userTB = new();
                currentUser = new Users();
                int userID = userTB.GetUserID(email.Text.Trim(), password.Text.Trim());
                int userClass = userTB.GetUserClass(email.Text.Trim(), password.Text.Trim());
                

                if (email.Text == "admin" && password.Text == "admin" || userClass == 2)
                {
                    editMenu.IsEnabled = true;
                    adminMenu.IsEnabled = true;
                }
                else if (userClass == 0)
                {
                    student = new Student();
                    var students = student.LoadStudents();
                    foreach (var student in students)
                    {
                        if (student.UserID == userID)
                            currentUser = student;
                    }
                    adminMenu.IsEnabled = false;
                    requestLookUp.IsEnabled = false;
                }
                else if (userClass == 1)
                {
                    prof = new Professor();
                    var professors = prof.LoadProfessors();
                    foreach (var prof in professors)
                    {
                        if (prof.UserID == userID)
                            currentUser = prof;
                    }
                    adminMenu.IsEnabled = false;
                    addRequest.IsEnabled = false;
                }    
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
