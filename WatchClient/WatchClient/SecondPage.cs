using Microcharts;
using Microcharts.Forms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace WatchClient
{
    public class SecondPage : ContentPage
    {

        ChartView chart2 = new ChartView { HeightRequest = 300, BackgroundColor = Color.White };


        public SecondPage()
        {
            Label header = new Label
            {
                Text = "Tempo de Atividade por Dia",
                FontSize = 30,
                HorizontalOptions = LayoutOptions.Center
            };

            var navigateButton = new Button { Text = "Próxima Página" };

            navigateButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new ThirdPage());
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
                    Children = { header, chart2, stackButtons }
                }
            };
            
        }

        public BarChart ActivityByDay()
        {
            IEnumerable<SmartwatchData> data = App.GenerateSmartwatchData();
            var entries = data.Select(x => new ChartEntry(x.activityTimeMinutes)
            {
                Label = x.meta.periodRange,
                ValueLabel = x.activityTimeMinutes.ToString(),
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
            chart2.Chart = ActivityByDay();
        }
    }
}