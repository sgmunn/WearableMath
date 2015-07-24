//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="InterfaceController.cs" company="(c) Greg Munn">
//    (c) 2014 (c) Greg Munn  All Rights Reserved
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------
using System;

using WatchKit;
using Foundation;
using UIKit;

namespace WearableMath
{
	public partial class InterfaceController : WKInterfaceController
	{
		private readonly CalculatorApp app;

		public InterfaceController (IntPtr handle) : base (handle)
		{
			this.app = CalculatorApp.Default;
		}

		public override void Awake (NSObject context)
		{
			base.Awake (context);

			// Configure interface objects here.
			Console.WriteLine ("{0} awake with context", this);
		}

		public override void WillActivate ()
		{
			// This method is called when the watch view controller is about to be visible to the user.
			Console.WriteLine ("{0} will activate", this);
			this.DisplayKeyboard ();
			this.DisplayValue ();
		}

		public override void DidDeactivate ()
		{
			// This method is called when the watch view controller is no longer visible to the user.
			Console.WriteLine ("{0} did deactivate", this);
		}

		private void DisplayKeyboard ()
		{
			this.Button0.SetTitle (this.app.Buttons [0].Label);
			this.Button1.SetTitle (this.app.Buttons [1].Label);
			this.Button2.SetTitle (this.app.Buttons [2].Label);
			this.Button3.SetTitle (this.app.Buttons [3].Label);
			this.Button4.SetTitle (this.app.Buttons [4].Label);
			this.Button5.SetTitle (this.app.Buttons [5].Label);
			this.Button6.SetTitle (this.app.Buttons [6].Label);
			this.Button7.SetTitle (this.app.Buttons [7].Label);
			this.Button8.SetTitle (this.app.Buttons [8].Label);
			this.Button9.SetTitle (this.app.Buttons [9].Label);
			this.Button10.SetTitle (this.app.Buttons [10].Label);
			this.Button11.SetTitle (this.app.Buttons [11].Label);

			this.Button0.SetBackgroundColor (this.app.Buttons [0].Dark ? UIColor.LightGray : UIColor.ViewFlipsideBackgroundColor);
			this.Button1.SetBackgroundColor (this.app.Buttons [1].Dark ? UIColor.LightGray : UIColor.ViewFlipsideBackgroundColor);
			this.Button2.SetBackgroundColor (this.app.Buttons [2].Dark ? UIColor.LightGray : UIColor.ViewFlipsideBackgroundColor);
			this.Button3.SetBackgroundColor (this.app.Buttons [3].Dark ? UIColor.LightGray : UIColor.ViewFlipsideBackgroundColor);
			this.Button4.SetBackgroundColor (this.app.Buttons [4].Dark ? UIColor.LightGray : UIColor.ViewFlipsideBackgroundColor);
			this.Button5.SetBackgroundColor (this.app.Buttons [5].Dark ? UIColor.LightGray : UIColor.ViewFlipsideBackgroundColor);
			this.Button6.SetBackgroundColor (this.app.Buttons [6].Dark ? UIColor.LightGray : UIColor.ViewFlipsideBackgroundColor);
			this.Button7.SetBackgroundColor (this.app.Buttons [7].Dark ? UIColor.LightGray : UIColor.ViewFlipsideBackgroundColor);
			this.Button8.SetBackgroundColor (this.app.Buttons [8].Dark ? UIColor.LightGray : UIColor.ViewFlipsideBackgroundColor);
			this.Button9.SetBackgroundColor (this.app.Buttons [9].Dark ? UIColor.LightGray : UIColor.ViewFlipsideBackgroundColor);
			this.Button10.SetBackgroundColor (this.app.Buttons [10].Dark ? UIColor.LightGray : UIColor.ViewFlipsideBackgroundColor);
			this.Button11.SetBackgroundColor (this.app.Buttons [11].Dark ? UIColor.LightGray : UIColor.ViewFlipsideBackgroundColor);
		}

		private void DisplayValue ()
		{
			this.ResultLabel.SetText (this.app.DisplayValue.ToString ());
		}

		partial void Button0_Activated (WKInterfaceButton sender)
		{
			if (this.app.ButtonClicked (0))
				this.DisplayKeyboard ();
			
			this.DisplayValue ();
		}

		partial void Button1_Activated (WKInterfaceButton sender)
		{
			if (this.app.ButtonClicked (1))
				this.DisplayKeyboard ();

			this.DisplayValue ();
		}

		partial void Button2_Activated (WKInterfaceButton sender)
		{
			if (this.app.ButtonClicked (2))
				this.DisplayKeyboard ();

			this.DisplayValue ();
		}

		partial void Button3_Activated (WKInterfaceButton sender)
		{
			if (this.app.ButtonClicked (3))
				this.DisplayKeyboard ();

			this.DisplayValue ();
		}

		partial void Button4_Activated (WKInterfaceButton sender)
		{
			if (this.app.ButtonClicked (4))
				this.DisplayKeyboard ();

			this.DisplayValue ();
		}

		partial void Button5_Activated (WKInterfaceButton sender)
		{
			if (this.app.ButtonClicked (5))
				this.DisplayKeyboard ();

			this.DisplayValue ();
		}

		partial void Button6_Activated (WKInterfaceButton sender)
		{
			if (this.app.ButtonClicked (6))
				this.DisplayKeyboard ();

			this.DisplayValue ();
		}

		partial void Button7_Activated (WKInterfaceButton sender)
		{
			if (this.app.ButtonClicked (7))
				this.DisplayKeyboard ();

			this.DisplayValue ();
		}

		partial void Button8_Activated (WKInterfaceButton sender)
		{
			if (this.app.ButtonClicked (8))
				this.DisplayKeyboard ();

			this.DisplayValue ();
		}

		partial void Button9_Activated (WKInterfaceButton sender)
		{
			if (this.app.ButtonClicked (9))
				this.DisplayKeyboard ();

			this.DisplayValue ();
		}

		partial void Button10_Activated (WKInterfaceButton sender)
		{
			if (this.app.ButtonClicked (10))
				this.DisplayKeyboard ();

			this.DisplayValue ();
		}

		partial void Button11_Activated (WKInterfaceButton sender)
		{
			if (this.app.ButtonClicked (11))
				this.DisplayKeyboard ();

			this.DisplayValue ();
		}
	}
}