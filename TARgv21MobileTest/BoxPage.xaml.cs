using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv21MobileTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BoxPage : ContentPage
    {
        BoxView box;
        public BoxPage()
        {
            box = new BoxView
            {
                Color = Color.Black,
                CornerRadius = 20,
                WidthRequest = 200, HeightRequest = 500,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            box.GestureRecognizers.Add(tap);
            Content = new StackLayout { Children = { box } };
        }


        Random rnd;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            Random rnd = new Random();
            box.Color = Color.FromRgb(rnd.Next(0,255), rnd.Next(0,255), rnd.Next(0,255));
            box.WidthRequest = box.Width + 10;
            box.HeightRequest = box.Height + 10;
            if (box.HeightRequest>(int)DeviceDisplay.MainDisplayInfo.Height/4)
            {
                box.HeightRequest = 300;
                box.WidthRequest = 200;
            }
        }
    }
}