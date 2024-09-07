using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MortgageCalculator : Page
	{
		public MortgageCalculator()
		{
			this.InitializeComponent();
		}


		private void ExitButton_Click_1(object sender, RoutedEventArgs e)
		{
			principalBorrowTextBox.Text = "";
			yearsTextBox.Text = "";
			monthsTextBox.Text = "";
			yearlyInterestRateTextBox.Text = "";
			monthlyInterestRateTextBox.Text = "";
			monthlyRepaymentTextBox.Text = "";

		}

		private void CalculateButton_Click(object sender, RoutedEventArgs e)
		{
			double principal = double.Parse(principalBorrowTextBox.Text);
			double yearlyInterestRate = double.Parse(yearlyInterestRateTextBox.Text);
			double years = double.Parse(yearsTextBox.Text);
			double months = double.Parse(monthsTextBox.Text);


			months = (years *12) + months;

			if (yearlyInterestRate > 1)
			{
				yearlyInterestRate /= 100;
			}

			double monthlyInterestRate = yearlyInterestRate / 12;
			monthlyInterestRateTextBox.Text = monthlyInterestRate.ToString("P");


			double monthlyRepayments = (principal * monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, months)) / (Math.Pow(1 + monthlyInterestRate, months) - 1);
			monthlyRepaymentTextBox.Text = monthlyRepayments.ToString("C");
			


		}
	}
}
