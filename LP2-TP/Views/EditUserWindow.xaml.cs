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
    /// Interaction logic for EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        User online;
        User before;
        UserController uc = new UserController();

        public EditUserWindow(User online)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            this.before = online;
            this.online = online;
            tbxDescription.Text = this.online.Description;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            UserMainWindow umw = new UserMainWindow(online);
            umw.Show();
            this.Close();
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            if (this.online.Password == pbxActual.Password)
            {
                if (pbxActual.Password != string.Empty && pbxNew1.Password != string.Empty && pbxNew2.Password != string.Empty)
                {
                    if (uc.CheckPassword(pbxNew1.Password) == true)
                    {
                        if (uc.ComparePassword(pbxNew1.Password, pbxNew2.Password) == true)
                        {
                            this.online.Password = pbxNew1.Password;
                            pbxActual.Clear();
                            pbxNew1.Clear();
                            pbxNew2.Clear();
                            uc.EditUser(this.before, this.online);
                            MessageBox.Show("Password changed!");
                        }
                        else
                        {
                            MessageBox.Show("The passwords are not the same!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your password must contain more than 5 characters and at least one upper character and one digit!");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill all password information");
                }
            }
            else
            {
                MessageBox.Show("Current password is not correct!");
            }
        }

        private void btnChangeEmail_Click(object sender, RoutedEventArgs e)
        {
            if(this.online.Email == tbxActualEmail.Text)
            {
                if(uc.CheckEmail(tbxActualEmail.Text))
                {
                    this.online.Email = tbxActualEmail.Text;
                    uc.EditUser(this.before, this.online);
                    tbxActualEmail.Clear();
                    tbxNewEmail.Clear();
                }
                else
                {
                    MessageBox.Show("New e-mail not accepted!");
                }
            }
            else
            {
                MessageBox.Show("Actual e-mail is not correct!");
            }
        }

        private void btnChangeDescription_Click(object sender, RoutedEventArgs e)
        {
            this.online.Description = tbxDescription.Text;
            uc.EditUser(this.before, this.online);
            MessageBox.Show("Description updated!");
        }

        private void btnChangeLocation_Click(object sender, RoutedEventArgs e)
        {
            if(tbxNewCountry.Text != string.Empty)
            {
                if(tbxNewCountry.Text == this.online.Country)
                {
                    MessageBox.Show("{0} already is your actual location!", tbxNewCountry.Text);
                }
                else
                {
                    this.online.Country = tbxNewCountry.Text;
                }
            }

            if(tbxNewCity.Text != string.Empty)
            {
                if(tbxNewCity.Text == this.online.City)
                {
                    MessageBox.Show("{0} already is your actual location!", tbxNewCity.Text);
                }
                else
                {
                    this.online.City = tbxNewCity.Text;
                }
            }
            if(tbxNewCity.Text == string.Empty && tbxNewCountry.Text == string.Empty)
            {
                MessageBox.Show("Please fill the information you chose to change!");
            }
            else
            {
                MessageBox.Show("Location changed!");
            }
        }
    }
}
