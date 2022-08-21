using System.Collections.Generic;
using System.Linq;
using CodeChallenge.Console.Interfaces;
using CodeChallenge.Console.Enums;
using CodeChallenge.Console.ViewModels;

namespace CodeChallenge.Console.Classes
{
    public class CurrencyConverter : ICurrencyConverter
    {
        public (ConvertCurrencyResult result, double convertedAmount) Convert(ConvertCurrencyViewModel convertCurrency)
        {
            //double fromCurrencyToBCAmount = convertCurrency.fromCurrencyToBaseAmountConversionRate * convertCurrency.Amount;
            //double toCurrencyToBCAmount = convertCurrency.toCurrencyToBaseAmountConversionRate * convertCurrency.Amount;
            double converstionRate = convertCurrency.fromCurrencyToBaseAmountConversionRate / convertCurrency.toCurrencyToBaseAmountConversionRate;
            double convertedAmount = convertCurrency.Amount * converstionRate;
            return (ConvertCurrencyResult.CurrencyConvertedSuccessfully, convertedAmount);
        }

        public (ConvertCurrencyResult result, double convertedAmount) Convert(string fromCurrency, string toCurrency,
            double amount, double conversionAmount, double fromCurrencyToBaseAmountConversionRate, double toCurrencyToBaseAmountConversionRate)
        {
            if (fromCurrency is null) return (ConvertCurrencyResult.NotValid, 0);
            if (toCurrency is null) return (ConvertCurrencyResult.NotValid, 0);
            ConvertCurrencyViewModel convertCurrency = new ConvertCurrencyViewModel()
            {
                Amount = amount,
                FromCurrency = fromCurrency,
                ToCurrency = toCurrency,
                fromCurrencyToBaseAmountConversionRate = fromCurrencyToBaseAmountConversionRate,
                ConversionAmount = conversionAmount,
                toCurrencyToBaseAmountConversionRate = toCurrencyToBaseAmountConversionRate
            };
            return Convert(convertCurrency);
        }

    }
}
