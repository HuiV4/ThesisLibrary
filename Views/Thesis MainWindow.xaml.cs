using System.Windows;
using System.Windows.Controls;
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

            Thesis thesis = new();
            if (thesisListBox == null)
                return;
            this.DataContext = thesis.LoadThesisList();
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
                

                if (userClass == 2)
                {
                    editMenu.IsEnabled = false;
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
                        continue;
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
                        continue;
                    }
                    adminMenu.IsEnabled = false;
                    addRequest.IsEnabled = false;
                }    
            }

            Thesis thesis = new();
            if (thesisListBox == null)
                return;
            this.DataContext = thesis.LoadThesisList();
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
            ThesisRequest tr = new((Student)currentUser);
            tr.ShowDialog();
        }
        private void OnClickAddUser(object sender, RoutedEventArgs e)
        {
            ModalAddUser mad = new();
            mad.ShowDialog();
        }
        private void OnSelectChangeValues(object sender, SelectionChangedEventArgs e)
        {
            dynamicDock.DataContext = (Thesis)thesisListBox.SelectedItem;
            dynamicTitle.DataContext = (Thesis)thesisListBox.SelectedItem;
        }
        private void OnClickLookUp(object sender, RoutedEventArgs e)
        {
            LookUpThesisReq lutr = new((Professor)currentUser);
            lutr.ShowDialog();
        }
    }
}
