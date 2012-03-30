using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearnOOInterface.Factory;
using LearnOOInterface.SimpleObject;

namespace LearnOOInterface.AbstractFactoryEx
{
    public interface IFactoryEx<T>
    {
        IProduct CreateNewProduct(ProductType type, String productName, int productPrice, T userData);
    }

    public interface IBrandEx
    {
        String Name { get; }
        String Country { get; }
        IEnumerable<ProductInfo> GetProducts();
    }

    public struct ProductInfo
    {
        public string Name;
        public int Price;
        public ProductType type;
    }

}
