using System;

namespace AlgorithmPractice
{
    public abstract class D
    {
        public abstract void G();
    }

    public class D1 : D
    {
        public virtual void G2()
        {
            Console.WriteLine("G2 in D1");
        }

        public override void G()
        {
            Console.WriteLine("G in D1");
        }
    }

    public class D2 : D1
    {
        public void G2()
        {
            Console.WriteLine("G2 in D2");
        }
        public override void G()
        {
            base.G();
            Console.WriteLine("G in D2");
        }
    }
}
