using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnOOInterface.Composite
{
    public interface IComponent
    {
        IComponent Add(IComponent newChild);
        IComponent Remove(IComponent usedChild);
        IComponent Parent { get; set; }
        IEnumerable<IComponent> Items();
        String Display();
    }
}
