using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            var 중재자 = new 중재자();

            var 기획 = new 기획("kim jr", 중재자);
            var 개발 = new 개발("lee dh", 중재자);
            var QATest = new QATest("park ge", 중재자);
            var UI = new UI("ryu ih", 중재자);

            중재자.구성(기획, 개발, QATest, UI, "고객 단체 메일 발송 기능");
            중재자.칸반이터레이션실행();
            Console.ReadKey();
        }
    }

    abstract class abstract중재자
    {
        public abstract void 칸반이터레이션실행();
    }

    class 중재자 : abstract중재자
    {
        private 기획 _기획 { get; set; }
        private 개발 _개발 { get; set; }
        private QATest _QATest { get; set; }
        private UI _UI { get; set; }
        private string _Title { get; set; }

        public void 구성(기획 기획, 개발 개발, QATest QATest, UI UI, string Title)
        {
            _기획 = 기획;
            _개발 = 개발;
            _QATest = QATest;
            _UI = UI;
            _Title = Title;
        }

        public override void 칸반이터레이션실행()
        {
            Console.WriteLine(_Title + "를(을) 제작합니다.");
            기획요청();
        }
        public void 퍼블리싱요청()
        {
            _UI.실행();
        }
        public void 기획요청()
        {
            _기획.실행();
        }
        public void 개발요청()
        {
            _개발.실행();
        }
        public void 테스트요청()
        {
            _QATest.실행();
        }
    }
    abstract class abstract업무
    {
        protected 중재자 _중재자;
        public abstract업무(중재자 중재자)
        {
            _중재자 = 중재자;
        }
    }
    class 기획 : abstract업무
    {

        private string _기획자 { get; set; } = "";
        public 기획(string 기획자, 중재자 중재자) : base(중재자)
        {
            _기획자 = 기획자;
        }
        public void 실행()
        {
            Console.WriteLine(_기획자 + "가 기획을 합니다.");
            _중재자.퍼블리싱요청();
        }
    }
    class 개발 : abstract업무
    {
        private string _개발자 { get; set; } = "";
        public 개발(string 개발자, 중재자 중재자) : base(중재자)
        {
            _개발자 = 개발자;
        }
        public void 실행()
        {
            Console.WriteLine(_개발자 + "가 개발을 합니다.");
            _중재자.테스트요청();
        }
    }
    class QATest : abstract업무
    {
        private string _테스터 { get; set; } = "";
        public QATest(string 테스터, 중재자 중재자) : base(중재자)
        {
            _테스터 = 테스터;
        }
        public void 실행()
        {
            Console.WriteLine(_테스터 + "가 테스트를 합니다.");
        }
    }
    class UI : abstract업무
    {
        private string _퍼블리셔 { get; set; } = "";
        public UI(string 퍼블리셔, 중재자 중재자) : base(중재자)
        {
            _퍼블리셔 = 퍼블리셔;
        }
        public void 실행()
        {
            Console.WriteLine(_퍼블리셔 + "가 퍼블리싱을 합니다.");
            _중재자.개발요청();
        }
    }
}
