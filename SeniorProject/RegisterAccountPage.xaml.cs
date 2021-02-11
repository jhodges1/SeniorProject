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
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }

        // User clicks "Enter"
        private void btnEnter_Click(object sender, EventArgs e)
        {
            var username = USERNAME.Text;
            var firstname = FIRSTNAME.Text;
            var lastname = LASTNAME.Text;
            var email = EMAIL.Text;
            var password = PASSWORD.Text;

            try
            {
                string connectionString = "SERVER=localhost;DATABASE=TeamBeach_Database;UID=root;PASSWORD=root;"; // Needs administrator privileges to confirm account registration

                MySqlConnection connection = new MySqlConnection(connectionString);

                using (var cmdCount = new MySqlCommand("select count * from account", connection))
                {
                    int count = Convert.ToInt32(cmdCount.ExecuteScalar()) + 1;
                }

                /* UID probably does not get added properly */
                string query = "INSERT INTO `ACCOUNT` (`ACCOUNT_ID`,`ACCOUNT_FIRSTNAME`,`ACCOUNT_LASTNAME`,`ACCOUNT_USERNAME`,`ACCOUNT_EMAIL`,`ACCOUNT_PASSWORD`) " +
                                    $"VALUES(count, {firstname}, {lastname}, {username}, {email}, {password};";

                MySqlCommand cmd = new MySqlCommand("insert into * from account", connection);

                DataTable dt = new DataTable();

                connection.Open();
                dt.Load(cmd.ExecuteReader());
                
                if (cmd.ExecuteReader() == null)
                {
                    DisplayAlert("Information", "Account Registration failed!", "Back");

                    /* Needs to display errors (i.e., empty entries, user credentials are already taken, user credentials are invalid) */
                }
                else
                {
                    DisplayAlert("Information", "Account Registration successful!", "Enter");

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