using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
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

			List<string> list = CallAPI(item);

			One.Text = list[0];
			Two.Text = list[1];
			Three.Text = list[2];
			Four.Text = list[3];
			Five.Text = list[4];
		}

		public List<string> CallAPI(MenuItem menuItem)
		{
			//This makes the actual API call

			//Create an Example API
			List<string> list = ConstructList(GetResponseFromAPI(menuItem));


			return list;
		}

		public string GetResponseFromAPI(MenuItem menuItem)
		{

			//string query = constructQuery(menuItem);

			string results = "[{ One : \"Thomas 2\", Two : \"Is the best 2\", Three : \"And number three \", Four : \"And is four too much\", Five : \"A a high five\"}]"; //string results = call query.

			return results;
		}

		public List<string> ConstructList(string response)
		{

			List<string> items = new List<string>();

			dynamic jsonResult = JsonConvert.DeserializeObject(response); //var jsonResult = Newtonsoft.Json.Linq.JObject.Parse(results);

			foreach (var item in jsonResult)
			{
				items.Add(item["One"].Value);
				items.Add(item["Two"].Value);
				items.Add(item["Three"].Value);
				items.Add(item["Four"].Value);
				items.Add(item["Five"].Value);
			}

			return items;

		}
	}
}

