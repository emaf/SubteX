using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Subte
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            var navPage =
                    new NavigationPage(
                        new MainPage(new MainPageViewModel())
                        {
                            Title = "Estado del Subte"
                        })
                    {
                        BarBackgroundColor = Color.FromHex("547799")
                    };

            navPage.BarTextColor = Color.White;

            // set the MainPage of the app to the navPage
            MainPage = navPage;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
