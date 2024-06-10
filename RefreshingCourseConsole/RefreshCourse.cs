using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefreshingCourseConsole
{
    public class RefresherCourse
    {

        //Tax rate is computed baases on the length of the product vehicle.
        class SrpProduct //responsible for maintainingg the data
        {
            private string _productName;
            private double _price;
            private double _length;
            /*private double _taxRate;*/

            //public SrpProduct(string name, double price, double taxRate) => (_productName, _price, _taxRate) = (name, price, _taxRate);
            public SrpProduct(string name, double price, double length) => (_productName, _price, _length) = (name, price, length);

            public string ProductName { get => _productName; set => _productName = value; }
            public double Price { get => _price; set => _price = value; }
            public double Length { get => _length; set => _length = value; }
            //public double TaxRate { get => _taxRate; set => _taxRate = value; }

            /*public double CalculateTax()
            {
                return _price * _taxRate;
            }*/
        }

        class CountryWiseTaxRate
        {

        }

        class TaxCalculator //reponsible for calculating the tax
        {
            public static double CalculateTax(SrpProduct product, double taxRate)
            {
                return product.Price * taxRate;
            }

            public static double GetTaxRate(SrpProduct product, string countryCode)
            {
                if (countryCode == "IN")
                {
                    if (product.Length < 4.00) return 0.105;
                    else return 0.125;
                }
                else if(countryCode == "SL")
                {
                    if (product.Length < 5.00) return 0.125;
                    else return 0.175;
                }
                else
                {
                    return 0.05;
                }
            }
        }

        public class Srp
        {
            internal static void Test()
            {
                SrpProduct prd = new SrpProduct("Item 1", 10.56, 0.18);
                //var tax = prd.CalculateTax();
                var taxRate = TaxCalculator.GetTaxRate(prd, "IN");
                var tax = TaxCalculator.CalculateTax(prd, taxRate);
                //var tax = TaxCalculator.CalculateTax(prd);
                Console.WriteLine($"{prd.ProductName}=> Price: {prd.Price}, Tax: {taxRate}, ComputedTax: {tax} ");

                var taxRate1 = TaxCalculator.GetTaxRate(prd, "SL");
                var tax1 = TaxCalculator.CalculateTax(prd, taxRate1);
                //var tax = TaxCalculator.CalculateTax(prd);
                Console.WriteLine($"{prd.ProductName}=> Price: {prd.Price}, Tax: {taxRate1}, ComputedTax: {tax1} ");

                var taxRate2 = TaxCalculator.GetTaxRate(prd, "AU");
                var tax2 = TaxCalculator.CalculateTax(prd, taxRate2);
                //var tax = TaxCalculator.CalculateTax(prd);
                Console.WriteLine($"{prd.ProductName}=> Price: {prd.Price}, Tax: {taxRate2}, ComputedTax: {tax2} ");
            }
        }
    }
}
