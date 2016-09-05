using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace AppAPITemplate
{
	public class FirstMenu : Menu
	{
		public FirstMenu()
		{
			Title = "API Template";
			Content = list;

			list.ItemsSource = CallAPI(); //Need to add an "await" into this

			list.ItemTapped += (sender, e) =>
			{
				list.SelectedItem = null;
				//Navigation.PushAsync(new SecondMenu(e.Item as MenuItem));
				ClickMenuItem(e.Item as MenuItem);
			};
		}

		public List<MenuItem> CallAPI()
		{
			List<MenuItem> menuList = ConstructMenuItemList(GetResponseFromAPI(new MenuItem()));

			return menuList;
		}

		public void ClickMenuItem(MenuItem itemClicked)
		{
			//Implements menu item click
			//e.g. Navigation.PushAsync(new SecondMenu(e.Item as string));
			Navigation.PushAsync(new SecondMenu(itemClicked));
		}


		public string GetResponseFromAPI(MenuItem menuItem) {

			//string query = constructQuery(menuItem);

			string results = "[{ Name : \"FTSE 100 Index\", Description : \"Number 6\"}, { Name : \"NYSE Composite Index\", Description : \"Number 5\"}, { Name : \"NASDAQ 100 Index\", Description : \"Number 4\"}, { Name : \"NASDAQ Composite Index\", Description : \"Number 3\"}, { Name : \"S&P 500 Index\", Description : \"Number 1\"}, {Name : \"Dow Jones Industrial Average\", Description : \"Number 2\"}]"; //string results = call query.

			return results;
		}

		public List<MenuItem> ConstructMenuItemList(string response) {

			List<MenuItem> menuItems = new List<MenuItem>();

			dynamic jsonResult = JsonConvert.DeserializeObject(response); //var jsonResult = Newtonsoft.Json.Linq.JObject.Parse(results);

			foreach (var item in jsonResult)
			{
				MenuItem tempMenuItem = new MenuItem();

				tempMenuItem.Name = item["Name"].Value;
				tempMenuItem.Description = item["Description"].Value;


				menuItems.Add(tempMenuItem);


			}


			return menuItems;

		}


		/*
			constructQuery(MenuItem menuItem) {

				return query;
	
			}
		*/

	}
}

