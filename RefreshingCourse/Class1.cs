namespace RefreshingCourse
{
    public class RefresherCourse
    {
        class SrpProduct //responsible for maintainingg the data
        {
            private string _productName;
            private double _price;
            private double _taxRate;

            public SrpProduct(string name, double price, double taxRate) => (_productName, _price, _taxRate) = (name, price, _taxRate);

            public string ProductName { get => _productName; set => _productName = value; }
            public double Price { get => _price; set => _price = value; }
            public double TaxRate { get => _taxRate; set => _taxRate = value; }

            /*public double CalculateTax()
            {
                return _price * _taxRate;
            }*/
        }

        class TaxCalculator //reponsible for calculating the tax
        {
            public static double CalculateTax(SrpProduct product)
            {
                return (product.Price * 0.15) * product.TaxRate;
            }
        }

        public class Srp
        {
            internal static void Test()
            {
                SrpProduct prd = new SrpProduct("Item 1", 10.56, 0.18);
                //var tax = prd.CalculateTax();
                var tax = TaxCalculator.CalculateTax(prd);
                Console.WriteLine($"{prd.ProductName}=> Price: {prd.Price}, Tax: {prd.TaxRate}, ComputedTax: {tax} ");
            }
        }
    }
}
