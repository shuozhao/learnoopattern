using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearnOOInterface.Observer;
using LearnOOInterface.Observer.Base;

namespace LearnOOInterface.ObserverEx
{
    public class PushsubWithDispatcher<T> where T: INotifyManager,new()
    {
        INotifyManager currentManagerProvider;

        public PushsubWithDispatcher()
        {
            currentManagerProvider = new T();
        }

        public void SimulateObserverRegisterSubject()
        {
            SubjectEx newTopic = new SubjectEx("housing Issue", currentManagerProvider);

            SubjectEx moneyTopic = new SubjectEx("Salary", currentManagerProvider);

            SimulateTenBuyerRegisterTheTopic(newTopic);

            SimulateTenEmployerRegisterTheTopic(moneyTopic);

            SimulateTopicPublish(newTopic);

            SimulateTopicPublish(moneyTopic);
        }

        private void SimulateTopicPublish(SubjectEx newTopic)
        {
            newTopic.PublishSomething();
            Console.ReadKey();
        }

        private void SimulateTenEmployerRegisterTheTopic(SubjectEx moneyTopic)
        {

            for (int i = 0; i < 10; i++)
            {
                Follower employer = new Follower("Employer" + i.ToString());
                moneyTopic.Attach(employer);
            }
        }

        private void SimulateTenBuyerRegisterTheTopic(SubjectEx newTopic)
        {
            for (int i = 0; i < 10; i++)
            {
                Follower buyer = new Follower("Buyer" + i.ToString());
                newTopic.Attach(buyer);
            }
        }
    }
}
