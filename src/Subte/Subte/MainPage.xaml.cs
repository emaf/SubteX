using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Subte
{
	public partial class MainPage : ContentPage
	{
        MainPageViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage(MainPageViewModel vm)
            : this()
        {
            BindingContext = viewModel = vm;
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.LineItems.Count == 0)
                await viewModel.ExecuteLoadSubwayLinesCommand();
        }
    }
}
