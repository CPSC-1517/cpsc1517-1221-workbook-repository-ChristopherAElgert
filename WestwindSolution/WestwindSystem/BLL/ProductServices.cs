using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using WestwindSystem.DAL;
using WestwindSystem.Entities;

namespace WestwindSystem.BLL
{
    public class ProductServices
    {
        private readonly WestwindContext _dbContext;

        internal ProductServices(WestwindContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Product> FindProductsByCategoryId(int categoryId)
        {
            var query = _dbContext
                .Products
                .Where(currentProduct => currentProduct.CategoryId == categoryId);
            return query.ToList();
        }

        public List<Product> FindProductsByProductName(string partialProductName)
        {
            var query = _dbContext
                .Products
                .Where(currentProduct => currentProduct.ProductName.Contains(partialProductName));
            return query.ToList();
        }
    }
}
