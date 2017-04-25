using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            데이터집합 데이터 = new 데이터집합();
            데이터[0] = "공룡";
            데이터[1] = "나무";
            데이터[2] = "원숭이";
            데이터[3] = "거미";
            I반복자 반복자 = 데이터.반복자생성();
            
            while(!반복자.IsDone())
            {
                반복자.한방();
            }


            Console.ReadKey();
        }
    }
    class 데이터집합 
    {
        private ArrayList _arr데이터 = new ArrayList();
        public I반복자 반복자생성()
        {
            return new 반복자(this);
        }
        public int Count{ get { return _arr데이터.Count; } }
        public object this[int index]{ get { return _arr데이터[index]; } set { _arr데이터.Insert(index, value); } }
    }
    interface I반복자
    {
        void 한방();
        void 식물();
        void 동물();
        bool IsDone();
        void Next();
        object CurrentItem();
    }
    class 반복자 : I반복자
    {
        private 데이터집합 _데이터집합;
        private int _current = 0;
        public 반복자(데이터집합 데이터집합)
        {
            this._데이터집합 = 데이터집합;
        }
        public void 한방()
        {
            Console.Write(CurrentItem() + " : ");
            식물();
            동물();
            Next();
            Console.WriteLine("");
        }
        public void 식물()
        {
            if("나무,풀,꽃".Contains(CurrentItem().ToString()))
            {
                Console.Write("식물");
            }
        }
        public void 동물()
        {
            if ("원숭이,거미,개".Contains(CurrentItem().ToString()))
            {
                Console.Write("동물");
            }
        }
        public void Next()
        {
            ++_current;
        }
        public object CurrentItem()
        {
            
            return _데이터집합[_current];
        }
        public bool IsDone()
        {
            return _current >= _데이터집합.Count;
        }
    }
}
