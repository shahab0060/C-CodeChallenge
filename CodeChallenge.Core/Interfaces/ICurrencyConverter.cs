using CodeChallenge.Domain.Enums;
using CodeChallenge.Domain.ViewModels;

namespace CodeChallenge.Core.Interfaces
{
    public interface ICurrencyConverter
    {
        (ConvertCurrencyResult result,double convertedAmount) Convert(ConvertCurrencyViewModel convertCurrency);
        (ConvertCurrencyResult result,double convertedAmount) Convert(string? fromCurrency,string? toCurrency,double amount);
        void AddBaseCurrencies();
    }
}
