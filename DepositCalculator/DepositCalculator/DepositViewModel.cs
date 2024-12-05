﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DepositCalculator
{
	internal class DepositViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private double _depositAmount;
		public double DepositAmount
		{
			get => _depositAmount;
			set
			{
				_depositAmount = value;
				OnPropertyChanged("Result");
			}
		}

		private int _depositPeriod;
		public int DepositPeriod
		{
			get => _depositPeriod;
			set
			{
				_depositPeriod = value;
				OnPropertyChanged("Result");
				OnPropertyChanged("DepositPeriod");
			}
		}

		private bool[] _paymentMethod = [true, false];
		public bool[] PaymentMethod
		{
			get => _paymentMethod;
			set
			{
				_paymentMethod = value;
				OnPropertyChanged("Result");
			}
		}
		private int _selectedPaymentMethodIndex
		{
			get => _paymentMethod[0] ? 0 : 1;
		}

		private string _selectedCurrency;
		public string SelectedCurrency
		{
			get => _selectedCurrency;
			set
			{
				_selectedCurrency = value;
				OnPropertyChanged("Result");
				OnPropertyChanged("SelectedCurrency");
			}
		}

		private ObservableCollection<string> _listOfCurrencies = new ObservableCollection<string> { "USD", "EUR", "UAH" };
		public ObservableCollection<string> ListOfCurrencies
		{
			get => _listOfCurrencies;
		}

		DepositCalculatorModel _model = new DepositCalculatorModel();
		private double _result;
		public double Result
		{
			get => _model.CalculateDeposit(_depositAmount, _depositPeriod, _selectedPaymentMethodIndex, _selectedCurrency, 5);
		}




	}
}