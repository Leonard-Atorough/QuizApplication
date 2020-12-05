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

namespace QuizApplicationGUI.Pages
{
    /// <summary>
    /// Interaction logic for StudentMain.xaml
    /// </summary>
    public partial class StudentMain : Page
    {
        CRUDManager _crudManager = new CRUDManager();
        string name;
        public StudentMain()
        {
            InitializeComponent();
        }
        public StudentMain(string userFromLogin):this()
        {
            name = userFromLogin;
            QuizList.ItemsSource = _crudManager.ListStudentQuizzes(name);
            UserBlock.Text = $"Hello {name}";
        }

        private void QuizList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _crudManager.SetSelectedQuiz(QuizList.SelectedItem);
            QuizQuestionsBox.ItemsSource = _crudManager.ListStudentQuizQuestions(_crudManager.SelectedQuiz.QuizId);
            QuestionDisplayBox.Text = null;
            AnswerBox.Text = null;
        }

        private void QuizQuestionsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _crudManager.SetSelectedQuestion(QuizQuestionsBox.SelectedItem);
            QuestionDisplayBox.Text = _crudManager.SelectedQuestion.Question1;
            AnswerBox.IsEnabled = true;
            AnswerBox.Text = _crudManager.DisplaySelectedQuestionAnswer(name, _crudManager.SelectedQuestion.QuestionId);
        }

        private void SaveAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (_crudManager.SelectedQuiz != null && _crudManager.SelectedQuestion != null)
            {
                _crudManager.UpdateAnswer(name, _crudManager.SelectedQuestion.QuestionId, AnswerBox.Text);
            }
            else
            {
                MessageBox.Show("Select a valid quiz & question");
            }
            
        }

    }
}
