using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmPractice
{
    public class Team
    {
        public string teamName;
        public int noOfPlayers;


        public Team(string name, int player)
        {
            teamName = name;
            noOfPlayers = player;
        }

        public virtual void AddPlayer(int count)
        {
            this.noOfPlayers = this.noOfPlayers + count;
        }

        public bool RemovePlayer(int count)
        {
            this.noOfPlayers -= count;
            if (this.noOfPlayers < 0)
                return false;
            return true;
        }
    }

    public class Subteam : Team
    {


        public Subteam(string name, int player) : base(name, player)
        {

        }

        public void ChangeTeamName(string name)
        {
            base.teamName = name;
        }

    }

    public class LinqSolution
    {
        public  Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
        {
            var f = employees.GroupBy(item => item.Company);
            Dictionary<string, int> age = new Dictionary<string, int>();

            foreach (var item in f)
            {
                age.Add(item.Key, (int)item.Average(i => i.Age));
            }
            return age;
        }

        public  Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
        {
            var f = employees.GroupBy(item => item.Company).OrderBy(item => item.Key);
            Dictionary<string, int> count = new Dictionary<string, int>();

            foreach (var item in f)
            {
                count.Add(item.Key, (int)item.Sum(itemt => { return 1; }));
            }
            return count;
        }

        public  Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
        {
            var f = employees.GroupBy(item => item.Company).OrderBy(item => item.Key);
            Dictionary<string, Employee> oldage = new Dictionary<string, Employee>();

            foreach (var item in f)
            {
                int oldAge = (int)item.Max(itemt => itemt.Age);
                var oldEmployee = item.Where(i => i.Age == oldAge).SingleOrDefault();
                oldage.Add(item.Key, oldEmployee);
            }
            return oldage;
        }
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
    }
}
