using CodeChallenge.Console.Enums;
using CodeChallenge.Console.ViewModels;

namespace CodeChallenge.Console.Interfaces
{
    public interface ICurrencyConverter
    {
        (ConvertCurrencyResult result,double convertedAmount) Convert(ConvertCurrencyViewModel convertCurrency);
        (ConvertCurrencyResult result,double convertedAmount) Convert(string fromCurrency,string toCurrency,double amount,double conversionAmount,
            double fromCurrencyToBaseAmountConversionRate,double toCurrencyToBaseAmountConversionRate);
    }
}
