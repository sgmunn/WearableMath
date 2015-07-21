//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CalculatorApp.cs" company="(c) Greg Munn">
//    (c) 2014 (c) Greg Munn  All Rights Reserved
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace WearableMath
{
	public class CalculatorApp
	{
		private readonly ButtonArrangement[] numberButtons;
		private readonly ButtonArrangement[] actionButtons;

		private string inputText;
		private decimal lastInputValue;
		private CalculatorButton lastActionButton;

		public CalculatorApp ()
		{
			this.numberButtons = new ButtonArrangement [12];
			this.actionButtons = new ButtonArrangement [12];

			this.InitNumberButtons ();
			this.InitActionButtons ();

			this.AllClear ();
		}

		public bool KeyboardToggled { get; private set; }

		public decimal Value { get; private set; }

		public string ValueText { 
			get {
				if (!string.IsNullOrEmpty (this.inputText))
					return this.inputText;
				
				return this.Value.ToString ();
			}
		}

		public string CurrentOperationLabel { get; private set; }

		public ButtonArrangement[] Buttons {
			get {
				return this.KeyboardToggled ? this.actionButtons : this.numberButtons;
			}
		}

		private bool AllClear ()
		{
			this.inputText = "0";
			this.lastActionButton = CalculatorButton.Plus;
			this.lastInputValue = 0;
			this.Value = 0;
			return true;
		}

		public bool ButtonClicked (int index)
		{
			if (index < 0 || index > (this.Buttons.Length - 1))
				return false;

			var button = this.Buttons [index];
			switch (button.Button) {
			case CalculatorButton.Toggle:
				return Toggle ();
			case CalculatorButton.Number0:
				return InputNumber ("0");
			case CalculatorButton.Number1:
				return InputNumber ("1");
			case CalculatorButton.Number2:
				return InputNumber ("2");
			case CalculatorButton.Number3:
				return InputNumber ("3");
			case CalculatorButton.Number4:
				return InputNumber ("4");
			case CalculatorButton.Number5:
				return InputNumber ("5");
			case CalculatorButton.Number6:
				return InputNumber ("6");
			case CalculatorButton.Number7:
				return InputNumber ("7");
			case CalculatorButton.Number8:
				return InputNumber ("8");
			case CalculatorButton.Number9:
				return InputNumber ("9");
			case CalculatorButton.Decimal:
				return InputDecimal ();
			case CalculatorButton.Plus:
			case CalculatorButton.Subtract:
			case CalculatorButton.Multiply:
			case CalculatorButton.Divide:
				return this.PerformAction (button.Button);
			case CalculatorButton.Equals:
				return PerformEquals ();
			}

			return false;
		}

		private bool Toggle ()
		{
			this.KeyboardToggled = !this.KeyboardToggled;
			return true;
		}

		private bool InputNumber (string number)
		{
			if (this.inputText == "0") {
				this.inputText = number;
				return false;
			}
				
			this.inputText += number;
			return false;
		}

		private bool InputDecimal ()
		{
			if (!this.inputText.Contains ("."))
				this.inputText += ".";
			return false;
		}

		private void ParseInput ()
		{
			if (!this.inputText.Contains (".")) {
				decimal v;
				if (decimal.TryParse (this.inputText, out v)) {
					this.lastInputValue = v;
				} else {
					this.lastInputValue = 0;
				}
			}
		}

		private void PerformPendingOperation ()
		{
			switch (this.lastActionButton) {
			case CalculatorButton.Plus:
				this.Value += this.lastInputValue;
				return;
			case CalculatorButton.Subtract:
				this.Value -= this.lastInputValue;
				return;
			case CalculatorButton.Multiply:
				this.Value *= this.lastInputValue;
				return;
			case CalculatorButton.Divide:
				this.Value /= this.lastInputValue;
				return;
			default:
				this.Value = this.lastInputValue;
				return;
			}
		}

		private bool PerformAction (CalculatorButton button)
		{
			this.ParseInput ();
			this.PerformPendingOperation ();
			this.lastActionButton = button;
			this.inputText = "";
			this.KeyboardToggled = false;
			return true;
		}

		private bool PerformEquals ()
		{
			this.ParseInput ();
			this.PerformPendingOperation ();
			this.lastActionButton = CalculatorButton.Plus;
			this.inputText = "";
			this.KeyboardToggled = false;
			return true;
		}

		private void InitNumberButtons ()
		{
			this.numberButtons [0] = new ButtonArrangement { Button = CalculatorButton.Number0, Dark = false, Label = "0" };
			this.numberButtons [1] = new ButtonArrangement { Button = CalculatorButton.Decimal, Dark = false, Label = "." };
			this.numberButtons [2] = new ButtonArrangement { Button = CalculatorButton.Toggle, Dark = true, Label = "+/-" };
			this.numberButtons [3] = new ButtonArrangement { Button = CalculatorButton.Number1, Dark = false, Label = "1" };
			this.numberButtons [4] = new ButtonArrangement { Button = CalculatorButton.Number2, Dark = false, Label = "2" };
			this.numberButtons [5] = new ButtonArrangement { Button = CalculatorButton.Number3, Dark = false, Label = "3" };
			this.numberButtons [6] = new ButtonArrangement { Button = CalculatorButton.Number4, Dark = false, Label = "4" };
			this.numberButtons [7] = new ButtonArrangement { Button = CalculatorButton.Number5, Dark = false, Label = "5" };
			this.numberButtons [8] = new ButtonArrangement { Button = CalculatorButton.Number6, Dark = false, Label = "6" };
			this.numberButtons [9] = new ButtonArrangement { Button = CalculatorButton.Number7, Dark = false, Label = "7" };
			this.numberButtons [10] = new ButtonArrangement { Button = CalculatorButton.Number8, Dark = false, Label = "8" };
			this.numberButtons [11] = new ButtonArrangement { Button = CalculatorButton.Number9, Dark = false, Label = "9" };
		}

		private void InitActionButtons ()
		{
			this.actionButtons [0] = new ButtonArrangement { Button = CalculatorButton.Equals, Dark = true, Label = "=" };
			this.actionButtons [1] = new ButtonArrangement { Button = CalculatorButton.None, Dark = false, Label = "" };
			this.actionButtons [2] = new ButtonArrangement { Button = CalculatorButton.Toggle, Dark = true, Label = "+/-" };
			this.actionButtons [3] = new ButtonArrangement { Button = CalculatorButton.None, Dark = false, Label = "" };
			this.actionButtons [4] = new ButtonArrangement { Button = CalculatorButton.None, Dark = false, Label = "" };
			this.actionButtons [5] = new ButtonArrangement { Button = CalculatorButton.None, Dark = false, Label = "" };
			this.actionButtons [6] = new ButtonArrangement { Button = CalculatorButton.Subtract, Dark = true, Label = "-" };
			this.actionButtons [7] = new ButtonArrangement { Button = CalculatorButton.Plus, Dark = true, Label = "+" };
			this.actionButtons [8] = new ButtonArrangement { Button = CalculatorButton.None, Dark = false, Label = "" };
			this.actionButtons [9] = new ButtonArrangement { Button = CalculatorButton.Divide, Dark = true, Label = "/" };
			this.actionButtons [10] = new ButtonArrangement { Button = CalculatorButton.Multiply, Dark = true, Label = "*" };
			this.actionButtons [11] = new ButtonArrangement { Button = CalculatorButton.None, Dark = false, Label = "" };
		}
	}

	public struct ButtonArrangement 
	{
		public CalculatorButton Button;
		public bool Dark;
		public string Label;
	}

	public enum CalculatorButton
	{
		None,
		Number1,
		Number2,
		Number3,
		Number4,
		Number5,
		Number6,
		Number7,
		Number8,
		Number9,
		Number0,
		Toggle,
		Decimal,
		Plus,
		Subtract,
		Multiply,
		Divide,
		Equals
	}
}