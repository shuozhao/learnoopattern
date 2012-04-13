using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnOOInterface.Composite
{
    public class Product : BaseComponent
    {
        readonly String name;
        readonly String price;

        public Product(String pName, String pPrice)
        {
            name = pName;
            price = pPrice;
        }

        public override IComponent Add(IComponent newChild)
        {
            return null;
        }

        public override IComponent Remove(IComponent usedChild)
        {
            return null;
        }

        public override IEnumerable<IComponent> Items()
        {
            return null;
        }

        public override String Display()
        {
            StringBuilder sbProducetDescription = new StringBuilder();
            sbProducetDescription.Append("Product: ");
            sbProducetDescription.AppendLine(name);
            sbProducetDescription.Append("Price: ");
            sbProducetDescription.AppendLine(price);

            return sbProducetDescription.ToString();
        }
    }
}
