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
    /// Interaction logic for TeacherLogin.xaml
    /// </summary>
    public partial class TeacherLogin : Page
    {
        CRUDManager _crudManager = new CRUDManager();
        TeacherMain teacherMain = new TeacherMain();

        public TeacherLogin()
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
                _crudManager.CreateTeacherAccount(username, password, email);
                this.NavigationService.Navigate(teacherMain);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameTextBox.Text;
            var password = PasswordTextBox.Text;

            try
            {
                _crudManager.TeacherLogin(username, password);
                this.NavigationService.Navigate(teacherMain);
            }
            catch (Exception ex)
            {
                ErrorBox.Text = ex.Message;
            }
            
            
        }
    }
}
