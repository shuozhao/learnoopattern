using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearnOOInterface.SimpleObject;

namespace LearnOOInterface.SimpleFactory
{
    public class SimpleFactoryVivienneClient
    {
        SimpleFactoryVivienneAccessories newAccessoriesCollection = null;

        public SimpleFactoryVivienneClient()
        {
        }

        public void CreateProductLine()
        {
            SimpleFactoryVivienneAccessorFactory newVivienneFactry = new SimpleFactoryVivienneAccessorFactory();
            newAccessoriesCollection = new SimpleFactoryVivienneAccessories();

            newAccessoriesCollection.AddNewAccessories(
                newVivienneFactry.CreateNewAccessory(ProductType.Bags, "DERBY BAG NEW EXHIBITION 5571", 655));
            newAccessoriesCollection.AddNewAccessories(
                newVivienneFactry.CreateNewAccessory(ProductType.Bags, "DOLCE VITA BAG 5301", 910));
            newAccessoriesCollection.AddNewAccessories(
                newVivienneFactry.CreateNewAccessory(ProductType.Shoes, "PINK WANTING BALLERINAS", 115));
            newAccessoriesCollection.AddNewAccessories(
                newVivienneFactry.CreateNewAccessory(ProductType.Shoes, "BLACK BUTTON SANDAL", 108));
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

    public class SimpleFactoryVivienneAccessorFactory
    {
        public SimpleFactoryVivienneAccessorFactory()
        {

        }

        public virtual BaseAccessories CreateNewAccessory(ProductType type, String productName, int productPrice)
        {
            if (type == ProductType.Bags)
            {
                return new SimpleFactoryVivienneBags(productName, productPrice);
            }
            else if(type == ProductType.Shoes)
            {
                return new SimpleFactoryVivienneShoes(productName, productPrice);
            }
            return null;
        }
    }

    public class SimpleFactoryVivienneAccessories
    {
        List<BaseAccessories> accessoriesCollection;

        public SimpleFactoryVivienneAccessories()
        {
            accessoriesCollection = new List<BaseAccessories>();
        }

        public void AddNewAccessories(BaseAccessories newAccessory)
        {
            if (null != newAccessory)
            {
                accessoriesCollection.Add(newAccessory);
            }
        }

        public void DisplayVivienneAccessories()
        {
            foreach (BaseAccessories curAccessory in accessoriesCollection)
            {
                DisplayItem(curAccessory.GetAccessoryOutput());
            }
        }

        private void DisplayItem(String currentItem)
        {
            Console.WriteLine(currentItem);
        }
    }

    public class SimpleFactoryVivienneBags: BaseAccessories
    {
        public SimpleFactoryVivienneBags(String productName, int productPrice)
            : base(productName, productPrice)
        {

        }

        public override String GetAccessoryOutput()
        {
            return "VivienneBags " + base.GetAccessoryOutput();
        }
    }

    public class SimpleFactoryVivienneShoes: BaseAccessories
    {
        public SimpleFactoryVivienneShoes(String productName, int productPrice)
            : base(productName, productPrice)
        {

        }

        public override String GetAccessoryOutput()
        {
            return "VivienneShoes " + base.GetAccessoryOutput();
        }
    }

    public class BaseAccessories
    {
        String name;
        int price;

        public BaseAccessories(String productName, int productPrice)
        {
            name = productName;
            price = productPrice;
        }

        public virtual String GetAccessoryOutput()
        {
            return "From: UK" + " Product: "+name + " Price: $" + price.ToString();
        }
    }
}
