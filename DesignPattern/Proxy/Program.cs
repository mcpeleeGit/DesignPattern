using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            string 연설문 = Get연설문();
            I권한 권한 = new 대리인(연설문);
            권한.연설();
            Console.ReadLine();
        }

        private static string Get연설문()
        {
            return "잘살아봅시다.";
        }
    }

    public interface I권한
    {
        void 연설();
    }

    public class 대통령 : I권한
    {
        private string 연설문 = "";
        public 대통령(string 연설문)
        {
            this.연설문 = 연설문;
        }

        public void 연설()
        {
            Console.WriteLine("대통령 연설 : " + 연설문);
        }
    }

    public class 대리인 : I권한
    {
        private string 연설문 = "";
        public 대리인(string 연설문)
        {
            this.연설문 = "우주의 기운을 모아 " + 연설문;
        }

        public void 연설()
        {
            I권한 권한 = new 대통령(연설문);
            권한.연설();
        }
    }
}
