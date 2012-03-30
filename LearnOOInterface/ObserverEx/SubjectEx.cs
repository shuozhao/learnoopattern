using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearnOOInterface.Observer.Base;
using LearnOOInterface.Observer;

namespace LearnOOInterface.ObserverEx
{
    public class SubjectEx:ISubject<IObserver>
    {
        INotifyManager currentPushProvider = null;
        String subName;
        public SubjectEx(String name, INotifyManager pushManager)
        {
            subName = name;
            currentPushProvider = pushManager;
            Notify += pushManager.Dispatch;
        }

        public void Attach(IObserver observer)
        {
            currentPushProvider.Subscribe(this, observer);
        }

        public void Detach(IObserver observer)
        {
            currentPushProvider.UnSubscribe(this, observer);
        }

        public event EventHandler<EventArgs> Notify;

        public void PublishSomething()
        {
            if (null != Notify)
            {
                Notify(this, new SubjectEventArgs(subName));
            }
        }

        public override string ToString()
        {
            return subName;
        }

    }
}
