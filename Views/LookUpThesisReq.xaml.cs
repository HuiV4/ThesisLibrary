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

namespace ThesisLibrary.Views
{
    /// <summary>
    /// Interaktionslogik für LookUpThesisReq.xaml
    /// </summary>
    public partial class LookUpThesisReq : Window
    {
        public LookUpThesisReq(Users currentUser)
        {
            InitializeComponent();
        }
    }
}
