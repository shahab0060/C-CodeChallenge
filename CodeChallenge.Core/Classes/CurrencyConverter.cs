using System.Collections.Generic;
using System.Linq;
using CodeChallenge.Core.Interfaces;
using CodeChallenge.Domain.Enums;
using CodeChallenge.Domain.ViewModels;

namespace CodeChallenge.Core.Classes
{
    public class CurrencyConverter : ICurrencyConverter
    {
        protected List<ConvertCurrencyViewModel> Currencies = new List<ConvertCurrencyViewModel>();

        public (ConvertCurrencyResult result, double convertedAmount) Convert(ConvertCurrencyViewModel convertCurrency)
        {
            #region Valiation

            if (Currencies.All(c => c.FromCurrency != convertCurrency.FromCurrency.ToUpper() ||
                                    c.ToCurrency != convertCurrency.FromCurrency.ToUpper()))
                return (ConvertCurrencyResult.FromCurrencyNotValid, 0);
            if (Currencies.All(c => c.ToCurrency != convertCurrency.ToCurrency.ToUpper() ||
                                    c.FromCurrency != convertCurrency.ToCurrency.ToUpper()))
                return (ConvertCurrencyResult.ToCurrencyNotValid, 0);

            #endregion

            if (Currencies.Any(c => c.FromCurrency == convertCurrency.FromCurrency.ToUpper() &&
                                    c.ToCurrency == convertCurrency.ToCurrency.ToUpper()))
            {
                var convertAmount = Currencies
                    .Where(c => c.FromCurrency == convertCurrency.FromCurrency.ToUpper() &&
                                c.ToCurrency == convertCurrency.ToCurrency.ToUpper())
                    .Select(c => c.Amount)
                    .SingleOrDefault();
                return (ConvertCurrencyResult.CurrencyConvertedSuccessfully, convertAmount * convertCurrency.Amount);
            }

            if (Currencies.Any(c => c.FromCurrency == convertCurrency.ToCurrency.ToUpper() &&
                                    c.ToCurrency == convertCurrency.FromCurrency.ToUpper()))
            {
                var convertAmount = Currencies
                    .Where(c => c.FromCurrency == convertCurrency.FromCurrency.ToUpper() &&
                                c.ToCurrency == convertCurrency.ToCurrency.ToUpper())
                    .Select(c => c.Amount)
                    .SingleOrDefault();
                return (ConvertCurrencyResult.CurrencyConvertedSuccessfully, convertCurrency.Amount / convertAmount);
            }

            double result = 0;
            return (ConvertCurrencyResult.CurrencyConvertedSuccessfully, result);
        }

        public (ConvertCurrencyResult result, double convertedAmount) Convert(string? fromCurrency, string? toCurrency, double amount)
        {
            if (fromCurrency is null) return (ConvertCurrencyResult.FromCurrencyNotValid, 0);
            if (toCurrency is null) return (ConvertCurrencyResult.ToCurrencyNotValid, 0);
            ConvertCurrencyViewModel convertCurrency = new ConvertCurrencyViewModel()
            {
                Amount = amount,
                FromCurrency = fromCurrency,
                ToCurrency = toCurrency
            };
            return Convert(convertCurrency);
        }

        public void AddBaseCurrencies()
        {
            ConvertCurrencyViewModel firstCurrency = new ConvertCurrencyViewModel()
            {
                FromCurrency = "USD",
                ToCurrency = "CAD",
                Amount = 1.34
            };
            ConvertCurrencyViewModel secondCurrency = new ConvertCurrencyViewModel()
            {
                FromCurrency = "USD",
                ToCurrency = "CAD",
                Amount = 1.34
            };
            ConvertCurrencyViewModel thirdCurrency = new ConvertCurrencyViewModel()
            {
                FromCurrency = "USD",
                ToCurrency = "CAD",
                Amount = 1.34
            };
            Currencies.Add(firstCurrency);
            Currencies.Add(secondCurrency);
            Currencies.Add(thirdCurrency);
        }
    }
}
