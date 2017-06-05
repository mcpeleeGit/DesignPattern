using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            var o = new Order(1000, "박카스");
            o.OrderState = new Normal();
            o.Name();
            o.Price();
            o.OrderState = new DiscountState10Percent();
            o.Name();
            o.Price();
            o.OrderState = new Free();
            o.Name();
            o.Price();
            Console.ReadKey();
        }
    }

    abstract class OrderState
    {
        public abstract float Price(float price);
        public abstract string Name(string name);
    }

    class Normal : OrderState
    {
        public override float Price(float price)
        {
            return price;
        }
        public override string Name(string name)
        {
            return name;
        }
    }

    class DiscountState10Percent : OrderState
    {
        public override float Price(float price)
        {
            return price * (float)0.9;
        }
        public override string Name(string name)
        {
            return "[10% 할인]" + name;
        }
    }

    class Free : OrderState
    {
        public override float Price(float price)
        {
            return 0;
        }
        public override string Name(string name)
        {
            return "[공짜]" + name;
        }
    }

    class Order
    {
        public OrderState OrderState { get; set; }
        public float _price;
        public string _name;
        public Order(float price, string name)
        {
            this._price = price;
            this._name = name;
        }
        public float Price()
        {
            Console.WriteLine("가격 : " + OrderState.Price(_price));
            return OrderState.Price(_price);
        }
        public string Name()
        {
            Console.WriteLine("상품 : " + OrderState.Name(_name));
            return OrderState.Name(_name);
        }
    }
}
