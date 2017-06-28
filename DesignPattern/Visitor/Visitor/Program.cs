using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            고객s e = new 고객s();
            e.Attach(new 일반고객());
            e.Attach(new 우수고객());
            e.Attach(new VIP고객());

            e.Accept(new 구매할인10퍼센트Visitor());

            e.Accept(new 적립금Visitor());

            Console.ReadKey();
        }
    }
    interface IVisitor
    {
        void Visit(Element element);
    }
    class 구매할인10퍼센트Visitor : IVisitor
    {
        public void Visit(Element element)
        {
            고객 고객 = element as 고객;
            고객.구매금액 = 고객.구매금액 * 0.09;
            Console.WriteLine("{0} {1}'s 구매금액: {2:C}", 고객.GetType().Name, 고객.고객명, 고객.구매금액);
        }
    }
    class 적립금Visitor : IVisitor
    {
        public void Visit(Element element)
        {
            고객 고객 = element as 고객;
            double 적립금 = 고객.구매금액 * (double)고객.적립율 * 0.01;
            Console.WriteLine("{0} {1}'s 적립금: {2}", 고객.GetType().Name, 고객.고객명, 적립금);
        }
    }
    abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }
    class 고객 : Element
    {
        private string _고객명;
        private double _구매금액;
        private int _적립율;
        
        public 고객(string 고객명, double 구매금액,int 적립율)
        {
            this._고객명 = 고객명;
            this._구매금액 = 구매금액;
            this._적립율 = 적립율;
        }
        
        public string 고객명
        {
            get { return _고객명; }
            set { _고객명 = value; }
        }
        
        public double 구매금액
        {
            get { return _구매금액; }
            set { _구매금액 = value; }
        }
        
        public int 적립율
        {
            get { return _적립율; }
            set { _적립율 = value; }
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    
    class 고객s
    {
        private List<고객> _고객s = new List<고객>();

        public void Attach(고객 고객)
        {
            _고객s.Add(고객);
        }

        public void Detach(고객 고객)
        {
            _고객s.Remove(고객);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (고객 e in _고객s)
            {
                e.Accept(visitor);
            }
            Console.WriteLine();
        }
    }
    
    class 일반고객 : 고객{public 일반고객(): base("홍길동", 10000, 1){}}
    class 우수고객 : 고객{public 우수고객(): base("김사장", 10000, 2){}}
    class VIP고객 : 고객{public VIP고객(): base("박사장", 10000, 5){}}
}
