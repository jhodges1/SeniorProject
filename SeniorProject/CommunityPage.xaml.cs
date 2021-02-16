using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class CommunityPage : ContentPage
    {
        private ListView listView;
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        private Button enterNewForm;
        public CommunityPage(){

            this.Title = "Community Page";

            var db = new SQLiteConnection(dbPath);

            StackLayout stackLayout = new StackLayout();

            enterNewForm = new Button();
            enterNewForm.Text = "Enter new form";
            enterNewForm.Clicked += OnButtonClicked;
            stackLayout.Children.Add(enterNewForm);

            listView = new ListView();
            listView.ItemsSource = db.Table<CommunityEntry>().OrderBy(x => x.Title).ToList();
            stackLayout.Children.Add(listView);

            Content = stackLayout;

            //InitializeComponent();
        }
        private async void OnButtonClicked(object sender, EventArgs e){
            await Navigation.PushAsync(new CommunityEntryForm());
            //(sender as Button).Text = "Navigation Needs to be implemented";
        }
    }
}