using System;

using Xamarin.Forms;

namespace StarWarsTextToSpeech
{
	public class Home : ContentPage
	{
		int currentPicture = 0;
		Image image;
		Label imageLabel;
		string[] imageNames = new string[] { "C-3PO", "Chewbacca", "Darth Vader", "Luke SkyWalker",
			"Princess Leia","R2D2", "Yoda" };
		string[] imageFileNames = new string[] { "C3PO.PNG", "Chewbacca.PNG", "DarthVader.PNG", "LukeSkyWalker.PNG",
			"PrincessLeia.PNG","R2D2.PNG", "Yoda.PNG" };
		public Home ()
		{
			Label title = new Label
			{
				Text = "Star Wars Images",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
			};
			imageLabel = new Label
			{
				Text = "C-3PO",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
			};
			image = new Image
			{
				VerticalOptions = LayoutOptions.StartAndExpand,	
				HeightRequest = 350,
				WidthRequest = 275
			};
			image.Source = ImageSource.FromFile(imageFileNames[0]);

			Button previousButton = new Button
			{
				Text = "Prev",
				HorizontalOptions = LayoutOptions.StartAndExpand
			};
			previousButton.Clicked += PreviousButton_Clicked;

			Button nextButton = new Button
			{
				Text = "Next",
				HorizontalOptions = LayoutOptions.EndAndExpand
			};
			nextButton.Clicked += NextButton_Clicked;
			StackLayout navigationStack = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				Children = {previousButton, nextButton}
			};

			StackLayout stack = new StackLayout
			{
				Children = { title, imageLabel, image, navigationStack}
			};

			this.Padding = new Thickness(10, Device.OnPlatform(20, 10, 10), 10, 10);
			this.Content = stack;
		}

		private void NextButton_Clicked(object sender, EventArgs e)
		{
			if (currentPicture == 6)
				currentPicture = 0;
			else
				currentPicture++;
			image.Source = ImageSource.FromFile(imageFileNames[currentPicture]);
			imageLabel.Text = imageNames[currentPicture];
			DependencyService.Get<ITextToSpeech> ().Speak (imageNames[currentPicture]);
		}

		private void PreviousButton_Clicked(object sender, EventArgs e)
		{
			if (currentPicture == 0)
				currentPicture = 6;
			else
				currentPicture--;
			image.Source = ImageSource.FromFile(imageFileNames[currentPicture]);
			imageLabel.Text = imageNames[currentPicture];
			DependencyService.Get<ITextToSpeech> ().Speak (imageNames[currentPicture]);
		}
	}
}


