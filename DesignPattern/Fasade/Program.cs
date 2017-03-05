using System;

namespace Fasade
{
    class Program
    {
        static void Main(string[] args)
        {
            Fasade 회사원Fasade = new Fasade();
            회사원Fasade.출근();
            회사원Fasade.일하기();
            회사원Fasade.잠깨기();
            Console.ReadLine();
        }
    }
    public class Fasade
    {
        private 사람 사람;
        private 개인PC 개인PC;
        public Fasade()
        {
            사람 = new 사람();
            개인PC = new 개인PC();
        }

        public void 출근()
        {
            Console.WriteLine("=======출근==========");
            사람.세면();사람.옷입기();사람.짐싸기();사람.전철타기();사람.버스타기();개인PC.켜기();
        }

        public void 잠깨기()
        {
            Console.WriteLine("=======잠깨기==========");
            사람.세면();
        }

        public void 일하기()
        {
            Console.WriteLine("=======일하기==========");
            개인PC.켜기();사람.코딩();            
        }
    }

    public class 사람
    {
        public void 세면() { Console.WriteLine("짐싸기"); }
        public void 옷입기() { Console.WriteLine("짐싸기"); }
        public void 짐싸기(){ Console.WriteLine("짐싸기"); }
        public void 전철타기() { Console.WriteLine("전철타기"); }
        public void 버스타기() { Console.WriteLine("버스타기"); }
        public void 코딩() { Console.WriteLine("코딩"); }
    }

    public class 개인PC
    {
        public void 켜기() { Console.WriteLine("켜기"); }
        public void 끄기() { Console.WriteLine("끄기"); }
    }
}
