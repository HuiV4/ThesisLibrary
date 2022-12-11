using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ThesisLibrary.DataBase;
using ThesisLibrary.DataModel;

namespace ThesisLibrary.Views
{
    /// <summary>
    /// Interaktionslogik für LookUpThesisReq.xaml
    /// </summary>
    public partial class LookUpThesisReq : Window
    {
        Professor currentUser;
        /// <summary>
        /// With the initialization of the window, a list of all theses which correspond with the current PorfID of the current User
        /// </summary>
        /// <param name="currentUser">The current professor logged in</param>
        public LookUpThesisReq(Professor currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;

            Thesis theses = new();
            if (thesisListBox == null)
                return;
            List<Thesis> thesesList =  theses.LoadThesisList();
            foreach(Thesis thesis in thesesList)
            {
                if (thesis.Status == 4)
                    thesisListBox.Items.Remove(thesis);
                else if(thesis.ProfessorID == currentUser.ProfessorID)
                    thesisListBox.Items.Add(thesis);
            }
            thesisListBox.SelectedIndex = 0;
        }
        /// <summary>
        /// Foreach item in the Listbox the specific information shall be displayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSelectChangeValues(object sender, SelectionChangedEventArgs e)
        {
            Student students = new();
            Thesis selThesis = (Thesis)thesisListBox.SelectedItem;
            List<Users> studentList = students.LoadStudents();
            foreach (Student student in studentList)
            {       
                if (selThesis.StudentID == student.StudentID)
                    studentStack.DataContext = student;
                continue;
            }
            thesisSatck.DataContext = (Thesis)thesisListBox.SelectedItem;
        }
        private void OnClickClose(object sender, RoutedEventArgs e) => this.Close();
        /// <summary>
        /// Updating the information of that specific thesis in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickAccept(object sender, RoutedEventArgs e)
        {
            string formattedStart = "";
            string formattedSubmit = "";
            Thesis thesis = (Thesis)thesisListBox.SelectedItem;

            DateTime? selectedStartDate = startDate.SelectedDate;
            if (selectedStartDate.HasValue)
                formattedStart = selectedStartDate.Value.ToString("yyyy-MM-dd"); //string format that is valid with the date type of SQLite

            DateTime? selectedSubmitDate = submissionDate.SelectedDate;
            if (selectedSubmitDate.HasValue)
                formattedSubmit = selectedSubmitDate.Value.ToString("yyyy-MM-dd"); //string format that is valid with the date type of SQLite
            int status = (int)statusBox.SelectedItem;
            int thesisID = thesis.ThesisID;

            ThesisDB tDB= new();
            tDB.UpdateThesisData(thesisID, formattedStart, formattedSubmit, status);
        }
        /// <summary>
        /// Thesis cannot be accepted, when fields are empty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSelectActivateAccept(object sender, RoutedEventArgs e)
        {
            if (currentStatus.Text == "0")
            {
                if (statusBox.SelectedItem != null && startDate.SelectedDate != null! & submissionDate.SelectedDate != null)
                {
                    acceptButton.IsEnabled = true;
                    hintBox.Visibility = Visibility.Hidden;
                }
                else
                    hintBox.Visibility = Visibility.Visible;
            }
        }
        /// <summary>
        /// This function does not exist yet, since an implemented mail service is required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickDecline(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Diese Funktion ist über diesen Button noch nicht integriert!");
        }
    }
}
