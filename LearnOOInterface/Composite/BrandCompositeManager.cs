using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearnOOInterface.AbstractFactory;

namespace LearnOOInterface.Composite
{
    public class BrandCompositeManager
    {
        IComponent newBrandList;

        public BrandCompositeManager()
        {
            newBrandList = new ProductCategory("Shopping Mall");
        }

        public IComponent Root
        {
            get { return newBrandList; }
        }

        public void CreateAllBrand()
        {
            newBrandList.Add(CreateVivinneBrand());
            newBrandList.Add(CreateGucciBrand());
        }

        private IComponent CreateVivinneBrand()
        {
            IComponent vivineBest = new Brand<VivienneBrand>();

            IComponent WomensAccessory = vivineBest.Add(new ProductCategory("WomensAccessory"));

            IComponent Bages = WomensAccessory.Add(new ProductCategory("Bags"));
            Bages.Add(new Product("DERBY BAG NEW EXHIBITION 5571", "$655"));
            Bages.Add(new Product("DOLCE VITA BAG 5301", "$910"));


            IComponent Shoes = WomensAccessory.Add(new ProductCategory("Shoes"));
            Shoes.Add(new Product("PINK WANTING BALLERINAS", "$115"));
            Shoes.Add(new Product("BLACK BUTTON SANDAL", "$108"));

            IComponent Womenswear = vivineBest.Add(new ProductCategory("Womenswear"));

            IComponent Dresses = Womenswear.Add(new ProductCategory("Dresses"));
            Dresses.Add(new Product("AVA CHANGEANT TAFFETA DRESS", "$855"));

            IComponent Coats = Womenswear.Add(new ProductCategory("Coats"));
            Coats.Add(new Product("WATERPROOF MA", "$980"));

            return vivineBest;
        }

        private IComponent CreateGucciBrand()
        {
            IComponent vivineBest = new Brand<GucciBrand>();

            IComponent WomensAccessory = vivineBest.Add(new ProductCategory("WomensAccessory"));

            IComponent Bages = WomensAccessory.Add(new ProductCategory("Bags"));
            Bages.Add(new Product("GG running large tote with double G", "$3400"));
            Bages.Add(new Product("Jackie Shoulder Bag", "$1890"));

            IComponent Shoes = WomensAccessory.Add(new ProductCategory("Shoes"));
            Shoes.Add(new Product("ophelie flat thong tiger head", "$1750"));
            Shoes.Add(new Product("women's horsebit moccasin", "$585"));

            IComponent Womenswear = vivineBest.Add(new ProductCategory("Womenswear"));

            IComponent Dresses = Womenswear.Add(new ProductCategory("Dresses"));
            Dresses.Add(new Product("bi-color overlap dress", "$1900"));

            IComponent Coats = Womenswear.Add(new ProductCategory("Coats"));
            Coats.Add(new Product("Jacket with leather collar", "$2100"));

            return vivineBest;
        }

        public void DisplayItem(IComponent currentComponent)
        {
            Console.Write(currentComponent.Display());

            if (currentComponent.Items() !=null)
            {
                foreach (IComponent currentItem in currentComponent.Items())
                {
                    if (null != currentItem)
                    {
                        DisplayItem(currentItem);
                    }
                }
            }
        }
    }

}
