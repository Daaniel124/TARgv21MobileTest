using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace TARgv21MobileTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Valgusfoor : ContentPage
    {
        Label label1, label2, label3;
        Frame frame1, frame2, frame3;
        Button btn1, btn2;
        bool bl = false;

        public Valgusfoor()
        {
            this.BackgroundColor = Color.FromHex("40241F");
            label1 = new Label
            {
                Text = "Красный",
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                VerticalOptions = LayoutOptions.Center
            };

            label2 = new Label
            {
                Text = "Желтый",
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                VerticalOptions = LayoutOptions.Center
            };

            label3 = new Label
            {
                Text = "Зеленый",
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                VerticalOptions = LayoutOptions.Center
            };

            frame1 = new Frame
            {
                Content = label1,
                BackgroundColor = Color.Black,
                CornerRadius = 1000,
                WidthRequest = 175,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center

            };

            frame2 = new Frame
            {
                Content = label2,

                BackgroundColor = Color.Black,
                CornerRadius = 1000,
                WidthRequest = 175,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center

            };

            frame3 = new Frame
            {
                Content = label3,
                BackgroundColor = Color.Black,
                CornerRadius = 1000,
                WidthRequest = 175,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center

            };

            btn1 = new Button
            {
                Text = "Включить",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End

            };

            btn2 = new Button
            {
                Text = "Выключить",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End
            };

            btn1.Clicked += Btn1_Clicked;
            btn2.Clicked += Btn2_Clicked;
            StackLayout st = new StackLayout
            {
                Children = { frame1, frame2, frame3, btn1, btn2 }
            };

            Content = st;
            TapGestureRecognizer tap = new TapGestureRecognizer();
            TapGestureRecognizer tap2 = new TapGestureRecognizer();
            TapGestureRecognizer tap3 = new TapGestureRecognizer();

            tap.Tapped += Tap_Tapped;
            tap2.Tapped += Tap2_Tapped;
            tap3.Tapped += Tap3_Tapped;

            frame1.GestureRecognizers.Add(tap);
            frame2.GestureRecognizers.Add(tap2);
            frame3.GestureRecognizers.Add(tap3);


        }

        private void Tap3_Tapped(object sender, EventArgs e)
        {
            if (bl)
            {
                if (frame3.BackgroundColor == Color.Green)
                {
                    label3.Text = "Идите";
                }
                else if (frame3.BackgroundColor == Color.Black)
                {
                    label3.Text = "Зеленый";
                }

            }
            else
            {
                label3.Text = "Пожалуйста, включите светофор";
            }
        }

        private void Tap2_Tapped(object sender, EventArgs e)
        {
            if (bl)
            {
                if (frame2.BackgroundColor == Color.Yellow)
                {
                    //label2.TextColor = Color.Black;
                    label2.Text = "Ждите";
                }
                else if (frame2.BackgroundColor == Color.Black)
                {
                    //label2.TextColor = Color.White;
                    label2.Text = "Желтый";
                }

            }
            else
            {
                label2.Text = "Пожалуйста, включите светофор";
            }
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            if (bl)
            {
                if (frame1.BackgroundColor == Color.Red)
                {
                    label1.Text = "Стойте";
                }
                else if (frame1.BackgroundColor == Color.Black)
                {
                    label1.Text = "Красный";
                }

            }
            else
            {
                label1.Text = "Пожалуйста, включите светофор";
            }
        }

        private async void Btn2_Clicked(object sender, EventArgs e)
        {
            bl = false;
            this.BackgroundColor = Color.FromHex("40241F");
            label1.Text = "Красный";
            label2.Text = "Желтый";
            label3.Text = "Зеленый";

            while (bl)
            {

                this.BackgroundColor = Color.White;
                frame1.BackgroundColor = Color.Gray;
                await Task.Delay(100);
                frame2.BackgroundColor = Color.Gray;
                await Task.Delay(100);
                frame3.BackgroundColor = Color.Gray;
                await Task.Delay(100);
            }
        }

        private async void Btn1_Clicked(object sender, EventArgs e)
        {
            bl = true;
            if (bl)
            {
                label1.Text = "Красный";
                label2.Text = "Желтый";
                label3.Text = "Зеленый";
            }
            if (frame1.BackgroundColor == Color.Gray)
            {
                label1.Text = "Красный";
            }
            if (frame2.BackgroundColor == Color.Gray)
            {
                label2.Text = "Желтый";
            }
            if (frame1.BackgroundColor == Color.Gray)
            {
                label3.Text = "Зеленый";
            }

            while (bl)
            {

                this.BackgroundColor = Color.FromHex("193C40");
                frame1.BackgroundColor = Color.Red;
                await Task.Delay(3000);

                frame1.BackgroundColor = Color.Black;
                frame2.BackgroundColor = Color.Yellow;
                label2.TextColor = Color.Black;
                await Task.Delay(2000);

                label2.TextColor = Color.White;
                frame2.BackgroundColor = Color.Black;
                frame3.BackgroundColor = Color.Green;
                await Task.Delay(3000);

                frame3.BackgroundColor = Color.Black;
                await Task.Delay(500);

                frame3.BackgroundColor = Color.Green;
                await Task.Delay(500);

                frame3.BackgroundColor = Color.Black;
                await Task.Delay(500);

                frame3.BackgroundColor = Color.Green;
                await Task.Delay(500);

                frame3.BackgroundColor = Color.Black;
            }

        }
    }
}