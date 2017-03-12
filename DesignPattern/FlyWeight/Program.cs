using System;
using System.Collections.Generic;
using System.Linq;

namespace FlyWeight
{
    class Program
    {
        static void Main(string[] args)
        {
            식당주문Factory 주문 = new 식당주문Factory();
            테이블정보Factory 테이블 = new 테이블정보Factory();

            테이블.Add주문("1번테이블"  , new 주문종류_FlyWeight[] {
                                              주문.Get주문("깐풍기")
                                            , 주문.Get주문("팔보채")
                                            , 주문.Get주문("짜장면") });
            테이블.Add주문("2번테이블", new 주문종류_FlyWeight[] {
                                              주문.Get주문("짜장면")
                                            , 주문.Get주문("짜장면")
                                            , 주문.Get주문("짜장면")
                                            , 주문.Get주문("짜장면") });
            테이블.Add주문("3번테이블", new 주문종류_FlyWeight[] {
                                              주문.Get주문("꿔바로우") });
            테이블.Get서빙("1번테이블");
            테이블.Get서빙("2번테이블");
            테이블.Get서빙("3번테이블");
            Console.ReadLine();
        }


    }

    public class 식당주문Factory
    {
        Dictionary<string, 주문종류_FlyWeight> 주문s = new Dictionary<string, 주문종류_FlyWeight>();
        public 주문종류_FlyWeight Get주문(string 주문명)
        {
            주문종류_FlyWeight 주문 = 주문s.FirstOrDefault(x => x.Key.Equals(주문명)).Value;
            if (주문 == null) {
                주문 = new 주문종류_FlyWeight(주문명);
                주문s.Add(주문명, 주문);
            }
            return 주문;
        }
    }
    
    public class 테이블정보Factory
    {
        Dictionary<string, 주문종류_FlyWeight[]> 테이블정보s = new Dictionary<string, 주문종류_FlyWeight[]>();
        public void Add주문(string 테이블종류, 주문종류_FlyWeight[] 주문종류)
        {
            테이블정보s.Add(테이블종류, 주문종류);
        }
        public void Get서빙(string 테이블종류)
        {
            Console.WriteLine(테이블종류 + " 서빙");
            foreach (var item in 테이블정보s.FirstOrDefault(x => x.Key.Equals(테이블종류)).Value)
            {
                item.Get주문종류();
            }
        }
    }

    public class 주문종류_FlyWeight
    {
        string 주문명 = "";
        public 주문종류_FlyWeight(string 주문명){Console.WriteLine(주문명 +" 생성");this.주문명 = 주문명;}
        public string Get주문종류(){ Console.WriteLine(주문명); return 주문명;}
    }
}
