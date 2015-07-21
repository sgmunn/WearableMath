//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="MortgageCalcController.cs" company="(c) Greg Munn">
//    (c) 2014 (c) Greg Munn  All Rights Reserved
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------
using System;
using WatchKit;
using Foundation;

namespace WearableMath
{
	public partial class MortgageCalcController : WKInterfaceController
	{
		public MortgageCalcController (IntPtr handle) : base (handle)
		{
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
		}

		public override void DidDeactivate ()
		{
			// This method is called when the watch view controller is no longer visible to the user.
			Console.WriteLine ("{0} did deactivate", this);
		}
//
//		partial void PrincipleButton_Activated ()
//		{
//			Console.WriteLine ("{0} did principle", this);
//		}
	}
}