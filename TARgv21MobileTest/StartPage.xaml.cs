using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv21MobileTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            //InitializeComponent();
            Button Editor_btn = new Button
            {
                Text = "Editor Page",
                TextColor = Color.Black,
                BackgroundColor = Color.White
            };
            Button Timer_btn = new Button
            {
                Text = "Timer Page",
                BackgroundColor = Color.LightBlue
            };
            Button Box_btn = new Button
            {
                Text = "BoxView Page",
                BackgroundColor = Color.LightGreen
            };
            Button Valgusfoor_btn = new Button
            {
                Text = "Valgusfoor Page",
                TextColor = Color.Black,
                BackgroundColor = Color.LightYellow
            };
            StackLayout st = new StackLayout();
            st.Children.Add(Editor_btn);
            st.Children.Add(Timer_btn);
            st.Children.Add(Box_btn);
            st.Children.Add(Valgusfoor_btn);
            Content = st;
            Editor_btn.Clicked += Editor_btn_Clicked;
            Timer_btn.Clicked += Timer_btn_Clicked;
            Box_btn.Clicked += Box_btn_Clicked;
            Valgusfoor_btn.Clicked += Valgusfoor_btn_Clicked;
        }

        private async void Valgusfoor_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Valgusfoor());
        }

        private async void Box_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BoxPage());
        }

        private async void Timer_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimerPage());
        }

        private async void Editor_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditorPage());
        }
    }
}