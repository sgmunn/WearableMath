//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="MortgageCalculator.cs" company="(c) Greg Munn">
//    (c) 2014 (c) Greg Munn  All Rights Reserved
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------
using System;

namespace WearableMath
{
	public interface IMortgageCalculator
	{
		double Principle { get; set; }
		double Interest { get; set; }
		int Periods { get; set; }
		double Repayments { get; }
	}
	
}