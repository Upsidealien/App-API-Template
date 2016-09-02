using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppAPITemplate
{
	public class InfoPage : ContentPage
	{
		/*
			Displays all the information for the API menus	
		*/
		static Label One = new Label
		{
			Text = "",
			HorizontalOptions = LayoutOptions.Start,
		};
		static Label Two = new Label
		{
			Text = "",
			HorizontalOptions = LayoutOptions.Start,
		};
		static Label Three = new Label
		{
			Text = "",
			HorizontalOptions = LayoutOptions.Start,
		};
		static Label Four = new Label
		{
			Text = "",
			HorizontalOptions = LayoutOptions.Start,
		};
		static Label Five = new Label
		{
			Text = "",
			HorizontalOptions = LayoutOptions.Start,
		};



		StackLayout pageInfo = new StackLayout
		{
			Spacing = 0,
			VerticalOptions = LayoutOptions.FillAndExpand,

			Children =
			{
				One,
				Two,
				Three,
				Four,
				Five

			},
		};


		public MenuItem currentItem;

		//This holds the Views (it will switch between saying "Loading" and showing the info)
		public InfoPage(MenuItem item)
		{
			currentItem = item;
			Content = pageInfo;


		}


		protected override async void OnAppearing()
		{
			//This will call the API and change the pageInfo once the info has been retrieved
			base.OnAppearing();
			List<string> list = await RequestTimeAsync();

			One.Text = list[0];
			Two.Text = list[1];
			Three.Text = list[2];
			Four.Text = list[3];
			Five.Text = list[4];
		}

		static async Task<List<string>> RequestTimeAsync()
		{
			//This makes the actual API call

			//Create an Example API
			List<string> list = new List<string>();
			list.Add("One");
			list.Add("Two");
			list.Add("Three");
			list.Add("Four");
			list.Add("Five");

			return list;
		}
	}
}

