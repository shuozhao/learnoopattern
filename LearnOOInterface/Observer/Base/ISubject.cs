using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnOOInterface.Observer.Base
{
    public interface ISubject<T>
    {
        void Attach(T observer);
        void Detach(T observer);
        event EventHandler<EventArgs> Notify;

        void PublishSomething();
    }
}
