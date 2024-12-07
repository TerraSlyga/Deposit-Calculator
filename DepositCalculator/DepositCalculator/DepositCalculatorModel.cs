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
		private readonly Dictionary<string, Dictionary<int,double>> _depositInterestRates = new Dictionary<string, Dictionary<int, double>>
		{
			["UAH"] = new Dictionary<int, double>
			{
				[3] =  0.15,
				[6] =  0.15,
				[9] =  0.154,
				[12] = 0.155,
				[24] = 0.16

			},
			["USD"] = new Dictionary<int, double>
			{
				[3] = 0.01,
				[6] = 0.016,
				[9] = 0.019,
				[12] = 0.021
			},
			["EUR"] = new Dictionary<int, double>
			{
				[3] = 0.001,
				[6] = 0.011,
				[9] = 0.014,
				[12] = 0.016
			}
		};

		public string CalculateDeposit(double depositAmount, int depositPeriod, int selectedPaymentMethodIndex, string selectedCurrency, int round)
		{
			try
			{
				double depositResult;
				if (selectedPaymentMethodIndex == 0)
				{
					depositResult = CalculateWithCapitalization(depositAmount, depositPeriod, selectedCurrency, round);
				}
				else
				{
					depositResult = CalculateWithMonthlyPayment(depositAmount, depositPeriod, selectedCurrency, round);
				}
				return string.Format("You will receive {0} {1} after {2} mouth", depositResult, selectedCurrency, depositPeriod);
			}
			catch (DepostitDataNotFoundExeption)
			{
				return string.Format("There is no data for {0} currency with {1} period", selectedCurrency, depositPeriod);
			}

		}

		public double CalculateWithMonthlyPayment(double depositAmount, int depositPeriod, string selectedCurrency, int round)
		{
			try
			{
				double interestRate = _depositInterestRates[selectedCurrency][depositPeriod];
				double result = depositAmount * (1f + interestRate * depositPeriod / 12);
				return Math.Round(result, round);
			}
			catch (Exception)
			{
				throw new DepostitDataNotFoundExeption();
			}
		}

		public double CalculateWithCapitalization(double depositAmount, int depositPeriod, string selectedCurrency, int round)
		{
			try
			{
				double interestRate = _depositInterestRates[selectedCurrency][depositPeriod];
				double result = depositAmount * Math.Pow(1f + interestRate / 12, depositPeriod);
				return Math.Round(result, round);

			}
			catch (Exception)
			{
				throw new DepostitDataNotFoundExeption();
			}
		}
	}
}
