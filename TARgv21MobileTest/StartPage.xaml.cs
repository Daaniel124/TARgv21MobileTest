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
        List<ContentPage> pages = new List<ContentPage>()
        {
            new EditorPage(),
            new TimerPage(),
            new BoxPage(),
            new DateTimePage(),
            new StepperSlider(),
            new Rgb(),
            new Frame_Page(),
            new Frame_page_grid(),
            new PopUpPage(),
            new Puzzles()
        };

        List<string> textBtn = new List<string>()
        {
            "Editor Page",
            "Timer Page",
            "BoxView Page",
            "Date Time",
            "Stepper Slider Page",
            "Rgb Page",
            "Frame Page",
            "Frame Page Grid",
            "PopUp page",
            "Puzzles"
        };
        List<string> colorBtn = new List<string>()
        {
            "White",
            "LightBlue",
            "LightGreen"
        };
        Random rnd = new Random();
        
        public StartPage()
        {
            //InitializeComponent();
            /*Button Editor_btn = new Button
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
            };*/

            StackLayout st = new StackLayout();
            for (int i = 0; i < pages.Count; i++)
            {
                Button button = new Button
                {
                    Text = textBtn[i],
                    //BackgroundColor = Color.colorBtn[i],
                    BackgroundColor = Color.FromRgb(rnd.Next(0,255), rnd.Next(0, 255), rnd.Next(0, 255)),
                    TabIndex = i
                };
                st.Children.Add(button);
                button.Clicked += Button_Clicked;
            }
            Content = st;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button b = sender as Button;
            await Navigation.PushAsync(pages[b.TabIndex]);
        }
    }
}