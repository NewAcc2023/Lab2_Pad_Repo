namespace Lab2.Service
{
    public class CurrencyConvertService : ICurrencyConvertService
    {
        public double CurrencyConvert(string from, string to, double amount)
        {
            if(from == "MDL" && to == "USD"){
                return amount/17.8;
            }
            else
            {
                return 0;
            }
        }

    }
}
