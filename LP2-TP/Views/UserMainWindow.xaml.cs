/* Trabalho Prático, Turno 1, 08/06/2017
 * Plataforma de Gestão de Projetos de Software
 * 
 * LP2 - LESI - EST - IPCA
 * 2016/2017, 2º Semestre
 * 
 * a10944 - João Oliviera
 * a11595 - Daniel Amorim
 */
using System;
using System.Windows;
using System.Windows.Controls;
using LP2_TP.Models;
using LP2_TP.Controllers;

namespace LP2_TP.Views
{
    /// <summary>
    /// Interaction logic for UserMainWindow.xaml
    /// </summary>
    public partial class UserMainWindow : Window
    {
        User online;
        ProjectController pc = new ProjectController();

        public UserMainWindow(User online)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            this.online = online;
            lblUsername.Content = this.online.Username;
            lblSurnameName.Content = String.Format("{0}, {1}", this.online.Surname, this.online.Name);
            lblEmail.Content = this.online.Email;
            
            lbxProjectList.ItemsSource = pc.ShowProjects(online);
        }
        private void miNewProject_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            NewProjectWindow npw = new NewProjectWindow(this.online);
            npw.Show();
            this.Close();
        }

        private void miMyTask_Click(object sender, RoutedEventArgs e)
        {

        }

        private void miEditProfile_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            EditUserWindow euw = new EditUserWindow(this.online);
            euw.Show();
            this.Close();
        }

        private void miLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();
        }

        private void miDeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rsltMessageBox = MessageBox.Show("Are you sure you want to delete your account?", online.Username, MessageBoxButton.YesNo);
            switch(rsltMessageBox)
            {
                case MessageBoxResult.Yes:
                    online.Active = false;
                    UserController.Serialize();
                    MessageBox.Show("User deleted!");
                    this.Hide();
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    this.Hide();
                    break;

                case MessageBoxResult.No:
                    break;
            }
        }

        private void lbxProjectList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string projectInfo = lbxProjectList.SelectedItem.ToString();

            this.Hide();
            ProjectMainWindow pmw = new ProjectMainWindow(pc.FindProjectListBox(projectInfo), online);
            pmw.Show();
            this.Close();
        }
    }
}
