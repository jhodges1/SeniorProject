using System;
using System.Data;
using Xamarin.Forms;
using MySql.Data.MySqlClient;

namespace SeniorProject
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = USERNAME.Text;
            var password = PASSWORD.Text;
            try
            {
                string connectionString = $"SERVER=localhost;DATABASE=TeamBeach_Database;UID={username};PASSWORD={password};";

                MySqlConnection connection = new MySqlConnection(connectionString);

                MySqlCommand cmd = new MySqlCommand("select * from account", connection);

                DataTable dt = new DataTable();

                connection.Open();
                dt.Load(cmd.ExecuteReader());
                if (cmd.ExecuteReader() == null)
                {
                    DisplayAlert("Information", "Login failed!", "Back");

                    /* Consider incrementing a login attempt counter */
                }
                else
                {
                    DisplayAlert("Information","Login successful!","Enter");
                    
                    // Notes:
                    // Needs to redirect to HomePage
                    // 1. Create new HomePage here
                    // 2. Create function in HomePage that allows for a redirect
                }
                connection.Close();
            }
            catch (Exception)
            {

            }
        }

        // Redirects user to the Register Account Page
        private async void btnRegisterAccount_Click(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterAccountPage());
        }



        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}