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
        }
    }
}
