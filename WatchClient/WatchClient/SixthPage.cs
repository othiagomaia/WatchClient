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
    public class SixthPage : ContentPage
    {
        ChartView chart6 = new ChartView { HeightRequest = 300, BackgroundColor = Color.White };

        public SixthPage()
        {

            Label header = new Label
            {
                Text = "Tempo de Atividade por Dispositivo",
                FontSize = 30,
                HorizontalOptions = LayoutOptions.Center
            };

            var backButton = new Button
            {
                Text = "Voltar"
            };

            backButton.Clicked += async (sender, args) =>
            {
                await Navigation.PopAsync();
            };

            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = { header, chart6, backButton }
                }
            };
        }

        public DonutChart ActivityTimeByDevice()
        {
            IEnumerable<SmartwatchData> data = App.GenerateSmartwatchData();
            var groupedData = data.GroupBy(x => x.meta.device)
                                  .Select(g => new
                                  {
                                      Device = g.Key,
                                      TotalActivityTime = g.Sum(x => x.activityTimeMinutes)
                                  });

            var entries = groupedData.Select(x => new ChartEntry(x.TotalActivityTime)
            {
                Label = x.Device,
                ValueLabel = x.TotalActivityTime.ToString(),
                Color = SKColor.Parse("#" + new Random().Next(0x1000000).ToString("X6")),
                TextColor = App.TextColor
            });

            DonutChart donutChart = new DonutChart()
            {
                Entries = entries,
                LabelTextSize = 35
            };

            return donutChart;
        }

        protected override void OnAppearing()
        {
            chart6.Chart = ActivityTimeByDevice();
        }

    }
}
