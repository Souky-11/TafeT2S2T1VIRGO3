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
using System.Windows;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainMenu : Page
	{
		public MainMenu()
		{
			this.InitializeComponent();
		}

		private void Heading_SelectionChanged(object sender, RoutedEventArgs e)
		{

        }

		private void MathsCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			//NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
			MainPage mainPage = new MainPage();
			this.Content = mainPage;
		}

		private void MortgageCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			MortgageCalculator mortgageCalculator = new MortgageCalculator();
			this.Content = mortgageCalculator;
		}

		private void CurrencyConverterButton_Click(object sender, RoutedEventArgs e)
		{
			CurrencyConvensionCalculator calculator = new CurrencyConvensionCalculator();
			this.Content = calculator;
		}

		private async void TripCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			var dialogMessage = new MessageDialog("Trip calculator C# code will be developed later");
			await dialogMessage.ShowAsync();

		}
	}
}
