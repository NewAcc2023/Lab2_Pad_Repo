namespace Lab2.Service
{
    public interface ICurrencyConvertService
    {
        public double CurrencyConvert(string from, string to, double amount);
    }
}
