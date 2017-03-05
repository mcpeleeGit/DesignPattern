using System;

namespace Singleton
{
    class Singleton
    {
        private static Singleton _SingletoneInstance;

        private Singleton() { }

        public static Singleton _GetInstance()
        {
            if (_SingletoneInstance == null) _SingletoneInstance = new Singleton();
            return _SingletoneInstance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Singleton _InstanceA = Singleton._GetInstance();
            Singleton _InstanceB = Singleton._GetInstance();
            if (_InstanceA == _InstanceB) Console.WriteLine("isEqual : " + _InstanceA + "==" + _InstanceB);


            Singleton _InstanceC = Singleton._GetInstance();
            if (_InstanceB == _InstanceC) Console.WriteLine("isEqual : " + _InstanceB + "==" + _InstanceC);

        }
    }
}