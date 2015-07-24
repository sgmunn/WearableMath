
using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace WearableMath.Wear
{
	public class MortageFragment : Fragment
	{
		private readonly CalculatorApp app;
		private readonly MortgageCalculator calc;

		private Button principleButton;
		private Button interestButton;
		private Button yearsButton;
		private TextView principleLabel;
		private TextView interestLabel;
		private TextView yearsLabel;
		private TextView repaymentsLabel;

		public MortageFragment ()
		{
			this.app = CalculatorApp.Default;
			this.calc = new MortgageCalculator ();
			this.calc.Interest = 4.5f / 12f;
			this.calc.Periods = 30 * 12;
		}

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			return inflater.Inflate(Resource.Layout.Mortgage, container, false);
		}

		public override void OnViewCreated (View view, Bundle savedInstanceState)
		{
			base.OnViewCreated (view, savedInstanceState);
			this.CalculatorLayoutInflated (view);
		}

		public override void OnStart ()
		{
			base.OnStart ();
			this.Display ();
		}

		private void CalculatorLayoutInflated (View view)
		{
			this.principleButton = view.FindViewById<Button> (Resource.Id.principleButton);
			this.interestButton = view.FindViewById<Button> (Resource.Id.interestButton);
			this.yearsButton = view.FindViewById<Button> (Resource.Id.yearsButton);

			this.principleLabel = view.FindViewById<TextView> (Resource.Id.principleLabel);
			this.interestLabel = view.FindViewById<TextView> (Resource.Id.interestLabel);
			this.yearsLabel = view.FindViewById<TextView> (Resource.Id.yearsLabel);
			this.repaymentsLabel = view.FindViewById<TextView> (Resource.Id.repaymentsLabel);

			this.principleButton.Click -= PrincipleButton_Click;
			this.principleButton.Click += PrincipleButton_Click;

			this.interestButton.Click -= InterestButton_Click;
			this.interestButton.Click += InterestButton_Click;

			this.yearsButton.Click -= YearsButton_Click;
			this.yearsButton.Click += YearsButton_Click;

			this.Display ();
		}

		private void PrincipleButton_Click (object sender, EventArgs e)
		{
			this.principleLabel.Text = CalculatorApp.Default.DisplayValue.ToString ();
			this.calc.Principle = (double)CalculatorApp.Default.DisplayValue;

			this.Display ();
			this.app.AllClear ();
		}

		private void InterestButton_Click (object sender, EventArgs e)
		{
			this.interestLabel.Text = CalculatorApp.Default.DisplayValue.ToString ();
			calc.Interest = (double)CalculatorApp.Default.DisplayValue / 12f;

			this.Display ();
			this.app.AllClear ();
		}

		private void YearsButton_Click (object sender, EventArgs e)
		{
			this.yearsLabel.Text = CalculatorApp.Default.DisplayValue.ToString ();
			calc.Periods = (int)CalculatorApp.Default.DisplayValue * 12;

			this.Display ();
			this.app.AllClear ();
		}

		private void Display ()
		{
			this.repaymentsLabel.Text = this.calc.Repayments.ToString ("N2");
			this.principleLabel.Text = this.calc.Principle.ToString ("N2");
			this.interestLabel.Text = (this.calc.Interest * 12).ToString ("N2");
			this.yearsLabel.Text = (this.calc.Periods / 12).ToString ();
		}
	}
}