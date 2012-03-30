using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnOOInterface.SimpleObject
{
    public enum ProductType
    {
        Bags,
        Shoes,
        Dresses,
        Coats
    }

    public class SimpleObjectVivienneClient
    {
        SimpleVivienneAccessories newAccessoriesCollection=null;

        public SimpleObjectVivienneClient()
        {

        }

        public void CreateProductLine()
        {
            newAccessoriesCollection = new SimpleVivienneAccessories();

            newAccessoriesCollection.AddNewAccessories(ProductType.Bags, "DERBY BAG NEW EXHIBITION 5571", 655);
            newAccessoriesCollection.AddNewAccessories(ProductType.Bags, "DOLCE VITA BAG 5301", 910);
            newAccessoriesCollection.AddNewAccessories(ProductType.Shoes, "PINK WANTING BALLERINAS", 115);
            newAccessoriesCollection.AddNewAccessories(ProductType.Shoes, "BLACK BUTTON SANDAL", 108);
        }

        public void DiplayAllItems()
        {
            if (null != newAccessoriesCollection)
            {
                newAccessoriesCollection.DisplayVivienneAccessories();
                Console.ReadKey();
            }
        }
    }

    public class SimpleVivienneBags
    {
        String name;
        int price;

        public SimpleVivienneBags(String productName, int productPrice)
        {
            name = productName;
            price = productPrice;
        }

        public String GetVivienneBagsOutput()
        {
            return "VivienneBags " + "From: UK" + " Product: " + name + " Price: $" + price.ToString();
        }
    }

    public class SimpleVivienneShoes
    {
        String name;
        int price;

        public SimpleVivienneShoes(String productName, int productPrice)
        {
            name = productName;
            price = productPrice;
        }

        public String GetSimpleVivienneShoesOutput()
        {
            return "VivienneShoes " + "From: UK" + " Product: " + name + " Price: $" + price.ToString();
        }
    }

    public class SimpleVivienneAccessories
    {
        List<SimpleVivienneBags> lstBags = new List<SimpleVivienneBags>();
        List<SimpleVivienneShoes> lstShoes = new List<SimpleVivienneShoes>();

        private void AddNewVivienneBags(String productName, int productPrice)
        {
            lstBags.Add(new SimpleVivienneBags(productName, productPrice));
        }

        private void AddNewVivienneShoes(String productName, int productPrice)
        {
            lstShoes.Add(new SimpleVivienneShoes(productName, productPrice));
        }

        public void AddNewAccessories(ProductType type, String productName, int productPrice)
        {
            if (type == ProductType.Bags)
            {
                AddNewVivienneBags(productName, productPrice);
            }
            else if (type == ProductType.Shoes)
            {
                AddNewVivienneShoes(productName, productPrice);
            }
        }

        public void DisplayVivienneAccessories()
        {
            foreach (SimpleVivienneBags curBag in lstBags)
            {
                DisplayItem(curBag.GetVivienneBagsOutput());
            }

            foreach (SimpleVivienneShoes curShoe in lstShoes)
            {
                DisplayItem(curShoe.GetSimpleVivienneShoesOutput());
            }
        }

        private void DisplayItem(String currentItem)
        {
            Console.WriteLine(currentItem);
        }
    }
}
