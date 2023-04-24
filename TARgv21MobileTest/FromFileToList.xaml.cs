using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv21MobileTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FromFileToList : ContentPage
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string kusfile;
        string vasfile;
        List<string> kusimused = new List<string>();
        List<string> vastused = new List<string>();
        Grid gr;
        Button btn;
        Entry entry;
        public FromFileToList()
        {
            kusimused = File.ReadLines(Path.Combine(folderPath, kusfile)).ToList();
            vastused = File.ReadLines(Path.Combine(folderPath, vasfile)).ToList();
            for (int i = 0; i < 3; i++)
            {
                gr.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                for (int j = 0; j < kusimused.Count; j++)
                {
                    gr.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    gr.Children.Add(new Label { Text = kusimused[j] }, j, i);
                }
            }
            btn = new Button { Text = "Salvesta" };
            btn.Clicked += Btn_Clicked;
            entry = new Entry();
            gr.Children.Add(entry, 2, kusimused.Count - 2);
            gr.Children.Add(btn, 2, kusimused.Count - 1);
            Content = gr;
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            Salvesta("Kusimused.txt");
        }

        public async void Salvesta(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return;
            if (File.Exists(Path.Combine(folderPath, fileName)))
            {
                bool isRewrited = await DisplayAlert("Warning!", "File is already exist, do you want to replace it?", "Yes", "No");
                if (isRewrited == false) return;
            }
            File.WriteAllText(Path.Combine(folderPath, fileName), "Tekst");
        }
    }
}