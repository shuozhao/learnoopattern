using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearnOOInterface.Factory;
using LearnOOInterface.SimpleObject;

namespace LearnOOInterface.AbstractFactory
{
    public interface IFactory<T>
    {        
        IProduct CreateNewProduct(ProductType type, String productName, int productPrice);
    }

    public interface IBrand
    {
        String Name { get; }
        String Country { get; }
    }
}
