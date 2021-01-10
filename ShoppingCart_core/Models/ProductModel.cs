using System;
using System.Linq;
using System.Collections.Generic;

namespace ShoppingCart_core.Models
{
    public class ProductModel
    {
        

        public List<Product> findAll()
        {
            return testData();
        }

        public Product findFromID(string id)
        {
            var listProduct = findAll();

            var product = listProduct.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return null;
            }
            else
            {
                return product;
            }
        }

        public List<Product> testData()
        {
            List<Product> returnModel = new List<Product>();
            Product product;

            product = new Product();
            product.Id = "01";
            product.Name = "鹹豬肉";
            product.Price = 330;
            returnModel.Add(product);

            product = new Product();
            product.Id = "02";
            product.Name = "戰斧牛排";
            product.Price = 380;
            returnModel.Add(product);

            product = new Product();
            product.Id = "03";
            product.Name = "黑鮪魚冷凍切片";
            product.Price = 1200;
            returnModel.Add(product);

            return returnModel;

        }

    }
}
