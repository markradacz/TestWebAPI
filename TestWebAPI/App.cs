using System;
using Xamarin.Forms;

namespace TestWebAPI
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			var navpage = new NavigationPage(new TestPage());
			//navpage.BarBackgroundColor = Helpers.Color.Blue.ToFormsColor ();

			return navpage;
		}
	}
}

