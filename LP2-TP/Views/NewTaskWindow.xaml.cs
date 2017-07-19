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
using LP2_TP.Controllers;
using LP2_TP.Models;

namespace LP2_TP.Views
{
    /// <summary>
    /// Interaction logic for NewTaskWindow.xaml
    /// </summary>
    public partial class NewTaskWindow : Window
    {
        User online;
        Project open;
        TaskController tc = new TaskController();

        public NewTaskWindow(User online, Project open)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            this.online = online;
            this.open = open;
        }
        
        private void btnNewTask_Click(object sender, RoutedEventArgs e)
        {
            tc.NewTask(tbxTitle.Text, tbxDescription.Text, online, open);
            MessageBox.Show("New task created!");

            this.Hide();
            TaskMainWindow tmw = new TaskMainWindow(TaskController.TaskList[TaskController.TaskList.Count -1], online);
            tmw.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ProjectMainWindow pmw = new ProjectMainWindow(open, online);
            pmw.Show();
            this.Close();
        }
    }
}
