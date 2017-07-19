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

namespace LP2_TP.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            
            UserController.Deserialize();
            ProjectController.Deserialize();
        }
        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SignUpWindow suw = new SignUpWindow();
            suw.Show();
            this.Close();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LogInWindow liw = new LogInWindow();
            liw.Show();
            this.Close();
        }
    }
}
