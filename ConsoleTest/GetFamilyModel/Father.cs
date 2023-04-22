using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest.GetFamilyModel
{
    public class Father
    {
        public int FatherId { get; set; }
        public string Appat { get; set; }
        public string Apmat { get; set; }
        public string Name { get; set; }
        public List<Child> Childrens { get; set; }

        public IEnumerable<dynamic> GetList()
        {
            Child child1 = new Child() { ChildId = 1, Appat = "AAA", Apmat = "AAA", Name = "AAA" };
            Child child2 = new Child() { ChildId = 2, Appat = "BBB", Apmat = "BBB", Name = "BBB" };
            Child child3 = new Child() { ChildId = 3, Appat = "CCC", Apmat = "CCC", Name = "CCC" };
            Child child4 = new Child() { ChildId = 4, Appat = "DDD", Apmat = "DDD", Name = "DDD" };

            Father father1 = new Father()
            {
                FatherId = 1,
                Appat = "MMM",
                Apmat = "MMM",
                Name = "MMM",
                Childrens = new List<Child>() { child1, child2, child3 }
            };

            Father father2 = new Father()
            {
                FatherId = 2,
                Appat = "PPP",
                Apmat = "PPP",
                Name = "PPP",
                Childrens = new List<Child>() { child4 }
            };

            Father father3 = new Father()
            {
                FatherId = 3,
                Appat = "QQQ",
                Apmat = "QQQ",
                Name = "QQQ",
                Childrens = new List<Child>()
            };

            List<Father> listOfFathers = new List<Father>() { father1, father2, father3 };

            dynamic res1 = listOfFathers
                .SelectMany(i => i.Childrens, (Top, Bottom) => (Top, Bottom));

            dynamic res2 = listOfFathers
                .SelectMany(i => i.Childrens, (Top, Bottom) => (Top, Bottom))
                .Where(i => i.Top.Childrens.Any());

            return res1;
        }
    }
}
