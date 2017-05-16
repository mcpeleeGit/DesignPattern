using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderInfo s = new OrderInfo(new OrderLog());
            s.Name = "명함";
            s.Price = 100;
            s.Discount = 0;
            s.Save();

            s.Name = "명함(세일)";
            s.Price = 90;
            s.Discount = 10;
            s.Save();

            s.UnDo();
            s.ReDo();
            
            Console.ReadKey();
        }
    }
    class OrderInfo 
    {
        public OrderLog OrderLog { get; set; }
        private int LogIdx { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public OrderInfo(OrderLog orderLog)
        {
            this.OrderLog = orderLog;
        }

        public void Save()
        {
            Console.WriteLine("Save = Name : " + Name + " / Price : " + Price + " / Discount : " + Discount);
            LogIdx = OrderLog.Add(this.MemberwiseClone());
        }
        
        public void UnDo()
        {
            int rtnIdx;
            Mapper(OrderLog.Undo(LogIdx, out rtnIdx));
            LogIdx = rtnIdx;
            Console.WriteLine("UnDo = Name : " + Name + " / Price : " + Price + " / Discount : " + Discount);
        }
        public void ReDo()
        {
            int rtnIdx;
            Mapper(OrderLog.Redo(LogIdx, out rtnIdx));
            LogIdx = rtnIdx;
            Console.WriteLine("ReDo = Name : " + Name + " / Price : " + Price + " / Discount : " + Discount);
        }

        private void Mapper(Object obj)
        {
            OrderInfo tmp = (OrderInfo)obj;
            this.Name = tmp.Name;
            this.Price = tmp.Price;
            this.Discount = tmp.Discount;
        }
    }
    
    class OrderLog 
    {
        private ArrayList _arr데이터 = new ArrayList();
        public int Add(object obj)
        {
            _arr데이터.Add(obj);
            return _arr데이터.Count - 1;
        }
        public object Undo(int idx, out int rtnIdx)
        {
            rtnIdx = idx - 1;
            if ((rtnIdx) < 0)
            {
                rtnIdx = idx;
                return _arr데이터[idx];
            }
            return _arr데이터[rtnIdx];
        }
        public object Redo(int idx, out int rtnIdx)
        {
            rtnIdx = idx + 1;
            if ((rtnIdx) > (_arr데이터.Count + 1))
            {
                rtnIdx = idx;
                return _arr데이터[idx];
            }
            
            return _arr데이터[rtnIdx];
        }
    }

}
