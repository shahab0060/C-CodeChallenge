namespace CodeChallenge.Console.ViewModels
{
    public class ConvertCurrencyViewModel
    {
        public string FromCurrency { get; set; }

        public string ToCurrency { get; set; }

        public double Amount { get; set; }

        public double ConversionAmount { get; set; }
        public double fromCurrencyToBaseAmountConversionRate { get; set; }
        public double toCurrencyToBaseAmountConversionRate { get; set; }
    }
}
