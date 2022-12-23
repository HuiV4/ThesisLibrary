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

        private void OnClickOpenHelp(object sender, RoutedEventArgs e)
        {
            if (sender == visitorHelp)
            {
                MessageBox.Show("Als Gast können die den 'Thesis-Browser benutzen',\ndie Kurzbeschreibung einsehen und welcher Dozent die\nausgewählte Thesis betreut hat.\n\n" +
                                "In zukunft wird es möglich sein, sich die Thesis als PDF herunterzuladen,\ndies muss der Student allerdings erlaubt haben!\n" +
                                "Des Weiteren folgt in Zukunft auch die Filterfunktion!");
            }
            else if (sender == studentHelp)
            {
                MessageBox.Show("Als Student können sie die gewälte Thesis ihrer Kommilitonen begutachten!\nEs ist immer sichtbar, aus welchem Fachberich diese Arbeit stammt,\n" +
                                "unter welchem Studiengang und welcher Professor die Thesis betreut hat.\nSomit soll es ihnen in Zukunft leichter fallen Inspiration und den richtigen Ansprechpartner zu finden.\n" +
                                "Des Weiteren können sie über das Menü 'Bearbeiten'" +
                                "die Anfrage für eine Thesis stellen, wenn ihnen diese bevorsteht.\n\nDie Filterfunktion wird in Zukunft folgen!");
            }
            else if (sender == professorHelp)
            {
                MessageBox.Show("Für sie gelten die gleichen Grundfunktionalitäten wie für den Gast,\nbitte lesen sie sich daher diese Info bitte noch durch!" +
                                "Sie als Professor sind dazu befugt, sich alle Thesis-Anfragen anzusehen,\ndie an sie gerichtet worden sind." +
                                "Bis dato sind sie leider nur in der Lage, die Anfrage anzunehmen.\n\nFür das ablehnen benötigen sie die Hilfe eines Datenbank-Admins.\n" +
                                "Die Funktion wird ihnen aber in Zukunft so zur verfügung stehen,\nsodass sie dies selbstständig erledigen können.");
            }
            else
            {
                MessageBox.Show("Für sie gelten die gleichen Grundfunktionalitäten wie für den Gast,\nbitte lesen sie sich daher diese Info bitte noch durch!" +
                                "Des Weitern sind sie dazu berechtigt, Nutzer in das System zu pflegen!\nDiese Funktion steht ihnen unter dem Menü 'Verwalten' zu verfügung\n\n" +
                                "In Zukunft werden ihnen weiter Funktionalitäten zur Verfügung stehen!");
            }

        }
    }
}
