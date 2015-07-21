using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace WearableMath
{
	partial class MortgageCalculatorController : WatchKit.WKInterfaceController
	{
		private readonly IMortgageCalculator calc;

		public MortgageCalculatorController (IntPtr handle) : base (handle)
		{
			this.calc = new MortgageCalculator ();
			this.calc.Interest = 4.75f / 12f;
			this.calc.Periods = 30 * 12;
		}

		private void Display ()
		{
			this.PrincipleLabel.SetText (this.calc.Principle.ToString ("N2"));
			this.InterestLabel.SetText ((this.calc.Interest * 12).ToString ("N2"));
			this.YearsLabel.SetText ((this.calc.Periods / 12).ToString ());
			this.RepaymentsLabel.SetText (this.calc.Repayments.ToString ("N2"));
		}

		partial void PrincipleButton_Activated (WatchKit.WKInterfaceButton sender)
		{
			this.PrincipleLabel.SetText (CalculatorApp.Default.DisplayValue.ToString ());
			this.calc.Principle = (double)CalculatorApp.Default.DisplayValue;

			this.Display ();
		}

		partial void InterestButton_Activated (WatchKit.WKInterfaceButton sender)
		{
			this.InterestLabel.SetText (CalculatorApp.Default.DisplayValue.ToString ());
			calc.Interest = (double)CalculatorApp.Default.DisplayValue / 12f;

			this.Display ();
		}

		partial void YearsButton_Activated (WatchKit.WKInterfaceButton sender)
		{
			this.YearsLabel.SetText (CalculatorApp.Default.DisplayValue.ToString ());
			calc.Periods = (int)CalculatorApp.Default.DisplayValue * 12;

			this.Display ();
		}
	}
}
