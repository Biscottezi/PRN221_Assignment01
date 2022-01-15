using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO _instance = null;
        private static readonly object instanceLock = new object();
        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new ProductDAO();
                    }
                    return _instance;
                }
            }
        }

        public IEnumerable<Product> GetProductList()
        {
            List<Product> products;
            try
            {
                var db = new FStoreDBAssignmentContext();
                products = db.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public Product GetProductById(int id)
        {
            Product product = null;
            try
            {
                var db = new FStoreDBAssignmentContext();
                product = db.Products.SingleOrDefault(prod => prod.ProductId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public IEnumerable<Product> SearchProduct(String keyword)
        {
            List<Product> products;
            try
            {
                var db = new FStoreDBAssignmentContext();
                products = db.Products.Where(p => p.ProductName.Contains(keyword)).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public IEnumerable<Product> GetProductByUnitInStock(int unitInStock)
        {
            List<Product> products;
            try
            {
                var db = new FStoreDBAssignmentContext();
                products = db.Products.Where(p => p.UnitslnStock == unitInStock)
                                        .ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }
        public IEnumerable<Product> GetProductByUnitPrice(decimal unitPrice)
        {
            List<Product> products;
            try
            {
                var db = new FStoreDBAssignmentContext();
                products = db.Products.Where(p => p.UnitPrice == unitPrice)
                                        .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public void Create(Product product)
        {
            try
            {
                var prod = GetProductById(product.ProductId);
                if (prod == null)
                {
                    var db = new FStoreDBAssignmentContext();
                    db.Products.Add(product);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("This product already exists.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Product product)
        {
            try
            {
                var prod = GetProductById(product.ProductId);
                if (prod != null)
                {
                    var db = new FStoreDBAssignmentContext();
                    db.Entry<Product>(product).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("This product doesn't exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Product product)
        {
            try
            {
                var prod = GetProductById(product.ProductId);
                if (prod != null)
                {
                    var db = new FStoreDBAssignmentContext();
                    db.Products.Remove(product);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("This product doesn't exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
