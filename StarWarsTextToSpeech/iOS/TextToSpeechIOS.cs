using System;
using StarWarsTextToSpeech.iOS;
using AVFoundation;

[assembly: Xamarin.Forms.Dependency (typeof (TextToSpeechIOS))]

namespace StarWarsTextToSpeech.iOS
{
	public class TextToSpeechIOS : ITextToSpeech
	{
		public void Speak(string text){
			var speechSynthesizer = new AVSpeechSynthesizer ();
			var speechUtterance = new AVSpeechUtterance (text) {
				Rate = AVSpeechUtterance.MaximumSpeechRate/2,
				Voice = AVSpeechSynthesisVoice.FromLanguage ("en-US"),
				Volume = 1.0f,
				PitchMultiplier = 1.0f
			};

			speechSynthesizer.SpeakUtterance (speechUtterance);
		}
	}
}

