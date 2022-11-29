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
        public ThesisRequest(Users currentUser)
        {
            InitializeComponent();
            degree = new DegreeCourse();
            List<DegreeCourse> degreeList = degree.LoadDegreeCourses();
            dept = new Department();
            List<Department> deptList = dept.LoadDepartments();
            prof = new Professor();
            profBox.ItemsSource = prof.LoadProfessors();
            courseBox.ItemsSource = degreeList;
            deptBox.ItemsSource = deptList;
            generalInputs.DataContext= currentUser;
        }
        private void OnClickClose(object sender, RoutedEventArgs e) => this.Close();

        private void OnClickSubmit(object sender, RoutedEventArgs e)
        {

        }
    }
}
