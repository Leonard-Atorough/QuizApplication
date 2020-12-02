using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QuizApplicationBusinessLayer;
using QuizApplicationModel;

namespace QuizApplicationGUI.Pages
{
    /// <summary>
    /// Interaction logic for TeacherMain.xaml
    /// </summary>
    public partial class TeacherMain : Page
    {
        CRUDManager _crudManager = new CRUDManager();
        public TeacherMain()
        {
            InitializeComponent();
            ListAllStudents();
            ListAssignedStudents();
        }

        private void ListAllStudents()
        {
            AllStudentsBox.ItemsSource = _crudManager.ListAllStudents();
        }

        private void ListAssignedStudents()
        {
            string username = (string)Application.Current.Properties["username"];
            AssignedStudentsBox.ItemsSource = _crudManager.ListAssignedStudents(username);
        }
    }
}
