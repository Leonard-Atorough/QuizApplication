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
    /// Interaction logic for StudentLogin.xaml
    /// </summary>
    public partial class StudentLogin : Page
    {
        CRUDManager _crudManager = new CRUDManager();
        public StudentLogin()
        {
            InitializeComponent();
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameRegistrationTextBox.Text;
            var password = PasswordRegistrationTextBox.Text;
            var email = EmailRegistrationBox.Text;

            try
            {
                if (ErrorBox.Text.Length > 0)
                {
                    ErrorBox.Text.Remove(0);
                }
                _crudManager.CreateStudentAccount(username, password, email);
                StudentMain studentMain = new StudentMain(username);
                this.NavigationService.Navigate(studentMain);
            }
            catch (Exception ex)
            {
                ErrorBox.Text = ex.Message;
            }
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameTextBox.Text;
            var password = PasswordTextBox.Text;

            try
            {
                if (ErrorBox.Text.Length > 0)
                {
                    ErrorBox.Text.Remove(0);
                }
                _crudManager.StudentLogin(username, password);
                StudentMain studentMain = new StudentMain(username);
                this.NavigationService.Navigate(studentMain);
            }
            catch (Exception ex)
            {
                ErrorBox.Text = ex.Message;
            }
        }
    }
}
