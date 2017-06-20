using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractClass aA = new ClassA();
            aA.Method();

            AbstractClass aB = new ClassB();
            aB.Method();
            
            Console.ReadKey();
        }
        abstract class AbstractClass
        {
            public abstract void Operation1();
            public abstract void Operation2();
            
            public void Method()
            {
                Operation1();
                Operation2();
                Console.WriteLine("");
            }
        }
        class ClassA : AbstractClass
        {
            public override void Operation1()
            {
                Console.WriteLine("ClassA.Operation1()");
            }
            public override void Operation2()
            {
                Console.WriteLine("ClassA.Operation2()");
            }
        }
        class ClassB : AbstractClass
        {
            public override void Operation1()
            {
                Console.WriteLine("ClassB.Operation1()");
            }
            public override void Operation2()
            {
                Console.WriteLine("ClassB.Operation2()");
            }
        }
    }
}
