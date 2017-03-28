using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainofResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            int 체크데이터 = 90;

            var c1 = new 체커_0보다큰가();
            var c2 = new 체커_100보다작은가();
            var c3 = new 체커_짝수인가();
            var c4 = new 체커_홀수인가();

            c1.Set체커(c2);
            c2.Set체커(c3);
            c3.Set체커(c4);

            c1.체크요청(체크데이터);

            Console.ReadLine();
        }
    }

    public abstract class abstract체커
    {
        protected abstract체커 체커;
        public void Set체커(abstract체커 체커)
        {           
            this.체커 = 체커;
        }
        public abstract void 체크요청(int 체크데이터);
        public void 추가체크(int 체크데이터)
        {
            if (체커 != null) 체커.체크요청(체크데이터);
        }
    }

    public class 체커_0보다큰가 : abstract체커
    {
        public override void 체크요청(int 체크데이터)
        {
            if (체크데이터>0) Console.WriteLine("체커_0보다큰가 true");
            else Console.WriteLine("체커_0보다큰가 false");

            추가체크(체크데이터);
        }
    }
    public class 체커_100보다작은가 : abstract체커
    {
        public override void 체크요청(int 체크데이터)
        {
            if (체크데이터 < 100) Console.WriteLine("체커_100보다작은가 true");
            else Console.WriteLine("체커_100보다작은가 false");

            추가체크(체크데이터);
        }
    }
    public class 체커_짝수인가 : abstract체커
    {
        public override void 체크요청(int 체크데이터)
        {
            if ((체크데이터 % 2) == 0) Console.WriteLine("체커_짝수인가 true");
            else Console.WriteLine("체커_짝수인가 false");

            추가체크(체크데이터);
        }
    }
    public class 체커_홀수인가 : abstract체커
    {
        public override void 체크요청(int 체크데이터)
        {
            if ((체크데이터 % 2) != 0) Console.WriteLine("체커_홀수인가 true");
            else Console.WriteLine("체커_홀수인가 false");

            추가체크(체크데이터);
        }
    }
}

