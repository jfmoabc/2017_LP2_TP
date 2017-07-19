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
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        public LogInWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            UserController uc = new UserController();

            if (uc.LogIn(tbxUsername.Text, pbxPassword.Password) == true)
            {
                if (uc.GetUser(tbxUsername.Text).Active == true)
                {
                    this.Hide();
                    UserMainWindow umw = new UserMainWindow(uc.GetUser(tbxUsername.Text));
                    umw.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("This user no longer exists!");
                }
            }
            else
            {
                MessageBox.Show("Username and Password do not Match!");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
