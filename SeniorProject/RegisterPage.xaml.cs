using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MySqlConnector;

using System.Data;

namespace SeniorProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();

            // Gets rid of extra blue navigation bar that occurs
            NavigationPage.SetHasNavigationBar(this, false);

        }

        private async void Register(object sender, EventArgs e)
        {
            string firstname = FirstName.Text;
            string lastname = LastName.Text;
            string email = Email.Text;

            string uid = Username.Text;
            string pwd = Password.Text;

            //string dbConnection = $"SERVER=localhost;DATABASE=TeamBeach_Database;UID={username};PASSWORD={password};";

            string dbConnection = "Server=localhost; Port=3306; Database=teambeach_database; Uid=root; Pwd=root;"; // Test !

            MySqlConnection connection = new MySqlConnection(dbConnection);

            connection.Open(); // Error !

            DataTable dt = new DataTable();

            int number = dt.Rows.Count + 1;

            string query = "INSERT INTO `ACCOUNT` (`ACCOUNT_ID`,`ACCOUNT_FIRSTNAME`,`ACCOUNT_LASTNAME`,`ACCOUNT_USERNAME`,`ACCOUNT_EMAIL`,`ACCOUNT_PASSWORD) " +
                $"VALUES('{number}', {firstname}, {lastname}, {uid}, {email}, {pwd});"; 

            MySqlCommand cmd = new MySqlCommand(query, connection);

            dt.Load(cmd.ExecuteReader());

            // Account Registration failed
            if (cmd.ExecuteReader() == null)
            {
                await DisplayAlert("Error", "Invalid user credentials", "OK");
            }
            // Account Registration successful
            else
            {
                await Navigation.PushModalAsync(new MainPage());
            }

            connection.Close();
        }


        private async void Register_OnClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "Account Registration successful!", "OK");

            await Navigation.PushModalAsync(new MainPage());
        }

        private async void Back_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}
