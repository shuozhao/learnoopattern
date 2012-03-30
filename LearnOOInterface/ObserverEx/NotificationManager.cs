using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearnOOInterface.Observer.Base;
using LearnOOInterface.Observer;

namespace LearnOOInterface.ObserverEx
{
    public class NotificationManager:INotifyManager
    {
        Dictionary<String, List<IObserver>> pushsubMapping;

        public NotificationManager()
        {
            pushsubMapping = new Dictionary<string, List<IObserver>>();
        }

        public void Subscribe(ISubject<IObserver> topic, IObserver follower)
        {
            if (pushsubMapping.ContainsKey(topic.ToString()))
            {
                pushsubMapping[topic.ToString()].Add(follower);
            }
            else
            {
                List<IObserver> newFollower = new List<IObserver>();
                newFollower.Add(follower);
                pushsubMapping.Add(topic.ToString(), newFollower);
            }
        }

        public void UnSubscribe(ISubject<IObserver> topic, IObserver follower)
        {
            if (pushsubMapping.ContainsKey(topic.ToString()))
            {
                pushsubMapping[topic.ToString()].Remove(follower);
            }
        }

        public void Dispatch(object topic, EventArgs args)
        {
            if (pushsubMapping.ContainsKey(topic.ToString()))
            {
                List<IObserver> followerList = pushsubMapping[topic.ToString()];

                foreach (IObserver currObserver in followerList)
                {
                    currObserver.Update(topic, new SubjectEventArgs("Dispatch by Notification Manager " + (args as SubjectEventArgs).Value));
                }
            }
        }
    }
}
