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
    public partial class CommunityEntryForm : ContentPage
    {
        private Entry titleEntry;
        private Entry descriptionEntry;
        private Button submitButton;

        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public CommunityEntryForm()
        {
            Title = "Community Entry Form";

            StackLayout stackLayout = new StackLayout();

            titleEntry = new Entry();
            titleEntry.Keyboard = Keyboard.Text;
            titleEntry.Placeholder = "Enter Title";
            stackLayout.Children.Add(titleEntry);

            descriptionEntry = new Entry();
            descriptionEntry.Keyboard = Keyboard.Text;
            descriptionEntry.Placeholder = "Enter Description";
            stackLayout.Children.Add(descriptionEntry);

            submitButton = new Button();
            submitButton.Text = "Submit";
            submitButton.Clicked += submitButton_clicked;
            stackLayout.Children.Add(submitButton);

            Content = stackLayout;

            //InitializeComponent();

        }
        private async void submitButton_clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<CommunityEntry>();
            var maxPk = db.Table<CommunityEntry>().OrderByDescending(c => c.Id).FirstOrDefault();
            CommunityEntry communityEntry = new CommunityEntry()
            {
                Id = (maxPk == null ? 1 : maxPk.Id + 1),
                Title = titleEntry.Text,
                Description = descriptionEntry.Text
            };
            db.Insert(communityEntry); 
            await Navigation.PushAsync(new SubmissionConfirmationPage());
        }

    }
}