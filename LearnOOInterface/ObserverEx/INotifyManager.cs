using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearnOOInterface.Observer.Base;
using LearnOOInterface.Observer;

namespace LearnOOInterface.ObserverEx
{
    public interface INotifyManager
    {
        void Subscribe(ISubject<IObserver> topic, IObserver follower);
        void UnSubscribe(ISubject<IObserver> topic, IObserver follower);
        void Dispatch(object topic, EventArgs args);
    }
}
