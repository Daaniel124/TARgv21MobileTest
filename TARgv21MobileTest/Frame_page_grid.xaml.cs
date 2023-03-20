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
    public partial class Frame_page_grid : ContentPage
    {
        Frame fr;
        Grid gr;
        int r, g, b;
        Label lbl;
        public Frame_page_grid()
        {
            lbl = new Label
            {
                Text = "Raami kujundus",
                FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label)),
            };
            gr = new Grid
            {
                VerticalOptions= LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            Random rnd = new Random();
            List<int> laiused = new List<int> { (int)DeviceDisplay.MainDisplayInfo.Height/20, (int)
                (DeviceDisplay.MainDisplayInfo.Height)/40, (int)DeviceDisplay.MainDisplayInfo.Height/20};
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    r = rnd.Next(0, 255);
                    g = rnd.Next(0, 255);
                    b = rnd.Next(0, 255);
                    gr.RowDefinitions.Add(new RowDefinition { Height = new GridLength(laiused[i]) });
                    gr.Children.Add(
                        new BoxView
                        {
                        Color = Color.FromRgb(r, g, b),
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        }, j, i);
                }
                gr.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            fr = new Frame
            {
                Content = gr,
                BorderColor = Color.FromRgb(20, 120, 255),
                CornerRadius = 20,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            StackLayout st = new StackLayout
            {
                Children = { lbl, fr }
            };
            Content = st;

        }
    }
}