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
    /// Interaction logic for NewProjectWindow.xaml
    /// </summary>
    public partial class NewProjectWindow : Window
    {
        User admin;

        public NewProjectWindow(User admin)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            this.admin = admin;
        }
        
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            UserMainWindow umw = new UserMainWindow(this.admin);
            umw.Show();
            this.Close();
        }

        private void btnNewProject_Click(object sender, RoutedEventArgs e)
        {
            ProjectController pc = new ProjectController();
            pc.NewProject(tbxTitle.Text, tbxDescription.Text, this.admin);
            MessageBox.Show("New Project Created!\n" + tbxTitle.Text);
            this.Hide();
            ProjectMainWindow pmw = new ProjectMainWindow(Project.ProjectList[Project.ProjectList.Count - 1], admin);
            pmw.Show();
            this.Close();
        }
    }
}
