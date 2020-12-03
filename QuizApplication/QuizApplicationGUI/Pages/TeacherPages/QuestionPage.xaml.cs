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

namespace QuizApplicationGUI.Pages.TeacherPages
{
    /// <summary>
    /// Interaction logic for QuestionPage.xaml
    /// </summary>
    public partial class QuestionPage : Page
    {
        CRUDManager _crudManager = new CRUDManager();
        string name = "";
        public QuestionPage()
        {
            InitializeComponent();
        }

        public QuestionPage(string userFromLogin):this()
        {
            name = userFromLogin;
            ListQuestions(name);
        }

        private void ListQuestions(string username)
        {
            QuestionsListBox.ItemsSource = _crudManager.ListAllQuestions(username);
        }

        private void CreateQuestion_Checked(object sender, RoutedEventArgs e)
        {
            UpdateQuestion.IsChecked = false;
            CreateBorder.Background = Brushes.Gray;
            QuestionBox.Visibility = Visibility.Visible;
            QuestionBox.IsManipulationEnabled = true;
            QuestionBox.Text = "";
            DeleteBorder.Visibility = Visibility.Hidden;
            SaveChangesBorder.Visibility = Visibility.Visible;
            SaveChanges.IsManipulationEnabled = true;
        }
        private void CreateQuestion_UnChecked(object sender, RoutedEventArgs e)
        {
            CreateBorder.Background = Brushes.White;
            QuestionBox.Visibility = Visibility.Hidden;
            QuestionBox.IsManipulationEnabled = false;
            DeleteBorder.Visibility = Visibility.Visible;
            SaveChangesBorder.Visibility = Visibility.Hidden;
            SaveChanges.IsManipulationEnabled = false;
        }

        private void UpdateQuestion_Checked(object sender, RoutedEventArgs e)
        {
            CreateQuestion.IsChecked = false;
            UpdateBorder.Background = Brushes.Gray;
            QuestionBox.Visibility = Visibility.Visible;
            QuestionBox.IsManipulationEnabled = true;
            DeleteBorder.Visibility = Visibility.Hidden;
            SaveChangesBorder.Visibility = Visibility.Visible;
            SaveChanges.IsManipulationEnabled = true;
        }
        private void UpdateQuestion_UnChecked(object sender, RoutedEventArgs e)
        {
            UpdateBorder.Background = Brushes.White;
            QuestionBox.Visibility = Visibility.Hidden;
            QuestionBox.IsManipulationEnabled = false;
            DeleteBorder.Visibility = Visibility.Visible;
            SaveChangesBorder.Visibility = Visibility.Hidden;
            SaveChanges.IsManipulationEnabled = false;
        }

        private void SaveChanges_Button_Click(object sender, RoutedEventArgs e)
        {
            if (CreateQuestion.IsChecked == true && QuestionBox.Text.Length > 0)
            {
                _crudManager.CreateQuestion(QuestionBox.Text, name);
                ListQuestions(name);
            }
            //else if (UpdateQuestion.IsChecked == true && QuestionBox.Text.Length > 0)
            //{

            //}
        }

        private void DisplaySelectedQuestion()
        {
            QuestionBox.Text = _crudManager.SelectedQuestion.Question1;
        }
        private void QuestionsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            QuestionBox.Visibility = Visibility.Visible;
            QuestionBox.IsManipulationEnabled = true;
            if (QuestionsListBox.SelectedItem != null)
            {
                _crudManager.DisplaySelectedQuestion(QuestionsListBox.SelectedItem);
                DisplaySelectedQuestion();
            }
        }

        private void DeleteQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (QuestionsListBox.SelectedItem != null)
            {
                _crudManager.DeleteQuestion(QuestionsListBox.SelectedItem.ToString(), name);
                ListQuestions(name);
                QuestionBox.Text = "";
            }
        }
    }
}
