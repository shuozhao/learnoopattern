using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearnOOInterface.SimpleObject;

namespace LearnOOInterface.Factory
{
    public class FactoryVivienneClient
    {
        FactoryProducts prodcutsCollection = null;

        public FactoryVivienneClient()
        {

        }

        public void CreateProductLine()
        {
            FactoryVivienneProductFactory newVivienneFactry = new FactoryVivienneProductFactory();
            prodcutsCollection = new FactoryProducts();

            prodcutsCollection.AddNewProduct(
                newVivienneFactry.CreateNewProduct(ProductType.Bags, "DERBY BAG NEW EXHIBITION 5571", 655));
            prodcutsCollection.AddNewProduct(
                newVivienneFactry.CreateNewProduct(ProductType.Bags, "DOLCE VITA BAG 5301", 910));
            prodcutsCollection.AddNewProduct(
                newVivienneFactry.CreateNewProduct(ProductType.Shoes, "PINK WANTING BALLERINAS", 115));
            prodcutsCollection.AddNewProduct(
                newVivienneFactry.CreateNewProduct(ProductType.Shoes, "BLACK BUTTON SANDAL", 108));
            prodcutsCollection.AddNewProduct(
                newVivienneFactry.CreateNewProduct(ProductType.Dresses, "AVA CHANGEANT TAFFETA DRESS", 855));
            prodcutsCollection.AddNewProduct(
                newVivienneFactry.CreateNewProduct(ProductType.Coats, "WATERPROOF MAC", 980));
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

    public class FactoryVivienneProductFactory
    {
        public FactoryVivienneProductFactory()
        {

        }

        public virtual IProduct CreateNewProduct(ProductType type, String productName, int productPrice)
        {
            if (type == ProductType.Bags)
            {
                return new FactoryVivienneBags(productName, productPrice);
            }
            else if (type == ProductType.Shoes)
            {
                return new FactoryVivienneShoes(productName, productPrice);
            }
            if (type == ProductType.Dresses || type == ProductType.Coats)
            {
                return new BaseWear(productName, productPrice, type.ToString());
            }
            return null;
        }
    }

    public class FactoryProducts
    {
        List<IProduct> productCollection;

        public FactoryProducts()
        {
            productCollection = new List<IProduct>();
        }

        public void AddNewProduct(IProduct newAccessory)
        {
            if (null != newAccessory)
            {
                productCollection.Add(newAccessory);
            }
        }

        public void DisplayVivienneProducts()
        {
            foreach (IProduct curAccessory in productCollection)
            {
                DisplayItem(curAccessory.GetProductOutput());
            }
        }

        private void DisplayItem(String currentItem)
        {
            Console.WriteLine(currentItem);
        }
    }

    public class FactoryVivienneBags : BaseAccessories
    {
        public FactoryVivienneBags(String productName, int productPrice)
            : base(productName, productPrice)
        {

        }

        public override String GetProductOutput()
        {
            return "VivienneBags " + base.GetProductOutput();
        }
    }

    public class FactoryVivienneShoes : BaseAccessories
    {
        public FactoryVivienneShoes(String productName, int productPrice)
            : base(productName, productPrice)
        {

        }

        public override String GetProductOutput()
        {
            return "VivienneShoes " + base.GetProductOutput();
        }
    }

    public class BaseAccessories:IProduct
    {
        String name;
        int price;

        public BaseAccessories(String productName, int productPrice)
        {
            name = productName;
            price = productPrice;
        }

        #region IProduct Members

        public virtual string GetProductOutput()
        {
            return "From: UK" + " Product: "+name + " Price: $" + price.ToString();
        }

        #endregion
    }

    public class BaseWear : IProduct
    {
        String name;
        String style;
        int price;

        public BaseWear(String productName, int productPrice,String productStyle)
        {
            name = productName;
            price = productPrice;
            style = productStyle;
        }

        #region IProduct Members

        public string GetProductOutput()
        {
            return "Vivienne" + style + " From: UK" + " Product: " + name + " Price: $" + price.ToString();
        }
        #endregion
    }

}
