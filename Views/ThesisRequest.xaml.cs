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

namespace ThesisLibrary.Windows
{
    /// <summary>
    /// Interaktionslogik für ThesisRequest.xaml
    /// </summary>
    public partial class ThesisRequest : Window
    {
        Department dept;
        DegreeCourse degree;
        Professor prof;
        Student currentUser;
        public ThesisRequest(Student currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            degree = new DegreeCourse();
            List<DegreeCourse> degreeList = degree.LoadDegreeCourses();
            dept = new Department();
            List<Department> deptList = dept.LoadDepartments();
            prof = new Professor();
            profBox.ItemsSource = prof.LoadProfessors();
            courseBox.ItemsSource = degreeList;
            deptBox.ItemsSource = deptList;
            generalInputs.DataContext= currentUser;
            foreach (var item in courseBox.Items)
            {
                if(currentUser.DegreeName == item.ToString())
                    courseBox.SelectedItem = item;
                continue;
            }
        }
        private void OnClickClose(object sender, RoutedEventArgs e) => this.Close();

        private void OnClickSubmit(object sender, RoutedEventArgs e)
        {
            try
            {
                int privacy = 0;
                string[] keywords = { keyword1.Text.Trim(), keyword2.Text.Trim(), keyword3.Text.Trim(), keyword4.Text.Trim(), keyword5.Text.Trim() };
                Professor prof = (Professor)profBox.SelectedItem;
                if (privacyCheck.IsChecked == true)
                    privacy = 1;

                ThesisDB tDB = new();
                tDB.AddThesisData(thesisTitel.Text.Trim(), thesisAbstract.Text.Trim(), keywords, currentUser.StudentID, prof.ProfessorID, typeOfThesisBox.SelectedIndex, privacy);

                MessageBox.Show("Anfrage wurde erfolgreich gespeichert");

                this.Close();
            }
            catch (NullReferenceException ex)
            { MessageBox.Show($"Bitte füllen sie alle Felder aus!\n{ex.Message}"); }
        }

        private void OnChangeSetDept(object sender, SelectionChangedEventArgs e)
        {
            Professor selectedProf = (Professor)profBox.SelectedItem;
            foreach (var item in deptBox.Items)
            {
                if (selectedProf.DepartmentName == item.ToString())
                    deptBox.SelectedItem = item;
                continue;
            }
        }
    }
}
