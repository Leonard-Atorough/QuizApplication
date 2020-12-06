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
    /// Interaction logic for QuizPage.xaml
    /// </summary>
    public partial class QuizPage : Page
    {
        CRUDManager _crudManager = new CRUDManager();
        string name;
        public QuizPage()
        {
            InitializeComponent();
        }
        public QuizPage(string username) : this()
        {
            name = username;
            ListQuestions(name);
            ListQuizzes(name);
        }

        private void ListQuestions(string username)
        {
            AllQuestionsBox.ItemsSource = _crudManager.ListAllQuestions(username);
        }

        private void ListQuizQuestions(string username, string quizName)
        {
            QuizQuestionsBox.ItemsSource = _crudManager.ListAllQuestionsInQuiz(username, quizName);
        }

        private void ListQuizzes(string username)
        {
            QuizBox.ItemsSource = _crudManager.ListAllQuizzes(username);
        }


        private void Navigation_Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var operation = button.Content.ToString();

            switch (operation)
            {
                case "Students":
                    TeacherMain teacherMain = new TeacherMain(name);
                    this.NavigationService.Navigate(teacherMain);
                    break;
                case "Questions":
                    QuestionPage questionPage = new QuestionPage(name);
                    this.NavigationService.Navigate(questionPage);
                    break;
                case "Exit":
                    HomePage homePage = new HomePage();
                    this.NavigationService.Navigate(homePage);
                    break;
                default:
                    break;
            }
        }


        private void QuizSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(QuizSearchBox.Text))
            {
                QuizBox.ItemsSource = _crudManager.SearchForQuizInList(QuizSearchBox.Text);
            }
            else
            {
                ListQuizzes(name);
            }
        }


        private void QuizBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (QuizBox.SelectedItem == null && QuizBox.Items.Count > 0)
            {
                _crudManager.SetSelectedQuiz(QuizBox.Items[0]);
                ListQuizQuestions(name, _crudManager.SelectedQuiz.QuizName);
            }
            else if (QuizBox.SelectedItem == null)
            {
                _crudManager.SetSelectedQuiz(null);
            }
            else
            {
                _crudManager.SetSelectedQuiz(QuizBox.SelectedItem);
                ListQuizQuestions(name, _crudManager.SelectedQuiz.QuizName);
            }
                
        }
        private void AllQuestionsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _crudManager.SetSelectedQuestion(AllQuestionsBox.SelectedItem);
        }
        private void QuizQuestionsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _crudManager.SetSelectedQuestion(QuizQuestionsBox.SelectedItem);
        }


        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _crudManager.AddQuestionToQuiz(_crudManager.SelectedQuiz.QuizName, _crudManager.SelectedQuestion.Question1);
                ListQuizQuestions(name, _crudManager.SelectedQuiz.QuizName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _crudManager.RemoveQuestionsFromQuiz(_crudManager.SelectedQuestion.Question1);
                ListQuizQuestions(name, _crudManager.SelectedQuiz.QuizName);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }    
        }


        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _crudManager.DeleteQuiz(_crudManager.SelectedQuiz.QuizName, name);
                ListQuizzes(name);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
}
        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _crudManager.CreateQuiz(QuizCreateBox.Text, name);
                ListQuizzes(name);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void Publish_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _crudManager.PublishQuiz(QuizBox.SelectedItem.ToString(), name);
                MessageBox.Show("Quiz Published!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
