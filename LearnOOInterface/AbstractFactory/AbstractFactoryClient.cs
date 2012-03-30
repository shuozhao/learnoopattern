using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearnOOInterface.SimpleObject;
using LearnOOInterface.Factory;

namespace LearnOOInterface.AbstractFactory
{
    public class AbstractFactoryClient<T> where T:IBrand,new()
    {
        FactoryProducts prodcutsCollection = null;

        public void CreateProductLine()
        {
            BaseFactory<T> newVivienneFactry = new BaseFactory<T>();
            prodcutsCollection = new FactoryProducts();

            prodcutsCollection.AddNewProduct(
                newVivienneFactry.CreateNewProduct(ProductType.Bags, "Sample 1", 655));
            prodcutsCollection.AddNewProduct(
                newVivienneFactry.CreateNewProduct(ProductType.Bags, "Sample 2", 910));
            prodcutsCollection.AddNewProduct(
                newVivienneFactry.CreateNewProduct(ProductType.Shoes, "Sample 3", 115));
            prodcutsCollection.AddNewProduct(
                newVivienneFactry.CreateNewProduct(ProductType.Shoes, "Sample 4", 108));
            prodcutsCollection.AddNewProduct(
                newVivienneFactry.CreateNewProduct(ProductType.Dresses, "Sample 5", 855));
            prodcutsCollection.AddNewProduct(
                newVivienneFactry.CreateNewProduct(ProductType.Coats, "Sample 6", 980));
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

    public class BaseFactory<T> : IFactory<T> where T:IBrand,new()
    {
        #region IFactory<IBrand> Members

        public IProduct CreateNewProduct(ProductType type, string productName, int productPrice)
        {
            return new BaseProduct<T>(productName, productPrice, type.ToString());
        }

        #endregion
    }

    public class BaseProduct<T> : IProduct where T : IBrand, new()
    {
        String name;
        String style;
        int price;
        T currentBrandContext;

        public BaseProduct()
        {
            currentBrandContext = new T();
        }

        public BaseProduct(String productName, int productPrice, String productStyle)
            : this()
        {
            name = productName;
            price = productPrice;
            style = productStyle;
        }

        #region IProduct Members

        public virtual string GetProductOutput()
        {
            return currentBrandContext.Name+style + " From: "+ currentBrandContext.Country+" Product: " + name + " Price: $" + price.ToString();
        }
        #endregion
    }

    public class VivienneBrand : IBrand
    {
        #region IBrand Members

        public string Name
        {
            get { return "Vivienne"; }
        }

        public string Country
        {
            get { return "UK"; }
        }

        #endregion
    }

    public class GucciBrand : IBrand
    {
        #region IBrand Members

        public string Name
        {
            get { return "Gucci"; }
        }

        public string Country
        {
            get { return "Italy"; }
        }

        #endregion
    }
}
