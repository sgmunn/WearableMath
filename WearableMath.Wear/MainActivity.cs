using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.Wearable.Views;
using Android.Views;
using Android.Widget;

namespace WearableMath.Wear
{
	[Activity (Label = "WearableMath.Wear", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private Button[] buttons;
		private TextView resultLabel;
		private CalculatorApp app;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			this.app = new CalculatorApp ();

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			var v = FindViewById<WatchViewStub> (Resource.Id.watch_view_stub);
			v.LayoutInflated += CalculatorLayoutInflated;
		}

		private void CalculatorLayoutInflated (object sender, WatchViewStub.LayoutInflatedEventArgs e)
		{
			this.buttons = new Button[12];
			this.buttons [0] = this.FindViewById<Button> (Resource.Id.button0);
			this.buttons [1] = this.FindViewById<Button> (Resource.Id.button1);
			this.buttons [2] = this.FindViewById<Button> (Resource.Id.button2);
			this.buttons [3] = this.FindViewById<Button> (Resource.Id.button3);
			this.buttons [4] = this.FindViewById<Button> (Resource.Id.button4);
			this.buttons [5] = this.FindViewById<Button> (Resource.Id.button5);
			this.buttons [6] = this.FindViewById<Button> (Resource.Id.button6);
			this.buttons [7] = this.FindViewById<Button> (Resource.Id.button7);
			this.buttons [8] = this.FindViewById<Button> (Resource.Id.button8);
			this.buttons [9] = this.FindViewById<Button> (Resource.Id.button9);
			this.buttons [10] = this.FindViewById<Button> (Resource.Id.button10);
			this.buttons [11] = this.FindViewById<Button> (Resource.Id.button11);

			this.resultLabel = this.FindViewById<TextView> (Resource.Id.resultLabel);

			for (int i = 0; i < this.buttons.Length; i++) {
				this.buttons[i].Click -= ButtonClicked;
				this.buttons[i].Click += ButtonClicked;
			}

			this.DisplayKeyboard ();
		}

		private void ButtonClicked (object sender, EventArgs e)
		{
			for (int i = 0; i < this.buttons.Length; i++) {
				if (this.buttons[i] == sender) {
					if (this.app.ButtonClicked (i))
						this.DisplayKeyboard ();

					this.DisplayValue ();
					return;
				}
			}
		}

		private void DisplayKeyboard ()
		{
			for (int i = 0; i < this.buttons.Length; i++) {
				this.buttons [i].Text = this.app.Buttons [i].Label;

				this.buttons [i].SetBackgroundResource (this.app.Buttons [i].Dark ? Android.Resource.Drawable.DialogHoloLightFrame : Android.Resource.Drawable.DialogHoloDarkFrame);
				this.buttons [i].SetTextColor (this.app.Buttons [i].Dark ? Android.Graphics.Color.Black : Android.Graphics.Color.White);
			}
		}

		private void DisplayValue ()
		{
			this.resultLabel.Text = this.app.DisplayValue.ToString ();
		}
	}
}