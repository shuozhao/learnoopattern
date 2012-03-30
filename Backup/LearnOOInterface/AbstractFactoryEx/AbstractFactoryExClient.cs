using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearnOOInterface.Factory;
using LearnOOInterface.SimpleObject;
using LearnOOInterface.AbstractFactory;

namespace LearnOOInterface.AbstractFactoryEx
{
    public class AbstractFactoryExClient<T> where T : IBrandEx, new()
    {
        FactoryProducts prodcutsCollection = null;
        T currentBrandContext;

        public AbstractFactoryExClient()
        {
            currentBrandContext = new T();
        }

        public void CreateProductLine()
        {
            BaseFactoryEx<T> newVivienneFactry = new BaseFactoryEx<T>();

            prodcutsCollection = new FactoryProducts();

            foreach (ProductInfo currentProduct in currentBrandContext.GetProducts())
            {
                prodcutsCollection.AddNewProduct(
                    newVivienneFactry.CreateNewProduct(currentProduct.type, currentProduct.Name, currentProduct.Price, currentBrandContext));
            }
        }

        public void DiplayAllItems()
        {
            if (null != prodcutsCollection)
            {
                prodcutsCollection.DisplayVivienneProducts();
                Console.ReadKey();
            }
        }

    }

    public class BaseFactoryEx<T> : IFactoryEx<T> where T : IBrandEx
    {
        #region IFactory<IBrand> Members

        public IProduct CreateNewProduct(ProductType type, string productName, int productPrice, T userData)
        {
            return new BaseProductEx<T>(productName, productPrice, type.ToString(), userData);
        }

        #endregion
    }

    public class BaseProductEx<T> : IProduct where T : IBrandEx
    {
        String name;
        String style;
        int price;
        T currentBrandContext;

        public BaseProductEx(String productName, int productPrice, String productStyle, T newContext)
        {
            name = productName;
            price = productPrice;
            style = productStyle;
            currentBrandContext = newContext;
        }

        #region IProduct Members

        public virtual string GetProductOutput()
        {
           return currentBrandContext.Name + style + " From: " + currentBrandContext.Country + " Product: " + name + " Price: $" + price.ToString();
        }
        #endregion
    }

    public class VivienneBrandEx : IBrandEx
    {
        ProductInfo[] currentProduct = new ProductInfo[6];

        public VivienneBrandEx()
        {
            currentProduct[0].Name = "DERBY BAG NEW EXHIBITION 5571";
            currentProduct[0].Price = 655;
            currentProduct[0].type = ProductType.Bags;

            currentProduct[1].Name = "DOLCE VITA BAG 5301";
            currentProduct[1].Price = 910;
            currentProduct[1].type = ProductType.Bags;

            currentProduct[2].Name = "PINK WANTING BALLERINAS";
            currentProduct[2].Price = 115;
            currentProduct[2].type = ProductType.Shoes;

            currentProduct[3].Name = "BLACK BUTTON SANDAL";
            currentProduct[3].Price = 108;
            currentProduct[3].type = ProductType.Shoes;

            currentProduct[4].Name = "AVA CHANGEANT TAFFETA DRESS";
            currentProduct[4].Price = 855;
            currentProduct[4].type = ProductType.Dresses;

            currentProduct[5].Name = "WATERPROOF MA";
            currentProduct[5].Price = 980;
            currentProduct[5].type = ProductType.Coats;
        }
        #region IBrand Members

        public string Name
        {
            get { return "Vivienne"; }
        }

        public string Country
        {
            get { return "UK"; }
        }

        public IEnumerable<ProductInfo> GetProducts()
        {
            foreach (ProductInfo product in currentProduct)
            {
                yield return product;
            }
        }
        #endregion
    }

    public class GucciBrandEx : IBrandEx
    {
        ProductInfo[] currentProduct = new ProductInfo[6];

        public GucciBrandEx()
        {
            currentProduct[0].Name = "GG running large tote with double G";
            currentProduct[0].Price = 3400;
            currentProduct[0].type = ProductType.Bags;

            currentProduct[1].Name = "Jackie Shoulder Bag";
            currentProduct[1].Price = 1890;
            currentProduct[1].type = ProductType.Bags;

            currentProduct[2].Name = "ophelie flat thong tiger head";
            currentProduct[2].Price = 1750;
            currentProduct[2].type = ProductType.Shoes;

            currentProduct[3].Name = "women's horsebit moccasin";
            currentProduct[3].Price = 585;
            currentProduct[3].type = ProductType.Shoes;

            currentProduct[4].Name = "bi-color overlap dress";
            currentProduct[4].Price = 1900;
            currentProduct[4].type = ProductType.Dresses;

            currentProduct[5].Name = "Jacket with leather collar";
            currentProduct[5].Price = 2100;
            currentProduct[5].type = ProductType.Coats;
        }
        #region IBrand Members

        public string Name
        {
            get { return "Gucci"; }
        }

        public string Country
        {
            get { return "Italy"; }
        }

        public IEnumerable<ProductInfo> GetProducts()
        {
            foreach (ProductInfo product in currentProduct)
            {
                yield return product;
            }
        }
        #endregion
    }
}
