using Microcharts;
using Microcharts.Forms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WatchClient
{
    public class FirstPage : ContentPage
    {
        ChartView chart1 = new ChartView { HeightRequest = 300, BackgroundColor = Color.White };

        public FirstPage()
        {
            Label header = new Label
            {
                Text = "Passos por Dia",
                FontSize = 30,
                HorizontalOptions = LayoutOptions.Center
            };

            var navigateButton = new Button { Text = "Próxima Página" };

            navigateButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new SecondPage());
            };

            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Spacing = 10,
                    Children = { header, chart1, navigateButton }
                }
            };

        }

        public BarChart StepsByDay()
        {
            IEnumerable<SmartwatchData> data = App.GenerateSmartwatchData();
            var entries = data.Select(x => new ChartEntry(x.steps)
            {
                Label = x.meta.periodRange,
                ValueLabel = x.steps.ToString(),
                Color = SKColor.Parse("#266489"),
                TextColor = App.TextColor
            });

            BarChart barChart = new BarChart()
            {
                Entries = entries,
                LabelTextSize = 35, 
                LabelOrientation = Orientation.Horizontal 
            };

            return barChart;
        }

        protected override void OnAppearing()
        {
            chart1.Chart = StepsByDay();
        }

    }
}
