// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace WearableMath
{
	[Register ("MortgageCalculatorController")]
	partial class MortgageCalculatorController
	{
		[Outlet]
		WatchKit.WKInterfaceLabel PrincipleLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		WatchKit.WKInterfaceButton InterestButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		WatchKit.WKInterfaceLabel InterestLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		WatchKit.WKInterfaceButton PrincipleButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		WatchKit.WKInterfaceLabel RepaymentsLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		WatchKit.WKInterfaceButton YearsButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		WatchKit.WKInterfaceLabel YearsLabel { get; set; }

		[Action ("YearsButtonClicked")]
		partial void YearsButtonClicked ();

		[Action ("InterestButton_Activated:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void InterestButton_Activated (WatchKit.WKInterfaceButton sender);

		[Action ("PrincipleButton_Activated:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void PrincipleButton_Activated (WatchKit.WKInterfaceButton sender);

		[Action ("YearsButton_Activated:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void YearsButton_Activated (WatchKit.WKInterfaceButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (InterestButton != null) {
				InterestButton.Dispose ();
				InterestButton = null;
			}
			if (InterestLabel != null) {
				InterestLabel.Dispose ();
				InterestLabel = null;
			}
			if (PrincipleButton != null) {
				PrincipleButton.Dispose ();
				PrincipleButton = null;
			}
			if (PrincipleLabel != null) {
				PrincipleLabel.Dispose ();
				PrincipleLabel = null;
			}
			if (RepaymentsLabel != null) {
				RepaymentsLabel.Dispose ();
				RepaymentsLabel = null;
			}
			if (YearsButton != null) {
				YearsButton.Dispose ();
				YearsButton = null;
			}
			if (YearsLabel != null) {
				YearsLabel.Dispose ();
				YearsLabel = null;
			}
		}
	}
}
