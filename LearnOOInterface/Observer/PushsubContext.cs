using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnOOInterface.Observer
{
    public class PushsubContext
    {
        public PushsubContext()
        {

        }

        public void SimulateObserverRegisterSubject()
        {
            Subject newTopic = new Subject("housing Issue");

            Subject moneyTopic = new Subject("Salary");

            SimulateTenBuyerRegisterTheTopic(newTopic);

            SimulateTenEmployerRegisterTheTopic(moneyTopic);

            SimulateTopicPublish(newTopic);

            SimulateTopicPublish(moneyTopic);
        }

        private void SimulateTopicPublish(Subject newTopic)
        {
            newTopic.PublishSomething();
            Console.ReadKey();
        }

        private void SimulateTenEmployerRegisterTheTopic(Subject moneyTopic)
        {

            for (int i = 0; i < 10; i++)
            {
                Follower employer = new Follower("Employer" + i.ToString());
                moneyTopic.Attach(employer);
            }
        }

        private void SimulateTenBuyerRegisterTheTopic(Subject newTopic)
        {
            for (int i = 0; i < 10; i++)
            {
                Follower buyer = new Follower("Buyer" + i.ToString());
                newTopic.Attach(buyer);
            }
        }
    }
}
