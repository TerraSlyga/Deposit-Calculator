using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositCalculator
{
	internal class InterestRates
	{
		private Dictionary<string, Dictionary<int, double>> _depositInterestRates = new Dictionary<string, Dictionary<int, double>>();

		public void AddInterestRates(string currency, int period, double rate)
		{
			if (!_depositInterestRates.ContainsKey(currency))
			{
				_depositInterestRates[currency] = new Dictionary<int, double>();
			}
			_depositInterestRates[currency][period] = rate;
		}

		public void AddInterestRates(InterestRates interestRates)
		{
			foreach (var currency in interestRates._depositInterestRates)
			{
				foreach (var period in currency.Value)
				{
					AddInterestRates(currency.Key, period.Key, period.Value);
				}
			}
		}

		public Dictionary<int, double> this[string currency]
		{
			get => _depositInterestRates[currency];
		}

		public double this[string outerKey, int innerKey]
		{
			get
			{
				if (_depositInterestRates.ContainsKey(outerKey) && _depositInterestRates[outerKey].ContainsKey(innerKey))
				{
					return _depositInterestRates[outerKey][innerKey];
				}
				throw new KeyNotFoundException("The key combination does not exist.");
			}
			set
			{
				if (!_depositInterestRates.ContainsKey(outerKey))
				{
					_depositInterestRates[outerKey] = new Dictionary<int, double>();
				}
				_depositInterestRates[outerKey][innerKey] = value;
			}
		}


	}
}
