using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        IEnumerable<ProductObject> GetProductList();
        IEnumerable<ProductObject> SearchProduct(String keyword);
        IEnumerable<ProductObject> GetProductByUnitInStock(int unitInStock);
        IEnumerable<ProductObject> GetProductByUnitPrice(decimal unitPrice);
        ProductObject GetProductById(int id);
        void CreateProduct(ProductObject productObject);
        void UpdateProduct(ProductObject productObject);
        void DeleteProduct(ProductObject productObject);
    }
}
