using System;
using System.Data;
using Xamarin.Forms;
using MySql.Data.MySqlClient;

namespace SeniorProject
{
    public partial class LoginPage : ContentPage
    {
        private string USERNAME;
        private string PASSWORD;

        public LoginPage()
        {
            InitializeComponent();

            // Removes the extra navigation bar
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                /* Need to double check if it takes from the text box entries properly */
                string connectionString = $"SERVER=localhost;DATABASE=TeamBeach_Database;UID={USERNAME.ToString()};PASSWORD={PASSWORD.ToString()};";

                MySqlConnection connection = new MySqlConnection(connectionString);

                MySqlCommand cmd = new MySqlCommand("select * from account", connection);

                DataTable dt = new DataTable();

                connection.Open();
                dt.Load(cmd.ExecuteReader());
                // User login failed
                if (cmd.ExecuteReader() == null)
                {
                    DisplayAlert("Information", "Login failed!", "Back");

                    /* Consider incrementing a login attempt counter */
                }
                // User login successful
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