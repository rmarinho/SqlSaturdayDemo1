using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace SqlSaturdayDemo1
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			var tabbedPage = new TabbedPage ();

			tabbedPage.Children.Add (DemoPage ("Page 1", "Hello Page 1"));
			tabbedPage.Children.Add (DemoPage ("Page 2", "Hello Page 2"));
			tabbedPage.Children.Add (ListPage());
			return new NavigationPage(tabbedPage);

		}
	
		public static Page ListPage(){
		
			var rootLayout = new StackLayout ();
		
			var items =	new ObservableCollection<string>();
		
			var listview = new ListView { ItemsSource = items };
			rootLayout.Children.Add (listview);

			var btnAddItem = new Button { Text="Add new item"};
			rootLayout.Children.Add (btnAddItem);

			btnAddItem.Clicked += (object sender, EventArgs e) => {
				items.Add(string.Format("Item {0}",items.Count));
			};

			listview.ItemSelected += async (object sender, SelectedItemChangedEventArgs e) => {
				await rootLayout.Navigation.PushAsync(DemoPage("Detail",e.SelectedItem.ToString()));
			};

			return new ContentPage {
				Title = "List Page",
				Content = rootLayout
			};
		}

		public static Page DemoPage(string title , string contentMsg){
			return new ContentPage {
				Title = title,
				Content = new Label {
					Text = contentMsg,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
				},
			};
		}
	}
}

