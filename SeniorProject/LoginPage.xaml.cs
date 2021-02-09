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

            // Gets rid of the extra blue navigation bar that occurs
            NavigationPage.SetHasNavigationBar(this, false);

        }

        private void btnRegisterAccount_Click()
        {
            // redirect to register account page
        }

        private void btnLogin_Click()
        {
            try
            {
                // Notes:
                // UID & PASSWORD mapped to XAML buttons
                string connectionString = "SERVER=localhost;DATABASE=TeamBeach_Database;UID=root;PASSWORD=root;";

                MySqlConnection connection = new MySqlConnection(connectionString);

                MySqlCommand cmd = new MySqlCommand("select * from account", connection);

                DataTable dt = new DataTable();

                connection.Open();
                dt.Load(cmd.ExecuteReader());
                connection.Close();

                // If cmd successful, redirect to Home Page
            }
            catch (Exception)
            { 
                // If cmd failed, retry Login Page
            }
        }

        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
