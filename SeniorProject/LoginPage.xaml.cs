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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            // Gets rid of extra blue navigation bar that occurs
            NavigationPage.SetHasNavigationBar(this, false);

        }

        private async void Login(object sender, EventArgs e)
        {
            string uid = Username.Text;
            string pwd = Password.Text;

            //string dbConnection = $"SERVER=localhost;DATABASE=TeamBeach_Database;UID={username};PASSWORD={password};";

            //string dbConnection = "server=localhost;user id=root;database=teambeach_database;persistsecurityinfo=True";

            string dbConnection = "Server=localhost; Port=3306; Database=teambeach_database; Uid=root; Pwd=root;";

            MySqlConnection connection = new MySqlConnection(dbConnection);
            MySqlCommand cmd = new MySqlCommand("select * from account", connection);

            DataTable dt = new DataTable();

            connection.Open(); // Error !

            dt.Load(cmd.ExecuteReader());

            // Login failed
            if (cmd.ExecuteReader() == null)
            {
                await DisplayAlert("Error", "Invalid username or password", "OK");
            }
            // Login successful
            else
            {
                await Navigation.PushModalAsync(new MainPage());
            }

            connection.Close();
        }

        private async void Login_OnClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "Login successful!", "OK");

            await Navigation.PushModalAsync(new MainPage()); 
        }

        private async void Register_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterPage());
        }
    }
}