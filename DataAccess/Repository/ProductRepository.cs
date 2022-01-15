using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using AutoMapper;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        private IMapper mapper;

        public ProductRepository()
        {
            var config = new MapperConfiguration(mc =>
            {
                mc.CreateMap<Member, MemberObject>().ReverseMap();
                mc.CreateMap<Product, ProductObject>().ReverseMap();
                mc.CreateMap<Order, OrderObject>().ReverseMap();
                mc.CreateMap<OrderDetail, OrderDetailObject>().ReverseMap();
            });
            mapper = config.CreateMapper();
        }

        public IEnumerable<ProductObject> GetProductList()
        {
            try
            {
                var prods = ProductDAO.Instance.GetProductList();
                var products = mapper.Map<IEnumerable<Product>, IEnumerable<ProductObject>>(prods);
                return products;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<ProductObject> SearchProduct(String keyword)
        {
            try
            {
                var prods = ProductDAO.Instance.SearchProduct(keyword);
                var products = mapper.Map<IEnumerable<Product>, IEnumerable<ProductObject>>(prods);
                return products;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<ProductObject> GetProductByUnitInStock(int unitInStock)
        {
            try
            {
                var prods = ProductDAO.Instance.GetProductByUnitInStock(unitInStock);
                var products = mapper.Map<IEnumerable<Product>, IEnumerable<ProductObject>>(prods);
                return products;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<ProductObject> GetProductByUnitPrice(decimal unitPrice)
        {
            try
            {
                var prods = ProductDAO.Instance.GetProductByUnitPrice(unitPrice);
                var products = mapper.Map<IEnumerable<Product>, IEnumerable<ProductObject>>(prods);
                return products;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ProductObject GetProductById(int id)
        {
            try
            {
                var prod = ProductDAO.Instance.GetProductById(id);
                var product = mapper.Map<Product, ProductObject>(prod);
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void CreateProduct(ProductObject productObject)
        {
            try
            {
                var product = mapper.Map<ProductObject, Product>(productObject);
                ProductDAO.Instance.Create(product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateProduct(ProductObject productObject)
        {
            try
            {
                var product = mapper.Map<ProductObject, Product>(productObject);
                ProductDAO.Instance.Update(product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteProduct(ProductObject productObject)
        {
            try
            {
                var product = mapper.Map<ProductObject, Product>(productObject);
                ProductDAO.Instance.Delete(product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
