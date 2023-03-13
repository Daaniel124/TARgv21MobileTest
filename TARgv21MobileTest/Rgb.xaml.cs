using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv21MobileTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Rgb : ContentPage
    {
        Label lbl, lbl2, lbl3, lbl4;
        Slider sld, sld2, sld3;
        Stepper stp;

        Button btn;
        BoxView box;

        public Rgb()
        {
            lbl = new Label { Text = "Red = ", HorizontalOptions = LayoutOptions.Center };
            lbl2 = new Label { Text = "Green = ", HorizontalOptions = LayoutOptions.Center };
            lbl3 = new Label { Text = "Blue = ", HorizontalOptions = LayoutOptions.Center };
            lbl4 = new Label { Text = "Alpha = ", HorizontalOptions = LayoutOptions.Center };

            box = new BoxView()
            {
                Color = Color.Black,
                WidthRequest = 400,
                HeightRequest = 350,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            sld = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 120,

                MinimumTrackColor = Color.Gray,
                MaximumTrackColor = Color.Black,
                ThumbColor = Color.Red
            };

            sld.ValueChanged += OnSlideValueChanged;

            sld2 = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 120,

                MinimumTrackColor = Color.Gray,
                MaximumTrackColor = Color.Black,
                ThumbColor = Color.Green
            };
            sld2.ValueChanged += OnSlideValueChanged;

            sld3 = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 120,
                MinimumTrackColor = Color.Gray,
                MaximumTrackColor = Color.Black,
                ThumbColor = Color.Blue
            };
            sld3.ValueChanged += OnSlideValueChanged;

            stp = new Stepper
            {
                Minimum = 0,
                Maximum = 255,
                Increment = 5,
                Value = 255,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            stp.ValueChanged += OnSlideValueChanged;

            btn = new Button
            {
                Text = "Рандом",
            };
            btn.Clicked += Btn_Clicked;

            StackLayout st = new StackLayout { Children = { box, sld, lbl, sld2, lbl2, sld3, lbl3, stp, lbl4, btn } };
            Content = st;
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            Random rnd = new Random();
            box.Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
        }

        private void OnSlideValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender == sld)
            {
                lbl.Text = String.Format("Red = {0:X2}", (int)e.NewValue);
            }
            else if (sender == sld2)
            {
                lbl2.Text = String.Format("Green = {0:X2}", (int)e.NewValue);
            }
            else if (sender == sld3)
            {
                lbl3.Text = String.Format("Blue = {0:X2}", (int)e.NewValue);
            }
            else if (sender == stp)
            {
                lbl4.Text = String.Format("Alpha = {0:X2}", (int)e.NewValue);
            }

            box.Color = Color.FromRgba((int)sld.Value,
                                      (int)sld2.Value,
                                      (int)sld3.Value,
                                      (int)stp.Value);
        }
    }
}