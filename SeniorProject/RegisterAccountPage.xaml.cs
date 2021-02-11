﻿using System;
using System.Data;
using Xamarin.Forms;
using MySql.Data.MySqlClient;

namespace SeniorProject
{
    public partial class RegisterAccountPage : ContentPage
    {
        private string FIRSTNAME;
        private string LASTNAME; 
        private string USERNAME;
        private string EMAIL;
        private string PASSWORD;

        public RegisterAccountPage()
        {
            InitializeComponent();

            // Removes the extra navigation bar
            NavigationPage.SetHasNavigationBar(this, false);
        }

        // User clicks "Enter"
        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "SERVER=localhost;DATABASE=TeamBeach_Database;UID=root;PASSWORD=root;"; // Needs administrator privileges to confirm account registration

                MySqlConnection connection = new MySqlConnection(connectionString);

                // Takes the number of rows in the account table
                using (var cmdCount = new MySqlCommand("select count * from account", connection))
                {
                    // Stores a new uid for the new account
                    int count = Convert.ToInt32(cmdCount.ExecuteScalar()) + 1;
                }

                /* Need to double check if it takes from the text box entries properly */
                string query = "INSERT INTO `ACCOUNT` (`ACCOUNT_ID`,`ACCOUNT_FIRSTNAME`,`ACCOUNT_LASTNAME`,`ACCOUNT_USERNAME`,`ACCOUNT_EMAIL`,`ACCOUNT_PASSWORD`) " +
                                    $"VALUES(count, {FIRSTNAME.ToString()}, {LASTNAME.ToString()}, {USERNAME.ToString()}, {EMAIL.ToString()}, {PASSWORD.ToString()};";

                MySqlCommand cmd = new MySqlCommand("insert into * from account", connection);

                DataTable dt = new DataTable();

                connection.Open();
                dt.Load(cmd.ExecuteReader());
                // Account Registration failed
                if (cmd.ExecuteReader() == null)
                {
                    DisplayAlert("Information", "Account Registration failed!", "Back");

                    /* Needs to display errors (i.e., empty entries, user credentials are already taken, user credentials are invalid) */
                }
                // Account Registration successful
                else
                {
                    DisplayAlert("Information", "Account Registration successful!", "Enter");

                    /* Redirects user back to the login page; Needs to check if works correctly*/
                    btnBack_Click(sender, e);
                }
                connection.Close();
            }
            catch (Exception)
            {

            }
        }

        // User clicks "Back"
        private async void btnBack_Click(object sender, EventArgs e)
        {
            // Redirects user back to the Login Page
            await Navigation.PushModalAsync(new LoginPage());
        }

        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}