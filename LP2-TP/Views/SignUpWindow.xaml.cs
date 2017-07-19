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
using LP2_TP.Controllers;

namespace LP2_TP.Views
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void btnBack_OnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void btnSignUp_OnClick(object sender, RoutedEventArgs e)
        {
            UserController uc = new Controllers.UserController();
            string message = String.Format("New User created!\n{0}, {1} ({2})", tbxSurname.Text, tbxName.Text, tbxUsername.Text);

            if (CheckTextBoxes() == true)
            {
                if (uc.SearchUsername(tbxUsername.Text) == false)
                {
                    if (uc.CheckPassword(tbxPassword.Password) == true)
                    {
                        if (uc.ComparePassword(tbxPassword.Password, tbxConfirm.Password) == true)
                        {
                            if (uc.SearchEmail(tbxEmail.Text) == false)
                            {
                                if (uc.CheckEmail(tbxEmail.Text) == true)
                                {
                                    if (uc.CheckPhoneNo(tbxPhoneNo.Text) == false)
                                    {
                                        if (cldBirthDate.SelectedDate.HasValue)
                                        {
                                            if (cbxGender.SelectedItem == cbxM)
                                            {
                                                uc.NewUser(tbxName.Text, tbxSurname.Text, 'M', cldBirthDate.SelectedDate.Value.ToShortDateString(), tbxUsername.Text, tbxPassword.Password, tbxEmail.Text, tbxPhoneNo.Text, tbxCountry.Text, tbxCity.Text, string.Empty);
                                                MessageBox.Show(message);                                            

                                                this.Hide();
                                                MainWindow mw = new MainWindow();
                                                mw.Show();
                                                this.Close();
                                            }
                                            else if (cbxGender.SelectedItem == cbxF)
                                            {
                                                uc.NewUser(tbxName.Text, tbxSurname.Text, 'F', cldBirthDate.SelectedDate.Value.ToShortDateString(), tbxUsername.Text, tbxPassword.Password, tbxEmail.Text, tbxPhoneNo.Text, tbxCountry.Text, tbxCity.Text, string.Empty);
                                                MessageBox.Show(message);

                                                this.Hide();
                                                MainWindow mw = new MainWindow();
                                                mw.Show();
                                                this.Close();
                                            }
                                            else
                                            {
                                                MessageBox.Show("Select your gender!");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Please pick your birth date!");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Phone number not accepted!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("e-mail not accepted!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("This e-mail is already on the platform!");
                            }
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
                    MessageBox.Show("This Username is already taken!");
                }
            }
            else
            {
                MessageBox.Show("Please fill all camps!");
            }
        }

        private bool CheckTextBoxes()
        {
            string[] tBoxes = { tbxName.Text, tbxSurname.Text, tbxUsername.Text, tbxPassword.Password, tbxConfirm.Password, tbxEmail.Text, tbxPhoneNo.Text, tbxCountry.Text, tbxCity.Text };

            for (int i = 0; i < tBoxes.Length; i++)
            {
                if(tBoxes[i] == string.Empty)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
