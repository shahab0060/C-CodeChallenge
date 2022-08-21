using System;
using CodeChallenge.Console.Classes;
using CodeChallenge.Console.Interfaces;
using CodeChallenge.Console.Enums;

namespace CodeChallenge.Console
{
    class Program
    {
        private static readonly ICurrencyConverter _currencyConverter = new CurrencyConverter();

        static void Main(string[] args)
        {
            #region Geting Values From User

            double fromCurrencyToBaseAmountConversionRate = 0;
            double toCurrencyToBaseAmountConversionRate = 0;
            double amountToConvert = 0;

            System.Console.WriteLine("We have a base currency in this project called BC");
            System.Console.WriteLine("Please Enter fromCurrency");
            string fromCurrency = System.Console.ReadLine();
            System.Console.WriteLine("Please Enter From Currency Conversion Rate To BC");
            try
            {
                fromCurrencyToBaseAmountConversionRate = Convert.ToDouble(System.Console.ReadLine());
            }
            catch
            {
                System.Console.WriteLine("Amount Is Not Valid");
                return;
            }
            System.Console.WriteLine("Please Enter toCurrency");
            string toCurrency = System.Console.ReadLine();
            System.Console.WriteLine("Please Enter To Currency Conversion Rate To Base Amount");
            try
            {
                toCurrencyToBaseAmountConversionRate = Convert.ToDouble(System.Console.ReadLine());
            }
            catch
            {
                System.Console.WriteLine("Amount Is Not Valid");
                return;
            }
            System.Console.WriteLine("Please Enter Amount To Convert");
            try
            {
                amountToConvert = Convert.ToDouble(System.Console.ReadLine());
            }
            catch
            {
                System.Console.WriteLine("Amount Is Not Valid");
                return;
            }

            #endregion

            var res = _currencyConverter.Convert(fromCurrency: fromCurrency, toCurrency: toCurrency,
               amount: amountToConvert, conversionAmount: fromCurrencyToBaseAmountConversionRate,
               fromCurrencyToBaseAmountConversionRate: fromCurrencyToBaseAmountConversionRate,
               toCurrencyToBaseAmountConversionRate: toCurrencyToBaseAmountConversionRate);
            switch (res.result)
            {
                case ConvertCurrencyResult.NotFound:
                    System.Console.WriteLine("Nothing found With The Entered Information");
                    break;
                case ConvertCurrencyResult.NotValid:
                    System.Console.WriteLine("The Entered Information was not valid");
                    break;
                case ConvertCurrencyResult.CurrencyConvertedSuccessfully:
                    System.Console.WriteLine("Currency Converted SuccessFully");
                    System.Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine($"The Converted Currency Is {res.convertedAmount}");
                    System.Console.ResetColor();
                    break;
            }
            System.Console.ReadKey();
        }
    }
}
