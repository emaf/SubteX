using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Subte
{
    public class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<SubwayLine> LineItems { get; set; } = new ObservableCollection<SubwayLine>();

        public Command LoadSubwayLinesCommand { get => new Command(async () => await ExecuteLoadSubwayLinesCommand()); }

        public async Task ExecuteLoadSubwayLinesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            LineItems.Clear();

            var items = await StatusService.GetStatusAsync();
            foreach (var item in items)
                LineItems.Add(item);

            IsBusy = false;
        }
    }
}
