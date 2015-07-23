using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using ModernHttpClient;
using Xamarin.Forms;

namespace TestWebAPI
{
	public class NewRestAgent
	{
		public async Task<string> GetStringWithoutArgument(HttpMessageHandler handler, string url)
		{
			var client = new System.Net.Http.HttpClient(handler);
            return GetStrFromStream(await client.GetStreamAsync(url));
		}

        public string GetStrFromStream(Stream stream)
        {
            var reader = new System.IO.StreamReader(stream);
            return reader.ReadToEnd();
        }
		}

    public class TestPage : ContentPage
	{
		public static readonly string WebApiUrl =  "http://httpbin.org/ip";

		Entry editUrl;
		Label testResult;

        public TestPage()
		{
            this.SetValue(Page.TitleProperty, "Test Web API v1.0.1");

			editUrl = new Entry 
			{
				Keyboard = Keyboard.Email,
				Placeholder = "Enter Web API URL",
				VerticalOptions = LayoutOptions.CenterAndExpand, 
				Text = WebApiUrl, 
				WidthRequest = 300
			};


			Button btnRunTest = new Button
			{
				Text = " Run Request ",
				Font = Font.SystemFontOfSize(NamedSize.Medium)
				//BorderWidth = 1
			};
			btnRunTest.Clicked += btnRunTest_Click;

			testResult = new Label
			{
				Font = Font.SystemFontOfSize(NamedSize.Small),
				VerticalOptions = LayoutOptions.CenterAndExpand
			};


			// Build the page
			this.Content = new StackLayout
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Children = 
				{
					new StackLayout
					{
						HorizontalOptions = LayoutOptions.Center,
						Children = 
						{
							editUrl,
							btnRunTest,
							testResult
						}
					}
				}
			};
					
		}

		async void btnRunTest_Click(object sender, EventArgs e)
		{
            string result = "";
            try
            {

			var restSa = new NewRestAgent();

			string url = editUrl.Text;

				result = await restSa.GetStringWithoutArgument(new NativeMessageHandler(), url);

			}
            catch (Exception ex)
			{
				result = ex.ToString();
			}

			//testResult.Text = result;
			//or
			await Navigation.PushAsync(new TestResultPage(result));

		}

	}
}

