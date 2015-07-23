using System;
using Xamarin.Forms;

namespace TestWebAPI
{
	class TestResultPage : ContentPage
	{
		public TestResultPage(string results)
		{
			this.SetValue(Page.TitleProperty, "Test Results");

			ScrollView scrollView = new ScrollView
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				Content = new Label
				{
					Text = results,
					Font = Font.SystemFontOfSize(NamedSize.Small)
				}
			};

			// Build the page.
			this.Content = new StackLayout
			{
				Children = 
				{
					scrollView
				}
			};
		}
	}
}
