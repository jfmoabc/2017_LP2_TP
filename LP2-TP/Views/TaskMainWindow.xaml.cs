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
    /// Interaction logic for TaskMainWindow.xaml
    /// </summary>
    public partial class TaskMainWindow : Window
    {
        Models.Task current;
        User online;
        TaskController tc = new TaskController();

        public TaskMainWindow(Models.Task t, User u)
        {
            InitializeComponent();

            current = t;

            lblTitle.Content = current.Title;
            tbkDescription.Text = current.Description;
            
        }

        private void miClose_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult rsltMessageBox = MessageBox.Show("Are you sure you want to close this task?", online.Username, MessageBoxButton.YesNo);
            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:
                    current.Active = false;
                    TaskController.Serialize();
                    MessageBox.Show("Task Closed!");
                    this.Hide();
                    UserMainWindow umw = new UserMainWindow(online);
                    umw.Show();
                    this.Hide();
                    break;

                case MessageBoxResult.No:
                    break;
            }
        }
    }
}
