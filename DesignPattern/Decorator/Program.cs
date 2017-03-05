using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {

        public static void Main(string[] args)
        {
            주문 주문 = new 대인();
            Console.WriteLine(주문.get결제방법() + "" + 주문.결제금액());

            주문 주문1 = new 제우스은행();
            Console.WriteLine(주문1.get결제방법() + "" + 주문1.결제금액());
            주문1 = new 쿠폰10퍼센트(주문1);
            Console.WriteLine(주문1.get결제방법() + "" + 주문1.결제금액());
            주문1 = new 쿠폰10퍼센트(주문1);
            Console.WriteLine(주문1.get결제방법() + "" + 주문1.결제금액());
            주문1 = new 감사할인10원(주문1);
            Console.WriteLine(주문1.get결제방법() + "" + 주문1.결제금액());

            Console.ReadLine();
        }

        public abstract class 주문
        {
            protected string 결제방법 = "결제";
            public virtual string get결제방법() { return 결제방법; }
            public abstract double 결제금액();
        }

        public abstract class 결제 : 주문
        {
            //new public abstract string get결제방법();
        }

        public class 제우스은행 : 주문
        {
            public 제우스은행() { 결제방법 = "제우스은행"; }

            public override double 결제금액() { return 100; }
        }

        public class 쿠폰10퍼센트 : 결제
        {
            주문 주문;
            public 쿠폰10퍼센트(주문 주문) { this.주문 = 주문; }
            public override string get결제방법() { return 주문.get결제방법() + "쿠폰10퍼센트"; }
            public override double 결제금액() { return 주문.결제금액() - get쿠폰10퍼센트(주문.결제금액()); }
            double get쿠폰10퍼센트(double 금액) { return 금액 * 0.1; }
        }
        public class 감사할인10원 : 결제
        {
            주문 주문;
            public 감사할인10원(주문 주문) { this.주문 = 주문; }
            public override string get결제방법() { return 주문.get결제방법() + "감사할인10원"; }
            public override double 결제금액() { return 주문.결제금액() - get감사할인10원(); }
            double get감사할인10원() { return 10; }
        }

        public class 대인 : 주문
        {
            public 대인() { 결제방법 = "대인"; }
            public override double 결제금액() { return 100 + get대인수수료(100); }

            double get대인수수료(double 금액)
            {
                if (금액 <= 10000) return 324;
                if (금액 <= 30000) return 432;
                if (금액 <= 100000) return 648;
                if (금액 <= 300000) return 1080;
                if (금액 <= 500000) return 2160;
                return 4320;
            }
        }
    }
}
