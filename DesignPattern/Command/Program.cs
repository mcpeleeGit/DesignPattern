using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            //객체를
            제품 명함 = new 명함();
            제품 스티커 = new 스티커();
            //구체적명령에 넣고
            후가공 박가공 = new 박가공(명함);
            후가공 형압가공 = new 형압가공(스티커);
            //처리자를 통해 실행하되 구체적 명령은 객체에게 처리를 요청한다.
            처리 처리 = new 처리();

            처리.Add명령(박가공);
            처리.Add명령(형압가공);
            처리.명령실행();
            Console.ReadLine();
        }
    }
    public abstract class 제품
    {
        public abstract void 후가공처리();
    }
    public class 명함 : 제품
    {
        public override void 후가공처리()
        {
            Console.Write("명함 후가공처리 : ");
        }
    }
    public class 스티커 : 제품
    {
        public override void 후가공처리()
        {
            Console.Write("스티커 후가공처리 : ");
        }
    }


    public abstract class 후가공
    {
        protected 제품 제품;
        public 후가공(제품 제품)
        {
            this.제품 = 제품;
        }
        public abstract void 처리();
    }

    public class 박가공 : 후가공
    {
        public 박가공(제품 제품) : base(제품) { }
        public override void 처리()
        {
            제품.후가공처리();
            Console.WriteLine("박가공 ");
        }
    }
    public class 형압가공 : 후가공
    {
        public 형압가공(제품 제품) : base(제품) { }
        public override void 처리()
        {
            제품.후가공처리();
            Console.WriteLine("형압가공 ");
        }
    }
    public class 처리
    {
        private List<후가공> 후가공s = null;
        public 처리()
        {
            후가공s = new List<후가공>();
        }
        public void Add명령(후가공 후가공)
        {
            this.후가공s.Add(후가공);
        }

        public void 명령실행()
        {
            foreach (var item in 후가공s)
            {
                item.처리();
            }
        }
    }
}
