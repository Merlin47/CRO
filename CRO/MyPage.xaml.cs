using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Forms;
using System.Reflection;

namespace CRO
{
    
    
    public partial class MyPage : ContentPage
    {
        ObservableCollection<FrTitle> numFr = new ObservableCollection<FrTitle>();

        public MyPage()
        {
            InitializeComponent();

            string json = string.Empty;

            var assembly = typeof(MyPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("CRO.data.txt");

            using (StreamReader r = new StreamReader(stream))
            {
                 json = r.ReadToEnd();

            }
            FrTitle[] mylist = FrTitle.FromJson(json);
            CROView.ItemsSource = mylist;
        }


        void OnItemTaped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            UsTitle ustitle = (UsTitle)e.Item;
            DisplayAlert("Item Selected", ustitle.Id, "Ok");
            //((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.
        }
    }
}
