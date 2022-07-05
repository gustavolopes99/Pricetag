using System.Globalization;

namespace Prod.Entities
{
    public class ImportedProduct : Product
    {
        public double CustomsFee { get; set; }
        public ImportedProduct(string name, double price, double customsfee) : base(name, price)
        {
            CustomsFee = customsfee;
        }
        public double totalPrice()
        {
            return Price + CustomsFee;
        }
        public override string priceTag()
        {
            return $"{Name} $ {totalPrice().ToString("F2", CultureInfo.InvariantCulture)} (Customs fee: $ {CustomsFee.ToString("F2", CultureInfo.InvariantCulture)})";
        }
    }
}