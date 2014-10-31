using DataAccess;
using Domain;

namespace Logic.ScanningServices
{
    public interface IScannerService
    {
        Product Scan();
    }

    public class ScannerService : IScannerService
    {
        private readonly IScanner _scanner;

        public ScannerService(IScanner scanner)
        {
            _scanner = scanner;
        }

        

        public Product Scan()
        {
            var product = _scanner.DoScan();
            var discount = new Percent((int)product.Percent);

            return new Product(product.Name, product.Price, product.Id, discount);
        }
    }
}
