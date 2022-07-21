using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmPractice
{
    public class Knowledge
    {
        public void TrySortInList()
        {
            Employee e1 = new Employee();
            e1.Age = 50;
            e1.Company = "io";
            e1.FirstName = "9";
            e1.LastName = "8";

            Employee e2 = new Employee();
            e2.Age = 52;
            e2.Company = "io";
            e2.FirstName = "92";
            e2.LastName = "82";

            Employee e3 = new Employee();
            e3.Age = 54;
            e3.Company = "io";
            e3.FirstName = "93";
            e3.LastName = "83";

            Employee e4 = new Employee();
            e4.Age = 54;
            e4.Company = "io1";
            e4.FirstName = "93";
            e4.LastName = "83";

            List<Employee> list = new List<Employee>();
            list.Add(e1);
            list.Add(e2);
            list.Add(e3);
            list.Add(e4);

            list.Sort(CompareEmployee);
        }

        public int CompareEmployee(Employee x, Employee y)
        {
            if (x.Age > y.Age)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    
        public void TryObjectContainInDictionary()
        {
            Dictionary<TreeNode, int> d = new Dictionary<TreeNode, int>();
            TreeNode s = new TreeNode();
            s.data = 8;
            d.Add(s, 5);

            TreeNode t = s;

            bool flag1 = d.ContainsKey(s);//true
            bool flag2 = d.ContainsKey(t);//true
            bool flag3 = d.ContainsKey(new TreeNode(8));// no

        }
    }
}
