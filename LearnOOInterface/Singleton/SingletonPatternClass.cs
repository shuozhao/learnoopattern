using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnOOInterface.Singleton
{
    public class SingletonPatternClass
    {
        static readonly SingletonPatternClass staticInstance = new SingletonPatternClass();

        Int32 initialTimes = 0;

        public static SingletonPatternClass Instance
        {
            get
            {
                return staticInstance;
            }
        }

        public SingletonPatternClass()
        {
            initialTimes++;
        }

        public Int32 InstaceCount
        {
            get
            {
                return initialTimes;
            }
        }
    }
}
