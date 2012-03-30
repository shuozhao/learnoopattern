using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnOOInterface.Observer.Base
{
    public interface IObserver
    {
        void Update(object sender, EventArgs args);
    }
}
