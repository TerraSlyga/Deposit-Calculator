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


		/// <summary>
		/// Adds interest rates to the dictionary using currency and period as keys
		/// </summary>
		/// <param name="currency">Currency</param>
		/// <param name="period">Period of deposit</param>
		/// <param name="rate">Interest rate</param>
		public void AddInterestRates(string currency, int period, double rate)
		{
			if (!_depositInterestRates.ContainsKey(currency))
			{
				_depositInterestRates[currency] = new Dictionary<int, double>();
			}
			_depositInterestRates[currency][period] = rate;
		}

		/// <summary>
		/// Adds interest rates to the dictionary using another InterestRates object
		/// </summary>
		/// <param name="interestRates">InterestRates object</param>
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

		/// <summary>
		/// Overloaded indexer for the dictionary
		/// </summary>
		/// <param name="currency"></param>
		/// <returns></returns>
		public Dictionary<int, double> this[string currency]
		{
			get => _depositInterestRates[currency];
		}

		/// <summary>
		/// Overloaded double indexer for the dictionary
		/// </summary>
		/// <param name="outerKey"></param>
		/// <param name="innerKey"></param>
		/// <returns></returns>
		/// <exception cref="KeyNotFoundException"></exception>
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
