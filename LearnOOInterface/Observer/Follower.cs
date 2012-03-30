using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearnOOInterface.Observer.Base;

namespace LearnOOInterface.Observer
{
    public class Follower:IObserver
    {
        readonly String uniqueName;

        public Follower(String name)
        {
            uniqueName = name;
        }

        public void Update(object sender, EventArgs args)
        {
            Console.WriteLine(uniqueName + " got push value from " + (args as SubjectEventArgs).Value);
        }
    }
}
