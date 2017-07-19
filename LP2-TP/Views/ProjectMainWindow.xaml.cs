/* Trabalho Prático, Turno 1, 08/06/2017
 * Plataforma de Gestão de Projetos de Software
 * 
 * LP2 - LESI - EST - IPCA
 * 2016/2017, 2º Semestre
 * 
 * a10944 - João Oliviera
 * a11595 - Daniel Amorim
 */
using System.Windows;
using LP2_TP.Models;
using LP2_TP.Controllers;

namespace LP2_TP.Views
{
    /// <summary>
    /// Interaction logic for ProjectMainWindow.xaml
    /// </summary>
    public partial class ProjectMainWindow : Window
    {
        Project open;
        User online;
        ProjectController pc = new ProjectController();
        TaskController tc = new TaskController();

        public ProjectMainWindow(Project p, User u)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            this.open = p;
            this.online = u;
            lblTitle.Content = open.Title;
            tbkDescription.Text = open.Description;

            lvwTaskList.ItemsSource = tc.ShowTasks(open);
            lvwUserList.ItemsSource = pc.ShowUsers(open);
        }
        
        private void miClose_Click(object sender, RoutedEventArgs e)
        {
            if (online.ID == open.Admin.ID)
            {
                MessageBoxResult rsltMessageBox = MessageBox.Show("Are you sure you want to close this project?", online.Username, MessageBoxButton.YesNo);
                switch (rsltMessageBox)
                {
                    case MessageBoxResult.Yes:
                        open.Active = false;
                        ProjectController.Serialize();
                        MessageBox.Show("Project Closed!");
                        this.Hide();
                        UserMainWindow umw = new UserMainWindow(online);
                        umw.Show();
                        this.Hide();
                        break;

                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Only the admin can close the project!");
            }
        }

        private void miChangeAdmin_Click(object sender, RoutedEventArgs e)
        {
            //if(online.ID == open.Admin.ID)
            //{
            //    MessageBoxResult rsltMessageBox = MessageBox.Show("Are you sure you want to change the project's admin?", online.Username, MessageBoxButton.YesNo);
            //    switch (rsltMessageBox)
            //    {
            //        case MessageBoxResult.Yes:
            //            MessageBox.Show("Chose the new admin");
            //            UserListWindow ulw = new UserListWindow(online);
            //            ulw.Show();
                        
            //            break;

            //        case MessageBoxResult.No:
            //            break;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Only the current admin can chose the new admin!");
            //}
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            UserMainWindow umw = new UserMainWindow(online);
            umw.Show();
            this.Close();
        }

        private void miNewTask_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            NewTaskWindow ntw = new NewTaskWindow(online, open);
            ntw.Show();
            this.Close();
        }

        private void miAddUsers_Click(object sender, RoutedEventArgs e)
        {
            UserListWindow ulw = new UserListWindow(open);
            ulw.Show();
        }
    }
}
