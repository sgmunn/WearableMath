//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="MortgageCalculator.cs" company="(c) Greg Munn">
//    (c) 2014 (c) Greg Munn  All Rights Reserved
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------
using System;

namespace WearableMath
{
	public class MortgageCalculator : IMortgageCalculator
	{
		private double principle;
		private double interest;
		private int periods;
		private double repayments;

		public MortgageCalculator ()
		{
		}

		private void Calculate ()
		{
			// P = (Pv*R) / [1 - (1 + R)^(-n)] 
			var rate = this.interest / 100;
			double p = 0 - this.periods;
			this.repayments = principle * rate / (1 - Math.Pow((1 + rate), p));
		}

		public double Principle {
			get {
				return this.principle;
			}

			set {
				if (value >= 0) {
					this.principle = value;
					this.Calculate ();
				} else { 
					this.principle = 0;
					this.repayments = 0;
				}
			}
		}

		public double Interest {
			get {
				return this.interest;
			}

			set {
				if (value >= 0) {
					this.interest = value;
				} else { 
					this.interest = 0;
				}

				this.Calculate ();
			}
		}

		public int Periods {
			get {
				return this.periods;
			}

			set {
				if (value >= 0) {
					this.periods = value;
				} else { 
					this.periods = 0;
				}

				this.Calculate ();
			}
		}

		public double Repayments {
			get {
				return this.repayments;
			}
		}
	}
}