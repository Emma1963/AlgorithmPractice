
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmPractice
{
   public class HashAlgorithm
    {
        //nearly similar rectangle
        public long InterchangeableRectangles(long[][] rectangles)
        {
            long result = 0;
            Dictionary<double, int> pairs = new Dictionary<double, int>();
            for (int i = 0; i < rectangles.Length; i++)
            {
                //long must use double, use float will make the result not right
                double number = (double)rectangles[i][0] / (double)rectangles[i][1];

                if (pairs.Keys.Contains(number))
                {
                    result += pairs[number]; //add the match pair count before the item
                    pairs[number] = pairs[number] + 1;
                }

                else
                {
                    pairs.Add(number, 1);
                }
            }

            return result;
        }
    }
}
