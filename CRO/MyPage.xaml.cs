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


            StackLayout content = new StackLayout();
            content.Orientation = StackOrientation.Vertical;

            foreach (FrTitle item in mylist)
            {
				StackLayout numFR = new StackLayout()
				{
					Orientation = StackOrientation.Vertical
				};

				Label title = new Label()
				{
					Text = item.LibraryTitle,
					HorizontalOptions = LayoutOptions.Center
				};
				numFR.Children.Add(title);

				StackLayout details = new StackLayout()
				{
					Orientation = StackOrientation.Horizontal
				};
				Image img = new Image()
				{
                    Source = "http://cbibli.esy.es/paniniImage/" + item.Ean + ".jpeg",
					WidthRequest = 150
				};
				details.Children.Add(img);

				StackLayout details_muneros = new StackLayout()
				{
					Orientation = StackOrientation.Vertical
				};
                foreach (UsTitle ustitle in item.UsTitle)
                {
					Label lb = new Label()
					{
                        Text = ustitle.TitleName
					};
					details_muneros.Children.Add(lb);

					
                }
                details.Children.Add(details_muneros);
				numFR.Children.Add(details);
				content.Children.Add(numFR);

            }


			//end for each numFR

			var scrollView = new ScrollView { Content = content };

            Content = scrollView ;
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
