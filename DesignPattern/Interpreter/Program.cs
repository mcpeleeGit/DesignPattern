using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            //string 주문번호 = "170408-0000015-1";
            //string 주문번호 = "170408-0000015";
            string 주문번호 = "0000015";
            Context context = new Context(주문번호);
            ArrayList list = new ArrayList();
            
            list.Add(new 주문번호Expression());
            list.Add(new 날짜Expression());
            list.Add(new 일련번호Expression());

            // Interpret
            foreach (AbstractExpression exp in list)
            {
                exp.Interpret(context);
            }
            Console.WriteLine("{0} = {1}", 주문번호, context.Output);

            Console.ReadLine();
        }
    }
    class Context
    {
        private string _input;
        private string _output;
        public Context(string input)
        {
            this._input = input;
        }
        public string Input
        {
            get { return _input; }
            set { _input = value; }
        }
        public string Output
        {
            get { return _output; }
            set { _output = value; }
        }
    }
    abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }
    class 주문번호Expression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("주문번호Expression");
            string[] data = context.Input.Split('-');
            if (data.Count() == 3) context.Output += "주문번호 : " + data[1];
            if (data.Count() == 2) context.Output += "주문번호 : " + data[1];
            if (data.Count() == 1) context.Output += "주문번호 : " + context.Input;
        }
    }
    class 날짜Expression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("날짜Expression");
            string[] data = context.Input.Split('-');
            if (data.Count() == 3) context.Output += " 날짜 : " + data[0];
            if (data.Count() == 2) context.Output += " 날짜 : " + data[0];
            if (data.Count() == 1) context.Output += " 날짜 : 없음";
        }
    }
    class 일련번호Expression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("일련번호Expression");
            string[] data = context.Input.Split('-');
            if (data.Count() == 3) context.Output += " 일련번호 : " + data[2];
            if (data.Count() == 2) context.Output += " 일련번호 : 없음";
            if (data.Count() == 1) context.Output += " 일련번호 : 없음";
        }
    }
}
