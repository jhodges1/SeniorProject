using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SeniorProject
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            // This should get rid of the extra blue bar that appears
            NavigationPage.SetHasBackButton(this, false);
            

            // This will set the second "child" of the tabbed page as the default
            CurrentPage = Children[1];
        }

    }
}
