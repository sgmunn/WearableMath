
using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace WearableMath.Wear
{
	public class CalculatorFragment : Fragment
	{
		private readonly CalculatorApp app;
		private Button[] buttons;
		private TextView resultLabel;

		public CalculatorFragment ()
		{
			this.app = CalculatorApp.Default;
		}

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			return inflater.Inflate(Resource.Layout.RectangleMain, container, false);
		}

		public override void OnViewCreated (View view, Bundle savedInstanceState)
		{
			base.OnViewCreated (view, savedInstanceState);
			this.CalculatorLayoutInflated (view);
		}

		public override void OnAttach (Activity activity)
		{
			base.OnAttach (activity);
		}

		public override void OnResume ()
		{
			base.OnResume ();
		}

		public void Display ()
		{
			this.DisplayKeyboard ();
			this.DisplayValue ();
		}

		private void CalculatorLayoutInflated (View view)
		{
			this.buttons = new Button[12];
			this.buttons [0] = view.FindViewById<Button> (Resource.Id.button0);
			this.buttons [1] = view.FindViewById<Button> (Resource.Id.button1);
			this.buttons [2] = view.FindViewById<Button> (Resource.Id.button2);
			this.buttons [3] = view.FindViewById<Button> (Resource.Id.button3);
			this.buttons [4] = view.FindViewById<Button> (Resource.Id.button4);
			this.buttons [5] = view.FindViewById<Button> (Resource.Id.button5);
			this.buttons [6] = view.FindViewById<Button> (Resource.Id.button6);
			this.buttons [7] = view.FindViewById<Button> (Resource.Id.button7);
			this.buttons [8] = view.FindViewById<Button> (Resource.Id.button8);
			this.buttons [9] = view.FindViewById<Button> (Resource.Id.button9);
			this.buttons [10] = view.FindViewById<Button> (Resource.Id.button10);
			this.buttons [11] = view.FindViewById<Button> (Resource.Id.button11);

			this.resultLabel = view.FindViewById<TextView> (Resource.Id.resultLabel);

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