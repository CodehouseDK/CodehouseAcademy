using System;
using System.Linq;
using DataAccess.Domain;

namespace DataAccess
{
    public interface IScanner
    {
        ProductDto DoScan();
    }

    public class Scanner : IScanner
    {
        private readonly Database _db;

        public Scanner()
        {
            _db = DataAccess.Database.Instance;
        }
        public ProductDto DoScan()
        {
            var allProducts = _db.ReadAll<ProductDto>().ToList();
            var random = new Random((int)DateTime.Now.Ticks);
            var next = random.Next(allProducts.Count());
            return allProducts[next];
        }
    }
}
