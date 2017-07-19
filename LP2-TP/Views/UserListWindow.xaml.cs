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
using System.Windows.Controls;
using LP2_TP.Models;
using LP2_TP.Controllers;

namespace LP2_TP.Views
{
    /// <summary>
    /// Interaction logic for UserListWindow.xaml
    /// </summary>
    public partial class UserListWindow : Window
    {
        UserController uc = new UserController();
        ProjectController pc = new ProjectController();
        Project open;

        public UserListWindow(Project open)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            this.open = open;

            
            lbxUserList.ItemsSource = pc.UsersToAdd(this.open);
        }

        private void lbxUserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string userInfo = lbxUserList.SelectedItem.ToString();

            this.Hide();
            pc.AddUser(uc.GetUser2(userInfo), open);
            this.Close();
        }
    }
}
