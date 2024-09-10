using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
	///

	// Add a comment for commit the branch again


	public sealed partial class CurrencyConvensionCalculator : Page
	{
		// Conversion rates
		private const double UsdToGbpRate = 0.72872436;
		private const double UsdToEurRate = 0.85189982;
		private const double UsdToInrRate = 74.257327;

		private const double GbpToUsdRate = 1.371907;
		private const double GbpToEurRate = 1.1686692;
		private const double GbpToInrRate = 101.68635;

		private const double EurToUsdRate = 1.1739732;
		private const double EurToGbpRate = 0.8556672;
		private const double EurToInrRate = 87.00755;

		private const double InrToUsdRate = 0.011492628;
		private const double InrToEurRate = 0.013492774;
		private const double InrToGbpRate = 0.0098339397;

		public CurrencyConvensionCalculator()
		{
			this.InitializeComponent();
		}

		private string GetConversionRateText(string fromCurrency, string toCurrency)
		{
			if (fromCurrency.Contains("USD"))
			{
				if (toCurrency.Contains("GBP")) return $"1 USD = {UsdToGbpRate:F8} GBP";
				if (toCurrency.Contains("EUR")) return $"1 USD = {UsdToEurRate:F8} EUR";
				if (toCurrency.Contains("INR")) return $"1 USD = {UsdToInrRate:F8} INR";
			}
			else if (fromCurrency.Contains("GBP"))
			{
				if (toCurrency.Contains("USD")) return $"1 GBP = {GbpToUsdRate:F8} USD";
				if (toCurrency.Contains("EUR")) return $"1 GBP = {GbpToEurRate:F8} EUR";
				if (toCurrency.Contains("INR")) return $"1 GBP = {GbpToInrRate:F8} INR";
			}
			else if (fromCurrency.Contains("EUR"))
			{
				if (toCurrency.Contains("USD")) return $"1 EUR = {EurToUsdRate:F8} USD";
				if (toCurrency.Contains("GBP")) return $"1 EUR = {EurToGbpRate:F8} GBP";
				if (toCurrency.Contains("INR")) return $"1 EUR = {EurToInrRate:F8} INR";
			}
			else if (fromCurrency.Contains("INR"))
			{
				if (toCurrency.Contains("USD")) return $"1 INR = {InrToUsdRate:F8} USD";
				if (toCurrency.Contains("EUR")) return $"1 INR = {InrToEurRate:F8} EUR";
				if (toCurrency.Contains("GBP")) return $"1 INR = {InrToGbpRate:F8} GBP";
			}
			return "Conversion rate not available.";
		}

		private string GetReverseConversionRateText(string fromCurrency, string toCurrency)
		{
			if (toCurrency.Contains("USD"))
			{
				if (fromCurrency.Contains("GBP")) return $"1 GBP = {GbpToUsdRate:F8} USD";
				if (fromCurrency.Contains("EUR")) return $"1 EUR = {EurToUsdRate:F8} USD";
				if (fromCurrency.Contains("INR")) return $"1 INR = {InrToUsdRate:F8} USD";
			}
			else if (toCurrency.Contains("GBP"))
			{
				if (fromCurrency.Contains("USD")) return $"1 USD = {UsdToGbpRate:F8} GBP";
				if (fromCurrency.Contains("EUR")) return $"1 EUR = {EurToGbpRate:F8} GBP";
				if (fromCurrency.Contains("INR")) return $"1 INR = {InrToGbpRate:F8} GBP";
			}
			else if (toCurrency.Contains("EUR"))
			{
				if (fromCurrency.Contains("USD")) return $"1 USD = {UsdToEurRate:F8} EUR";
				if (fromCurrency.Contains("GBP")) return $"1 GBP = {GbpToEurRate:F8} EUR";
				if (fromCurrency.Contains("INR")) return $"1 INR = {InrToEurRate:F8} EUR";
			}
			else if (toCurrency.Contains("INR"))
			{
				if (fromCurrency.Contains("USD")) return $"1 USD = {UsdToInrRate:F8} INR";
				if (fromCurrency.Contains("GBP")) return $"1 GBP = {GbpToInrRate:F8} INR";
				if (fromCurrency.Contains("EUR")) return $"1 EUR = {EurToInrRate:F8} INR";
			}
			return "Conversion rate not available.";
		}

		private async void ButtonConversion_Click(object sender, RoutedEventArgs e)
		{

			if (!double.TryParse(amountTextBox.Text, out double amount))
			{
				var dialogMessage = new MessageDialog("Please enter a valid amount.");
				await dialogMessage.ShowAsync();
				return;
			}

			string fromCurrency = ((ComboBoxItem)fromComboBox.SelectedItem)?.Content.ToString();
			string toCurrency = ((ComboBoxItem)toComboBox.SelectedItem)?.Content.ToString();

			if (fromCurrency == null || toCurrency == null)
			{
				var dialogMessage = new MessageDialog("Please select both source and target currencies.");
				await dialogMessage.ShowAsync();
				return;
			}



			double resultAmount = 0;
			string resultText1 = "";
			string resultText2 = "";

			if (fromCurrency.Contains("USD"))
			{
				if (toCurrency.Contains("GBP"))
				{
					resultAmount = amount * UsdToGbpRate;
					resultText1 = $"{amount} US Dollars =";
					resultText2 = $"$ {resultAmount:F8} British Pound";
				}
				else if (toCurrency.Contains("EUR"))
				{
					resultAmount = amount * UsdToEurRate;
					resultText1 = $"{amount} US Dollars =";
					resultText2 = $"€ {resultAmount:F8} Euro";
				}
				else if (toCurrency.Contains("INR"))
				{
					resultAmount = amount * UsdToInrRate;
					resultText1 = $"{amount} US Dollars =";
					resultText2 = $"₹ {resultAmount:F8} Indian Rupee";
				}
			}
			else if (fromCurrency.Contains("GBP"))
			{
				if (toCurrency.Contains("USD"))
				{
					resultAmount = amount * GbpToUsdRate;
					resultText1 = $"{amount} British Pounds =";
					resultText2 = $"$ {resultAmount:F8} US Dollars";
				}
				else if (toCurrency.Contains("EUR"))
				{
					resultAmount = amount * GbpToEurRate;
					resultText1 = $"{amount} British Pounds =";
					resultText2 = $"€ {resultAmount:F8} Euro";
				}
				else if (toCurrency.Contains("INR"))
				{
					resultAmount = amount * GbpToInrRate;
					resultText1 = $"{amount} British Pounds =";
					resultText2 = $"₹ {resultAmount:F8} Indian Rupee";
				}
			}
			else if (fromCurrency.Contains("EUR"))
			{
				if (toCurrency.Contains("USD"))
				{
					resultAmount = amount * EurToUsdRate;
					resultText1 = $"{amount} Euros =";
					resultText2 = $"$ {resultAmount:F8} US Dollars";
				}
				else if (toCurrency.Contains("GBP"))
				{
					resultAmount = amount * EurToGbpRate;
					resultText1 = $"{amount} Euros =";
					resultText2 = $"£ {resultAmount:F8} British Pounds";
				}
				else if (toCurrency.Contains("INR"))
				{
					resultAmount = amount * EurToInrRate;
					resultText1 = $"{amount} Euros =";
					resultText2 = $"₹ {resultAmount:F8} Indian Rupee";
				}
			}
			else if (fromCurrency.Contains("INR"))
			{
				if (toCurrency.Contains("USD"))
				{
					resultAmount = amount * InrToUsdRate;
					resultText1 = $"{amount} Indian Rupees =";
					resultText2 = $"$ {resultAmount:F8} US Dollars";
				}
				else if (toCurrency.Contains("EUR"))
				{
					resultAmount = amount * InrToEurRate;
					resultText1 = $"{amount} Indian Rupees =";
					resultText2 = $"€ {resultAmount:F8} Euros";
				}
				else if (toCurrency.Contains("GBP"))
				{
					resultAmount = amount * InrToGbpRate;
					resultText1 = $"{amount} Indian Rupees =";
					resultText2 = $"£ {resultAmount:F8} British Pounds";
				}
			}
			else
			{
				var dialogMessage = new MessageDialog("Conversion between the same currencies is not supported.");
				await dialogMessage.ShowAsync();
				return;
			}

			amountDTextBlock.Text = resultText1;
			convertTextBlock.Text = resultText2;

			fromtoTextBlock.Text = GetConversionRateText(fromCurrency, toCurrency);
			tofromTextBlock.Text = GetReverseConversionRateText(toCurrency, fromCurrency);

		}
	}
}
