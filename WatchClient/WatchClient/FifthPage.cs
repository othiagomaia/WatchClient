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
    public class FifthPage : ContentPage
    {
        ChartView chart5 = new ChartView { HeightRequest = 300, BackgroundColor = Color.White };

        public FifthPage()
        {

            Label header = new Label
            {
                Text = "Relação entre Distancia e Calorias Queimadas",
                FontSize = 30,
                HorizontalOptions = LayoutOptions.Center
            };

            var navigateButton = new Button { Text = "Próxima Página" };

            navigateButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new SixthPage());
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
                    Children = { header, chart5, stackButtons }
                }
            };
        }

        public PointChart DistanceVsCaloriesBurned()
        {
            IEnumerable<SmartwatchData> data = App.GenerateSmartwatchData();
            var entries = data.Select(x => new ChartEntry(x.distanceMeters)
            {
                Label = x.meta.periodRange,
                ValueLabel = x.energyBurnedKcal.ToString(),
                Color = SKColor.Parse("#266489"),
                TextColor = App.TextColor
            });

            PointChart pointChart = new PointChart()
            {
                Entries = entries,
                LabelTextSize = 35,
                LabelOrientation = Orientation.Horizontal
            };

            return pointChart;
        }

        protected override void OnAppearing()
        {
            chart5.Chart = DistanceVsCaloriesBurned();
        }
    }
}
