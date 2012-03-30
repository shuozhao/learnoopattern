using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearnOOInterface.Observer.Base;

namespace LearnOOInterface.Observer
{
    public class Subject:ISubject<IObserver>
    {
        List<IObserver> lstObserver;
        String topicName = String.Empty;
        public Subject(String name)
        {
            lstObserver = new List<IObserver>();
            topicName = name;
        }

        public void Attach(IObserver observer)
        {
            if (null != observer)
            {
                lstObserver.Add(observer);
                Notify += observer.Update;
            }
        }

        public void Detach(IObserver observer)
        {
            if (null != observer)
            {
                lstObserver.Remove(observer);
                Notify -= observer.Update;
            }
        }

        public event EventHandler<EventArgs> Notify;

        public void PublishSomething()
        {
            if (null != Notify)
            {
                Notify(this, new SubjectEventArgs(topicName));
            }
        }

        public override string ToString()
        {
            return topicName;
        }
    }

    public class SubjectEventArgs : EventArgs
    {
        readonly String currentValue;

        public SubjectEventArgs(String value)
        {
            currentValue = value;
        }

        public String Value
        {
            get { return currentValue; }
        }
    }
}
