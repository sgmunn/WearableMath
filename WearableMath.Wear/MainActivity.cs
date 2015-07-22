using System;

using Android.App;
using Android.OS;
using Android.Support.Wearable.Views;

namespace WearableMath.Wear
{
	[Activity (Label = "WearableMath.Wear", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private GridViewPager pager;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			var v = FindViewById<WatchViewStub> (Resource.Id.watch_view_stub);
			v.LayoutInflated += CalculatorLayoutInflated;
		}

		private void CalculatorLayoutInflated (object sender, WatchViewStub.LayoutInflatedEventArgs e)
		{
			pager = (GridViewPager)FindViewById (Resource.Id.pager);
			//pager.SetOnApplyWindowInsetsListener (this);
			pager.Adapter = new CalculatorGridPagerAdapter (this, this.FragmentManager);
		}
	}
}