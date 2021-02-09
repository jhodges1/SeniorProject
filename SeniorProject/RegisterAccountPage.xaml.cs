using System;
using System.Data;
using Xamarin.Forms;
using MySql.Data.MySqlClient;

namespace SeniorProject
{
    public partial class RegisterAccountPage : ContentPage
    {
        public RegisterAccountPage()
        {
            // InitializeComponent();

            // Gets rid of the extra blue navigation bar that occurs
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void btnRegisterAccount_Click()
        {
            try
            {
                // Notes:
                // UID & PASSWORD mapped to XAML buttons
                // 1. Create text box bindings in RegisterAccountPage.xaml 
                string connectionString = "SERVER=localhost;DATABASE=TeamBeach_Database;UID=root;PASSWORD=root;";

                MySqlConnection connection = new MySqlConnection(connectionString);

                MySqlCommand cmd = new MySqlCommand("select * from account", connection);

                DataTable dt = new DataTable();
                connection.Open();
                dt.Load(cmd.ExecuteReader());
                // User account does not exist
                if (cmd.ExecuteReader() == null)
                {
                    // Attempt to register account using the provided user credentials
                    try
                    {
                        // Notes:
                        // 1. Check if user credentials exist already
                    }
                    catch (Exception)
                    {

                    }
                }
                // User account exists
                else
                {
                    // Notes:
                    // Allow for redirect back to LoginPage
                }
                connection.Close();
            }
            catch (Exception)
            {
                
            }
        }

        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}