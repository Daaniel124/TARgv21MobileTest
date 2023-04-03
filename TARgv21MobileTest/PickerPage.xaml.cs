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
    public partial class PickerPage : ContentPage
    {
        Picker picker;
        WebView webview;
        Frame frame;
        StackLayout st;
        string[] pages = new string[3] { "https://tahvel.edu.ee", "https://moodle.edu.ee", "https://www.tthk.ee" };
        public PickerPage()
        {
            picker = new Picker
            {
                Title = "Pages"
            };
            picker.Items.Add("Tahvel");
            picker.Items.Add("Moodle");
            picker.Items.Add("TTHK");
            webview= new WebView { Source = new UrlWebViewSource { Url = pages[0] } };
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
            frame = new Frame
            {
                Content= webview,
                BorderColor = Color.Black,
                CornerRadius = 10,
                HeightRequest = 100,
                WidthRequest = 200,
                VerticalOptions= LayoutOptions.Center,
                HorizontalOptions= LayoutOptions.CenterAndExpand,
                HasShadow= true
            };
            st = new StackLayout { Children = {picker, frame} };
            Content = st;
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            webview.Source = new UrlWebViewSource { Url = pages[picker.SelectedIndex] };
        }
    }
}