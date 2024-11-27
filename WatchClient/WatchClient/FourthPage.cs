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
    public class FourthPage : ContentPage
    {
        ChartView chart4 = new ChartView { HeightRequest = 300, BackgroundColor = Color.White };

        public FourthPage()
        {

            Label header = new Label
            {
                Text = "Calorias Queimadas por Dia",
                FontSize = 30,
                HorizontalOptions = LayoutOptions.Center
            };

            var navigateButton = new Button { Text = "Próxima Página" };

            navigateButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new FifthPage());
            };

            var backButton = new Button
            {
                Text = "Voltar"
            };

            backButton.Clicked += async (sender, args) =>
            {
                await Navigation.PopAsync();
            };

            StackLayout stackButtons = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                Children = { backButton, navigateButton }
            };

            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = { header, chart4, stackButtons }
                }
            };
        }

        public LineChart EnergyBurnedByDay()
        {
            IEnumerable<SmartwatchData> data = App.GenerateSmartwatchData();
            var entries = data.Select(x => new ChartEntry(x.energyBurnedKcal)
            {
                Label = x.meta.periodRange,
                ValueLabel = x.energyBurnedKcal.ToString(),
                Color = SKColor.Parse("#266489"),
                TextColor = App.TextColor
            });

            LineChart lineChart = new LineChart()
            {
                Entries = entries,
                LineMode = LineMode.Straight,
                LineSize = 8,
                PointMode = PointMode.Square,
                PointSize = 18,
                LabelTextSize = 35,
                LabelOrientation = Orientation.Horizontal
            };

            return lineChart;
        }

        protected override void OnAppearing()
        {
            chart4.Chart = EnergyBurnedByDay();
        }
    }
}
