using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositCalculator
{
	internal class DepositCalculatorModel
	{
		// Dictionary with deposit interest rates for different currencies and periods
		Dictionary<string, Dictionary<int,List<double>>> _depositInterestRates = new Dictionary<string, Dictionary<int, List<double>>>
		{
			["UAH"] = new Dictionary<int, List<double>>
			{
				[3] = new List<double> { 15, 6 },
				[6] = new List<double> { 15.2, 7 },
				[9] = new List<double> { 15.4, 8 },
				[12] = new List<double> { 15.5, 9 },
				[24] = new List<double> { 16, 9 }
			},
			["USD"] = new Dictionary<int, List<double>>
			{
				[3] = new List<double> { 0.1, 0.1 },
				[6] = new List<double> { 1.6, 1.6 },
				[9] = new List<double> { 1.9, 1.9 },
				[12] = new List<double> { 2.1, 2.1 }
			},
			["EUR"] = new Dictionary<int, List<double>>
			{
				[3] = new List<double> { 0.1, 0.1 },
				[6] = new List<double> { 1.1, 1.1 },
				[9] = new List<double> { 1.4, 1.4 },
				[12] = new List<double> { 1.6, 1.6 }
			}
		};

		public double CalculateDeposit(double depositAmount, int depositPeriod, int selectedPaymentMethodIndex, string selectedCurrency, int round)
		{
			double interestRate = _depositInterestRates[selectedCurrency][depositPeriod][selectedPaymentMethodIndex];
			double result = Math.Round(depositAmount * (1 + interestRate / 100 * depositPeriod / 12), round);
			return result;
		}
	}
}
