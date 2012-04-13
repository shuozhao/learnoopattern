using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnOOInterface.Command
{
    public delegate bool InvokerBase<T1, T2>(T1 oprand1, T2 oprand2);
    public delegate bool InvokerBase<T1>(T1 oprand1);
    public delegate bool InvokerBase();

    //without using delegate to save the operation, each command have to define a class to track their receiver,and execute action
    //or we can use interface instead of delegate, but it can not be modified run-time
    public class DelegateCommand<T1, T2> : ICommand
    {
        private T1 _parameter1;
        private T2 _parameter2;
        private InvokerBase<T1, T2> _operationMethod;

        public DelegateCommand(InvokerBase<T1, T2> commandDelegate, T1 parameter1, T2 parameter2)
            : base()
        {
            _operationMethod = commandDelegate;
            _parameter1 = parameter1;
            _parameter2 = parameter2;
        }

        public bool Execute()
        {
            bool iRet = false;

            if (_operationMethod != null)
            {
                iRet = _operationMethod(_parameter1, _parameter2);
            }
            return iRet;
        }
    }

    public class DelegateCommand<T1> : ICommand
    {
        private T1 _parameter1;
        private InvokerBase<T1> _operationMethod;

        public DelegateCommand(InvokerBase<T1> commandDelegate, T1 parameter1)
            : base()
        {
            _operationMethod = commandDelegate;
            _parameter1 = parameter1;
        }

        public bool Execute()
        {
            bool iRet = false;

            if (_operationMethod != null)
            {
                iRet = _operationMethod(_parameter1);
            }
            return iRet;
        }
    }

    public class DelegateCommand : ICommand
    {
        private InvokerBase _operationMethod;

        public DelegateCommand(InvokerBase commandDelegate)
            : base()
        {
            _operationMethod = commandDelegate;
        }

        public bool Execute()
        {
            bool iRet = false;

            if (_operationMethod != null)
            {
                iRet = _operationMethod();
            }
            return iRet;
        }
    }
}
