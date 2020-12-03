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
//using System.Windows.Forms;
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
        string username;

        public TeacherMain()
        {
            InitializeComponent();
            ListAllStudents();
            
        }

        public TeacherMain(string userFromLogin):this()
        {
            username = userFromLogin;
            ListAssignedStudents(username);
        }

        private void ListAllStudents()
        {
            AllStudentsBox.ItemsSource = _crudManager.ListAllStudents();
        }

        private void ListAssignedStudents(string username)
        {
            AssignedStudentsBox.ItemsSource = _crudManager.ListAssignedStudents(username);
        }


        private void Student_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(this);
        }


        private void Remove_Student_Click(object sender, RoutedEventArgs e)
        {
            if (AssignedStudentsBox.SelectedItem != null)
            {
                _crudManager.RemoveStudentFromList(AssignedStudentsBox.SelectedItem.ToString(), username);
                ListAssignedStudents(username);
            }
            else
            {
                MessageBox.Show("Select a valid student.");
            }
        }

        private void Add_Student_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AllStudentsBox.SelectedItem != null && !AssignedStudentsBox.Items.Contains(AllStudentsBox.SelectedItem))
                {
                    _crudManager.AddStudentToList(AllStudentsBox.SelectedItem.ToString(), username);
                    ListAssignedStudents(username);
                }
                else
                {
                    MessageBox.Show("Select a valid student.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void StudentSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(StudentSearchBox.Text))
            {
                AllStudentsBox.ItemsSource = _crudManager.SearchForStudentsInList(StudentSearchBox.Text);
            }
            else
            {
                ListAllStudents();
            }
        }

        private void Questions_Button_Click(object sender, RoutedEventArgs e)
        {
            TeacherPages.QuestionPage questionPage = new TeacherPages.QuestionPage(username);
            this.NavigationService.Navigate(questionPage);
        }

        //private void AssignedStudentsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

    }
}
