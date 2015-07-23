using System;

using Android.Content;
using Android.Support.Wearable.Views;

namespace WearableMath.Wear
{
	public class CalculatorGridPagerAdapter : FragmentGridPagerAdapter
	{
		private CalculatorFragment calculatorFragment;

		public CalculatorGridPagerAdapter (Context ctx, Android.App.FragmentManager gm) :base(gm)
		{
			this.calculatorFragment = new CalculatorFragment ();
		}

		public override Android.App.Fragment GetFragment (int row, int col)
		{
			if (col == 1) {
				return new MortageFragment ();
			}

			return this.calculatorFragment;
		}

		public override int RowCount {
			get {
				return 1;
			}
		}

		public override int GetColumnCount (int rowNum)
		{
			return 2;
		}

		public void Refresh ()
		{
			this.calculatorFragment.Display ();
		}
	}
}