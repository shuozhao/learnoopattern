using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using LearnOOInterface.AbstractFactory;

namespace LearnOOInterface.Composite
{
    public class Brand<T> : BaseComponent where T : IBrand, new()
    {
        T currentBrandContext;

        public Brand()
        {
            currentBrandContext = new T();
        }

        public override string Display()
        {
            StringBuilder sbDisplay = new StringBuilder();
            sbDisplay.Append("Brand: ");
            sbDisplay.AppendLine(currentBrandContext.Name);
            sbDisplay.Append("Country: ");
            sbDisplay.AppendLine(currentBrandContext.Country);

            return sbDisplay.ToString();
        }
    }

}
