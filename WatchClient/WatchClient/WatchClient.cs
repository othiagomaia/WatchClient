using Bogus;
using Microcharts;
using Microcharts.Forms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace WatchClient
{
    public class App : Application
    {
        public static readonly SKColor TextColor = SKColors.Black;

        
        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new FirstPage());
        }

        public static IEnumerable<SmartwatchData> GenerateSmartwatchData()
        {
            string[] devices = { "Galaxy Watch 3", "Galaxy Watch 4", "Galaxy Watch 5", "Galaxy Watch 6" };

            return new Faker<SmartwatchData>().Rules((f, x) =>
            {
                x.activityTimeMinutes = f.Random.Int(0, 360);
                x.distanceMeters = f.Random.Int(0, 10000);
                x.energyBurnedKcal = f.Random.Float(0);
                x.heartBeat = f.Random.Int(0, 200);
                x.steps = f.Random.Int(0);
                x.meta = new Meta
                {
                    device = f.PickRandom(devices),
                    periodRange = f.Date.Recent().ToString("dd/MM"),
                    updateFrequencySeconds = f.Random.Int(0)
                };
            }).Generate(5);
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
            
        }

        protected override void OnResume()
        {
            
        }
    }
}
