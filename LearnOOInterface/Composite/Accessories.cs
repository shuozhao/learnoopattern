using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnOOInterface.Composite
{
    public class ProductCategory: BaseComponent
    {
        String currentName = String.Empty;

        public ProductCategory(String accessoryName)
        {
            currentName = accessoryName;
        }

        public override string Display()
        {
            return "Category: " + currentName + Environment.NewLine;
        }
    }
}
